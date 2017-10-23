using IFinancas.DAO;
using IFinancas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFinancas.ViewModel
{
    public class PageContaViewModel
    {
        private bool _incluindo;

        public Conta Conta { get; set; }

        public string Descricao { get; set; }

        public int Tipo { get; set; }

        public List<string> TiposStr { get; set; }

        //public int TipoSelecionado { get; set; }

        private void PreparaTipoConta()
        {
            TiposStr = new List<string>()
            {
                "Conta Corrente", "Ações", "Fundo De Investimento", "Tesouro Direto"
            };
        }

        public PageContaViewModel(Conta conta)
        {
            PreparaTipoConta();

            Conta = conta;
            Descricao = conta.Descricao;
            Tipo = (int)conta.Tipo;
            _incluindo = false;

            
        }

        public PageContaViewModel()
        {
            PreparaTipoConta();

            Conta = new Conta();
            Tipo = (int)TipoConta.TesouroDireto;
            _incluindo = true;            
        }

        public void Salvar()
        {
            Conta.Descricao = Descricao;
            Conta.Tipo = (TipoConta)Tipo;

            var dao = new ContaDAO();
            if (_incluindo)
            {
                dao.Incluir(Conta);
            }
            else
            {
                dao.Salvar(Conta);
            }

        }
    }
}
