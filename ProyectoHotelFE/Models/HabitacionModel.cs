using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotelFE.Models
{
    public class HabitacionModel
    {
        #region Propiedades

        public int habitacionID { get; set; }
        [Required]
        [Display(Name = "Habitación #")]
        public int numeroHabitacion { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public string tipoHabitacion { get; set; }
        [Required]
        [Display(Name = "Capacidad")]
        public int capacidad { get; set; }
        [Required]
        [Display(Name = "Precio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal precio { get; set; }

        #endregion

        #region Constructor 

        public HabitacionModel()
        {
            habitacionID = 0;
            numeroHabitacion = 0;
            tipoHabitacion = string.Empty;
            capacidad = 0;
            precio = 0.0m;
        }

        #endregion
    }
}
