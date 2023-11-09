using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace AccesoDatos
{
    public class Conexion
    {
        public MySqlConnection conexion;

        public bool Conectar()
        {
            string cadenaConexion = "server=localhost; database=proyectocita; user=root; password=esteban; port=3306";
            conexion = new MySqlConnection(cadenaConexion);
            try {
                conexion.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Desconectar()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
               
        }
        public DataTable EjecutarConsulta(string procedimiento, List<Parametro> parametros = null)
        {
            Conectar(); 
             DataTable data = new DataTable();
            try
            {
                MySqlCommand Comando = new MySqlCommand(procedimiento, conexion);
                Comando.CommandType = System.Data.CommandType.StoredProcedure;
                if(parametros != null )
                {
                    foreach(Parametro parametro in parametros)
                    {
                        Comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                MySqlDataReader lector = Comando.ExecuteReader();
                data.Load(lector);
            }
            catch   (Exception ex) 
            {
            Console.WriteLine("Error al traer datos del usuario" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return data;
        }
        public bool EjecutarTransaccion(string procedimiento, List<Parametro> parametros = null)
        {
            Conectar();
            try
            {
                MySqlCommand comando = new MySqlCommand(procedimiento, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure; 

                if (parametros != null )
                {
                    foreach(Parametro parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine ("Error al Enviar Datos del usuario" + e.Message);
                return false;
               
            }
            finally { Desconectar(); }
        }

        public bool EjecutarTransaccion(List<Transaccion> transacciones)
        {
            throw new NotImplementedException();
        }
    }
}