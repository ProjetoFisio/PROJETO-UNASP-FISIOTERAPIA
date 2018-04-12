using CamadaDeNegocios.Negocios;
using FECprojeto.Models.Classes.Abstrata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECprojeto.Models.Classes.Concretas
{
    /*Classe filha : Classe Pai*/
    public class Paciente : Pessoa
    {

        /*Propriedades da classe*/

        private int id_pac { get; set; }
        public byte[] img_pac { get; set; }
        public string senha_pac { get; set; }
        public string dados_pac { get; set; }
        public string tel_pac { get; set; }
        public string endereco_pac { get; set; }
        public bool ativo_pac { get; set; }
        /*-------------------------------------------------------------------------------------------------------------------------------*/
        /*Construtores da classe*/
        public Paciente()
        {

        }
        public Paciente(int id, byte[] img_pac, string nome, string tel_pac, string telCelular, string cpf, string rg, string email, string senha, String dadosPac, DateTime dataDeAniversario)
        {
            id_pac = id;
            this.img_pac = img_pac;
            this.nome = nome;
            this.telCelular = telCelular;
            this.tel_pac = tel_pac;
            this.cpf = cpf;
            this.rg = rg;
            this.email = email;
            this.senha_pac = senha;
            this.dados_pac = dadosPac;
            this.dataDeAniversario = dataDeAniversario;
        }
        public Paciente(int id, byte[] img_pac, string nome, string telResidencial, string cpf, string rg, string senha, string email, String dadosPac, DateTime dataDeAniversario)
        {
            SetIdPac(id);
            this.img_pac = img_pac;
            this.nome = nome;
            telCelular = telCelular;
            this.cpf = cpf;
            this.rg = rg;
            this.senha_pac = senha;
            this.email = email;
            this.dados_pac = dadosPac;
            this.dataDeAniversario = dataDeAniversario;
        }
        /*-------------------------------------------------------------------------------------------------------------------------------*/
        /*Getters e Setters*/
        public int GetIdPac
        {
            //Coletar valor na propriedade.
            get
            {
                return id_pac;
            }
        }
        public void SetIdPac(int id)
        {
            //Mudando o valor da propriedade privada.
            this.id_pac = id;
        }
        public string GetSenha
        {
            get
            {
                //Coletar valor na propriedade.
                return senha_pac;
            }
        }
        public void SetSenha(string senha)
        {
            //Mudando o valor da propriedade privada.
            senha_pac = senha;
        }
        /*-------------------------------------------------------------------------------------------------------------------------------*/
        /*Métodos da classe*/
        public bool fazerLogin(string email, string senha)
        {
             Paciente_Negocios bp = new Paciente_Negocios();
            return bp.fazerLogin(email, senha);
        }
        public void receberMensagem()
        {

        }

    }
}