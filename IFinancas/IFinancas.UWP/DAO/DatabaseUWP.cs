using IFinancas.DAO;
using IFinancas.UWP.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseUWP))]
namespace IFinancas.UWP.DAO
{
    public class DatabaseUWP : IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var nomeDb = "Dados.db3";
            var caminhoDb = ApplicationData.Current.LocalFolder.Path;
            var caminhoCompleto = Path.Combine(caminhoDb, nomeDb);

            return new SQLiteConnection(caminhoCompleto);
        }
    }
}
