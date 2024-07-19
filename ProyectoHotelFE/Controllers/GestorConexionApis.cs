using ProyectoHotelFE.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoHotelFE.Controllers
{
    public class GestorConexionApis
    {
        #region Propiedades

        public HttpClient ConexionApis { get; set; }

        #endregion

        #region Constructor

        public GestorConexionApis()
        {
            ConexionApis = new HttpClient();
            EstablecerDatosBaseConexion();
        }

        #endregion

        #region Metodos

        #region Privado

        private void EstablecerDatosBaseConexion()
        {
            ConexionApis.BaseAddress = new Uri("http://localhost:84/");
            ConexionApis.DefaultRequestHeaders.Accept.Clear();
            ConexionApis.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion

        #region Publico

        #region Usuarios

        public async Task<List<UsuarioModel>> ListarUsuarios()
        {
            List<UsuarioModel> listaresultado = new List<UsuarioModel>();
            string rutaAPI = @"api/Hotel/ConsultarUsuarios";

            HttpResponseMessage resultadoconsumo = await ConexionApis.GetAsync(rutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                listaresultado = JsonSerializer.Deserialize<List<UsuarioModel>>(jsonstring);
            }

            return listaresultado;
        }

        public async Task<bool> AgregarUsuario(UsuarioModel usuario)
        {
            string rutaAPI = @"api/Hotel/AgregarUsuario";

            HttpResponseMessage resultadoconsumo = await ConexionApis.PostAsJsonAsync(rutaAPI, usuario);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarUsuario(UsuarioModel usuario)
        {
            string rutaAPI = @"api/Hotel/ModificarUsuario";

            ConexionApis.DefaultRequestHeaders.Add("usuarioID", usuario.usuarioID.ToString());
            HttpResponseMessage resultadoconsumo = await ConexionApis.PutAsJsonAsync(rutaAPI, usuario);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarUsuario(int usuarioID)
        {
            string rutaAPI = @"api/Hotel/EliminarUsuario";

            ConexionApis.DefaultRequestHeaders.Add("usuarioID", usuarioID.ToString());
            HttpResponseMessage resultadoconsumo = await ConexionApis.DeleteAsync(rutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        #endregion

        #region Tarjetas de Crédito

        public async Task<List<TarjetaCreditoModel>> ListarTarjetasCredito()
        {
            List<TarjetaCreditoModel> listaresultado = new List<TarjetaCreditoModel>();
            string rutaAPI = @"api/Hotel/ConsultarTarjetasCredito";

            HttpResponseMessage resultadoconsumo = await ConexionApis.GetAsync(rutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                listaresultado = JsonSerializer.Deserialize<List<TarjetaCreditoModel>>(jsonstring);
            }

            return listaresultado;
        }

        public async Task<bool> AgregarTarjetaCredito(TarjetaCreditoModel tarjeta)
        {
            string rutaAPI = @"api/Hotel/AgregarTarjetaCredito";

            HttpResponseMessage resultadoconsumo = await ConexionApis.PostAsJsonAsync(rutaAPI, tarjeta);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarTarjetaCredito(TarjetaCreditoModel tarjeta)
        {
            string rutaAPI = @"api/Hotel/ModificarTarjetaCredito";

            ConexionApis.DefaultRequestHeaders.Add("tarjetaID", tarjeta.tarjetaID.ToString());
            HttpResponseMessage resultadoconsumo = await ConexionApis.PutAsJsonAsync(rutaAPI, tarjeta);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarTarjetaCredito(int tarjetaID)
        {
            string rutaAPI = @"api/Hotel/EliminarTarjetaCredito";

            ConexionApis.DefaultRequestHeaders.Add("tarjetaID", tarjetaID.ToString());
            HttpResponseMessage resultadoconsumo = await ConexionApis.DeleteAsync(rutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        #endregion

        #region Reservas

        public async Task<List<ReservaModel>> ListarReservas()
        {
            List<ReservaModel> listaresultado = new List<ReservaModel>();
            string rutaAPI = @"api/Hotel/ConsultarReservas";

            HttpResponseMessage resultadoconsumo = await ConexionApis.GetAsync(rutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                listaresultado = JsonSerializer.Deserialize<List<ReservaModel>>(jsonstring);
            }

            return listaresultado;
        }

        public async Task<bool> AgregarReserva(ReservaModel reserva)
        {
            string rutaAPI = @"api/Hotel/AgregarReserva";

            HttpResponseMessage resultadoconsumo = await ConexionApis.PostAsJsonAsync(rutaAPI, reserva);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarReserva(ReservaModel reserva)
        {
            string rutaAPI = @"api/Hotel/ModificarReserva";

            ConexionApis.DefaultRequestHeaders.Add("reservaID", reserva.reservaID.ToString());
            HttpResponseMessage resultadoconsumo = await ConexionApis.PutAsJsonAsync(rutaAPI, reserva);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarReserva(int reservaID)
        {
            string rutaAPI = @"api/Hotel/EliminarReserva";

            ConexionApis.DefaultRequestHeaders.Add("reservaID", reservaID.ToString());
            HttpResponseMessage resultadoconsumo = await ConexionApis.DeleteAsync(rutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        #endregion

        #region Pagos

        public async Task<List<PagoModel>> ListarPagos()
        {
            List<PagoModel> listaresultado = new List<PagoModel>();
            string rutaAPI = @"api/Hotel/ConsultarPagos";

            HttpResponseMessage resultadoconsumo = await ConexionApis.GetAsync(rutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                listaresultado = JsonSerializer.Deserialize<List<PagoModel>>(jsonstring);
            }

            return listaresultado;
        }

        public async Task<bool> AgregarPago(PagoModel pago)
        {
            string rutaAPI = @"api/Hotel/AgregarPago";

            HttpResponseMessage resultadoconsumo = await ConexionApis.PostAsJsonAsync(rutaAPI, pago);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarPago(PagoModel pago)
        {
            string rutaAPI = @"api/Hotel/ModificarPago";

            ConexionApis.DefaultRequestHeaders.Add("pagoID", pago.pagoID.ToString());
            HttpResponseMessage resultadoconsumo = await ConexionApis.PutAsJsonAsync(rutaAPI, pago);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarPago(int pagoID)
        {
            string rutaAPI = @"api/Hotel/EliminarPago";

            ConexionApis.DefaultRequestHeaders.Add("pagoID", pagoID.ToString());
            HttpResponseMessage resultadoconsumo = await ConexionApis.DeleteAsync(rutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        #endregion

        #region Bitacora

        public async Task<List<BitacoraModel>> ListarBitacora()
        {
            List<BitacoraModel> listaresultado = new List<BitacoraModel>();
            string rutaAPI = @"api/Hotel/ConsultarBitacora";

            HttpResponseMessage resultadoconsumo = await ConexionApis.GetAsync(rutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                listaresultado = JsonSerializer.Deserialize<List<BitacoraModel>>(jsonstring);
            }

            return listaresultado;
        }

        #endregion

        #region Habitaciones

        public async Task<List<HabitacionModel>> ListarHabitaciones()
        {
            List<HabitacionModel> listaresultado = new List<HabitacionModel>();
            string rutaAPI = @"api/Hotel/ConsultarHabitaciones";

            HttpResponseMessage resultadoconsumo = await ConexionApis.GetAsync(rutaAPI);
            if (resultadoconsumo.IsSuccessStatusCode)
            {
                string jsonstring = await resultadoconsumo.Content.ReadAsStringAsync();
                listaresultado = JsonSerializer.Deserialize<List<HabitacionModel>>(jsonstring);
            }

            return listaresultado;
        }

        public async Task<bool> AgregarHabitacion(HabitacionModel habitacion)
        {
            string rutaAPI = @"api/Hotel/AgregarHabitacion";

            HttpResponseMessage resultadoconsumo = await ConexionApis.PostAsJsonAsync(rutaAPI, habitacion);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarHabitacion(HabitacionModel habitacion)
        {
            string rutaAPI = @"api/Hotel/ModificarHabitacion";

            ConexionApis.DefaultRequestHeaders.Add("habitacionID", habitacion.habitacionID.ToString());
            HttpResponseMessage resultadoconsumo = await ConexionApis.PutAsJsonAsync(rutaAPI, habitacion);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarHabitacion(int habitacionID)
        {
            string rutaAPI = @"api/Hotel/EliminarHabitacion";

            ConexionApis.DefaultRequestHeaders.Add("habitacionID", habitacionID.ToString());
            HttpResponseMessage resultadoconsumo = await ConexionApis.DeleteAsync(rutaAPI);
            return resultadoconsumo.IsSuccessStatusCode;
        }

        #endregion

        #endregion

        #endregion
    }
}
