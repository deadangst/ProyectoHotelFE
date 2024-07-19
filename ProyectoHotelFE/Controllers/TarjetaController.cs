using Microsoft.AspNetCore.Mvc;
using ProyectoHotelFE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoHotelFE.Controllers
{
    public class TarjetaController : Controller
    {
        public async Task<IActionResult> Index()
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}
