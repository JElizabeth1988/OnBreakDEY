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
        private String _fechaInicio;
        private String _horaInicio;
        private String _minutoInicio;


        private String _fechaTermino;
        private String _direccion;
        private String  _estado;
        private String _tipoEvento;
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

        


        //INICIO-------------------------

        public String FechaInicio
        {
            get { return _fechaInicio; }
            set {

                if (value != null)
                {
                    _fechaInicio = value;
                }
                else
                {
                    
                    throw new ArgumentException("ERROR: Campo Fecha Inicio no puede estar Vacío");
                }

                }
        }


        public String HoraInicio
        {
            get { return _horaInicio; }
            set {
                if (value != null)
                {
                    _horaInicio = value;

                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Hora Inicio no puede estar Vacío");
                }

                }
        }

        public String MinutoInicio
        {
            get { return _minutoInicio; }
            set
            {
                if (value != null)
                {
                    _minutoInicio = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Minuto Inicio no puede estar Vacío");
                }
            }
        }


      



        public String Direccion
        {
            get { return _direccion; }
            set {

                if (value != null)
                {

                    _direccion = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Direccion no puede estar Vacío");
                }
            }
        }

        //EVENTO----------------------------------------

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

        public String Estado
        {
            get { return _estado; }
            set {

                if (value != null)
                {
                    _estado = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Estado no puede estar Vacío");
                }
            }
        }

        public String TipoEvento
        {
            get { return _tipoEvento; }
            set { 

                if (value != null)
                {
                    _tipoEvento = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Tipo de Evento no puede estar Vacío");
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


    }

}

