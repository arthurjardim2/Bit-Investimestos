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
    public class TransacaoDAO
    {
        private SQLiteConnection _database;

        public TransacaoDAO()
        {
            _database = DependencyService.Get<IDatabase>().GetConnection();

            _database.CreateTable<Transacao>();
        }

        public TableQuery<Transacao> GetAll()
        {
            return _database.Table<Transacao>();
        }

        public int Salvar(Transacao t)
        {
            return _database.InsertOrReplace(t);
        }

        public int Incluir(Transacao t)
        {
            return _database.Insert(t);
        }

        public int Excluir(Transacao t)
        {
            return _database.Delete(t);
        }
    }
}
