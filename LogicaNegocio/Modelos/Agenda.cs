using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Modelos
{
    public class Agenda
    {
        public int Id { get; set; }
        public DateTime Fecha_Inicio {  get; set; }
        public DateTime Fecha_Fin {  get; set; }
        public TimeOnly Hora_Inicio { get; set; }
        public TimeOnly Hora_Fin { get; set; }

        public int Duracion_Cita {  get; set; }
        public string Estado {  get; set; }

        public Encargado Encargado { get; set; }
        public Cita Cita { get; set; }


    }
}
