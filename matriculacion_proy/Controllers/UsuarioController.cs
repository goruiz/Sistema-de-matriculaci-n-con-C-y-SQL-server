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
    public class UsuarioController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {


            List<UsuarioTableViewModel> lstUsuarioTableViewModel = null;
            using (var db = new db_matriculacion_proyEntities2())
            {
                lstUsuarioTableViewModel = (from u in db.tbl_usuario
                                            select new UsuarioTableViewModel
                                            {
                                                idUsuario = u.idUsuario,
                                                nombreUsuario = u.nombreUsuario,
                                                usuarioUsuario = u.usuarioUsuario,
                                                claveUsuario = u.claveUsuario,
                                                rolUsuario = u.rolUsuario,
                                                estatusUsuario = u.estatusUsuario,

                                            }).ToList();
            }

            return View(lstUsuarioTableViewModel);
        }
        [Autorizacion(rolUsuario = "Administrador")]
        public ActionResult Usuarios()
        {

            List<UsuarioTableViewModel> list = null;
            tbl_usuario usuario = (tbl_usuario)Session["Usuario"];
            using (var db = new db_matriculacion_proyEntities2())
            {
                list = (from d in db.tbl_usuario
                        select new UsuarioTableViewModel
                        {
                            idUsuario = d.idUsuario,
                            nombreUsuario = d.nombreUsuario,
                            usuarioUsuario = d.usuarioUsuario,
                            claveUsuario = d.claveUsuario,
                            rolUsuario = d.rolUsuario,
                            estatusUsuario = d.estatusUsuario,
                        }).ToList();
            }
            return View(list);

        }

        [HttpGet] //responde a solicitudes get

        public void CargarCboxVehiculos()
        {
            List<SelectListItem> list = null;
            using (var db = new db_matriculacion_proyEntities2())
            {
                list = (from m in db.tbl_vehiculo
                        select new SelectListItem
                        {
                            Value = m.idVehiculo.ToString(),
                            Text = m.placaVehiculo.ToString(),

                       }).ToList();
                ViewBag.vehiculos = list;
            }

        }



        
        public ActionResult Nuevo()
        {
            CargarCboxVehiculos();

            return View();
        }





        [HttpPost] //responde a solicitudes post
        public ActionResult Nuevo(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CargarCboxVehiculos();
                return View(model);

            }

            using (var db = new db_matriculacion_proyEntities2())
            {

                tbl_usuario oUsuario = new tbl_usuario();

                oUsuario.nombreUsuario = model.nombre;
                oUsuario.usuarioUsuario = model.usuario;
                oUsuario.claveUsuario = model.clave;
                oUsuario.rolUsuario = "usuario";
                oUsuario.estatusUsuario = 0;
                db.tbl_usuario.Add(oUsuario);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Usuario/"));
        }



        //VAMOS A HACER EL EDITAR
        public ActionResult Editar(int id)
        {
            EditarUsuarioViewModel model = new EditarUsuarioViewModel();

            using (var db = new db_matriculacion_proyEntities2())
            {
                var oUsuario = db.tbl_usuario.Find(id);
                model.id = oUsuario.idUsuario;
                model.nombre = oUsuario.nombreUsuario;
                model.usuario = oUsuario.usuarioUsuario;
                model.clave = oUsuario.claveUsuario;
                model.rol = oUsuario.rolUsuario;
                model.estatus = oUsuario.estatusUsuario;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditarUsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new db_matriculacion_proyEntities2())
            {
                var oUsuario = db.tbl_usuario.Find(model.id);
                oUsuario.nombreUsuario = model.nombre;
                oUsuario.usuarioUsuario = model.usuario;
                oUsuario.claveUsuario = model.clave;
                oUsuario.rolUsuario = model.rol;
                oUsuario.estatusUsuario = model.estatus;

                db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Usuario/Index/"));
        }



        //FINALIZA EL EDITAR
        public ActionResult Eliminar(int idUsuario)
        {

            using (var db = new db_matriculacion_proyEntities2())
            {
                var oUsaurio = db.tbl_usuario.Find(idUsuario);
                db.tbl_usuario.Remove(oUsaurio);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Usuario/"));



        }




    }
}