using System;
using System.Collections.Generic;
using System.Text;

namespace SalaoG.Models
{
    public class ListaServico
    {
        public int codigoSERVICO { get; set; }
        public string descricaoSERVICO { get; set; }
        public Decimal precoSERVICO { get; set; }
        public int servicoDESCONTINUADO { get; set; }
    }
}
