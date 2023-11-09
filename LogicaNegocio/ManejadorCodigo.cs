using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ManejadorCodigo
    {
        private Conexion conexion = new Conexion();
        public DataTable GuardarCodigo(int codigo, long idUsuario)
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("p_mensaje", codigo),
                new Parametro("fk_usuario", idUsuario)
            };

            return conexion.EjecutarConsulta("Codigo", parametros);
        }

    }
}
