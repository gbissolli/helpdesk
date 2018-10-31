using System;
using System.Web.Mvc;

namespace HelpDesk.Mvc.Controllers
{
    public class PessoasController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Models.Pessoas pessoa)
        {
            try
            {
                pessoa.Create();
                return Json("Cadastro efetuado!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

      
    }
}
