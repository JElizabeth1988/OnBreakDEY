using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClase
{

    public class Contrato
    {
        private String _numero;
        private String _fechaCreacion;
        private String  _vigente;
        private String _fechaTermino;
        private String _fechaInicioEvento;
        private int _horaInicio;
        private int _minutoInicio;
        private String _fechaTerminoEvento;
        private int _horaTermino;
        private int _minutoTermino;
        private String _direccion;
        private int _numeroAsistentes;
        private String _tipoEvento;
        private String _observaciones;


        public String Numero
        {
            get { return _numero; }
            set {

                if (value != null)
                {
                    _numero =value;
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


        public String Vigente
        {
            get { return _vigente; }
            set { _vigente = value; }
        }


        public String FechaTermino
        {
            get { return _fechaTermino; }
            set
            {
                _fechaTermino = value;
            }
        }

        public String FechaInicioEvento
        {
            get { return _fechaInicioEvento; }
            set
            {

                if (value != null)
                {
                    _fechaInicioEvento = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Fecha Inicio no puede estar Vacío");
                }
            }
        }

        public int HoraInicio
        {
            get { return _horaInicio; }
            set
            {

                if (value != 0)
                {
                    _horaInicio = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Hora Inicio no puede estar Vacío");
                }
            }
        }

        public int MinutoInicio
        {
            get { return _minutoInicio; }
            set
            {
                if (value != 0)
                {
                    _minutoInicio = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Minuto Inicio no puede estar Vacío");
                }
            }
        }

        public String FechaTerminoEvento
        {
            get { return _fechaTermino; }
            set
            {
                if (value != null)
                {
                    _fechaTerminoEvento = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Fecha Termino no puede estar Vacío");
                }

            }
        }

        public int HoraTermino
        {
            get { return _horaTermino; }
            set
            {
                if (value != 0)
                {
                    _horaTermino = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Hora Termino no puede estar Vacío");
                }

            }
        }

        public int MinutoTermino
        {
            get { return _minutoTermino; }
            set
            {
                if (value != 0)
                {
                    _minutoTermino = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Hora Termino no puede estar Vacío");
                }
            }
        }

        public String Direccion
        {
            get { return _direccion; }
            set
            {
                if (value != null)
                {
                    _direccion = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Dirección no puede estar Vacío");
                }
            }
        }


        public int NumeroAsistentes
        {
            get { return _numeroAsistentes; }
            set
            {
                if (value != 0)
                {
                    _numeroAsistentes = value;
                }
                else
                {
                    throw new ArgumentException("ERROR: Campo Dirección no puede estar Vacío");
                }
            }
        }

        public String TipoEvento
        {
            get { return _tipoEvento; }
            set { _tipoEvento = value; }
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



        public Contrato(String numero,String fechaCreacion ,String vigente,String fechaTermino,
                        String fechaInicioEvento, int horaInicio, int minutoInicio,
                        String fechaTerminoEvento,int horaTermino, int minutoTermino, 
                        String direccion, int numeroAsistentes,String tipoEvento,String observaciones)
        {
            Numero = numero;FechaCreacion = fechaCreacion;Vigente = vigente;
            FechaTermino = fechaTermino ;FechaInicioEvento = fechaInicioEvento;
            HoraInicio = horaInicio;MinutoInicio = minutoInicio;FechaTerminoEvento = fechaTerminoEvento;
            HoraTermino = horaTermino;MinutoTermino = minutoTermino;Direccion = direccion;
            NumeroAsistentes = numeroAsistentes;TipoEvento = tipoEvento; Observaciones = observaciones;

        }


        public Contrato()
        {

        }






    }
    
}

