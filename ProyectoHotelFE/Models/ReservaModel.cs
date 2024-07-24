using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotelFE.Models
{
    public class ReservaModel
    {
        #region Propiedades

        [Display(Name = "Nº Reserva")]
        public int reservaID { get; set; }
        [Required]
        [Display(Name = "Nº de Habitación")]
        public int habitacionID { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public int usuarioID { get; set; }
        [Required]
        [Display(Name = "ID de Tarjeta")]
        public int tarjetaID { get; set; }
        [Required]
        [Display(Name = "Check In")]
        public DateTime fechaInicio { get; set; }
        [Required]
        [Display(Name = "Check Out")]
        public DateTime fechaFin { get; set; }
        [Required]
        [Display(Name = "Monto Total")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto total debe ser mayor a 0.")]
        public decimal montoTotal { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public int estadoID { get; set; }

        #endregion

        #region Constructor 

        public ReservaModel()
        {
            reservaID = 0;
            habitacionID = 0;
            usuarioID = 0;
            tarjetaID = 0;
            fechaInicio = DateTime.MinValue;
            fechaFin = DateTime.MinValue;
            montoTotal = 0.0m;
            estadoID = 0;
        }

        #endregion
    }
}
