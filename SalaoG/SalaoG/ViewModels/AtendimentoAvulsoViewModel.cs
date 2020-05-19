using SalaoG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace SalaoG.ViewModels
{
    public class AtendimentoAvulsoViewModel
    {

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)FinalizarAtendimento).ChangeCanExecute();
            }
        }

        public ICommand FinalizarAtendimento { get; private set; }

        public AtendimentoAvulsoViewModel()
        {
            FinalizarAtendimento = new Command(() =>
            {
                var atendimentoService = new AtendimentoAvulsoService();
                atendimentoService.FinalizarAtendimento(new Atendimento());

            }, () =>
            {
                return !string.IsNullOrEmpty("")
                        && !string.IsNullOrEmpty("");
            });
        }


    }
}
