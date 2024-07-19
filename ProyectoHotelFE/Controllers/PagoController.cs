using Microsoft.AspNetCore.Mvc;
using ProyectoHotelFE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoHotelFE.Controllers
{
    public class PagoController : Controller
    {
        public async Task<IActionResult> Index()
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}
