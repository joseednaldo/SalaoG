using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalaoG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDetail : ContentPage
    {
        public MenuDetail()
        {
            InitializeComponent();
        }

     

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new LoginView());
            //MainPage = new SalaoG.Views.LoginView();
            // DependencyService.Get<IMysql>().Abrircon();
            // new NavigationPage(new Comandas());
            //await Navigation.PopAsync();


            //await Navigation.PushModalAsync(new AtendimentoAvulso())
            await Navigation.PushAsync(new AtendimentoAvulso());

        }

        private async  void ListaComandas(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaDeAtendimentos());
        }
    }
}