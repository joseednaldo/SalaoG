using SalaoG.Models;
using SalaoG.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SalaoG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtendimentoAvulso : ContentPage
    {
        public ListaServicoViewModel ViewModel { get; set; }
        public ObservableCollection<ListaServico> lstItens = new ObservableCollection<ListaServico>();
        private  bool AtendimentoOK  = false;

        public AtendimentoAvulso()
        {
          
            InitializeComponent();

            this.ViewModel = new ListaServicoViewModel();
            this.BindingContext = this.ViewModel;
            listViewVeiculos.ItemsSource = lstItens;
            AtendimentoOK = false;
            

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();

            await this.ViewModel.GetServicos();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<ListaServico>(this, "ServicoSelecionado",
                (ListaServico) =>
                {
                    lstItens.Add(new ListaServico
                    {
                        codigoSERVICO = ListaServico.codigoSERVICO,
                        descricaoSERVICO = ListaServico.descricaoSERVICO,
                        precoSERVICO = Math.Round(ListaServico.precoSERVICO, 2),
                        servicoDESCONTINUADO = ListaServico.servicoDESCONTINUADO
                    });
                });

              MessagingCenter.Subscribe<Exception>(this, "FalhaListagemServico",
                (msg) =>
                {
                    DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de servicos. Por favor tente novamente mais tarde.", "Ok");
                });

             //Assinado atendimento
             MessagingCenter.Subscribe<Atendimento>(this, "SucessoAtendimento",
              (atendimento) =>
              {
                  AtendimentoOK = true;
                  DisplayAlert("Sucesso", "Atendimento realizado com sucesso!! Comanda nº " + atendimento.Numero_comanda, "Ok");
              });


            //Assinado atendimento
            MessagingCenter.Subscribe<AtendimentoAvulsoException>(this, "FalhaAtendimento",
             (msg) =>
             {
                 DisplayAlert("Erro", "Ocorreu um erro no atendimento. Por favor tente novamente mais tarde.", "Ok");
             });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CancelarAssinatura();
        }

        private void CancelarAssinatura()
        {
            MessagingCenter.Unsubscribe<ListaServico>(this, "ServicoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagemServico");
            MessagingCenter.Unsubscribe<Atendimento>(this, "SucessoAtendimento");
            MessagingCenter.Unsubscribe<AtendimentoAvulsoException>(this, "FalhaAtendimento");

        }

        private void Button_Clicked(object sender, EventArgs e)
        {


            //lstItens.Add(new ListaServico
            //{
            //    codigoSERVICO = ListaServico.codigoSERVICO,
            //    descricaoSERVICO = ListaServico.descricaoSERVICO,
            //    precoSERVICO = ListaServico.precoSERVICO,
            //    servicoDESCONTINUADO = ListaServico.servicoDESCONTINUADO

            //}); 
        }

        private void listViewVeiculos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contato = e.SelectedItem ;
            DisplayAlert("Item Selecionado (SelectedItem) ", "", "Ok");
        }

        private void listViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Selecionado (SelectedItem) ", "", "Ok");
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var servico = button?.BindingContext as ListaServico;
            var vm = BindingContext as ListaServicoViewModel;
            lstItens.Remove(servico);
           //vm?.RemoveCommand.Execute(servico);
        }

        private async void Atendimento_Clicked(object sender, EventArgs e)
        {


            if (await validaCampos())
                return;

            var button = sender as Button;

            FormaPagamento pgto = new FormaPagamento();
            if (fpgto.SelectedItem.ToString().ToUpper().Contains("CRÉDITO"))
            {
                pgto.tipoPAGAMENTO = 2;
            }else if (fpgto.SelectedItem.ToString().ToUpper().Contains("DÉBITO")){
                pgto.tipoPAGAMENTO = 1;
            }
            else
            {
                pgto.tipoPAGAMENTO = 0;
            } 


            // Confirma o atendimento
            bool acao = await DisplayAlert("Atendimento", "Confirme o atendimento?", "Sim", "Não");
            if (acao)
            {
                

                Atendimento atendimento = new Atendimento
                {
                    dataATENDIMENTO = DateTime.Now,
                    sistema = 0,
                    listaServicoATENDIMENTO = lstItens.ToList(),
                    tipoPAGAMENTO = pgto,
                    id_funcionario = App.GlobaisUsuario.funcionario  != 0 ? App.GlobaisUsuario.funcionario :  37,  // ATENDENTE PADRAO
                    id_empresaAtendimento =App.GlobaisUsuario.funcionario != 0 ? App.GlobaisUsuario.IdEmpresa : 1 // empresa PADRAO
                };

                var vm = BindingContext as ListaServicoViewModel;
                vm.AtendimentoAvulso = atendimento;
                //vm.FinalizarAtendimento(atendimento); - chamar essa função direto funciona tambem...
                vm?.AtendimentoCommand.Execute(atendimento);

                if(AtendimentoOK)
                    limpaDados();
            }
            else
            {
                limpaDados();
            }
        }

        private void limpaDados()
        {
            lstItens.Clear();
            fpgto.SelectedIndex = -1;
            listaServico.SelectedIndex = -1;
          
        }
        private async Task<bool> validaCampos()
        {
            bool resultado = false;

            if(lstItens.Count == 0)
            {
                //resultado = true;
                await DisplayAlert("Atenção", "Selecione o serviço", "Cancelar");
                return true;
            

            }
            if (fpgto.SelectedIndex < 0)
            {
               // resultado = true;
                await DisplayAlert("Atenção", "Selecione uma forma de pagamento", "Ok");
                return true;
            }

            return resultado;

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
          // var teste= e.NewDate.ToString();
        }
    }
}