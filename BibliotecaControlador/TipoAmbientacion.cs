using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaControlador
{
    public class TipoAmbientacion
    {
        private int _idTipoAmbientacion;

        public int IdTipoAmbientacion
        {
            get { return _idTipoAmbientacion; }
            set { _idTipoAmbientacion = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

      


    }
}
