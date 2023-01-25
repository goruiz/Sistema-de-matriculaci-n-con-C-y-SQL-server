using matriculacion_proy.Controllers;
using matriculacion_proy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace matriculacion_proy.Filtros
{
    public class Verificar : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var oUsuario = (tbl_usuario)HttpContext.Current.Session["Usuario"];


            if (oUsuario == null)
            {
                if (filterContext.Controller is LoginController == false)
                {

                    //filterContext.HttpContext.Response.Redirect("~/Login/");

                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}