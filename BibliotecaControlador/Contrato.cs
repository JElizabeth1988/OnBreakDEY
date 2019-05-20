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
        private DateTime _creacion;
        private DateTime _termino;
        private String _rutCliente;
        public int IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        private DateTime _fechaHoraInicio;
        private DateTime _fechaHoraTermino;
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

        public DateTime Creacion
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



        public DateTime Termino
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

        public DateTime FechaHoraInicio
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




        public DateTime FechaHoraTermino
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
        //Modificar
        public Boolean Modificar()
        {
            try
            {

                BibliotecaDALC.Contrato con = bdd.Contrato.Find(Numero);
                CommonBC.Syncronize(this, con);
                bdd.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //TERMINAR CONTRATO
        public Boolean TerminarContrato()
        {
            try
            {

                BibliotecaDALC.Contrato co = new BibliotecaDALC.Contrato();
                CommonBC.Syncronize(this, co);

                bdd.Contrato.Remove(co);
                bdd.Contrato.Add(co);
                bdd.SaveChanges();

                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //READ
        public bool Read()
        {
            try
            {
                BibliotecaDALC.Contrato con= bdd.Contrato.Find(Numero);
                CommonBC.Syncronize(con, this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //ReadAll
        public List<Contrato> ReadAll()
        {
            try
            {
                var c = from con in bdd.Contrato
                        join mod in bdd.ModalidadServicio
                        on con.IdModalidad equals mod.IdModalidad
                        select new Contrato()
                        {
                            Numero = con.Numero,
                            Creacion = con.Creacion,
                            Termino = con.Termino,
                            RutCliente = con.RutCliente,
                            IdModalidad = int.Parse(mod.IdModalidad),
                            IdTipoEvento =con.IdTipoEvento,
                            FechaHoraInicio = con.FechaHoraInicio,
                            FechaHoraTermino = con.FechaHoraTermino,
                            Asistentes = con.Asistentes,
                            PersonalAdicional = con.PersonalAdicional,
                            Realizado = con.Realizado,
                            ValorTotalContrato = con.ValorTotalContrato,
                            Observaciones = Observaciones
                        };
                return c.ToList();

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        
        //READALL2
        public List<ListaContratos> ReadAll2()
        {
            try
            {
                var c = from con in bdd.Contrato
                        join modal in bdd.ModalidadServicio
                          on con.IdModalidad equals modal.IdModalidad
                        join tip in bdd.TipoEvento
                          on con.IdTipoEvento equals tip.IdTipoEvento
                        select new ListaContratos()
                        {
                            Numero = con.Numero,
                            Creacion = con.Creacion.ToString(),
                            Termino = con.Termino.ToString(),
                            RutCliente = con.RutCliente,
                            Modalidad =modal.Nombre,
                            TipoEvento= tip.Descripcion,
                            FechaHoraInicio = con.FechaHoraInicio.ToString(),
                            FechaHoraTermino = con.FechaHoraTermino.ToString(),
                            Asistentes = con.Asistentes.ToString(),
                            PersonalAdicional = con.PersonalAdicional.ToString(),
                            Realizado = con.Realizado.ToString(),//?
                            ValorTotalContrato = con.ValorTotalContrato.ToString(),//?
                            Observaciones = Observaciones
                              
                        };
                return c.ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

      

        public class ListaContratos
        {
            public string Numero { get; set; }
            public string Creacion { get; set; }
            public string Termino { get; set; }
            public string RutCliente { get; set; }
            public string Modalidad { get; set; }
            public string TipoEvento{ get; set; }
            public string FechaHoraInicio { get; set; }
            public string FechaHoraTermino { get; set; }
            public string Asistentes { get; set; }
            public string PersonalAdicional { get; set; }
            public string Realizado { get; set; }
            public string ValorTotalContrato { get; set; }
            public string Observaciones { get; set; }

            public ListaContratos()
            {

            }
        }


    }

}

