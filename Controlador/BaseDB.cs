using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1_4.Modelos;
using SQLite;

namespace Ejercicio1_4.Controlador
{
    public class BaseDB
    {
        readonly SQLiteAsyncConnection _connection;
        public BaseDB(String dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            /*Crear todos mis objetos de base de datos: tablas*/
            _connection.CreateTableAsync<Empleados>().Wait();
        }
        /*Crear el CRUD de BD*/
        //Create
        public Task<int> AddEmple(Empleados fotografias)
        {
            if (fotografias.Id == 0)
            {
                return _connection.InsertAsync(fotografias);
            }
            else
            {
                return _connection.UpdateAsync(fotografias);
            }
        }

        //Read
        public Task<List<Empleados>> GetAll()
        {
            return _connection.Table<Empleados>().ToListAsync();
        }

        public Task<Empleados> GetById(int id)
        {
            return _connection.Table<Empleados>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Delete
        public Task<int> DeleteEmple(Empleados fotografias)
        {
            return _connection.DeleteAsync(fotografias);
        }
    }
}