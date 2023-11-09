using Ejercicio1_4.Controlador;
namespace Ejercicio1_4
{
    public partial class App : Application
    {
        static BaseDB basedatos;

        public static BaseDB BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    String dbname = "baseFoto";
                    String dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    String dbfulp = Path.Combine(dbpath, dbname);
                    basedatos = new BaseDB(dbfulp);
                }

                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PageCrear());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}