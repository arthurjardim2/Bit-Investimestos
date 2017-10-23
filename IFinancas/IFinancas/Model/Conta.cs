using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFinancas.Model
{
    public enum TipoConta
    {
        ContaCorrente,
        Acoes,
        FundoDeInvestimento,
        TesouroDireto
    }

    [Table("Clientes")]
    public class Conta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int IdCliente { get; set; }
        
        public TipoConta Tipo { get; set; }        

    }
}
