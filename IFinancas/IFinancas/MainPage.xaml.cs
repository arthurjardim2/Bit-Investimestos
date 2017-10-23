using IFinancas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IFinancas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnConfiguracoes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageConfiguracoes());
        }

        private void BtnContas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageListaContas());
        }
    }
}
