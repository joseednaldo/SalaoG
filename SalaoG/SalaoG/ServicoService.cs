using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalaoG.Data;
using SalaoG.Models;
using Xamarin.Forms;

namespace SalaoG
{
    public class ServicoService
    {
        public List<ListaServico> ListaServico()
        {

            ServicoDAO dao = new ServicoDAO();
            try
                {
               
                  return dao.ListaServico();
                    
                }                
                catch (Exception ex)
                {

                    dao = null;
                    MessagingCenter.Send<ServicoException>(new ServicoException(
                    @"Ocorreu um erro de comunicação com o servidor.
                    Por favor verifique a sua conexão e tente novamente mais tarde."),
                    "FalhaListagemServico");

                }
            finally
            {
                dao = null;
            }

            return null ;
        }
    }


    public class ServicoException : Exception
    {
        public ServicoException(string message) : base(message)
        {
        }
    }
}
