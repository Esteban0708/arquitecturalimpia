using AccesoDatos;
using LogicaNegocio.Modelos;
using System.Data;

namespace LogicaNegocio
{
    public class ManejadorCiudad
    {
        private Conexion conexion = new Conexion();

        public List<Ciudad> ObtenerCiudades(int id_ciudad)
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("p_id_ciudad", id_ciudad)
            };
            DataTable data = conexion.EjecutarConsulta("consultar_ciudad", parametros);
            List<Ciudad> ciudades = new List<Ciudad>();
            foreach (DataRow row in data.AsEnumerable())
            {
                ciudades.Add(new Ciudad()
                {
                    Id = Convert.ToInt32(row["id_ciudad"].ToString()),
                    Nombre = row["nombre"].ToString()
                });
            }
            return ciudades;
        }
    }
}
