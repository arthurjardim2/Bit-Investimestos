using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IFinancas.DAO;
using SQLite;
using IFinancas.Droid.DAO;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseAndroid))]
namespace IFinancas.Droid.DAO
{
    public class DatabaseAndroid : IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var nomeDb = "Dados.db3";
            var caminhoDb = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var caminhoCompleto = Path.Combine(caminhoDb, nomeDb);

            return new SQLiteConnection(caminhoCompleto);
        }
    }
}