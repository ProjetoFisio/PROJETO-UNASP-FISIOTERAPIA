using FECprojeto.Models.Classes.Concretas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECprojeto.Models.Classes.Auxiliares
{
    public class Fisioterapeuta_Paciente
    {
        public Fisioterapeuta fisio { get; set; }
        public Paciente pac { get; set; }
    }
}