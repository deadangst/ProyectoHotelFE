using Microsoft.AspNetCore.Mvc;
using ProyectoHotelFE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoHotelFE.Controllers
{
    public class HotelController : Controller
    {
        #region Acciones de apertura de vistas

        public async Task<IActionResult> Index()
        {
            GestorConexionApis objconexion = new GestorConexionApis();
            List<UsuarioModel> resultado = await objconexion.ListarUsuarios();
            return View(resultado);
        }

        public IActionResult AbrirCrearUsuario()
        {
            ViewBag.TipoUsuarios = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "SuperUsuario" },
                new SelectListItem { Value = "2", Text = "Administrador" },
                new SelectListItem { Value = "3", Text = "Recepcionista" },
                new SelectListItem { Value = "4", Text = "Cliente" }
            };
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEdicionUsuario(int usuarioID)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            List<UsuarioModel> lstresultado = await objgestor.ListarUsuarios();
            UsuarioModel encontrado = lstresultado.FirstOrDefault(u => u.usuarioID == usuarioID);

            ViewBag.TipoUsuarios = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "SuperUsuario" },
                new SelectListItem { Value = "2", Text = "Administrador" },
                new SelectListItem { Value = "3", Text = "Recepcionista" },
                new SelectListItem { Value = "4", Text = "Cliente" }
            };
            return View(encontrado);
        }

        public async Task<IActionResult> ListarTarjetasCredito()
        {
            GestorConexionApis objconexion = new GestorConexionApis();
            List<TarjetaCreditoModel> resultado = await objconexion.ListarTarjetasCredito();
            return View(resultado);
        }

        public IActionResult AbrirCrearTarjetaCredito()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEdicionTarjetaCredito(int tarjetaID)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            List<TarjetaCreditoModel> lstresultado = await objgestor.ListarTarjetasCredito();
            TarjetaCreditoModel encontrado = lstresultado.FirstOrDefault(t => t.tarjetaID == tarjetaID);
            return View(encontrado);
        }

        public async Task<IActionResult> ListarReservas()
        {
            GestorConexionApis objconexion = new GestorConexionApis();
            List<ReservaModel> resultado = await objconexion.ListarReservas();
            return View(resultado);
        }

        public IActionResult AbrirCrearReserva()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEdicionReserva(int reservaID)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            List<ReservaModel> lstresultado = await objgestor.ListarReservas();
            ReservaModel encontrado = lstresultado.FirstOrDefault(r => r.reservaID == reservaID);
            return View(encontrado);
        }

        public async Task<IActionResult> ListarPagos()
        {
            GestorConexionApis objconexion = new GestorConexionApis();
            List<PagoModel> resultado = await objconexion.ListarPagos();
            return View(resultado);
        }

        public IActionResult AbrirCrearPago()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEdicionPago(int pagoID)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            List<PagoModel> lstresultado = await objgestor.ListarPagos();
            PagoModel encontrado = lstresultado.FirstOrDefault(p => p.pagoID == pagoID);
            return View(encontrado);
        }

        public async Task<IActionResult> ListarBitacora()
        {
            GestorConexionApis objconexion = new GestorConexionApis();
            List<BitacoraModel> resultado = await objconexion.ListarBitacora();
            return View(resultado);
        }

        #endregion

        #region Acciones de Mantenimiento sobre UsuarioModel

        [HttpPost]
        public async Task<IActionResult> GuardarUsuario(UsuarioModel usuario)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.AgregarUsuario(usuario);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Usuario agregado exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al agregar el usuario.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditarUsuario(UsuarioModel usuario)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            // Obtener el usuario existente
            List<UsuarioModel> lstresultado = await objgestor.ListarUsuarios();
            UsuarioModel usuarioExistente = lstresultado.FirstOrDefault(u => u.usuarioID == usuario.usuarioID);

            if (usuario.passwordHash == "********")
            {
                // Mantener la contraseña existente si no se ha cambiado
                usuario.passwordHash = usuarioExistente.passwordHash;
            }

            var resultado = await objgestor.ModificarUsuario(usuario);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Usuario modificado exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al modificar el usuario.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> BorrarUsuario(int usuarioID)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.EliminarUsuario(usuarioID);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Usuario eliminado exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al eliminar el usuario.";
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Acciones de Mantenimiento sobre TarjetaCreditoModel

        [HttpPost]
        public async Task<IActionResult> GuardarTarjetaCredito(TarjetaCreditoModel tarjeta)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.AgregarTarjetaCredito(tarjeta);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Tarjeta de crédito agregada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al agregar la tarjeta de crédito.";
            }
            return RedirectToAction("ListarTarjetasCredito");
        }

        [HttpPost]
        public async Task<IActionResult> EditarTarjetaCredito(TarjetaCreditoModel tarjeta)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.ModificarTarjetaCredito(tarjeta);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Tarjeta de crédito modificada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al modificar la tarjeta de crédito.";
            }
            return RedirectToAction("ListarTarjetasCredito");
        }

        [HttpGet]
        public async Task<IActionResult> BorrarTarjetaCredito(int tarjetaID)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.EliminarTarjetaCredito(tarjetaID);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Tarjeta de crédito eliminada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al eliminar la tarjeta de crédito.";
            }
            return RedirectToAction("ListarTarjetasCredito");
        }

        #endregion

        #region Acciones de Mantenimiento sobre ReservaModel

        [HttpPost]
        public async Task<IActionResult> GuardarReserva(ReservaModel reserva)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.AgregarReserva(reserva);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Reserva agregada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al agregar la reserva.";
            }
            return RedirectToAction("ListarReservas");
        }

        [HttpPost]
        public async Task<IActionResult> EditarReserva(ReservaModel reserva)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.ModificarReserva(reserva);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Reserva modificada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al modificar la reserva.";
            }
            return RedirectToAction("ListarReservas");
        }

        [HttpGet]
        public async Task<IActionResult> BorrarReserva(int reservaID)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.EliminarReserva(reservaID);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Reserva eliminada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al eliminar la reserva.";
            }
            return RedirectToAction("ListarReservas");
        }

        #endregion

        #region Acciones de Mantenimiento sobre PagoModel

        [HttpPost]
        public async Task<IActionResult> GuardarPago(PagoModel pago)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.AgregarPago(pago);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Pago agregado exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al agregar el pago.";
            }
            return RedirectToAction("ListarPagos");
        }

        [HttpPost]
        public async Task<IActionResult> EditarPago(PagoModel pago)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.ModificarPago(pago);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Pago modificado exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al modificar el pago.";
            }
            return RedirectToAction("ListarPagos");
        }

        [HttpGet]
        public async Task<IActionResult> BorrarPago(int pagoID)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.EliminarPago(pagoID);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Pago eliminado exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al eliminar el pago.";
            }
            return RedirectToAction("ListarPagos");
        }

        #endregion
    }
}
