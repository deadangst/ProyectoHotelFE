using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotelFE.Models
{
    public class PagoModel
    {
        #region Propiedades

        public int pagoID { get; set; }
        [Required]
        public int reservaID { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.")]
        public decimal monto { get; set; }
        [Required]
        public DateTime fechaPago { get; set; }
        [Required]
        public int metodoPagoID { get; set; }

        #endregion

        #region Constructor 

        public PagoModel()
        {
            pagoID = 0;
            reservaID = 0;
            monto = 0.0m;
            fechaPago = DateTime.MinValue;
            metodoPagoID = 0;
        }

        #endregion
    }
}
