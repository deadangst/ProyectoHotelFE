using Microsoft.AspNetCore.Mvc;
using ProyectoHotelFE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}
