using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using matriculacion_proy.Filtros;
using matriculacion_proy.Models;
using matriculacion_proy.Models.TableViewModels;
using matriculacion_proy.Models.ViewModels;


namespace matriculacion_proy.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        [Autorizacion(rolUsuario = "Administrador")]
        public ActionResult Index()
        {
            List<ColorTableViewModel> list = null;
            using (db_matriculacion_proyEntities2 db = new db_matriculacion_proyEntities2())
            {
                list = (from d in db.tbl_color
                        select new ColorTableViewModel
                        {
                            idColor = d.idColor,
                            descripcionColor = d.descripcionColor,
                           
                        }).ToList();
            }
            return View(list);
        }


        [HttpGet] //responde a solicitudes get
        public ActionResult Nuevo()
        {
            return View();
        }


        [HttpPost] //responde a solicitudes post
        public ActionResult Nuevo(ColorViewModel model)
        {

            using (db_matriculacion_proyEntities2 db = new db_matriculacion_proyEntities2())
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                tbl_color oColor = new tbl_color();
                oColor.descripcionColor = model.descripcionColor;
                db.tbl_color.Add(oColor);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Color/"));
        }


        public ActionResult Editar(int id)
        {
            EditarColorViewModel model = new EditarColorViewModel();
            using (var db = new db_matriculacion_proyEntities2())
            {
                var oColor = db.tbl_color.Find(id); //consulta la tabla marca y busca por el ID
                model.idColor = oColor.idColor;
                model.descripcionColor = oColor.descripcionColor;
               
            }
            return View(model);//retornamos el modelo
        }

        [HttpPost]
        public ActionResult Editar(EditarColorViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (db_matriculacion_proyEntities2 db = new db_matriculacion_proyEntities2())
            {

                var oColor = db.tbl_color.Find(model.idColor);
                oColor.descripcionColor = model.descripcionColor;
                
                db.Entry(oColor).State = System.Data.Entity.EntityState.Modified; //para guardar
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Color/"));



        }


        public ActionResult Eliminar(int id)
        {




            using (var db = new db_matriculacion_proyEntities2())
            {
                var oColor = db.tbl_color.Find(id);
                db.tbl_color.Remove(oColor);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Color/"));



        }

    }
}
