using Microsoft.AspNetCore.Mvc;
using ProyectoHotelFE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoHotelFE.Controllers
{
    public class HabitacionController : Controller
    {
        #region Acciones de apertura de vistas

        public async Task<IActionResult> Index()
        {
            GestorConexionApis objconexion = new GestorConexionApis();
            List<HabitacionModel> resultado = await objconexion.ListarHabitaciones();
            return View(resultado);
        }

        public IActionResult AbrirCrearHabitacion()
        {
            ViewBag.TipoHabitaciones = new List<SelectListItem>
            {
                new SelectListItem { Value = "Simple", Text = "Simple" },
                new SelectListItem { Value = "Doble", Text = "Doble" },
                new SelectListItem { Value = "Suite", Text = "Suite" },
                new SelectListItem { Value = "Presidential Suite", Text = "Presidential Suite" }
            };
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AbrirEdicionHabitacion(int habitacionID)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            List<HabitacionModel> lstresultado = await objgestor.ListarHabitaciones();
            HabitacionModel encontrado = lstresultado.FirstOrDefault(h => h.habitacionID == habitacionID);

            ViewBag.TipoHabitaciones = new List<SelectListItem>
            {
                new SelectListItem { Value = "Simple", Text = "Simple" },
                new SelectListItem { Value = "Doble", Text = "Doble" },
                new SelectListItem { Value = "Suite", Text = "Suite" },
                new SelectListItem { Value = "Presidential Suite", Text = "Presidential Suite" }
            };
            return View(encontrado);
        }

        #endregion

        #region Acciones de Mantenimiento sobre HabitacionModel

        [HttpPost]
        public async Task<IActionResult> GuardarHabitacion(HabitacionModel habitacion)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.AgregarHabitacion(habitacion);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Habitación agregada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al agregar la habitación.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditarHabitacion(HabitacionModel habitacion)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.ModificarHabitacion(habitacion);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Habitación modificada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al modificar la habitación.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> BorrarHabitacion(int habitacionID)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            var resultado = await objgestor.EliminarHabitacion(habitacionID);
            if (resultado)
            {
                TempData["SuccessMessage"] = "Habitación eliminada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al eliminar la habitación.";
            }
            return RedirectToAction("Index");
        }

        #endregion
    }
}
