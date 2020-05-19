using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalaoG.Data;
using SalaoG.Models;
using Xamarin.Forms;

namespace SalaoG
{
    public  class AtendimentoAvulsoService
    {
 
        public  void FinalizarAtendimento(Atendimento atendimento)
        {
            using (AtendimentoAvulsoDAO dao = new AtendimentoAvulsoDAO())
            {
                try
                {

                    var atendimentoFinalizado = dao.FinalizarAtendimento(atendimento);

                    if (atendimentoFinalizado.Numero_comanda > 0)
                    {
                        MessagingCenter.Send<Atendimento>(atendimento, "SucessoAtendimento");
                    }   
                    else
                    {
                        MessagingCenter.Send<AtendimentoAvulsoException>(new AtendimentoAvulsoException("Atendimento" + ""),
                           "FalhaAtendimento");
                    }
                }
                catch (Exception ex)
                {

                    MessagingCenter.Send<AtendimentoAvulsoException>(new AtendimentoAvulsoException(
                       @"Ocorreu um erro de comunicação com o servidor.
                            Por favor verifique a sua conexão e tente novamente mais tarde."),
                       "FalhaLogin");
                }

            }
        }
    }


    public class AtendimentoAvulsoException : Exception
    {
        public AtendimentoAvulsoException(string message) : base(message)
        {
        }
    }
}
