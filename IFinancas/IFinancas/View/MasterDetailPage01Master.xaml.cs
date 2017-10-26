using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IFinancas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage01Master : ContentPage
    {
        public ListView ListView;

        public MasterDetailPage01Master()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPage01MasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPage01MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPage01MenuItem> MenuItems { get; set; }
            
            public MasterDetailPage01MasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPage01MenuItem>(new[]
                {
                    new MasterDetailPage01MenuItem(typeof(PageListaContas)) { Id = 0, Title = "Cadastro de Contas" },
                    new MasterDetailPage01MenuItem(typeof(PageListaTransacoes)) { Id = 1, Title = "Lançamentos" },
                    new MasterDetailPage01MenuItem(typeof(PageConfiguracoes)) { Id = 2, Title = "Configurações" },
                    //new MasterDetailPage01MenuItem { Id = 3, Title = "Page 4" },
                    //new MasterDetailPage01MenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}