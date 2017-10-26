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
    public partial class MasterDetailPage01 : MasterDetailPage
    {
        public MasterDetailPage01()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPage01MenuItem;
            if (item == null)
            {
                //var pageIni = (Page)new PageListaTransacoes();
                //pageIni.Title = "Transações";

                //Detail = new NavigationPage(pageIni);
                //IsPresented = false;

                //MasterPage.ListView.SelectedItem = null;
                return;
            }
                
            
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}