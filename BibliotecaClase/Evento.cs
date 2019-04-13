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


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        public int HoraInicio
        {
            get { return _horaInicio; }
            set { _horaInicio = value; }
        }

        public int MinutoInicio
        {
            get { return _minutoInicio; }
            set { _minutoInicio = value; }
        }

        public String FechaTermino
        {
            get { return _fechaTermino; }
            set { _fechaTermino = value; }
        }

        public int HoraTermino
        {
            get { return _horaTermino; }
            set { _horaTermino = value; }
        }

        public int MinutoTermino
        {
            get { return _minutoTermino; }
            set { _minutoTermino = value; }
        }

        public String Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }


        public int NumeroAsistentes
        {
            get { return _numeroAsistentes; }
            set { _numeroAsistentes = value; }
        }

        public String TipoEvento
        {
            get { return _tipoEvento; }
            set { _tipoEvento = value; }
        }


        public Evento(int id,String fechaInicio,int horaInicio,int minutoInicio,String fechaTermino,
                       int horaTermino,int minutoTermino,String direccion,int numeroAsistentes,
                       String tipoEvento)
        {
            Id = id;FechaInicio = fechaInicio;HoraInicio = horaInicio;MinutoInicio = minutoInicio;
            FechaTermino = fechaTermino;HoraTermino = horaTermino;MinutoTermino = MinutoTermino;
            Direccion = direccion;NumeroAsistentes = numeroAsistentes;TipoEvento = tipoEvento;
        }

        public Evento()
        {

        }



    }
}
