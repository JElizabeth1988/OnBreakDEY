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
        private String _fechaInicio;
        private int _horaInicio;
        private int _minutoInicio;
        private String _fechaTermino;
        private int _horaTermino;
        private int _minutoTermino;
        private String _direccion;
        private int _numeroAsistentes;
        private String _tipoEvento;
        private int _valorBase;
        private int _personalBase;

 

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

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

        public int HoraInicio
        {
            get { return _horaInicio; }
            set {

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
            set {
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
                    throw new ArgumentException("ERROR: Campo Fecha Termino no puede estar Vacío");
                }

            }
        }

        public int HoraTermino
        {
            get { return _horaTermino; }
            set {
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
            set { 
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
            set { 
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
            set {
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
            set { _tipoEvento = value;}
        }

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

        public Evento(int id,String fechaInicio,int horaInicio,int minutoInicio,String fechaTermino,
                       int horaTermino,int minutoTermino,String direccion,int numeroAsistentes,
                       String tipoEvento,int valorBase,int personalBase)
        {
            Id = id;FechaInicio = fechaInicio;HoraInicio = horaInicio;MinutoInicio = minutoInicio;
            FechaTermino = fechaTermino;HoraTermino = horaTermino;MinutoTermino = MinutoTermino;
            Direccion = direccion;NumeroAsistentes = numeroAsistentes;TipoEvento = tipoEvento;
            ValorBase = valorBase;PersonalBase = personalBase;
        }

        public Evento()
        {

        }



    }
}
