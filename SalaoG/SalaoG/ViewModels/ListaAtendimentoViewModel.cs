using SalaoG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SalaoG.ViewModels
{
   public class ListaAtendimentoViewModel
    {
        public List<ListaAtendimento> ListaAtendimento { get; private set; }

        public ListaAtendimentoViewModel()
        {
            this.ListaAtendimento = new List<ListaAtendimento>();
            
            

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<ListaAtendimento> GetAtendimento(int Idfunc)
        {


           
                var listaAtendimento = new ListaDeAtendimentoService();

                var lista  = listaAtendimento.listaAtendimento(Idfunc);

                foreach (var item in lista)
                {
                this.ListaAtendimento.Add(
                new ListaAtendimento
                {
                    numeroCOMANDA = item.numeroCOMANDA,
                    Total = item.Total,
                    movimentacao = item.movimentacao.ToString()
                }) ;
                }

                return ListaAtendimento;

        }

    }
}
