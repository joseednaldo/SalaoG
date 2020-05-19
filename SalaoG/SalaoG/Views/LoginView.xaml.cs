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
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin",
                async (exc) =>
                {
                    await DisplayAlert("Login", exc.Message, "Ok");
                    
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }

        private async  void RecuperaSenha(object sender, EventArgs e)
        {
           // MainPage = new SalaoG.Views.RecuperaSenha();
       
            await Navigation.PushModalAsync(new RecuperaSenha());

            //DisplayAlert("Login", "Senha enviada por e-mail", "Ok");
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{

        //    await Navigation.PushAsync(new Menu());
        //}

        //private async void Button_Clicked_1(object sender, EventArgs e)
        //{
        //   await Navigation.PopAsync(new RecuperaSenha(), true);
        //    //await Navigation.PushAsync(new Menu());
        //}
    }
}