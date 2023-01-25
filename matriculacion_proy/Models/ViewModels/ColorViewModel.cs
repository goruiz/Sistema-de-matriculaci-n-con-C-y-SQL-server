using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace matriculacion_proy.Models.ViewModels
{
    public class ColorViewModel
    {
        public int idColor { get; set; }
        [Required]
        [Display(Name = "Ingrese ele color: ")]
        [StringLength(30)]
        public string descripcionColor { get; set; }
        
    }
    public class EditarColorViewModel
    {
        [Required]
        public int idColor { get; set; }
        [Required]
        [Display(Name = "Ingrese el color ")]
        [StringLength(30)]
        public string descripcionColor { get; set; }
        
    }
    public class EliminarColorViewModel
    {
        [Required]
        public int idColor { get; set; }
        [Required]
        [Display(Name = "Ingrese el color")]
        [StringLength(10)]
        public string descripcionColor { get; set; }
    }
}