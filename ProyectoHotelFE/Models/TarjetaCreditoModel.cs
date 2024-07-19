using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotelFE.Models
{
    public class TarjetaCreditoModel
    {
        #region Propiedades

        public int tarjetaID { get; set; }
        [Required]
        [Display(Name = "Usuario ID")]
        public int usuarioID { get; set; }
        [Required]
        [CreditCard]
        [Display(Name = "Número de Tarjeta")]
        public string numeroTarjeta { get; set; }
        [Required]
        [Display(Name = "Fecha de Expiración")]
        public DateTime fechaExpiracion { get; set; }
        [Required]
        [Display(Name = "CVV")]
        public string codigoSeguridad { get; set; }
        [Required]
        [Display(Name = "Es Válida")]
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
