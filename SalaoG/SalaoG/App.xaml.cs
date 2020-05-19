using SalaoG.Data;
using SalaoG.Models;
using SalaoG.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalaoG
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

             MainPage = new SalaoG.Views.LoginView();
            // DependencyService.Get<IMysql>().Abrircon();
            // MainPage = new NavigationPage(new SalaoG.Views.MenuDetail()); 
        }

        protected override void OnStart()
        {


            MessagingCenter.Subscribe<Login>(this, "SucessoLogin",
                (usuario) =>
                {
                    GlobaisUsuario.cpf = usuario.cpf;
                    GlobaisUsuario.IdEmpresa = usuario.IdEmpresa;
                    GlobaisUsuario.funcionario= usuario.IdFuncionario;

                    // MainPage = new MenuDetail();
                    MainPage = new Views.Menu();
                });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static class GlobaisUsuario
        {
            public static int Id;
            public static int IdEmpresa;
            public static string cpf;
            public static string nome;
            public static int funcionario;

        }

    }
}
