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
    public partial class RecuperaSenha : ContentPage
    {
        public RecuperaSenha()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            await DisplayAlert("Login", "Senha enviada por e-mail", "Ok");
            await Navigation.PushModalAsync(new LoginView());

        }
    }
}