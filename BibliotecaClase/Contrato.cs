using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClase
{
    public enum TipoEvento
    {
        Matrimonio,Cumpleaños,Bautizo,Graduacion,Gala,Aniversario,BabyShower
    }

    public class Contrato
    {
        
        private String _numero;
        private String _fechaCreacion;
        private String  _vigente;
        private String _fechaTermino;
        private String _fechaInicioEvento;
        private int _horaInicio;
        private int _minutoInicio;
        private String _fechaFinEvento;
        private int _horaTermino;
        private int _minutoTermino;
        private String _direccion;
        private int _numeroAsistentes;
        private String _observaciones;
        private String _rutCliente;
        private int _personalAdicional;





        //PROPIEDADES

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
        }//hacerlo automatico

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
        }//hacerlo automatico

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

        public String FechaFinEvento
        {
            get { return _fechaFinEvento; }
            set
            {
                if (value != null)
                {
                    _fechaFinEvento = value;
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
                    throw new ArgumentException("ERROR: Campo Numero de Asistentes no puede estar Vacío");
                }
            }
        }

        public int PersonalAdicional
        {
            get { return _personalAdicional; }
            set { _personalAdicional = value; }
        }


        public TipoEvento Evento { get; set; }

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

        public String RutCliente
        {
            get { return _rutCliente; }
            set { _rutCliente = value; }
        }


        public Contrato()
        {

        }

        public Contrato(String numero,String fechaCreacion ,String vigente,String fechaTermino,
                        String fechaInicioEvento, int horaInicio, int minutoInicio,
                        String fechaFinEvento, int horaTermino, int minutoTermino,
                        String direccion, int numeroAsistentes,int personalAdicional,TipoEvento evento,String observaciones,
                        String rutCliente)
        {

            Numero = numero;
            FechaCreacion = fechaCreacion;
            Vigente = vigente;
            FechaTermino = fechaTermino ;
            FechaInicioEvento = fechaInicioEvento;
            HoraInicio = horaInicio;
            MinutoInicio = minutoInicio;
            FechaFinEvento = fechaFinEvento;
            HoraTermino = horaTermino;
            MinutoTermino = minutoTermino;
            Direccion = direccion;
            NumeroAsistentes = numeroAsistentes;
            PersonalAdicional = personalAdicional;
            Evento = evento;
            Observaciones = observaciones;
            RutCliente = rutCliente;
        }


       

    }
    
}

