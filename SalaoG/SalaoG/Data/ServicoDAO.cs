using System;
using System.Collections.Generic;
using System.Text;
using SalaoG.Models;
using Xamarin.Forms;

namespace SalaoG.Data
{
    public class ServicoDAO : IMysql
    {

        public List<ListaServico> ListaServico()
        {
            var strSql = "SELECT  codigoSERVICO,descricaoSERVICO,precoSERVICO,servicoDESCONTINUADO FROM tb_servico ";
            strSql = strSql + " WHERE servicoDESCONTINUADO = 0 ";

            return DependencyService.Get<IMysql>().ListaServico(strSql);
        }

        public void Abrircon()
        {
            throw new NotImplementedException();
        }

        public bool Logar(string strSql)
        {
            throw new NotImplementedException();
        }

        public List<ListaServico> ListaServico(string strSql)
        {
            throw new NotImplementedException();
        }

        public bool FinalizarAtendimento(List<Atendimento> listaAtendimento)
        {
            throw new NotImplementedException();
        }

        public bool FinalizarAtendimento(Atendimento listaAtendimento)
        {
            throw new NotImplementedException();
        }

        Atendimento IMysql.FinalizarAtendimento(Atendimento listaAtendimento)
        {
            throw new NotImplementedException();
        }

        Login IMysql.Logar(string strSql)
        {
            throw new NotImplementedException();
        }

        public List<ListaServico> ListaAtendimento(string strSql)
        {
            throw new NotImplementedException();
        }

        List<ListaAtendimento> IMysql.ListaAtendimento(string strSql)
        {
            throw new NotImplementedException();
        }
    }
}
