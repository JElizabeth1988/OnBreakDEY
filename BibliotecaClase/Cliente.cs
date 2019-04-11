using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClase
{
    public class Cliente
    {
        private String _rut;

        public String Rut
        {
            get { return _rut; }
            set
            {
                if (true)
                {
                    _rut = value;
                }
                else
                {
                    throw new ArgumentException("Todos los campos son Obligatorios");
                }
            }
        }

        private String _razonSocial;

        public String RazonSocial
        {
            get { return _razonSocial; }
            set
            {
                if (true)
                {
                    _razonSocial = value;
                }
                else
                {
                    throw new ArgumentException("Todos los campos son Obligatorios");
                }

            }
        }

        private String _nombreContacto;

        public String NombreContacto
        {
            get { return _nombreContacto; }
            set
            {
                if (true)
                {
                    _nombreContacto = value;
                }
                else
                {
                    throw new ArgumentException("Todos los campos son Obligatorios");
                }

            }
        }

        private String _mailContacto;

        public String Mail
        {
            get { return _mailContacto; }
            set
            {
                if (true)
                {
                    _mailContacto = value;
                }
                else
                {
                    throw new ArgumentException("Todos los campos son Obligatorios");
                }
            }
        }

        private String _direccion;

        public String Direccion
        {
            get { return _direccion; }
            set
            {
                if (_direccion != null)
                {
                    _direccion = value;
                }
                else
                {
                    throw new ArgumentException("Todos los campos son Obligatorios");
                }
            }
        }

        private int _telefono;

        public int Telefono
        {
            get { return _telefono; }
            set
            {
                if (_telefono != 0)
                {
                    _telefono = value;
                }
                else
                {
                    throw new ArgumentException("Todos los campos son Obligatorios");
                }

            }
        }

        /* private String _actividad;

         public String Actividad
         {
             get { return _actividad; }
             set { _actividad = value; }
         }

         private bool _tipo;//boleean??

         public bool Tipo
         {
             get { return _tipo; }
             set { _tipo = value; }
         }*/

    }
}
