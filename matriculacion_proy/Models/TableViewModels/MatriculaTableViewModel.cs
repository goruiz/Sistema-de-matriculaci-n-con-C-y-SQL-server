using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace matriculacion_proy.Models.TableViewModels
{
    public class MatriculaTableViewModel
    {
        public int idMatricula { get; set; }
        public DateTime fechaMatricula { get; set; }
        public string anioMatricula { get; set; }
        public string telefonoMatricula { get; set; }
        public string estadoMatricula { get; set; }
        public string idVehiculo { get; set; }
        public string idAgencia { get; set; }


    }
}