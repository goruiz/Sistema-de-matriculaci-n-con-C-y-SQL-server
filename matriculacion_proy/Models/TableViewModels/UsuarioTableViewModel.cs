using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matriculacion_proy.Models.TableViewModels
{
    public class UsuarioTableViewModel
    {
        public Nullable<int> idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string usuarioUsuario { get; set; }
        public string claveUsuario { get; set; }
        public string rolUsuario { get; set; }
        public int estatusUsuario { get; set; }
        //public Nullable<int> idVehiculo { get; set; }
    }
}