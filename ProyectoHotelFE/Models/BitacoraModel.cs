using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotelFE.Models
{
    public class BitacoraModel
    {
        #region Propiedades

        [Display(Name = "ID")]
        public string iD { get; set; }
        [Required]
        [Display(Name = "Tipo de Acción")]
        public string tipoAccion { get; set; }
        [Required]
        [Display(Name = "Usuario ID")]
        public int usuarioID { get; set; }
        [Required]
        [Display(Name = "Fecha de Acción")]
        public DateTime fechaAccion { get; set; }

        #endregion

        #region Constructor 

        public BitacoraModel()
        {
            iD = string.Empty;
            tipoAccion = string.Empty;
            usuarioID = 0;
            fechaAccion = DateTime.MinValue;
        }

        #endregion
    }
}
