using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaNegocio
{
    
    public class Contrato
    {

        private String _numero;
        private String _fechaCreacion;
        private String _vigente;
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
                    throw new ArgumentException("- Campo Número Contrato no puede estar Vacío");
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
                    throw new ArgumentException("- Campo Fecha Creación no puede estar Vacío");
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
                if (value != null)
                {
                    _fechaTermino = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Fecha Termino no puede estar Vacío");
                }
               
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
                    throw new ArgumentException("- Campo Fecha Inicio no puede estar Vacío");
                }
            }
        }

        public int HoraInicio
        {
            get { return _horaInicio; }
            set
            {

                if (value >= 0 && value <= 24)
                {
                    _horaInicio = value;
                }
                else
                {
                    throw new ArgumentException("- Ingrese hora entre 1 y 24");
                }
            }
        }

        public int MinutoInicio
        {
            get { return _minutoInicio; }
            set
            {
                if (value >= 0 && value < 60)
                {
                    _minutoInicio = value;
                }
                else
                {
                    throw new ArgumentException("- Ingrese entre 0 y 59 minutos");
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
                    throw new ArgumentException("- Campo Fecha Termino no puede estar Vacío");
                }

            }
        }

        public int HoraTermino
        {
            get { return _horaTermino; }
            set
            {
                if (value >= 1 && value <= 24)
                {
                    _horaTermino = value;
                }
                else
                {
                    throw new ArgumentException("- Ingrese hora entre 1 y 24");
                }

            }
        }

        public int MinutoTermino
        {
            get { return _minutoTermino; }
            set
            {
                if (value >= 0 && value < 60)
                {
                    _minutoTermino = value;
                }
                else
                {
                    throw new ArgumentException("- Ingrese entre 0 y 59 minutos");
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
                    throw new ArgumentException("- Campo Dirección no puede estar Vacío");
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
                    throw new ArgumentException("- Campo Numero de Asistentes no puede estar Vacío");
                }
            }
        }

        public int PersonalAdicional
        {
            get { return _personalAdicional; }
            set
            {
                if (value != 0)
                {
                    _personalAdicional = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Personal Adicional no puede estar Vacío");
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
                    throw new ArgumentException("- Campo observaciones no puede estar Vacío");
                }
            }
        }

        public String RutCliente
        {
            get { return _rutCliente; }
            set {

                if (value != null)
                {
                    _rutCliente = value;
                }
                else
                {
                   throw new ArgumentException("- Campo RUT no puede estar Vacío");
                }
            }
        }

       


       

        public Contrato()
        {

        }

        public Contrato(String numero,String fechaCreacion ,String vigente,String fechaTermino,
                        String fechaInicioEvento, int horaInicio, int minutoInicio,
                        String fechaFinEvento, int horaTermino, int minutoTermino,
                        String direccion, int numeroAsistentes,int personalAdicional,String observaciones,
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
            
            Observaciones = observaciones;
            RutCliente = rutCliente;
            
        }


       

    }
    
}

