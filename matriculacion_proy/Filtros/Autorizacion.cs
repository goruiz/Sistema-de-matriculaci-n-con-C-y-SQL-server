using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using matriculacion_proy.Models;
using matriculacion_proy.Models.ViewModels;
using matriculacion_proy.Models.TableViewModels;

namespace matriculacion_proy.Filtros
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class Autorizacion : AuthorizeAttribute
    {
        public tbl_usuario oUsuario;
        public db_matriculacion_proyEntities2 db = new db_matriculacion_proyEntities2();
        public string rolUsuario;
        public Autorizacion(string rolUsuario = "")
        {
            this.rolUsuario = rolUsuario;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                oUsuario = (tbl_usuario)HttpContext.Current.Session["Usuario"];
                if (oUsuario == null)
                {
                    filterContext.Result = new RedirectResult("/Error/Index");
                    return;
                }
                var lstOperaciones = from u in db.tbl_usuario
                                     where u.rolUsuario == oUsuario.rolUsuario
                                     select u;
                if (lstOperaciones.ToList().Count() < 1)
                {
                    filterContext.Result = new RedirectResult("/Error/");
                }
                if (!string.IsNullOrEmpty(rolUsuario))
                {
                    if (!lstOperaciones.Any(x => x.rolUsuario == rolUsuario))
                    {
                        filterContext.Result = new RedirectResult("/Error/");
                    }
                }
            }
            catch (Exception e)
            {
                //log error
                filterContext.Result = new RedirectResult("/Home/");
            }
        }
    }
}
