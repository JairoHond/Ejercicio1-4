using Plugin.Media;

namespace Ejercicio1_4.Views;

public partial class PageCrear : ContentPage
{

    Plugin.Media.Abstractions.MediaFile photo = null;
    public PageCrear()
    {
        InitializeComponent();
    }

    public String Getimage64()
    {
        if (photo != null)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Stream stream = photo.GetStream();
                stream.CopyTo(memory);
                byte[] fotobyte = memory.ToArray();

                String Base64 = Convert.ToBase64String(fotobyte);

                return Base64;
            }
        }

        return null;
    }

    public byte[] GetimageBytes()
    {
        if (photo != null)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Stream stream = photo.GetStream();
                stream.CopyTo(memory);
                byte[] fotobyte = memory.ToArray();

                return fotobyte;
            }

        }

        return null;
    }

    private async void btnfoto_Clicked(object sender, EventArgs e)
    {
        photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
        {
            Directory = "MYAPP",
            Name = "Foto.jpg",
            SaveToAlbum = true
        });

        if (photo != null)
        {
            Imagen.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

        }
    }

    private async void btnguardar_Clicked(object sender, EventArgs e)
    {
        var foto = new Modelos.Empleados
        {
            Descripcion = descripcion.Text,
            Imagen = GetimageBytes()
        };

        if (await App.BaseDatos.AddEmple(foto) > 0)
        {
            await DisplayAlert("Aviso", "Fotografia ingreso con exito", "OK");
        }
        else
            await DisplayAlert("Aviso", "A ocurrido un error", "OK");
    }

    private async void btnlista_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.ListEmp());
    }
}

