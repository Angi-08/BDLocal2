using BDLocal2.Model;
using Plugin.ValidationRules;
using Plugin.ValidationRules.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDLocal2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresarPersonas : ContentPage
    {
        MainPage d;
        
        public IngresarPersonas(MainPage detalle)
        {
            InitializeComponent();
            d = detalle;
        }


        private async void Guardar(object sender, EventArgs e)
        {
         
            var nombreP = nombres.Text;
            var apellidoP = apellidos.Text;

            var celularP = celular.Text;
            var direccionP = direccion.Text;
            var emailP = email.Text;

            persona person = new persona
            {
           
                Nombres = nombreP,
                Apellidos = apellidoP,
                Celular = celularP,
                Direccion = direccionP,
                Email = emailP
            };



            if (String.IsNullOrWhiteSpace(nombreP))
            {
                await DisplayAlert("Advertencia", "El campo del nombre es obligatorio.", "OK");
            }
            else if (String.IsNullOrWhiteSpace(apellidoP))
            {
                await DisplayAlert("Advertencia", "El campo del apellido es obligatorio.", "OK");
            }
            else if (String.IsNullOrWhiteSpace(celularP))
            {
                await DisplayAlert("Advertencia", "El campo del celular es obligatorio.", "OK");
            }
            else if (String.IsNullOrWhiteSpace(direccionP))
            {
                await DisplayAlert("Advertencia", "El campo de la direccion electronico es obligatorio.", "OK");
            }
            else if (String.IsNullOrWhiteSpace(emailP))
            {
                await this.DisplayAlert("Advertencia", "El campo del correo electronico es obligatorio.", "OK");
               
            }
            else
            {
                //Valida que el formato del correo sea valido
                bool isEmail = Regex.IsMatch(email.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    await this.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");

                }
                else
                {
                    var resultado = await App.BaseDatos.GuardarPersona(person);

                    if (resultado > 0)
                    {
                        await DisplayAlert("Mensaje", "Contacto agregado con exito", "Ok");
                        d.ObtenerLista();
                        limpiar();
                    }
                    else
                    {
                        await DisplayAlert("Mensaje", "Contacto no fue agregado con exito", "Ok");
                    }

                }

            }
          
        }

        private void limpiar()
        {
            nombres.Text = "";
            apellidos.Text = "";
            celular.Text = "";
            direccion.Text = "";
            email.Text = "";
        }


    }
}