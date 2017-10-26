using IFinancas.DAO;
using IFinancas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFinancas.ViewModel
{
    public class PageTransacaoViewModel
    {
        public IList<string> OperacoesStr { get; set; }

        private bool _incluindo;

        public Conta Conta { get; set; }

        public Transacao Transacao { get; set; }

        private int _operacaoIndex;
        public int OperacaoIndex
        {
            get { return _operacaoIndex; }
            set
            {
                _operacaoIndex = value;
                Transacao.Operacao = (Operacao)_operacaoIndex;
            }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set
            {
                _data = value;
                Transacao.Data = _data;
            }
        }

        private double _valor;
        public double Valor
        {
            get { return _valor; }
            set
            {
                _valor = value;
                Transacao.Valor = _valor;
            }
        }

        public PageTransacaoViewModel(Conta c)
        {
            _incluindo = true;
            Conta = c;
            Transacao = new Transacao();
            Transacao.Data = DateTime.Now;
            Transacao.Operacao = Operacao.Deposito;
            Transacao.Valor = 0;
            Transacao.IdConta = c.Id;
            
            Preparar();
        }

        public PageTransacaoViewModel(Conta c, Transacao t)
        {
            _incluindo = false;
            Conta = c;
            Transacao = Transacao;
            Preparar();
        }

        private void Preparar()
        {
            OperacoesStr = new List<string>()
            {
                "Depósito", "Saque", "Saldo"
            };

            OperacaoIndex = (int)Transacao.Operacao;
            _data = Transacao.Data;
        }

        public void Salvar()
        {
            if (Transacao.Operacao == Operacao.Saque)
            {
                Transacao.Tipo = TipoTransacao.Debito;
            }
            else
            {
                Transacao.Tipo = TipoTransacao.Credito;
            }

            var dao = new TransacaoDAO();
            if (_incluindo)
            {                
                dao.Incluir(Transacao);
            }
            else
            {
                dao.Salvar(Transacao);
            }
        }
    }
}
