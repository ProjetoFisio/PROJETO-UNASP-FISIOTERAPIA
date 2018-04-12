using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FECprojeto.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            if (Session["UsuarioPac"] != null)
            {

                return View(Session["UsuarioPac"]);
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult IndexFisio()
        {
            if (Session["UsuarioFisio"] != null)
            {

                return View(Session["UsuarioFisio"]);
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Config()
        {
            return View();
        }
        public ActionResult sair()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Inicio");
        }


    }
}