﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotelFE.Models
{
    public class ReservaModel
    {
        #region Propiedades

        public int reservaID { get; set; }
        [Required]
        public int habitacionID { get; set; }
        [Required]
        public int usuarioID { get; set; }
        [Required]
        public int tarjetaID { get; set; }
        [Required]
        public DateTime fechaInicio { get; set; }
        [Required]
        public DateTime fechaFin { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto total debe ser mayor a 0.")]
        public decimal montoTotal { get; set; }
        [Required]
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