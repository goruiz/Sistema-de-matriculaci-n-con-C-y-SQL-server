using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace matriculacion_proy.Controllers
{
    public class AccesController : Controller
    {
        // GET: Acces
      
        public ActionResult Logoff()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Usuario");
        }
    }
}