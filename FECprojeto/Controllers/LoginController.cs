using CamadaDeNegocios.Negocios;
using FECprojeto.Models.Classes.Concretas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FECprojeto.Controllers
{
    public class LoginController : Controller
    {

        Paciente_Negocios bp = new Paciente_Negocios();
        Fisioterapeuta_Negocios bf = new Fisioterapeuta_Negocios();

        // GET: Login
        public ActionResult Index()
        {
            if (Session["UsuarioFisio"] != null)
            {
                return RedirectToAction("IndexFisioterapeuta", "TelaInicial");
            }
            else if (Session["UsuarioPac"] != null)
            {
                return RedirectToAction("Index", "TelaInicial");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult logar(string email, string password)
        {
            if (bp.fazerLogin(email, password) || bf.fazerLogin(email, password))
            {
                //Caso sim, Abaixo será armazenado o Paciente ou o Fisioterapeuta caso seja encontrado, caso não, será null.
                var UserPac = bp.ObterPorLogin(email, password);
                var UserFisio = bf.ObterPorLogin(email, password);
                //Verificando se foi armazenado algo em 'UserPac e no UserFisio'.
                if (UserPac == null && UserFisio != null)
                {
                    //Verificando se a coluna 'cel_fis' está vazio.
                    if (UserFisio.cel_fis == null)
                    {
                        //Instanciando a classe Fisioterapeuta através do construtor apropriado pela a verificação.
                        Fisioterapeuta fis = new Fisioterapeuta(UserFisio.id_fis, UserFisio.img_fis, UserFisio.nome_fis, UserFisio.cpf_fis, UserFisio.rg_fis, UserFisio.senha_fis, UserFisio.email_fis, UserFisio.dados_fis, UserFisio.nasc_fis, UserFisio.adm_fis);
                        Session["UsuarioFisio"] = fis;
                        return RedirectToAction("IndexFisioterapeuta", "TelaInicial");

                    }
                    else
                    {
                        //Caso a coluna 'cel_fis' esteja com algum valor, irá ser instânciado a classe Fisioterapeuta através do construtor apropriado pela a verificação.
                        Fisioterapeuta fis = new Fisioterapeuta(UserFisio.id_fis, UserFisio.img_fis, UserFisio.nome_fis, UserFisio.cpf_fis, UserFisio.rg_fis, UserFisio.senha_fis, UserFisio.email_fis, UserFisio.dados_fis, UserFisio.nasc_fis, UserFisio.adm_fis);
                        Session["UsuarioFisio"] = fis;
                        return RedirectToAction("IndexFisioterapeuta", "TelaInicial");
                    }
                }
                //Caso o 'UserPac' esteja com algum valor e o 'UserFisio' não.
                else if (UserPac != null && UserFisio == null)
                {
                    //Verificando se a coluna 'cel_pac' esteja sem valor.
                    if (UserPac.cel_pac == null)
                    {
                        //Instanciando a classe Paciente através do construtor apropriado pela a verificação.
                        Paciente pac = new Paciente(UserPac.id_pac, UserFisio.img_fis, UserPac.nome_pac, UserPac.tel_pac, UserPac.cpf_pac, UserPac.rg_pac, UserPac.senha_pac, UserPac.email_pac, UserPac.dados_pac, UserPac.nasc_pac);
                        Session["UsuarioPac"] = pac;
                        return RedirectToAction("Index", "Inicio");
                    }
                    else
                    {
                        //Caso a coluna 'cel_pac' esteja com algum valor, irá ser instânciado a classe Paciente através do construtor apropriado pela a verificação.
                        Paciente pac = new Paciente(UserPac.id_pac, UserPac.img_pac, UserPac.nome_pac, UserPac.cel_pac, UserPac.tel_pac, UserPac.cpf_pac, UserPac.rg_pac, UserPac.senha_pac, UserPac.email_pac, UserPac.dados_pac, UserPac.nasc_pac);
                        Session["UsuarioPac"] = pac;
                        return RedirectToAction("Index", "Inicio");
                    }
                }
                //Redirecionando para a Action 'Index' do Controller 'TelaInicial'.

            }

            //Caso não seja encontrado o email e a senha passada.

            //Enviará para a View a mensagem abaixo.
            ViewBag.mensagem = "Usuário não cadastrado no sistema.";

            //Retornando a ActionResult 'Index'.
            return View("Index");
        }
    }
}
