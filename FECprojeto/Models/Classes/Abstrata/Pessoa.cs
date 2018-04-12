using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECprojeto.Models.Classes.Abstrata
{
    public abstract class Pessoa
    {
        public string nome { get; set; }
        public string telCelular { get; set; }
        public bool sexo { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string email { get; set; }
        public DateTime dataDeAniversario { get; set; }
    }
}