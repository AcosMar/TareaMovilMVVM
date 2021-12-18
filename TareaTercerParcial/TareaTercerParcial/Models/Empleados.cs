using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TareaTercerParcial.Modelos
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int Id_Empleado { get; set; }
        [MaxLength(40)]
        public string Nombre { get; set; }
        [MaxLength(60)]
        public string Apellido { get; set; }

        public string Edad { get; set; }
        [MaxLength(80)]
        public string Direccion { get; set; }
        public string Puesto { get; set; }
    }
}
