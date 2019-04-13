using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista
{

    public class Contrato
    {
        private String _numero;
        private String _fechaCreacion;
        private char   _vigente;
        private String _fechaTermino;
        private String _observaciones;
       

        public String Numero
        {
            get { return _numero; }
            set {

                if (value != null)
                {
                    _numero = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Número Contrato no puede estar Vacío");
                }
            }
        }



        public String FechaCreacion
        {
            get { return _fechaCreacion; }
            set
            {
                if (value != null)
                {
                    _fechaCreacion = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Fecha Creación no puede estar Vacío");
                }
        }
        }


        public char Vigente
        {
            get { return _vigente; }
            set { _vigente = value; }
        }


        public String FechaTermino
        {
            get { return _fechaTermino; }
            set { 

                if (value != null)
                {
                    _fechaTermino = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Fecha Término no puede estar Vacío");
                }
            }
        }

   

        public String Observaciones
        {
            get { return _observaciones; }
            set {
                if (value != null)
                {
                    _observaciones = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo observaciones no puede estar Vacío");
                }
            }
        }



        public Contrato(String numero,String fechaCreacion ,char vigente,String fechaTermino,String observaciones)
        {
            Numero = numero;FechaCreacion = fechaCreacion;Vigente = vigente;FechaTermino = fechaCreacion;
            Observaciones = observaciones;

        }


        public Contrato()
        {

        }






    }
    
}

