using SalaoG.Models;
using SalaoG.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalaoG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        private ObservableCollection<ItensMenu> _menuLista;
        public Menu()
        {
            InitializeComponent();

            _menuLista = ItensMenuService.GetMenuItens();
            ListMenu.ItemsSource = _menuLista;

            //Detail = new NavigationPage(new MenuDetail());
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MenuDetail)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (ItensMenu)e.SelectedItem;
            //obtem o tipo de objeto
            Type pagina = item.TargetType;

            if (item.Title.ToUpper() == "Sair".ToUpper())
            {
                System.Environment.Exit(0);
            }
                
            /*
             Abre uma pagina correspondente ao um item selecionado no listView
             cria uma isntancia do tipo selecioando usando o construtor
             */

            Detail = new NavigationPage((Page)Activator.CreateInstance(pagina));
            IsPresented = false;
        }
    }
}