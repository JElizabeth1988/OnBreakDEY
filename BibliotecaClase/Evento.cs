using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClase
{
    public class Evento
    {
        private int _id;
        private string _nombreTipoEvento; //vicky
        private int _valorBase;
        private int _personalBase;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string NombreTipoEvento
        {
            get { return _nombreTipoEvento; }
            set
            {
                if (value != null)
                {
                    _nombreTipoEvento = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Nombre Evento no puede estar Vacío");
                }
            }
        } //vicky

        //conectar nombre que se guarde AQUI al combobox de CONTRATO

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



        public Evento(int valorBase,int personalBase)
        {
            ValorBase = valorBase;
            PersonalBase = personalBase;
        }

        public Evento()
        {

        }
       


    }
}
