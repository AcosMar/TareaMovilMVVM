using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using TareaTercerParcial.DataBase;
using TareaTercerParcial.Modelos;

namespace TareaTercerParcial.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listaEmpleados : ContentPage
    {
        public listaEmpleados()
        {
            InitializeComponent();
            llenarLista();
        }

        public async void llenarLista()
        {
            var empleados = await BaseDatos.CurrentDB.ObtenerTodosEmpleados();
            if (empleados != null)
            {
                lisEmpleados.ItemsSource = empleados;
            }
            else
            {

            }
        }

        private async void lisEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            bool validacion = await DisplayAlert("Advertencia", "Modificara este registro?", "Si", "No");
            if (validacion == true)
            {
                Empleados item = (Empleados)e.Item;

                if (item != null)
                {
                    Empleados Ep = new Empleados
                    {
                        Id_Empleado = item.Id_Empleado,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Edad = item.Edad,
                        Direccion = item.Direccion,
                        Puesto = item.Puesto,
                    };
                    await Navigation.PushAsync(new modificarEmpleados(Ep));
                }
                //var mod = new modificarPagos();
                //mod.BindingContext = item;
                //await Navigation.PushAsync(mod);
            }
        }
    }
}