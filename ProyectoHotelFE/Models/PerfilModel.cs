using System;


namespace ProyectoHotelFE.Models
{
    public class PerfilModel
    {
        public int codigoPerfil { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public string email { get; set; }

        public PerfilModel()
        {
            codigoPerfil = 0;
            descripcion = string.Empty;
            estado = true;
            email = string.Empty;
        }
    }
}
