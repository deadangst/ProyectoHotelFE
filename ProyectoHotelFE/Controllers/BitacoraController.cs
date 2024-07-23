using Microsoft.AspNetCore.Mvc;
using ProyectoHotelFE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ProyectoHotelFE.Controllers
{
    public class BitacoraController : Controller
    {
        public async Task<IActionResult> Index()
        {
            GestorConexionApis objconexion = new GestorConexionApis();
            List<BitacoraModel> resultado = await objconexion.ListarBitacora();
            return View(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> FiltrarListaBitacora(DateTime? fechaEventoBuscar)
        {
            GestorConexionApis objgestor = new GestorConexionApis();
            List<BitacoraModel> listaBitacora = await objgestor.ListarBitacora();

            if (fechaEventoBuscar.HasValue)
                listaBitacora = listaBitacora.Where(item => item.fechaAccion.Date == fechaEventoBuscar.Value.Date).ToList();

            return View("Index", listaBitacora);
        }
    }
}
