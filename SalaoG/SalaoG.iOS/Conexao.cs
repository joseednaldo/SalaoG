using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using SalaoG.Data;
using SalaoG.Models;
using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using SalaoG.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(Conexao))]
namespace SalaoG.iOS
{
    public class Conexao : IMysql
    {
        /// <summary>
        /// Base de homologação
        /// </summary>
        public string conec = "Database=hom_sergio;Data Source=hom_sergio.mysql.dbaas.com.br; User Id=hom_sergio; Password=hom01102011;pooling=FALSE";

        /// <summary>
        /// Base de produção
        /// </summary>
        //public string conec = "Database=salao_sergio;Data Source=salao_sergio.mysql.dbaas.com.br; User Id=salao_sergio; Password=m01102011;pooling=FALSE";
        public MySqlConnection con = null;

        public void FecharCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Close();
                //con.Dispose();
            }
            catch (System.Exception ex)
            {
               
                //    await DisplayAlert("Título", "Mensagem do alerta", "OK");
                ////ShowAlert (Application.Context, "Erro ao fechar com o banco" + ex, ToastLength.Long).Show();
            }
        }
        public void Abrircon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Open();
            }
            catch (System.Exception ex)
            {
            }
        }
        public Atendimento FinalizarAtendimento(Atendimento atendimento)
        {
            try
            {
                Abrircon();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tb_faturamento (funcionarioFATURAMENTO,clienteFATURAMENTO,movimentacaoFATURAMENTO,sistemaFATURAMENTO,tipopgtoFATURAMENTO,origemFATURAMENTO) VALUES  (@funcionarioFATURAMENTO,@clienteFATURAMENTO,@DtaMovimentacao,@sistemaFATURAMENTO,@tipopgtoFATURAMENTO,@origemFATURAMENTO)", con);
                cmd.Parameters.AddWithValue("@funcionarioFATURAMENTO", atendimento.id_funcionario);
                cmd.Parameters.AddWithValue("@clienteFATURAMENTO", 0);
                cmd.Parameters.AddWithValue("@DtaMovimentacao", atendimento.dataATENDIMENTO);
                cmd.Parameters.AddWithValue("@sistemaFATURAMENTO", atendimento.sistema);
                cmd.Parameters.AddWithValue("@tipopgtoFATURAMENTO", atendimento.tipoPAGAMENTO.tipoPAGAMENTO);
                cmd.Parameters.AddWithValue("@origemFATURAMENTO", 1);
                cmd.ExecuteNonQuery();
                long id_faturamentp = cmd.LastInsertedId;
                for (int i = 0; i < atendimento.listaServicoATENDIMENTO.Count; i++)
                {
                    MySqlCommand cmdItem = new MySqlCommand("INSERT INTO tb_itens_faturamento (faturamentoITEMFATURAMENTO,servicoITEMFATURAMENTO,valorITEMFATURAMENTO) VALUES  (@idFaturamento,@servicoITEMFATURAMENTO,@valorITEMFATURAMENTO)", con);
                    cmdItem.Parameters.AddWithValue("@idFaturamento", id_faturamentp);
                    cmdItem.Parameters.AddWithValue("@servicoITEMFATURAMENTO", atendimento.listaServicoATENDIMENTO[i].codigoSERVICO);
                    cmdItem.Parameters.AddWithValue("@valorITEMFATURAMENTO", atendimento.listaServicoATENDIMENTO[i].precoSERVICO);
                    cmdItem.ExecuteNonQuery();
                    cmdItem = null;
                }

                FecharCon();
                atendimento.Numero_comanda = id_faturamentp;
                return atendimento;
            }
            catch (Exception ex)
            {
                throw;
            }

            finally
            {
                FecharCon();
            }
        }

        public List<ListaAtendimento> ListaAtendimento(string strSql)
        {
            List<ListaAtendimento> listaAtendimentos = new List<ListaAtendimento>();

            try
            {

                MySqlCommand cmd;
                Abrircon();
                cmd = new MySqlCommand(strSql, con);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaAtendimentos.Add
                        (new ListaAtendimento
                        {
                            numeroCOMANDA = Convert.ToInt32(reader[0]),
                            Total = Convert.ToDecimal(reader[1]),
                            movimentacao = reader[2].ToString()


                        }); ;
                };
                FecharCon();
            }
            catch (Exception ex)
            {
                FecharCon();
                throw;
            }

            FecharCon();
            return listaAtendimentos;
        }

        public List<ListaServico> ListaServico(string strSql)
        {

            List<ListaServico> Servicos = new List<ListaServico>();

            try
            {

                MySqlCommand cmd;
                Abrircon();
                cmd = new MySqlCommand(strSql, con);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Servicos.Add
                        (new ListaServico
                        {
                            codigoSERVICO = Convert.ToInt32(reader[0]),
                            descricaoSERVICO = reader[1].ToString(),
                            precoSERVICO = Convert.ToDecimal(reader[2]),
                            servicoDESCONTINUADO = Convert.ToInt32(reader[3])
                        });
                };
                FecharCon();
            }
            catch (Exception ex)
            {
                FecharCon();
                throw;
            }

            FecharCon();
            return Servicos;

        }

        public Login Logar(string strSql)
        {

            Login dadosLoin = new Login("", "");

            try
            {
                MySqlCommand cmd;
                Abrircon();
                cmd = new MySqlCommand(strSql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dadosLoin.loginUsario = reader[0].ToString();
                        dadosLoin.IdFuncionario = Convert.ToInt32(reader[1]);
                        dadosLoin.cpf = reader[2].ToString();
                        dadosLoin.IdEmpresa = Convert.ToInt32(reader[3]);
                    }
                }
                else
                {
                    return dadosLoin = null;
                }

                FecharCon();
                return dadosLoin;
            }
            catch (Exception ex)
            {
                FecharCon();
                return dadosLoin = null;
            }
        }
    }
}