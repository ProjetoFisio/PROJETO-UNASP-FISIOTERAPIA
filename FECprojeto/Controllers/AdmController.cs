using FECprojeto.Models.Classes.Concretas;
using System;
using System.Web.Mvc;
using CamadaDeDados.Banco.Sql;

namespace FECprojeto.Controllers
{
    public class AdmController : Controller
    {
        Adm a = new Adm();
        // GET: Adm
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SalvarFis(string name, string email, string senha1, string senha2, string dados, string telefone, string cpf, string rg, DateTime data, bool adm, bool sexo)
        {
            //Não está sendo invocado
            if (senha1 == senha2)
            {

                Fisioterapeuta f = new Fisioterapeuta
                {
                   
                    nome = name,
                    img_fis = null,
                    email = email,
                    senha_fis = senha1,
                    dados_fis = dados,
                    telCelular = telefone,
                    cpf = cpf,
                    rg = rg,
                    dataDeAniversario = data,
                    adm_fis = adm,
                    sexo = sexo
                };

                a.Cadastrar(null, f);
                ViewBag.mensagem = "Cadastrado com sucesso!";
            }
            else
            {
                ViewBag.mensagem = "Senhas diferentes.";
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult SalvarPac(string name,string email,string senha1,string senha2,string telefone,string celular,string cpf,string endereco,string cep,string rg,DateTime data,string dados,bool sexo)
        {
        if(senha1 == senha2)
            {
                Paciente p = new Paciente
                {
               
                    nome = name,
                    email = email,
                    senha_pac = senha1,
                    tel_pac = telefone,
                    telCelular = celular,
                    cpf = cpf,
                    endereco_pac = endereco,         
                    rg = rg,
                    dataDeAniversario = data,
                    dados_pac = dados,
                    sexo = sexo 
                };

                a.Cadastrar(p,null);
                ViewBag.mensagem = "Cadastrado com sucesso!";
            }
            else
            {
                ViewBag.mensagem = "Senhas diferentes.";
            }
            return View("Index");
        }
    }
}