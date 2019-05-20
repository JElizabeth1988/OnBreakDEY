using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{

    public class Contrato
    {

        private String _numero;
        private String _creacion;
        private String _termino;
        private String _rutCliente;
        public int IdModalidad { get; set; }
        public int IdTipoEvento{ get; set; }
        private String _fechaHoraInicio;
        private string _fechaHoraTermino;
        private int _asistentes;
        private int _personalAdicional;
        public bool Realizado { get; set; }
        private double _valorTotalContrato;
        private String _observaciones;





        //PROPIEDADES

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
                    throw new ArgumentException("- Campo Número Contrato no puede estar Vacío");
                }
            }
        }

        public String Creacion
        {
            get { return _creacion; }
            set
            {
                if (value != null)
                {
                    _creacion = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Fecha Creación no puede estar Vacío");
                }
            }
        }//hacerlo automatico



        public String Termino
        {
            get { return _termino; }
            set
            {
                if (value != null)
                {
                    _termino = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Fecha Termino no puede estar Vacío");
                }

            }
        }

        public String RutCliente
        {
            get { return _rutCliente; }
            set
            {

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

        public String FechaHoraInicio
        {
            get { return _fechaHoraInicio; }
            set
            {

                if (value != null)
                {
                    _fechaHoraInicio = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Fecha Inicio no puede estar Vacío");
                }
            }
        }

      


        public String FechaHoraTermino
        {
            get { return _fechaHoraTermino; }
            set
            {
                if (value != null)
                {
                    _fechaHoraTermino = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Fecha Termino no puede estar Vacío");
                }

            }
        }


        

        public int Asistentes
        {
            get { return _asistentes; }
            set
            {
                if (value != 0)
                {
                    _asistentes = value;
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

        public double ValorTotalContrato
        {
            get { return _valorTotalContrato; }
            set { _valorTotalContrato = value; }
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

       



      
        //objeto permite manipular todo en la BD
        private OnBreakEntities bdd = new OnBreakEntities();

        public Contrato()
        {

        }


        //MÉTODOS CRUD
        //grabar
        public Boolean Grabar()
        {
            try
            {
                
                BibliotecaDALC.Contrato co = new BibliotecaDALC.Contrato();
                CommonBC.Syncronize(this, co);
                bdd.Contrato.Add(co);
                bdd.SaveChanges();

                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //Buscar
        public bool Buscar()
        {
            try
            {
                BibliotecaDALC.Contrato co =
                    bdd.Contrato.First(con => con.Numero.Equals(Numero));
                //bdd.Cliente.Find(RutCliente);

                CommonBC.Syncronize(this, co);

                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }


        //Eliminar
        public bool Eliminar()
        {
            try
            {
                BibliotecaDALC.Contrato co =
                    bdd.Contrato.Find(Numero);

                bdd.Contrato.Remove(co);
                bdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }



    }

}

