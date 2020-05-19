using SalaoG.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SalaoG.Data
{
   public class LoginDAO:IMysql ,IDisposable
    {

        //public bool Logar(Login login)
        //{
        //   // return DependencyService.Get<IMysql>().Logar(login);

        //    return true;
        //}
        public void Dispose()
        {
           
        }

        public void Abrircon()
        {
            throw new NotImplementedException();
        }

        /*
        public bool Logar(Login login)
        {
            var strSql = "SELECT COUNT(*) FROM tb_usuarios ";
                        strSql = strSql + "INNER JOIN tb_funcionarios ON  codigoFUNCIONARIO = funcionarioUSUARIO";
                        strSql = strSql + " WHERE replace(replace(cpfFUNCIONARIO,'.',''),'-','')";
                        strSql = strSql +  " = '" + login.cpf.Replace(".","").Replace("-","") + "'";
                        strSql = strSql + " AND senhaUSUARIO = '" + login.senha + "'";

            return DependencyService.Get<IMysql>().Logar(strSql);
        }
        */

        /* funcional
        public Login Logar(Login login)
        {
            var strSql = "SELECT COUNT(*) FROM tb_usuarios ";
            strSql = strSql + "INNER JOIN tb_funcionarios ON  codigoFUNCIONARIO = funcionarioUSUARIO";
            strSql = strSql + " WHERE replace(replace(cpfFUNCIONARIO,'.',''),'-','')";
            strSql = strSql + " = '" + login.cpf.Replace(".", "").Replace("-", "") + "'";
            strSql = strSql + " AND senhaUSUARIO = '" + login.senha + "'";

            return DependencyService.Get<IMysql>().Logar(strSql);
        }
        */


        public Login Logar(Login login)
        {
            var strSql = "SELECT nomeFUNCIONARIO,funcionarioUSUARIO,cpfFUNCIONARIO,coalesce(IdEmpresa,0) FROM tb_usuarios ";
            strSql = strSql + "INNER JOIN tb_funcionarios ON  codigoFUNCIONARIO = funcionarioUSUARIO";
            strSql = strSql + " WHERE replace(replace(replace(cpfFUNCIONARIO,'.',''),'-',''),',','')";
            strSql = strSql + " = '" + login.cpf.Replace(".", "").Replace("-", "") + "'";
            strSql = strSql + " AND senhaUSUARIO = '" + login.senha + "'";


            return DependencyService.Get<IMysql>().Logar(strSql);
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

        public List<ListaAtendimento> ListaAtendimento(string strSql)
        {
            throw new NotImplementedException();
        }

        //public bool Logar(string strSql)
        //{
        //     var strSql = "SELECT COUNT(*) FROM tb_usuarios WHERE UPPER(loginUSUARIO) = '" + login.cpf + "'"
        //                + " AND senhaUSUARIO = '" + login.senha + "'";

        //    return DependencyService.Get<IMysql>().Logar(strSql);
        //}
    }
}
