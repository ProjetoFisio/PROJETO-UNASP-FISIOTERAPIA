using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECprojeto.Models.Classes.Concretas
{
    public class Mensagem
    {
        //Propriedades da classe
        private int idMensagem { get; set; }
        public string tituloMensagem { get; set; }
        public string corpoMensagem { get; set; }
        public DateTime dataMensagem { get; set; }
        //--------------------------------------------------------------------------------
        //Getters e Setters
        public int getIdMensagem
        {
            get
            {
                return idMensagem;
            }
        }
        public void SetIdMensagem(int id)
        {
            idMensagem = id;
        }
    }
}