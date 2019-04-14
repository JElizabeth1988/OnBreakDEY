using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClase
{
    public class Evento
    {
       
        private int _valorBase;
        private int _personalBase;

 

        //Cálculo valor Contrato

        public int ValorBase
        {
            get { return _valorBase; }
            set { _valorBase = value; }
        }

        public int PersonalBase
        {
            get { return _personalBase; }
            set { _personalBase = value; }
        }

        public Evento(,int valorBase,int personalBase)
        {
            ValorBase = valorBase;PersonalBase = personalBase;
        }

        public Evento()
        {

        }



    }
}
