using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotelFE.Models
{
    public class UsuarioModel
    {
        #region Propiedades

        public int usuarioID { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required]
        [Display(Name = "Tipo de Usuario")]
        public int tipoUsuarioID { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string passwordHash { get; set; }

        #endregion

        #region Constructor 

        public UsuarioModel()
        {
            usuarioID = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            email = string.Empty;
            telefono = string.Empty;
            tipoUsuarioID = 0;
            passwordHash = string.Empty;
        }

        #endregion
    }
}
