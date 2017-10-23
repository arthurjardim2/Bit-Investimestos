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
    public partial class PageListaContas : ContentPage
    {
        private PageListaContasViewModel _viewModel;

        public PageListaContas()
        {
            InitializeComponent();

            Atualizar();
        }

        private void BtnAddConta_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageConta(this));
        }

        public void Atualizar()
        {
            _viewModel = new PageListaContasViewModel();
            BindingContext = _viewModel;
        }

        private void ActExcluir_Clicked(object sender, EventArgs e)
        {
            var c = (((MenuItem)sender).CommandParameter) as Conta;
            _viewModel.Excluir(c);
            Atualizar();
        }

        private void ActEditar_Clicked(object sender, EventArgs e)
        {
            var c = (((MenuItem)sender).CommandParameter) as Conta;
            Navigation.PushAsync(new PageConta(this, c));
        }
    }
}