using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Modelos
{
    public  class Permiso_Rol
    {
        public Permiso Permiso {  get; set; }
        public Rol Rol { get; set; }
        public string Estado { get; set; }
    }
}
