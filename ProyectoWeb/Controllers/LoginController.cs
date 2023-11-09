using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using LogicaNegocio.Modelos;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ProyectoWeb.Controllers
{

    public class LoginController : Controller
    {
        public LoginController()
        {
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Crear()
        {
            return View(); 
        }
        public IActionResult Registro1()
        {
            ManejadorDepartamento manejadorDepartamento = new ManejadorDepartamento();
            List<Departamento> departamentos = manejadorDepartamento.ObtenerDepartamento(0);

            ManejadorCiudad manejadorCiudad = new ManejadorCiudad();
            List<Ciudad> municipios = manejadorCiudad.ObtenerCiudades(0);

            ManejadorGeneroDocumento manejador = new ManejadorGeneroDocumento();
            List<Genero> generos = manejador.ObtenerGenero(0); 

            List<Documento> documentos = manejador.ObtenerTipoDocumento(0);

            ViewBag.Documento = documentos;
            ViewBag.Departamentos = departamentos;
            ViewBag.Ciudad = municipios;
            ViewBag.Generos = generos;

            return View();
        }
      

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            ManejadorUsuario manejador = new ManejadorUsuario();

            DataTable data = manejador.Login(usuario.Correo, usuario.Contrasenia);
            if (data.Rows.Count > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciales incorrectas. Inténtalo de nuevo.");
                return View();
            }
           
        }
        [HttpPost]
        public IActionResult Registro1(Usuario usuario)
        {

            int generoId = Convert.ToInt32(Request.Form["Fkgenero"]); 
            int departamentoId = Convert.ToInt32(Request.Form["Fkdepartamento"]);
            string municipioId = Request.Form["FKmunicipio"];
            int tipoDocumentoId = Convert.ToInt32(Request.Form["FkTipoDocumento"]);


            usuario.Genero = new Genero { Id = generoId };
                usuario.Documento = new Documento { Id = tipoDocumentoId };
                usuario.Ciudad = new Ciudad { Nombre = municipioId };


                ManejadorRegistro manejador = new ManejadorRegistro();
                bool result = manejador.CrearRegistro(usuario);

                if (result)
                {
                    return RedirectToAction("Login");
                    
                }
                else
                {
                   
                    return RedirectToAction("RegistroFallido");
                }
            return View(usuario);
        }



        public IActionResult OlvidoContrasenia()
        {
            return View();
        }

        [HttpPost]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Olvidocontrasenia(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                ModelState.AddModelError("", "Por favor, ingresa tu número de celular.");
                return View();
            }
            ManejadorUsuario numero = new ManejadorUsuario();
            long idUsuario = numero.NumeroExistente(phoneNumber); 

            if (idUsuario != 0)
            {
       
                var code = new Random().Next(100000, 999999).ToString();

                const string ACCOUNT_SID = "ACe08371f3b363298225019e113bf4a021";
                const string authToken = "9bf7641b1a8e6e4572cba8b53ad421db";
                const string TWILIO_PHONE = "+18149850651";

                TwilioClient.Init(ACCOUNT_SID, authToken);
                try
                {
                    var message = MessageResource.Create(
                        body: $"Usa el codigo: {code} para autenticarse",
                        from: TWILIO_PHONE,
                        to: phoneNumber
                    );
                    ManejadorCodigo manejadorCodigo = new ManejadorCodigo();
                    manejadorCodigo.GuardarCodigo(Convert.ToInt32(code), idUsuario);
                }
                catch (Twilio.Exceptions.TwilioException)
                {
                    TempData["ErrorMessage"] = "Error al enviar el código. Por favor, inténtalo nuevamente.";
                    return View();
                }

                return RedirectToAction("IngresarCodigo");
            }
            else
            {
 
                TempData["NumeroNoExiste"] = true;
                return View();
            }
        }


        public IActionResult IngresarCodigo()
        {
            return View();
        }


    }

}
