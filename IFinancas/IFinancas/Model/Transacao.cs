using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFinancas.Model
{
    public enum TipoTransacao
    {
        Debito,
        Credito
    }

    public enum Operacao
    {
        Deposito,
        Saque,
        Saldo
    }

    [Table("Transacoes")]
    public class Transacao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public TipoTransacao Tipo { get; set; }

        public DateTime Data { get; set; }

        public double Valor { get; set; }

        public int IdConta { get; set; }

        public Conta Conta { get; set; }

        public Operacao Operacao { get; set; }

        public string Descricao { get; set; }
    }
}
