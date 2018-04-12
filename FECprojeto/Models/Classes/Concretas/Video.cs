using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECprojeto.Models.Classes.Concretas
{
    public class Videos
    {
        /*Propriedades da classe*/
        public int idVideo { get; set; }
        public string tituloVideo { get; set; }
        public byte midiaVideo { get; set; }
        public string descricaoVideo { get; set; }
        public DateTime dataVideo { get; set; }
    }
}