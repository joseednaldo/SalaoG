using SalaoG.Models;
using SalaoG.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SalaoG.Services
{
    public class ItensMenuService
    {
        private static ObservableCollection<ItensMenu>mnuLista { get; set; }
        public static ObservableCollection<ItensMenu> GetMenuItens()
        {
            mnuLista = new ObservableCollection<ItensMenu>();
            /*
                 Criando paginas para navegação 
                 definimos po titulo para o item
                 o icone do lado esquerdo e a pagina que vamos abrir
             */
            var paginaHome = new ItensMenu
            {
                Title="Comandas",
                Icon= "comanda1.png",
                TargetType=typeof(MenuDetail)
            };
            var paginaSair = new ItensMenu
            {
                Title = "Sair",
                Icon = "saida_96.png",
                TargetType = null // typeof(RecuperaSenha)
            };

            mnuLista.Add(paginaHome);
            mnuLista.Add(paginaSair);
            return mnuLista;
        }


    }
}
