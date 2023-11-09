using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Modelos
{
    public class Notificacion
    {
        public int Id {  get; set; }
        public int Mensaje { get; set; }
        public DateTime Fecha {  get; set; }
        public Usuario Usuario { get; set;}
        
    }
}
