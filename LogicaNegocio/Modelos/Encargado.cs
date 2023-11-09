using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Modelos
{
    public class Encargado
    {
        public int Id {  get; set; }
        public string TipoServicio {  get; set; }
        public Usuario Usuario { get; set;}
    }
}
