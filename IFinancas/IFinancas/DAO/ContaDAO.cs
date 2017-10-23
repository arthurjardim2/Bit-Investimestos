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
    public class ContaDAO
    {
        private SQLiteConnection _database;

        public ContaDAO()
        {
            _database = DependencyService.Get<IDatabase>().GetConnection();

            _database.CreateTable<Conta>();
        }

        public TableQuery<Conta> GetAll()
        {
            return _database.Table<Conta>();
        }

        public int Salvar(Conta conta)
        {
            return _database.InsertOrReplace(conta);
        }

        public int Incluir(Conta conta)
        {
            return _database.Insert(conta);
        }

        public int Excluir(Conta conta)
        {
            return _database.Delete(conta);
        }
    }
}
