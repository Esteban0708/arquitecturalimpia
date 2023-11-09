using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Controllers
{
    public class CrearController : Controller
    {
        public CrearController()
        {
        }
        public IActionResult crearUsuario()
        {
            return View();
        }
    }
}
