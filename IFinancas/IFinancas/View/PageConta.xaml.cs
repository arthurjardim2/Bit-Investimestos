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
    public partial class PageConta : ContentPage
    {
        private PageContaViewModel _viewModel;
        private PageListaContas _PageLista;

        public PageConta(PageListaContas pageListaContas)
        {
            InitializeComponent();

            _viewModel = new PageContaViewModel();
            _PageLista = pageListaContas;

            BindingContext = _viewModel;
        }

        public PageConta(PageListaContas pageListaContas, Conta c)
        {
            InitializeComponent();

            _viewModel = new PageContaViewModel(c);
            _PageLista = pageListaContas;

            BindingContext = _viewModel;
        }

        private void BtnSalvar_Clicked(object sender, EventArgs e)
        {
            _viewModel.Salvar();
            Navigation.PopAsync();
            _PageLista.Atualizar();
        }

        private async void ActExcluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Atenção", "Confirma Exclusão", "Sim", "Não");            
            if (resp)
            {
                _viewModel.Excluir();
                await Navigation.PopAsync();
                _PageLista.Atualizar();
            }            
        }
    }
}