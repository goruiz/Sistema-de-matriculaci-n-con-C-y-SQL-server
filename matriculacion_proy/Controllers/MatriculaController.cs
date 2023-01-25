using matriculacion_proy.Filtros;
using matriculacion_proy.Models;
using matriculacion_proy.Models.TableViewModels;
using matriculacion_proy.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace matriculacion_proy.Controllers
{
    public class MatriculaController : Controller
    {
        // GET: Estudiante
        [Autorizacion(rolUsuario = "Administrador")]
        public ActionResult Index()
        {

            List<MatriculaTableViewModel> list = null;
            using (var db = new db_matriculacion_proyEntities2())
            {
                list = (from v in db.tbl_matricula
                        join m in db.tbl_vehiculo on
                        v.idVehiculo equals m.idVehiculo
                        join n in db.tbl_agencia on
                        v.idAgencia equals n.idAgencia
                        select new MatriculaTableViewModel
                        {
                            idMatricula = (int)v.idMatricula,
                            fechaMatricula = v.fechaMatricula,
                            anioMatricula = v.anioMatricula,
                            telefonoMatricula = v.telefonoMatricula,
                            estadoMatricula = v.estadoMatricula,
                            idVehiculo = m.placaVehiculo,
                            idAgencia = n.descripcionAgencia

                        }).ToList();
            }
            return View(list);
        }

        public void cargarCboxAgencia()
        {
            List<SelectListItem> list = null;
            using (var db = new db_matriculacion_proyEntities2())
            {
                list = (from n in db.tbl_agencia
                        select new SelectListItem
                        {
                            Value = n.idAgencia.ToString(),
                            Text = n.descripcionAgencia.ToString()
                        }).ToList();
                ViewBag.agencia = list;
            }
        }
        public void cargarCboxVehiculo()
        {
            List<SelectListItem> list = null;
            using (var db = new db_matriculacion_proyEntities2())
            {
                list = (from m in db.tbl_vehiculo
                        select new SelectListItem
                        {
                            Value = m.idVehiculo.ToString(),
                            Text = m.placaVehiculo.ToString()
                        }).ToList();
                ViewBag.vehiculo = list;
            }
        }

        public ActionResult Nuevo()
        {
            cargarCboxAgencia();
            cargarCboxVehiculo();

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(MatriculaViewModel model)
        {
            if (!ModelState.IsValid)
            {

                cargarCboxAgencia();
                cargarCboxVehiculo();
                return View(model);
            }
            using (var db = new db_matriculacion_proyEntities2())
            {
                tbl_matricula oMatricula = new tbl_matricula();
                oMatricula.fechaMatricula = model.fechaMatricula;
                oMatricula.anioMatricula = model.anioMatricula;
                oMatricula.telefonoMatricula = model.telefonoMatricula;
                oMatricula.estadoMatricula = model.estadoMatricula;
                oMatricula.idVehiculo = model.idVehiculo;
                oMatricula.idAgencia = model.idAgencia;
                db.tbl_matricula.Add(oMatricula);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Matricula/"));
        }

        public ActionResult Editar(int id)
        {
            cargarCboxAgencia();
            cargarCboxVehiculo();

            EditarMatriculaViewModel model = new EditarMatriculaViewModel();

            using (var db = new db_matriculacion_proyEntities2())
            {
                var oMatricula = db.tbl_matricula.Find(id);
                model.idMatricula = oMatricula.idMatricula;
                model.fechaMatricula = oMatricula.fechaMatricula;
                model.anioMatricula = oMatricula.anioMatricula;
                model.telefonoMatricula = oMatricula.telefonoMatricula;
                model.estadoMatricula = oMatricula.estadoMatricula;
                model.idVehiculo = (int)oMatricula.idVehiculo;
                model.idAgencia = (int)oMatricula.idAgencia;

            }
            return View(model);
        }
        //
        [HttpPost]
        public ActionResult Editar(EditarMatriculaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                cargarCboxAgencia();
                cargarCboxVehiculo();

                return View(model);
            }

            using (var db = new db_matriculacion_proyEntities2())
            {
                var oMatricula = db.tbl_matricula.Find(model.idMatricula);
                oMatricula.fechaMatricula = model.fechaMatricula;
                oMatricula.anioMatricula = model.anioMatricula;
                oMatricula.telefonoMatricula = model.telefonoMatricula;
                oMatricula.estadoMatricula = model.estadoMatricula;
                oMatricula.idVehiculo = model.idVehiculo;
                oMatricula.idAgencia = model.idAgencia;
            

                db.Entry(oMatricula).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


            }
            return Redirect(Url.Content("~/Matricula/"));
        }
        public ActionResult Eliminar(int id)
        {
            EliminarMatriculaViewModel model = new EliminarMatriculaViewModel();

            using (var db = new db_matriculacion_proyEntities2())
            {
                var oMatricula = db.tbl_matricula.Find(id);
                db.tbl_matricula.Remove(oMatricula);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Matricula/"));
        }
    }
}