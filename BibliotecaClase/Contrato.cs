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
        private String _creacion;
        private String _fechaInicio;
        private String _horaInicio;

        private String _fechaTermino;
        private String _direccion;
        private bool _vigente;
        private String _tipo;
        private String _observaciones;

        public String Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public String Creacion
        {
            get { return _creacion; }
            set { _creacion = value; }
        }


        public String FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        public String HoraInicio
        {
            get { return _horaInicio; }
            set { _horaInicio = value; }
        }

        public String FechaTermino
        {
            get { return _fechaTermino; }
            set { _fechaTermino = value; }
        }


        public String Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public bool Vigente
        {
            get { return _vigente; }
            set { _vigente = value; }
        }

        public String Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public String Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }


    }

}

