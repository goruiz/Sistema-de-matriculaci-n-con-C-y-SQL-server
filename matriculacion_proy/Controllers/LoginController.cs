using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using matriculacion_proy.Models.ViewModels;
using matriculacion_proy.Models;


namespace matriculacion_proy.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new db_matriculacion_proyEntities2())
            {
                var list = from u in db.tbl_usuario
                           where u.usuarioUsuario == model.usuario
                           && u.claveUsuario == model.clave
                           //&& u.estatusUsuario == 1
                           select u;
                if (list.Count() > 0)
                {
                    var usuario = list.First();
                    Session["Usuario"] = usuario;
                    if (usuario.rolUsuario == "Administrador")
                    {
                        Session["Administrador"] = true;
                    }
                    else
                    {
                        Session["Administrador"] = false;
                    }
                }
                

            }
            return Redirect(Url.Content("/Home/"));
        }
    }
}