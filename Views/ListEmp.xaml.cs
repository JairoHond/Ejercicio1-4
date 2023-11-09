
using Ejercicio1_4.Modelos;
namespace Ejercicio1_4.Views;

public partial class ListEmp : ContentPage
{
	public ListEmp()
	{
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        Listaemple.ItemsSource = await App.BaseDatos.GetAll();
    }
}

