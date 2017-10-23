using IFinancas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFinancas.Negocio
{
    public class Bancario
    {
        private Conta _conta;
        private Transacao _saldoNoPeriodo;

        public double SaldoProvisorio { get; set; }

        public double Saldo { get; set; }

        public double Rendimentos { get; set; }

        public double PerRendimentos { get; set; }

        public double Depositos { get; set; }

        public double Saques { get; set; }

        public Bancario(Conta conta)
        {
            _conta = conta;

            _saldoNoPeriodo = null;

            Rendimentos = 0;
            PerRendimentos = 0;
            Depositos = 0;
            Saques = 0;
        }

        private bool IdentificaSaldo(Transacao transacao)
        {
            if (transacao.Operacao != Operacao.Saldo)
            {
                return false;
            }

            if (_saldoNoPeriodo == null)
            {
                _saldoNoPeriodo = transacao;
            }
            else if (DateTime.Compare(transacao.Data, _saldoNoPeriodo.Data) < 0)
            {
                _saldoNoPeriodo = transacao;
            }

            Saldo = _saldoNoPeriodo.Valor;
            return true;
        }

        private void CalculaRendimentos()
        {
            if (_saldoNoPeriodo == null)
            {
                Rendimentos = 0;
            }
            else
            {
                Rendimentos = _saldoNoPeriodo.Valor - SaldoProvisorio;
                PerRendimentos = (Rendimentos / Depositos) * 100;
            }
        }

        public double Executa(Transacao transacao)
        {

            if (IdentificaSaldo(transacao))
            {
                CalculaRendimentos();
                return SaldoProvisorio;
            }

            if (transacao.Tipo == TipoTransacao.Credito)
            {
                SaldoProvisorio += transacao.Valor;
            }
            else if (transacao.Tipo == TipoTransacao.Debito)
            {
                SaldoProvisorio -= transacao.Valor;
            }

            if (transacao.Operacao == Operacao.Deposito)
            {
                Depositos += transacao.Valor;
            }
            else if (transacao.Operacao == Operacao.Saque)
            {
                Saques += transacao.Valor;
            }

            CalculaRendimentos();

            return Saldo;
        }
    }

}
