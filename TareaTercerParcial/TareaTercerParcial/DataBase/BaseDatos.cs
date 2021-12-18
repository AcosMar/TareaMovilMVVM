using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TareaTercerParcial.Modelos;

namespace TareaTercerParcial.DataBase
{
    public class BaseDatos
    {
        readonly SQLiteAsyncConnection dataBase;
        private static BaseDatos instance { get; set; }
        private BaseDatos(string _dbPath)
        {
            dataBase = new SQLiteAsyncConnection(_dbPath);
            dataBase.CreateTableAsync<Empleados>().Wait();
        }

        //Se crea un metodo para poder crear una sola instancia de la base de datos 
        public static BaseDatos CurrentDB
        {
            get
            {
                if (instance == null)
                {
                    instance = new BaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MVVM.db3"));
                }
                return instance;
            }
        }

        public Task<List<Empleados>> ObtenerTodosEmpleados()
        {
            return dataBase.Table<Empleados>().ToListAsync();
        }
        public Task<int> ObtenerTodosEmpleadosCount()
        {
            return dataBase.Table<Empleados>().CountAsync();
        }

        public Task<Empleados> ObtenerEmpleadoPorId(int id)
        {
            return dataBase.Table<Empleados>().Where(i => i.Id_Empleado == id).FirstOrDefaultAsync();
        }
        public Task<int> GuardarEmpleado(Empleados empleado)
        {
            if (empleado.Id_Empleado != 0)
            {
                return dataBase.UpdateAsync(empleado);
            }
            else
            {
                return dataBase.InsertAsync(empleado);
            }
        }

        public Task<int> EliminarEmpleado(Empleados empleado)
        {
            return dataBase.DeleteAsync(empleado);
        }
    }
}
