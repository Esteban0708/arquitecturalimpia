using AccesoDatos;
using LogicaNegocio.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ManejadorDepartamento
    {
        private Conexion conexion = new Conexion();

        public List<Departamento> ObtenerDepartamento(int id_departamento)
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("p_id_departamento", id_departamento)
            };
            DataTable data = conexion.EjecutarConsulta("consultar_departamento", parametros);
            List<Departamento> departamentos = new List<Departamento>();
            foreach (DataRow row in data.AsEnumerable()) 
            {
                departamentos.Add(new Departamento() 
                {
                 Id = Convert.ToInt32(row["id_departamento"].ToString()),
                 nombre = row["nombre"].ToString()                   
                });
            }
            return departamentos; 
        }
    }
}
