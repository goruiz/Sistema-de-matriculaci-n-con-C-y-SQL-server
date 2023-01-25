using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace matriculacion_proy.Models.ViewModels
{
    public class MatriculaViewModel
    {
        public int idMatricula { get; set; }
        [Required]
        [Display(Name = "Ingrese la fecha")]
        public DateTime fechaMatricula { get; set; }

        [Required]
        [Display(Name = "Ingrese el anio")]
        [StringLength(30)]
        public string anioMatricula { get; set; }

        [Required]
        [Display(Name = "Ingrese eltelefono")]
        [StringLength(30)]
        public string telefonoMatricula { get; set; }

        [Required]
        [Display(Name = "Ingrese el estado")]
        [StringLength(30)]
        public string estadoMatricula { get; set; }

        [Required]
        //public int idVehiculo { get; set; }
        public Nullable<int> idVehiculo { get; set; }
        [Display(Name = "Ingrese el vehiculo")]
        public string Vehiculo { get; set; }

        public Nullable<int> idAgencia { get; set; }
        [Display(Name = "Ingrese la agencia")]
        public string Agencia { get; set; }
    }

    public class EditarMatriculaViewModel
    {
        [Required]
        public int idMatricula { get; set; }
        [Display(Name = "Ingrese la fecha")]
        public DateTime fechaMatricula { get; set; }

        [Required]
        [Display(Name = "Ingrese el anio")]
        [StringLength(30)]
        public string anioMatricula { get; set; }

        [Required]
        [Display(Name = "Ingrese eltelefono")]
        [StringLength(30)]
        public string telefonoMatricula { get; set; }

        [Required]
        [Display(Name = "Ingrese el estado")]
        [StringLength(30)]
        public string estadoMatricula { get; set; }

        [Required]
        public Nullable<int> idVehiculo { get; set; }
        [Display(Name = "Ingrese el vehiculo")]
        public string Vehiculo { get; set; }

        public Nullable<int> idAgencia { get; set; }
        [Display(Name = "Ingrese la agencia")]
        public string Agencia { get; set; }

    }

    public class EliminarMatriculaViewModel
    {
        public int idMatricula { get; set; }
    }
}