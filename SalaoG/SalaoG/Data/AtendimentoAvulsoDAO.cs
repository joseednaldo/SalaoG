using SalaoG.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SalaoG.Data
{
    public class AtendimentoAvulsoDAO : IMysql, IDisposable
    {
        public void Abrircon()
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
           
        }

        public Atendimento FinalizarAtendimento(Atendimento atendimento)
        {

            return DependencyService.Get<IMysql>().FinalizarAtendimento(atendimento);
        }

        public List<ListaServico> ListaServico(string strSql)
        {
            throw new NotImplementedException();
        }

        public bool Logar(string strSql)
        {
            throw new NotImplementedException();
        }

        Login IMysql.Logar(string strSql)
        {
            throw new NotImplementedException();
        }

        public List<ListaAtendimento> ListaAtendimento(int IdFunc)
        {

            //ano + "/" + mes + "/" + dia + "'";
           // var mes = DateTime.Now.Month ;
              
            var data = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;


            var strSql = "SELECT faturamentoITEMFATURAMENTO as Numero_comanda,sum(tb_itens_faturamento.valorITEMFATURAMENTO)Total,movimentacaoFATURAMENTO";
            strSql = strSql + " FROM tb_faturamento";
            strSql = strSql + " inner join tb_itens_faturamento on tb_itens_faturamento.faturamentoITEMFATURAMENTO = tb_faturamento.codigoFATURAMENTO";
            strSql = strSql + " join tb_servico on tb_servico.codigoSERVICO = tb_itens_faturamento.servicoITEMFATURAMENTO";
            strSql = strSql + " where cast(movimentacaoFATURAMENTO as date) = '" + data + "'";
            strSql = strSql + " and tb_faturamento.funcionarioFATURAMENTO = " + IdFunc ;
            strSql = strSql + " GROUP BY faturamentoITEMFATURAMENTO,movimentacaoFATURAMENTO order by movimentacaoFATURAMENTO desc";

            return DependencyService.Get<IMysql>().ListaAtendimento(strSql);

            }


        public List<ListaAtendimento> ListaAtendimento(string strSql)
        {
            throw new NotImplementedException();
        }
    }
}
