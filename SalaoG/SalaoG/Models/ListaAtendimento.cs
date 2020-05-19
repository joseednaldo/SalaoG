using System;
using System.Collections.Generic;
using System.Text;

namespace SalaoG.Models
{
  public  class ListaAtendimento
    {
        public int numeroCOMANDA { get; set; }
        public Decimal Total { get; set; }
        public string movimentacao { get; set; }

        public int IdFuncinario { get; set; }
    }
}
