using SalaoG.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaoG.Data
{
    public interface IMysql
    {
         void Abrircon();
        //bool Logar(string strSql);

        Login Logar(string strSql);

        List<ListaServico> ListaServico(string strSql);

        Atendimento FinalizarAtendimento(Atendimento listaAtendimento);

        List<ListaAtendimento> ListaAtendimento(string strSql);

    }


}
