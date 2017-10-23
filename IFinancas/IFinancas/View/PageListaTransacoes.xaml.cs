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
    public partial class PageListaTransacoes : ContentPage
    {
        private PageListaTransacoesViewModel _viewModel;

        public PageListaTransacoes()
        {
            InitializeComponent();
            Atualizar();
        }

        public void Atualizar()
        {
            _viewModel = new PageListaTransacoesViewModel();
            BindingContext = _viewModel;
        }

        private void ActExcluir_Clicked(object sender, EventArgs e)
        {

        }

        private void ActEditar_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnNovo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageTransacao(this, _viewModel.Conta));
        }
    }
}