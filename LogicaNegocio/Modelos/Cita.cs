using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Modelos
{
    public class Cita
    {
        public int Id { get; set; }
        public Time Hora {  get; set; }
        public DateTime Fecha { get; set; }
        public string estado {  get; set; }
        public TipoServicio TipoServicio { get; set;}
        public Notificacion Notificacion {  get; set; }

    }
}
