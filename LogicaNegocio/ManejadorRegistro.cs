using AccesoDatos;
using LogicaNegocio.Modelos;
using Org.BouncyCastle.Tls;

namespace LogicaNegocio
{
    public class ManejadorRegistro
    {
        private Conexion conexion = new Conexion();
        public bool CrearRegistro (Usuario Usuario)
        {
        
        List<Parametro> parametros = new List<Parametro>()
        {
            new Parametro("p_numero_documento", Usuario.Nuip),
            new Parametro("p_nombres", Usuario.Nombre),
            new Parametro("p_apellidos", Usuario.Apellido),
            new Parametro("p_correo", Usuario.Correo),
            new Parametro("p_contrasenia", Usuario.Contrasenia),
            new Parametro("p_telefono", Usuario.Telefono),
            new Parametro("p_genero", Usuario.Genero.Id),
            new Parametro("p_documento", Usuario.Documento.Id),
            new Parametro("p_ciudad", Usuario.Ciudad.Nombre)
          
            
                };
                return conexion.EjecutarTransaccion("registro", parametros);
      
            }

        }

    }

