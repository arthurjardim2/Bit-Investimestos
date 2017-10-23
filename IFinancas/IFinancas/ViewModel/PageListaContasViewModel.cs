using IFinancas.DAO;
using IFinancas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFinancas.ViewModel
{
    public class PageListaContasViewModel
    {
        public IList<Conta> Contas { get; set; }
        public PageListaContasViewModel()
        {
            var dao = new ContaDAO();
            Contas = dao.GetAll().ToList();            
        }

        public void Excluir(Conta c)
        {
            var dao = new ContaDAO();
            dao.Excluir(c);
        }
    }
}
