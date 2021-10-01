using BDLocal2.Model;
using BDLocal2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BDLocal2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ObtenerLista();


            Lista.RefreshCommand = new Command(() => {
                Lista.IsRefreshing = true;
                ObtenerLista();
            });
        }

        public async void ObtenerLista()
        {
            var listaPersonas = await App.BaseDatos.GetPersonas();
            Lista.ItemsSource = listaPersonas;
            Lista.IsRefreshing = false;
        }
        

        private async void IngresarPersona(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngresarPersonas(this));
        }


        private async void Ver(object sender, EventArgs e)
        {
            var pe = (persona)((Button)sender).BindingContext;
            await App.BaseDatos.GetPersonas();
            await Navigation.PushAsync(new DetallePersona(pe));

        }






        private async void Eliminar(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirmación", "¿Está seguro que desea eliminar este contacto?", "Si", "No");
            Debug.WriteLine("Answer: " + answer);
            var p = (persona)((ImageButton)sender).BindingContext;

            if (answer)
            {
                await App.BaseDatos.EliminarPersona(p);
                ObtenerLista();
            }


        }

        private async void Busqueda(object sender, TextChangedEventArgs e)
        {
            if (busqueda.Text.Equals("") == true)
            {
                ObtenerLista();
            }
            else
            {
                var resultado = await App.BaseDatos.GetPersonas();
                var buscar = resultado.Where(c => c.NombreCompleto.Contains(busqueda.Text));
                Lista.ItemsSource = buscar;
            }
        }
    }
}
