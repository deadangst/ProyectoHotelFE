using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoHotelFE.Models
{
    public class BitacoraModel
    {
        #region Propiedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Display(Name = "ID")]
        public string id { get; set; }
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
            id = string.Empty;
            tipoAccion = string.Empty;
            usuarioID = 0;
            fechaAccion = DateTime.MinValue;
        }

        #endregion
    }
}
