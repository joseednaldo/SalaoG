using SalaoG.Models;
using SalaoG.ViewModels;
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
    public partial class ListaDeAtendimentos : ContentPage
    {
        public ListaAtendimentoViewModel ViewModel { get; set; }

        public ObservableCollection<ListaAtendimento> lstItens = new ObservableCollection<ListaAtendimento>();

        public ListaDeAtendimentos()
        {
            InitializeComponent();

            this.ViewModel = new ListaAtendimentoViewModel();
            this.BindingContext = this.ViewModel;
            this.listViewAtendimento.ItemsSource = lstItens;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var idFunc =  App.GlobaisUsuario.funcionario;
           var lstItens =  ViewModel.GetAtendimento(idFunc);
            this.listViewAtendimento.ItemsSource = lstItens;
        }

 
    }
}