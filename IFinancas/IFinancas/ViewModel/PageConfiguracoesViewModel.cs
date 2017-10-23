using IFinancas.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFinancas.Model;

namespace IFinancas.ViewModel
{
    public class PageConfiguracoesViewModel
    {
        public Cliente Cliente { get; set; }
        public string Nome { get; set; }

        public PageConfiguracoesViewModel()
        {
            var dao = new ClienteDAO();
            Cliente = dao.Get();
            if (Cliente != null)
            {
                Nome = Cliente.Nome;
            }                           
        }

        public void Salvar()
        {
            if (Cliente == null)
            {
                Cliente = new Cliente();
            }
            var dao = new ClienteDAO();
            Cliente.Nome = Nome;
            dao.Salvar(Cliente);
        }
    }
}
