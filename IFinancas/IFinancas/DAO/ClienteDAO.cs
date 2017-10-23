using IFinancas.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IFinancas.DAO
{
    public class ClienteDAO
    {
        private SQLiteConnection _database;

        public ClienteDAO()
        {
            _database = DependencyService.Get<IDatabase>().GetConnection();

            _database.CreateTable<Cliente>();
        }

        public Cliente Get()
        {
            return _database.Table<Cliente>().FirstOrDefault();
        }

        public int Salvar(Cliente cliente)
        {
            return _database.InsertOrReplace(cliente);
        }

        public int Excluir(Cliente cliente)
        {
            return _database.Delete(cliente);
        }
    }
}
