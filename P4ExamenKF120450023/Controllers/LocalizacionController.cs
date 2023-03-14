using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using P4ExamenKF120450023.Models;
using SQLite;

namespace P4ExamenKF120450023.Controllers
{
    public  class LocalizacionController
    {

        readonly SQLiteAsyncConnection _connection;
        // Constructor de la clase

        public LocalizacionController(String DBPath)
        {
            _connection = new SQLiteAsyncConnection(DBPath);
            _connection.CreateTableAsync<Models.Localizacion>();
        }


        //CRUD - Create - Read - Update - Delete 
        //Create / update
        
        public Task<int> SaveGeo(Models.Localizacion localizacion)
        {

            if (localizacion.Id != 0)
                return _connection.UpdateAsync(localizacion);
            else
                return _connection.InsertAsync(localizacion);
        }

        // Read one una localizacion
        public Task<Models.Localizacion> GetLocalizaciones(int pid)
        {
            return _connection.Table<Models.Localizacion>()
                .Where(i => i.Id == pid)
                .FirstOrDefaultAsync();
        }

        // Read
        public Task<List<Models.Localizacion>> GetListlocalizaciones()
        {
            return _connection.Table<Models.Localizacion>().ToListAsync();
        }

        // Delete
        public Task<int> Deletelocalizacion(Models.Localizacion localizacion)
        {
            return _connection.DeleteAsync(localizacion);
        }
    }
}
