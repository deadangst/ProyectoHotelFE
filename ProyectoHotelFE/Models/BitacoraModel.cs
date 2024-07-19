using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotelFE.Models
{
    public class BitacoraModel
    {
        #region Propiedades

        public string iD { get; set; }
        [Required]
        public string tipoAccion { get; set; }
        [Required]
        public int usuarioID { get; set; }
        [Required]
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
