using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace matriculacion_proy.Models.TableViewModels
{
    public class MarcaTableViewModel
    {
        public int idMarca { get; set; }


        public string descripcionMarca { get; set; }
        
        public string paisMarca { get; set; }
    }
}