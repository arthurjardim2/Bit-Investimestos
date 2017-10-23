using IFinancas.Model;
using IFinancas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IFinancas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageTransacao : ContentPage
    {
        private Conta _conta;
        private PageListaTransacoes _pageLista;
        private PageTransacaoViewModel _viewModel;

        public PageTransacao(PageListaTransacoes pageListaTransacoes, Conta c)
        {
            InitializeComponent();

            _conta = c;
            _pageLista = pageListaTransacoes;
            _viewModel = new PageTransacaoViewModel(_conta);
            BindingContext = _viewModel;
        }
        
        private void BtnSalvar_Clicked(object sender, EventArgs e)
        {
            _viewModel.Salvar();
            Navigation.PopAsync();
            _pageLista.Atualizar();
        }
    }
}