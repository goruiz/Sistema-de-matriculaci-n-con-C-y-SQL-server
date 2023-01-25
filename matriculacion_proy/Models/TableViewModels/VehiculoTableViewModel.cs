using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matriculacion_proy.Models.TableViewModels
{
    public class VehiculoTableViewModel
    {
        public int idVehiculo { get; set; }
        public string placaVehiculo { get; set; }
        public string motorVehiculo { get; set; }
        public string chasisVehiculo { get; set; }
        public string combustibleVehiculo { get; set; }
        public string anioVehiculo { get; set; }
        public decimal avaluoVehiculo { get; set; }
        public string fotoVehiculo { get; set; }
        public string marcaVehiculo { get; set; }
        public string colorVehiculo { get; set; }
        public string usuarioVehiculo { get; set; }
        public int idMarca { get; set; }
        public int idColor { get; set; }
        public int idUsuario { get; set; }
    }
}