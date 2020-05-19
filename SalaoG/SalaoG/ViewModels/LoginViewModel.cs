using SalaoG.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SalaoG.ViewModels
{
   public class LoginViewModel
    {
        public string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
    
        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
                EntrarCommand = new Command( () =>
                {
                    var loginService = new LoginService();
                    loginService.FazerLogin(new Login(usuario, senha));

                },()=>
                {
                    return !string.IsNullOrEmpty(usuario)
                            && !string.IsNullOrEmpty(senha);
                });
        }

    }
}
