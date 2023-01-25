using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace matriculacion_proy.Models.ViewModels
{
    public class VehiculoViewModel
    {
        [Required]
        [Display(Name = "Ingrese la placa del vehiculo")]
        public string placaVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese el motor del vehiculo")]
        public string motorVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese el chasis del vehiculo")]
        public string chasisVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese el combustible del vehiculo")]
        public string combustibleVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese el anio del vehiculo")]
        [StringLength(4)]
        public string anioVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese el avaluo del vehiculo")]
        public decimal avaluoVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese la foto del vehiculo")]
        public string fotoVehiculo { get; set; }

        [Display(Name = "Ingrese la marca del vehiculo")]
        public Nullable<int> idMarca { get; set; }

        //public string Marca { get; set; }

        [Display(Name = "Ingrese el color del vehiculo")]
        public Nullable<int> idColor { get; set; }
        //public string Color { get; set; }
        [Display(Name = "Ingrese el usuario del vehiculo")]
        public Nullable<int> idUsuario { get; set; }

    }
    public class EditarVehiculoViewModel
    {
        public int idVehiculo { get; set; }
        [Required]
        [Display(Name = "Ingrese la placa del vehiculo")]
        [StringLength(10)]
        public string placaVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese el motor del vehiculo")]
        public string motorVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese el chasis del vehiculo")]
        public string chasisVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese el combustible del vehiculo")]
        public string combustibleVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese el anio del vehiculo")]
        public string anioVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese el avaluo del vehiculo")]
        public decimal avaluoVehiculo { get; set; }

        [Required]
        [Display(Name = "Ingrese la foto del vehiculo")]
        public string fotoVehiculo { get; set; }

        [Display(Name = "Ingrese la marca del vehiculo")]
        public Nullable<int> idMarca { get; set; }

        //public string Marca { get; set; }

        [Display(Name = "Ingrese el color del vehiculo")]
        public Nullable<int> idColor { get; set; }
        //public string Color { get; set; }
        [Display(Name = "Ingrese el usuario del vehiculo")]
        public Nullable<int> idUsuario { get; set; }

    }
    public class EliminarVehiculoViewModel
    {
        public int idVehiculo { get; set; }
        [Required]
        [Display(Name = "Ingrese la placa")]
        public string placaVehiculo { get; set; }
    }
}





