using System;
using System.Collections.Generic;
using System.Text;

namespace SalaoG.Models
{
    public class Login
    {
        public string cpf { get; set; }
        public string senha { get; set; }
        public string loginUsario { get; set; }
        public int IdFuncionario { get; set; }
        public int IdEmpresa { get; set; }
        public Login(string cpf, string senha)
        {
            /*
            if (string.IsNullOrEmpty(cpf))
               // throw new ArgumentException(nameof(cpf));

            if (string.IsNullOrEmpty(senha))
             //u  throw new ArgumentException(nameof(senha));
             */

            this.cpf = cpf;
            this.senha = senha;
        }
    }
}