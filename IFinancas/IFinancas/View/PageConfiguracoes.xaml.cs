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
    public partial class PageConfiguracoes : ContentPage
    {
        private PageConfiguracoesViewModel _viewModel;

        public PageConfiguracoes()
        {
            InitializeComponent();

            _viewModel = new PageConfiguracoesViewModel();
            BindingContext = _viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _viewModel.Salvar();
            Navigation.PopAsync();
        }
    }
}