using LogicaNegocio;
using LogicaNegocio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Controllers
{
    public class SuperController : Controller
    {
        public SuperController()
        {
        }
        public IActionResult Datos()
        { 
            return View(); 
        }
      


        public IActionResult Historial()
        {
            ManejadorUsuario manejadorUsuario = new ManejadorUsuario();
            List<LogicaNegocio.Modelos.Usuario> usuarios = manejadorUsuario.ObtenerUsuario(0);
            return View(usuarios);
        }

    }
}
