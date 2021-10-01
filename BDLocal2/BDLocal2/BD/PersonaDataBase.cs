using BDLocal2.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BDLocal2.BD
{
    public class PersonaDataBase
    {
        private readonly SQLiteAsyncConnection database;
        public PersonaDataBase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<persona>().Wait();
        }

        public async Task<List<persona>> GetPersonas()
        {
            return await database.Table<persona>().ToListAsync();
        }


        public async Task<persona> BuscaPorID(int ID)
        {
            return await database.Table<persona>().Where(x => x.Identificacion == ID).FirstOrDefaultAsync();
        }

        public async Task<int> GuardarPersona(persona p)
        {
            // si la persona existe lo que hará es actualizar
            if (p.Identificacion != 0)
            {
                return await database.UpdateAsync(p);
            }

            // sino hará una insercion
            else
            {
                return await database.InsertAsync(p);
            }
        }

        public async Task<int> EliminarPersona(persona p)
        {
            return await database.DeleteAsync(p);
        }
    }
}

