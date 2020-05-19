using System;
using System.Collections.Generic;
using System.Text;

namespace SalaoG.Models
{
   public class Atendimento
    {
        public List<ListaServico> listaServicoATENDIMENTO { get; set; }
        public DateTime dataATENDIMENTO { get; set; }
        public FormaPagamento tipoPAGAMENTO { get; set; }
        public int sistema { get; set; }
        public int id_funcionario { get; set; }
        public int id_empresaAtendimento { get; set; }

        private long numero_comanda { get; set; }

        public long Numero_comanda
        {
            get { return numero_comanda; }
            set
            {
                numero_comanda = value;

            }
        }

        public Atendimento()
        {

        }
    }
}

