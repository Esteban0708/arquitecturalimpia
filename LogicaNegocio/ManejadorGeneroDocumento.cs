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
    public class ManejadorGeneroDocumento
    {
        private Conexion conexion = new Conexion();
        public List<Genero> ObtenerGenero(int id_genero)
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("p_id_genero", id_genero)
            };
            DataTable data = conexion.EjecutarConsulta("consultar_genero", parametros);
            List<Genero> generos = new List<Genero>();
            foreach (DataRow row in data.AsEnumerable())
            {
                generos.Add(new Genero()
                {
                    Id = Convert.ToInt32(row["id_genero"].ToString()),
                    Nombre = row["genero"].ToString()
                });
            }
            return generos;
        }
        public List<Documento> ObtenerTipoDocumento(int id_documento)
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("p_id_tipo", id_documento)
            };
            DataTable data = conexion.EjecutarConsulta("consultar_TipoDocumento", parametros);
            List<Documento> documentos = new List<Documento>();
            foreach (DataRow row in data.AsEnumerable())
            {
                documentos.Add(new Documento()
                {
                    Id = Convert.ToInt32(row["id_documento"].ToString()),
                    tipo = row["tipo"].ToString()
                });
            }
            return documentos;
        }

    }
}
