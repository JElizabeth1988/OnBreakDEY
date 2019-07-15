﻿using System;
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
        public string IdModalidad { get; set; }
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

                if (value != string.Empty)// cambio a string.Empty, porque es más estable que null o que ""
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

                if (value != string.Empty)
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
                if (value >= 0)
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
                if (value >= 0)
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
                if (value != string.Empty)
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
               

                CommonBC.Syncronize(co, this);

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

        /*TERMINAR CONTRATO
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
        */

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
                            IdModalidad = mod.IdModalidad,
                            IdTipoEvento =con.IdTipoEvento,
                            FechaHoraInicio = con.FechaHoraInicio,
                            FechaHoraTermino = con.FechaHoraTermino,
                            Asistentes = con.Asistentes,
                            PersonalAdicional = con.PersonalAdicional,
                            Realizado = con.Realizado,
                            ValorTotalContrato = con.ValorTotalContrato,
                            Observaciones = con.Observaciones
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
                        join cli in bdd.Cliente
                            on con.RutCliente equals cli.RutCliente
                        select new ListaContratos()
                        {
                            
                            Numero = con.Numero,
                            Creacion = con.Creacion,
                            Termino = con.Termino,
                            RutCliente = con.RutCliente,
                            Modalidad =modal.Nombre,
                            TipoEvento= tip.Descripcion,
                            FechaHoraInicio = con.FechaHoraInicio,
                            FechaHoraTermino = con.FechaHoraTermino,
                            Asistentes = con.Asistentes,
                            PersonalAdicional = con.PersonalAdicional,
                            Realizado = con.Realizado,//?
                            ValorTotalContrato = con.ValorTotalContrato,//?
                            Observaciones = con.Observaciones

                        };
                return c.ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// /////////////////////////////////////////////////////////////////////////
        /// FILTROS
       //Filtro por número
        public List<ListaContratos> FiltroNumeroContrato(string num)
        {
            var co = from con in bdd.Contrato
                     join modal in bdd.ModalidadServicio
                       on con.IdModalidad equals modal.IdModalidad
                     join tip in bdd.TipoEvento
                       on con.IdTipoEvento equals tip.IdTipoEvento
                     where con.Numero == num
                     select new ListaContratos()
                     {
                         Numero = con.Numero,
                         Creacion = con.Creacion,
                         Termino = con.Termino,
                         RutCliente = con.RutCliente,
                         Modalidad = modal.Nombre,
                         TipoEvento = tip.Descripcion,
                         FechaHoraInicio = con.FechaHoraInicio,
                         FechaHoraTermino = con.FechaHoraTermino,
                         Asistentes = con.Asistentes,
                         PersonalAdicional = con.PersonalAdicional,
                         Realizado = con.Realizado,//?
                         ValorTotalContrato = con.ValorTotalContrato,//?
                         Observaciones = con.Observaciones

                     };

            return co.ToList();
        }


        //Filtro por Rut Cliente
        public List<ListaContratos> FiltroRut(string rut)
        {
            var co = from con in bdd.Contrato
                     join temp in bdd.Cliente
                     on con.RutCliente equals temp.RutCliente
                     join mod in bdd.ModalidadServicio 
                     on con.IdModalidad equals mod.IdModalidad
                     join tip in bdd.TipoEvento
                     on con.IdTipoEvento equals tip.IdTipoEvento
                     where con.RutCliente == rut
                     select new ListaContratos()
                     {
                         Numero = con.Numero,
                         Creacion = con.Creacion,
                         Termino = con.Termino,
                         RutCliente = con.RutCliente,
                         Modalidad = mod.Nombre,
                         TipoEvento = tip.Descripcion,
                         FechaHoraInicio = con.FechaHoraInicio,
                         FechaHoraTermino = con.FechaHoraTermino,
                         Asistentes = con.Asistentes,
                         PersonalAdicional = con.PersonalAdicional,
                         Realizado = con.Realizado,//?
                         ValorTotalContrato = con.ValorTotalContrato,//?
                         Observaciones = con.Observaciones

                     };

            return co.ToList();
        }

        //Filtro tipo evento
        public List<ListaContratos> FiltroTipoEvento(string tipo)
        {
            var co = from con in bdd.Contrato
                     join modal in bdd.ModalidadServicio
                       on con.IdModalidad equals modal.IdModalidad
                     join tip in bdd.TipoEvento
                       on con.IdTipoEvento equals tip.IdTipoEvento
                     where tip.Descripcion == tipo
                     select new ListaContratos()
                     {
                         Numero = con.Numero,
                         Creacion = con.Creacion,
                         Termino = con.Termino,
                         RutCliente = con.RutCliente,
                         Modalidad = modal.Nombre,
                         TipoEvento = tip.Descripcion,
                         FechaHoraInicio = con.FechaHoraInicio,
                         FechaHoraTermino = con.FechaHoraTermino,
                         Asistentes = con.Asistentes,
                         PersonalAdicional = con.PersonalAdicional,
                         Realizado = con.Realizado,//?
                         ValorTotalContrato = con.ValorTotalContrato,//?
                         Observaciones = con.Observaciones

                     };

            return co.ToList();
        }

        //FILTRO MODALIDAD
        public List<ListaContratos> FiltroModalidad(string mod)
        {
            var co = from con in bdd.Contrato
                     join modal in bdd.ModalidadServicio
                       on con.IdModalidad equals modal.IdModalidad
                     join tip in bdd.TipoEvento
                       on con.IdTipoEvento equals tip.IdTipoEvento
                     where modal.Nombre == mod
                     select new ListaContratos()
                     {
                         Numero = con.Numero,
                         Creacion = con.Creacion,
                         Termino = con.Termino,
                         RutCliente = con.RutCliente,
                         Modalidad = modal.Nombre,
                         TipoEvento = tip.Descripcion,
                         FechaHoraInicio = con.FechaHoraInicio,
                         FechaHoraTermino = con.FechaHoraTermino,
                         Asistentes = con.Asistentes,
                         PersonalAdicional = con.PersonalAdicional,
                         Realizado = con.Realizado,//?
                         ValorTotalContrato = con.ValorTotalContrato,//?
                         Observaciones = con.Observaciones

                     };

            return co.ToList();
        }

        ///////////////////////////////////////////////////////////////////////////////


        public bool verificarContratos()
        {
            try
            {
                BibliotecaDALC.Contrato cc = bdd.Contrato.First(c => c.RutCliente.Equals(RutCliente));
                return true;

            }
            catch (Exception ex) 
            {

                return false;
            }
        }

    }
    public class ListaContratos
    {
        public string Numero { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        public string RutCliente { get; set; }
        public string Modalidad { get; set; }
        public String TipoEvento { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        public string Observaciones { get; set; }

        public ListaContratos()
        {

        }
    }

}

