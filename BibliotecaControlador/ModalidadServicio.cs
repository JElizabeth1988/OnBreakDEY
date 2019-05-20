using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaControlador
{
    public class ModalidadServicio
    {
        public int Id { get; set; }
        public int IdtipoEvento { get; set; }//foranea

        public string Nombre { get; set; }

        public double ValorBase { get; set; }

        public int PersonalBase{ get; set; }
    }


}
