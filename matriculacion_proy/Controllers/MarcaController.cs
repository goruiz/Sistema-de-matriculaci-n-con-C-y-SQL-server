using matriculacion_proy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using matriculacion_proy.Models.TableViewModels;
using matriculacion_proy.Models.ViewModels;
using System.Text.RegularExpressions;
using matriculacion_proy.Filtros;

namespace matriculacion_proy.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Grupo
        [Autorizacion(rolUsuario = "Administrador")]
        public ActionResult Index()
        {
            List<MarcaTableViewModel> list = null;

            using (db_matriculacion_proyEntities2 db = new db_matriculacion_proyEntities2())
            {
                list = (from d in db.tbl_marca
                        select new MarcaTableViewModel
                        {
                            idMarca = d.idMarca,
                            descripcionMarca = d.descripcionMarca,
                            paisMarca = d.paisMarca
                        }).ToList();
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(MarcaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (db_matriculacion_proyEntities2 db = new db_matriculacion_proyEntities2())
            {
                tbl_marca oMarca = new tbl_marca();
                oMarca.descripcionMarca = model.descripcionMarca;
                oMarca.paisMarca = model.paisMarca;
                db.tbl_marca.Add(oMarca);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Marca/"));
        }

        public ActionResult Editar(int id)
        {
            EditarMarcaViewModel model = new EditarMarcaViewModel();

            using (var db = new db_matriculacion_proyEntities2())
            {
                var oMarca = db.tbl_marca.Find(id);
                model.idMarca = (int)oMarca.idMarca;
                model.descripcionMarca = oMarca.descripcionMarca;
                model.paisMarca = oMarca.paisMarca;
            }
            return View(model);
        }
        //
        [HttpPost]
        public ActionResult Editar(EditarMarcaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new db_matriculacion_proyEntities2())
            {
                var oMarca = db.tbl_marca.Find(model.idMarca);
                oMarca.idMarca = (int)model.idMarca;
                oMarca.paisMarca = model.paisMarca;
                oMarca.descripcionMarca = model.descripcionMarca;
                db.Entry(oMarca).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Marca/"));
        }
        //
        public ActionResult Eliminar(int id)
        {
            EliminarMarcaViewModel model = new EliminarMarcaViewModel();

            using (var db = new db_matriculacion_proyEntities2())
            {
                var oMarca = db.tbl_marca.Find(id);
                db.tbl_marca.Remove(oMarca);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Marca/"));
        }
    }
}