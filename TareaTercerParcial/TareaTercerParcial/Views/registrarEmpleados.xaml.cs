using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using TareaTercerParcial.Modelos;
using TareaTercerParcial.DataBase;

namespace TareaTercerParcial.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registrarEmpleados : ContentPage
    {
        public registrarEmpleados()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                Empleados newEmple = new Empleados
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Edad = txtEdad.Text,
                    Direccion = txtDireccion.Text,
                    Puesto = txtPuestos.Text,
                };
                await BaseDatos.CurrentDB.GuardarEmpleado(newEmple);

                await DisplayAlert("Registro", "Se agrego con exito", "ok");
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";
                txtDireccion.Text = "";
                txtPuestos.Text = "";
            }
            else
            {
                await DisplayAlert("Error", "Campos Vacios", "ok");
            }
        }
        public bool CamposVacios()
        {
            bool data;

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                data = false;
            }

            else if (String.IsNullOrEmpty(txtApellido.Text))
            {
                data = false;
            }

            else if (String.IsNullOrEmpty(txtEdad.Text))
            {
                data = false;
            }

            else if (String.IsNullOrEmpty(txtDireccion.Text))
            {
                data = false;
            }

            else if (String.IsNullOrEmpty(txtPuestos.Text))
            {
                data = false;
            }

            else
            {
                data = true;
            }
            return data;

        }
        private async void btnListaEmpleados_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listaEmpleados());
        }
    }
}