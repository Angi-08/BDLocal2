using BDLocal2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDLocal2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalle : ContentPage
    {
       

        public Detalle()
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
        private void Lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var personas = (persona)e.SelectedItem;
            App.MasterD.Detail.Navigation.PushAsync(new DetallePersona(e.SelectedItem as persona));
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