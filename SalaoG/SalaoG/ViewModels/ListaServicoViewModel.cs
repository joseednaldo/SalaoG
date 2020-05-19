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
    public class ListaServicoViewModel :INotifyPropertyChanged
    {
        public ObservableCollection<ListaServico> Servicos { get; private set; }
       // public ObservableCollection<ListaServico> listViewVeiculos { get; private set; }


        public ObservableCollection<ListaServico> _lstItens = new ObservableCollection<ListaServico>();

        public ObservableCollection<ListaServico> listViewVeiculos
        {

            get { return _lstItens; }

            set
            {
                _lstItens = value;
                OnPropertyChanged();
            }
        }


        ListaServico servicoSelecionado;
        public ListaServico ServicoSelecionado
        {
            get
            {
                return servicoSelecionado;
            }
            set
            {
                servicoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(servicoSelecionado, "ServicoSelecionado");
            }
        }

        private bool aguarde;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }



        private Atendimento atendimentoAvulso;
        public Atendimento AtendimentoAvulso
        {
            get { return atendimentoAvulso; }
            set
            {
                atendimentoAvulso = value;
               
            }
        }
        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public ListaServicoViewModel()
        {
            this.Servicos = new ObservableCollection<ListaServico>();
        

        }

        public  async Task GetServicos()
        {


            try
            {
                
                var servico = new ServicoService();
                var lista = servico.ListaServico();

                foreach (var item in lista)
                {
                    this.Servicos.Add(
                    new ListaServico
                    {
                        codigoSERVICO = item.codigoSERVICO,
                        descricaoSERVICO = item.descricaoSERVICO,
                        precoSERVICO = item.precoSERVICO,
                        servicoDESCONTINUADO = item.servicoDESCONTINUADO,
                    });
                }


            }

            catch (Exception ex)
            {

                MessagingCenter.Send<Exception>(ex, "FalhaListagemServico");
            }


        }

        public Command<ListaServico> RemoveCommand
        {
            get
            {
                return new Command<ListaServico>((servico) =>
                {
                    Servicos.Remove(servico);
                });
            }
        }




        public Command<Atendimento> AtendimentoCommand
        {
            get
            {
                return new Command<Atendimento>((atendimento) =>
                {
                    var atend = new AtendimentoAvulsoService();
                    atend.FinalizarAtendimento(atendimento);
                });
            }
        }

        public void FinalizarAtendimento(Atendimento atend)
        {
            // essa função tem funciona
        }


    }
}
