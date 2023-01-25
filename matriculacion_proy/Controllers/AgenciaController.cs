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
    public class AgenciaController : Controller
    {
        // GET: Agencia
        [Autorizacion(rolUsuario = "Administrador")]
        public ActionResult Index()
        {
            List<AgenciaTableViewModel> list = null;
            using (var db = new db_matriculacion_proyEntities2())
            {
                list = (from d in db.tbl_agencia
                        select new AgenciaTableViewModel
                        {
                            idAgencia = d.idAgencia,
                            descripcionAgencia = d.descripcionAgencia,
                            direccionAgencia = d.direccionAgencia,
                            telefonoAgencia = d.telefonoAgencia

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
       
        public ActionResult Nuevo(AgenciaViewModel model)
        {

            using (var db = new db_matriculacion_proyEntities2())
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                tbl_agencia oAgencia = new tbl_agencia();
                oAgencia.descripcionAgencia = model.descripcionAgencia;
                oAgencia.direccionAgencia = model.direccionAgencia;
                oAgencia.telefonoAgencia = model.telefonoAgencia;
                db.tbl_agencia.Add(oAgencia);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Agencia/"));
        }
       
        public ActionResult Editar(int id)
        {
            EditarAgenciaViewModel model = new EditarAgenciaViewModel();
            using (var db = new db_matriculacion_proyEntities2())
            {
                var oAgencia = db.tbl_agencia.Find(id); //consulta la tabla marca y busca por el ID
                model.idAgencia = oAgencia.idAgencia;
                model.descripcionAgencia = oAgencia.descripcionAgencia;
                model.direccionAgencia = oAgencia.direccionAgencia;
                model.telefonoAgencia = oAgencia.telefonoAgencia;

            }
            return View(model);//retornamos el modelo
        }

        [HttpPost]
        
        public ActionResult Editar(EditarAgenciaViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new db_matriculacion_proyEntities2())
            {
                var oAgencia = db.tbl_agencia.Find(model.idAgencia);
                oAgencia.descripcionAgencia = model.descripcionAgencia;
                oAgencia.direccionAgencia = model.direccionAgencia;
                oAgencia.telefonoAgencia = model.telefonoAgencia;
                db.Entry(oAgencia).State = System.Data.Entity.EntityState.Modified; //para guardar
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Agencia/"));



        }

    
        public ActionResult Eliminar(int id)
        {




            using (var db = new db_matriculacion_proyEntities2())
            {
                var oAgencia = db.tbl_agencia.Find(id);
                db.tbl_agencia.Remove(oAgencia);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Agencia/"));



        }

    }
}