using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaControlador
{
    public class CofeeBreak
    {
        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }


        private bool _vegetariana;

        public bool Vegetariana
        {
            get { return _vegetariana; }
            set { _vegetariana = value; }
        }


    }
}
