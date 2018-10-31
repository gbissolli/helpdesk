using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["CodUsuarioLogado"] != null)
            {
                ViewBag.CodUsuarioLogado = Session["CodUsuarioLogado"];
                ViewBag.CodNivelPessoa = Session["CodNivelPessoa"];
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new Models.Pessoas());
        }
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(Models.Pessoas pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.EMAIL))
            {
                return Json("Preencha o e-mail", JsonRequestBehavior.AllowGet);
            }else if (string.IsNullOrEmpty(pessoa.SENHA))
            {
                return Json("Preencha a senha", JsonRequestBehavior.AllowGet);
            }

            var getLogin = new Models.Pessoas().Login(pessoa.EMAIL, pessoa.SENHA);

            if (getLogin)
            {
                var pessoaLogada = new Models.Pessoas().GetPessoa(pessoa);
                Session["CodUsuarioLogado"] = pessoaLogada.COD_PESSOA;
                Session["NomeUsuarioLogado"] = pessoaLogada.NOME;
                Session["CodNivelPessoa"] = pessoaLogada.COD_NIVEL;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}