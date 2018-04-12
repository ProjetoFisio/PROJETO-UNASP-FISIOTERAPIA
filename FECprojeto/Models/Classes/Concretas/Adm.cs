using CamadaDeDados.Banco;
using CamadaDeDados.Banco.TabelasSQL;
using CamadaDeNegocios.Negocios;
using FECprojeto.Models.Classes.Abstrata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECprojeto.Models.Classes.Concretas
{
    public class Adm : Pessoa
    {
        /*Propriedades da classe*/

        private int idAdm { get; set; }
        /*-------------------------------------------------------------------------------------------------------------------------------*/
        /*Construtor da classe*/
        public Adm()
        {

        }
        public Adm(string nome, string telCelular, string telResidencial)
        {
            this.nome = nome;
            this.telCelular = telCelular;
        }
        /*-------------------------------------------------------------------------------------------------------------------------------*/
        /*Getters e Setters*/
        public int GetIdAdm
        {
            get
            {
                //Coletar valor na propriedade.
                return idAdm;
            }
        }
        public void SetIdAdm(int id)
        {
            //Mudando o valor da propriedade privada.
            this.idAdm = id;
        }
        /*-------------------------------------------------------------------------------------------------------------------------------*/
        /*Métodos da classe*/
        public void Cadastrar(Paciente p, Fisioterapeuta f)
        {
            if (p != null && f == null)
            {
                paciente bdp = new paciente
                {
                   nome_pac = p.nome,
                   img_pac = null,
                   email_pac = p.email,
                   senha_pac = p.senha_pac,
                   dados_pac = p.dados_pac,
                   tel_pac = p.tel_pac,
                   cel_pac = p.telCelular,
                   cpf_pac = p.cpf,
                   endereco_pac = p.endereco_pac,
                   rg_pac = p.rg,
                   nasc_pac = p.dataDeAniversario,
                   sexo_pac = p.sexo,
                   ativo_pac = true,
                   cep_pac = "0"

                };
                Paciente_Negocios bp = new Paciente_Negocios();
                bp.SalvarPaciente(bdp);

            }
            else if (f != null && p == null)
            {
                
                fisioterapeuta bdf = new fisioterapeuta
                {
                    id_fis = f.id_fis,
                    nome_fis = f.nome,
                     email_fis = f.email,
                     senha_fis = f.senha_fis,
                     dados_fis = f.dados_fis,
                    cel_fis = f.telCelular,
                    cpf_fis = f.cpf,
                    rg_fis = f.rg,
                    nasc_fis = f.dataDeAniversario,
                    adm_fis = f.adm_fis,
                    sexo_fis = f.sexo,
                    ativo_fis = true,  
                };
               
                Fisioterapeuta_Negocios bf = new Fisioterapeuta_Negocios();
                bf.SalvarFisioterapeuta(bdf);
            }
        }
        public void Desativar(Paciente p, Fisioterapeuta f)
        {

            if (p != null && f == null)
            {
                paciente bdp = new paciente
                {
                    id_pac = p.GetIdPac
                };
              Paciente_Negocios bp = new Paciente_Negocios();
                bp.Desativar(bdp);

            }
            else if (f != null && p == null)
            {
                fisioterapeuta bdf = new fisioterapeuta
                {
                    id_fis = f.id_fis,
                    nome_fis = f.nome,
                    cel_fis = f.telCelular,
                    cpf_fis = f.cpf,
                    rg_fis = f.rg,
                    email_fis = f.email,
                    nasc_fis = f.dataDeAniversario
                };
                Fisioterapeuta_Negocios bf = new Fisioterapeuta_Negocios();
                bf.Desativar(bdf);
            }
        }
    }
}