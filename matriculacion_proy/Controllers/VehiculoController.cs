using matriculacion_proy.Models;
using matriculacion_proy.Models.ViewModels;
using matriculacion_proy.Models.TableViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using matriculacion_proy.Filtros;

namespace matriculacion_proy.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        
        public ActionResult Index()
        {
         

            List<VehiculoTableViewModel> list = null;
            tbl_usuario usuario = (tbl_usuario)Session["Usuario"];
            using (var db = new db_matriculacion_proyEntities2())
            {
                list = (from d in db.tbl_vehiculo
                        join m in db.tbl_marca on
                        d.idMarca equals m.idMarca
                        join c in db.tbl_color on
                        d.idColor equals c.idColor
                        join u in db.tbl_usuario on
                        d.idUsuario equals u.idUsuario
                        where d.idUsuario == usuario.idUsuario
                        select new VehiculoTableViewModel
                        {
                            idVehiculo = d.idVehiculo,
                            placaVehiculo = d.placaVehiculo,
                            motorVehiculo = d.motorVehiculo,
                            chasisVehiculo = d.chasisVehiculo,
                            combustibleVehiculo = d.combustibleVehiculo,
                            anioVehiculo = d.anioVehiculo,
                            avaluoVehiculo = (decimal)d.avaluoVehiculo,
                            fotoVehiculo = d.fotoVehiculo,
                            marcaVehiculo = m.descripcionMarca,
                            colorVehiculo = c.descripcionColor,
                            usuarioVehiculo= u.nombreUsuario
                        }).ToList();
            }
            return View(list);
        }

        public void CargarCboxMarcas()
        {
            List<SelectListItem> list = null;
            using (var db = new db_matriculacion_proyEntities2())
            {
                list = (from m in db.tbl_marca
                        select new SelectListItem
                        {
                            Value = m.idMarca.ToString(),
                            Text = m.descripcionMarca.ToString()
                        }).ToList();
                ViewBag.Marca = list;
            }
        }

        public void CargarCboxColor()
        {
            List<SelectListItem> list = null;
            using (var db = new db_matriculacion_proyEntities2())
            {
                list = (from c in db.tbl_color
                        select new SelectListItem
                        {
                            Value = c.idColor.ToString(),
                            Text = c.descripcionColor.ToString()
                        }).ToList();
                ViewBag.Color = list;
            }
        }

     

        public ActionResult Nuevo()
        {
            CargarCboxMarcas();
            CargarCboxColor();
            return View();
        }


        [HttpPost]
        public ActionResult Nuevo(VehiculoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CargarCboxMarcas();
                CargarCboxColor();
                return View(model);
            }
            using (var db = new db_matriculacion_proyEntities2())
            {
                tbl_usuario usuario = (tbl_usuario)Session["Usuario"];
                tbl_vehiculo oVehiculo = new tbl_vehiculo();
                oVehiculo.placaVehiculo = model.placaVehiculo;
                oVehiculo.motorVehiculo = model.motorVehiculo;
                oVehiculo.chasisVehiculo = model.chasisVehiculo;
                oVehiculo.combustibleVehiculo = model.combustibleVehiculo;
                oVehiculo.anioVehiculo = model.anioVehiculo;
                oVehiculo.avaluoVehiculo = model.avaluoVehiculo;
                oVehiculo.fotoVehiculo = model.fotoVehiculo;
                oVehiculo.idMarca = (int)model.idMarca;
                oVehiculo.idColor = (int)model.idColor;
                oVehiculo.idUsuario = (int)usuario.idUsuario;
                db.tbl_vehiculo.Add(oVehiculo);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Vehiculo/"));
        }
        


        [HttpGet]
        public ActionResult Editar(int id)
        {
            CargarCboxMarcas();
            CargarCboxColor();
            EditarVehiculoViewModel model = new EditarVehiculoViewModel();
            using (var db = new db_matriculacion_proyEntities2())
            {
                var oVehiculo = db.tbl_vehiculo.Find(id);
                model.idVehiculo = oVehiculo.idVehiculo;
                model.placaVehiculo = oVehiculo.placaVehiculo;
                model.motorVehiculo = oVehiculo.motorVehiculo;
                model.chasisVehiculo = oVehiculo.chasisVehiculo;
                model.combustibleVehiculo = oVehiculo.combustibleVehiculo;
                model.anioVehiculo = oVehiculo.anioVehiculo;
                model.avaluoVehiculo = oVehiculo.avaluoVehiculo;
                model.fotoVehiculo = oVehiculo.fotoVehiculo;
                model.idMarca = oVehiculo.idMarca;
                model.idColor = oVehiculo.idColor;
                model.idUsuario = oVehiculo.idUsuario;
            }
            return View(model);

        }

        [HttpPost]
        public ActionResult Editar(EditarVehiculoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CargarCboxMarcas();
                CargarCboxColor();
                return View(model);
            }
            using (var db = new db_matriculacion_proyEntities2())
            {
                var oVehiculo = db.tbl_vehiculo.Find(model.idVehiculo);
                oVehiculo.placaVehiculo = model.placaVehiculo;
                oVehiculo.motorVehiculo = model.motorVehiculo;
                oVehiculo.chasisVehiculo = model.chasisVehiculo;
                oVehiculo.combustibleVehiculo = model.combustibleVehiculo;
                oVehiculo.anioVehiculo = model.anioVehiculo;
                oVehiculo.avaluoVehiculo = model.avaluoVehiculo;
                oVehiculo.fotoVehiculo = model.fotoVehiculo;
                oVehiculo.idMarca = (int)model.idMarca;
                oVehiculo.idColor = (int)model.idColor;
                oVehiculo.idUsuario = (int)model.idUsuario;
                db.Entry(oVehiculo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Vehiculo/"));
        }
        public ActionResult Eliminar(int id)
        {
            using (var db = new db_matriculacion_proyEntities2())
            {
                var oVehiculo = db.tbl_vehiculo.Find(id);
                db.tbl_vehiculo.Remove(oVehiculo);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Vehiculo/"));



        }

    }
}