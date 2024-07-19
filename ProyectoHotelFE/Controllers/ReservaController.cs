using Microsoft.AspNetCore.Mvc;
using ProyectoHotelFE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoHotelFE.Controllers
{
    public class ReservaController : Controller
    {
        public async Task<IActionResult> Index()
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}
