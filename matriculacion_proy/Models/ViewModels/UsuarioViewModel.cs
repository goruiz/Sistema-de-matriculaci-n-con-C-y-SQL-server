using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace matriculacion_proy.Models.ViewModels
{
    public class UsuarioViewModel
    {

        [Required]
        [Display(Name = "Ingrese el nombre: ")]
        [StringLength(10)]

        public string nombre { get; set; }

        [Required]

        [Display(Name = "Ingrese el usuario ")]
        public string usuario { get; set; }
        [Required]


        [Display(Name = "Ingrese el la clave")]
        public string clave { get; set; }

        [Display(Name = "Ingrese el rol")]
        public string rol { get; set; }

        [Display(Name = "Ingrese el estatus")]
        public int estatus { get; set; }





    }
    public class EditarUsuarioViewModel
    {

        public Nullable<int> id { get; set; }

        [Required]
        [Display(Name = "Ingrese el nombre: ")]
        [StringLength(10)]

        public string nombre { get; set; }

        [Required]

        [Display(Name = "Ingrese el usuario ")]
        public string usuario { get; set; }
        [Required]


        [Display(Name = "Ingrese el la clave")]
        public string clave { get; set; }

        [Display(Name = "Ingrese el rol")]
        public string rol { get; set; }

        [Display(Name = "Ingrese el status")]
        public int estatus { get; set; }

    }


    public class EliminarUsuarioViewModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        [Display(Name = "Desea eliminar el usuario?")]
        [StringLength(10)]
        public string nombreUsuario { get; set; }
        public string usuarioUsuario { get; set; }
        public string claveUsuario { get; set; }
        public string rolUsuario { get; set; }
        public int estatusUsuario { get; set; }
    }
}