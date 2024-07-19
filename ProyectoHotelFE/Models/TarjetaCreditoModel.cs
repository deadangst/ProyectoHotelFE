using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotelFE.Models
{
    public class TarjetaCreditoModel
    {
        #region Propiedades

        public int tarjetaID { get; set; }
        [Required]
        public int usuarioID { get; set; }
        [Required]
        [CreditCard]
        public string numeroTarjeta { get; set; }
        [Required]
        public DateTime fechaExpiracion { get; set; }
        [Required]
        public string codigoSeguridad { get; set; }
        [Required]
        public bool esValida { get; set; }

        #endregion

        #region Constructor 

        public TarjetaCreditoModel()
        {
            tarjetaID = 0;
            usuarioID = 0;
            numeroTarjeta = string.Empty;
            fechaExpiracion = DateTime.MinValue;
            codigoSeguridad = string.Empty;
            esValida = true;
        }

        #endregion
    }
}
