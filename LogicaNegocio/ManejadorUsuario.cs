using AccesoDatos;
using LogicaNegocio.Modelos;
using System.Data;

namespace LogicaNegocio
{
    public class ManejadorUsuario
    {
        private Conexion conexion = new Conexion();

        public DataTable Login(string nombreUsuario, string contrasenia)
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("p_correo_usuario", nombreUsuario),
                new Parametro("p_contrasenia_usuario", contrasenia)
            };

            return conexion.EjecutarConsulta("login", parametros);
        }
      
        public List<Usuario> ObtenerUsuario(long nuip)
        {
            List<Parametro> parametros = new List<Parametro>()
    {
        new Parametro("p_nuip_usuario", nuip)
    };

            DataTable data = conexion.EjecutarConsulta("consultar_usuarios", parametros);

            if (data.Rows.Count == 0)
            {
                return null;
            }

            List<Usuario> usuarios = new List<Usuario>();
            foreach (DataRow row in data.AsEnumerable())
            {
                if (row.IsNull("nuip"))
                {
                    continue;
                }

                Usuario usuario = new Usuario
                {
                    Nuip = Convert.ToInt64(row["nuip"]),
                    Nombre = row["nombres"].ToString(),
                    Apellido = row["apellidos"].ToString(),
                    Telefono = row["telefono"].ToString(),
                    Rol = new Rol()
                    {
                        Nombre = row["nombre"].ToString()
                    }
                };

                usuarios.Add(usuario);
            }

            return usuarios;
        }
        public long NumeroExistente(string phoneNumber)
        {
            List<Parametro> parametros = new List<Parametro>()
        {
            new Parametro("p_telefono_usuario", phoneNumber)
        };

            DataTable data = conexion.EjecutarConsulta("verificar_telefono_existente", parametros);
            if (data.Rows.Count > 0)
            {
                long idUsuario = Convert.ToInt64(data.Rows[0]["nuip"]);
                return idUsuario;
            }
            return 0;

        }



    }
}