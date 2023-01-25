using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace matriculacion_proy.Models.ViewModels
{
   
        public class MarcaViewModel
        {
            public int idMarca { get; set; }
            [Required]
            [Display(Name = "Ingrese el nombre")]
            [StringLength(50)]

            public string descripcionMarca { get; set; }
            [Required]
            [Display(Name = "Ingrese el pais")]
            [StringLength(50)]

            public string paisMarca { get; set; }
        }

        public class EditarMarcaViewModel
        {
            public Nullable<int> idMarca { get; set; }
            [Required]
            [Display(Name = "Ingrese el nombre")]
            [StringLength(50)]
             public string descripcionMarca { get; set; }

            [Required]
            [Display(Name = "Ingrese el pais")]
            [StringLength(50)]
            public string paisMarca { get; set; }
        }

        public class EliminarMarcaViewModel
        {
            public int idMarca { get; set; }
        }
    
}