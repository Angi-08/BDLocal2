using BDLocal2.BD;
using BDLocal2.Dependecy;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDLocal2
{
    public partial class App : Application
    {

        private static PersonaDataBase baseDatos;

        public static PersonaDataBase BaseDatos
        {
            get
            {
                if (baseDatos == null)
                {
                    return baseDatos = new PersonaDataBase(DependencyService.Get<IRuta>().GetPathBb("PersonaDB.bd3"));
                }
                else
                {
                    return baseDatos;
                }
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
