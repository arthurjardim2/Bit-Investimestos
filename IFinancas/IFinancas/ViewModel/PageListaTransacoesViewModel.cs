using IFinancas.DAO;
using IFinancas.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFinancas.ViewModel
{
    public class PageListaTransacoesViewModel
    {
        public ObservableCollection<Transacao> Transacoes { get; set; }

        public IList<Conta> Contas { get; set; }

        public IList<string> ContasStr { get; set; }

        public Conta Conta { get; set; }        

        private int _contaIndex;
        public int ContaIndex
        {
            get { return _contaIndex; }
            set
            {
                _contaIndex = value;
                CarregarLista();
            }
        }

        public PageListaTransacoesViewModel()
        {
            Transacoes = new ObservableCollection<Transacao>();
            CarregarContas();            
        }

        private void CarregarContas()
        {
            var contaDAO = new ContaDAO();
            Contas = contaDAO.GetAll().ToList();
            ContasStr = new List<string>();

            foreach (var c in Contas)
            {
                ContasStr.Add($"{c.Id} - {c.Descricao}");
            }
        }

        public void CarregarLista()
        {
            if (ContaIndex >= 0)
            {
                var dao = new TransacaoDAO();
                Conta = Contas[ContaIndex];
                var lista = dao.GetAll().Where(t => t.IdConta == Conta.Id).ToList();
                Transacoes.Clear();
                foreach (var item in lista)
                {
                    Transacoes.Add(item);
                }
            }            
        }

        public void Excluir(Transacao t)
        {
            var dao = new TransacaoDAO();
            dao.Excluir(t);
            CarregarLista();
        }
    }
}
