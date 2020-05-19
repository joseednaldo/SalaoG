using System;
using System.Threading.Tasks;
using SalaoG.Data;
using SalaoG.Models;
using Xamarin.Forms;

namespace SalaoG
{
    public class LoginService
    {
        public void FazerLogin(Login login)
        {
            using (LoginDAO dao = new LoginDAO())
            {
                try
                {
                   
                    var logado = dao.Logar(login);

                    if (logado!= null)
                    {

                        //MessagingCenter.Send<Usuario>(ResultadoLogin, "SucessoLogin");
                        MessagingCenter.Send<Login>(logado, "SucessoLogin");
                    }
                    else {
                        MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha incorretos"),
                           "FalhaLogin");
                    }
                }
                catch (Exception ex)
                {

                    MessagingCenter.Send<LoginException>(new LoginException(
                       @"Ocorreu um erro de comunicação com o servidor.
                            Por favor verifique a sua conexão e tente novamente mais tarde."),
                       "FalhaLogin");
                }
 
            }
        }
    }


    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
