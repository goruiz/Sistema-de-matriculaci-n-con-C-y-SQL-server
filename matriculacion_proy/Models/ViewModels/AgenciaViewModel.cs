using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace matriculacion_proy.Models.ViewModels
{
    public class AgenciaViewModel
    {
        public int idAgencia { get; set; }
        [Required]
        [Display(Name = "Ingrese la agencia: ")]
        [StringLength(30)]
        public string descripcionAgencia { get; set; }
        [Required]
        [Display(Name = "Ingrese la direccion de la agencia: ")]
        [StringLength(30)]
        public string direccionAgencia { get; set; }
        [Required]
        [Display(Name = "Ingrese el telefono de la agencia: ")]
        [StringLength(30)]
        public string telefonoAgencia { get; set; }
    }
    public class EditarAgenciaViewModel
    {
        [Required]
        public int idAgencia { get; set; }
        [Required]
        [Display(Name = "Ingrese la agencia: ")]
        [StringLength(30)]
        public string descripcionAgencia { get; set; }
        [Required]
        [Display(Name = "Ingrese la direccion de la agencia: ")]
        [StringLength(30)]
        public string direccionAgencia { get; set; }
        [Required]
        [Display(Name = "Ingrese el telefono de la agencia: ")]
        [StringLength(30)]
        public string telefonoAgencia { get; set; }
    }
    public class EliminarAgenciaViewModel
    {
        [Required]
        public int idAgencia { get; set; }
        [Required]
        [Display(Name = "Ingrese la marca")]
        [StringLength(10)]
        public string descripcionAgencia { get; set; }
    }
}