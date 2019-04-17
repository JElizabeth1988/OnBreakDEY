using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios
{
    public class ClDatos
    {

        public string version { get; set; }
        public string autor { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string unidad_medida { get; set; }
        public List<Serie> serie { get; set; }

        public ClDatos()
        {

        }

    }

    public class Serie
    {
        public string fecha { get; set; }
        public string valor { get; set; }

        public Serie()
        {

        }
    }
}
