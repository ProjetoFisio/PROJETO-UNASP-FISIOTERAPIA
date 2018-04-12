using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECprojeto.Models.Classes.Concretas
{
    public class Clinica
    {
        public int id_cli { get; set; }
        public string nome_cli { get; set; }
        public string endereco_cli { get; set; }
        public string tel_cli { get; set; }
        public string cep_cli { get; set; }
        public string estado_cli { get; set; }
        public string pais_cli { get; set; }
        public string cnpj_cli { get; set; }
        public bool ativo_cli { get; set; }
    }
}