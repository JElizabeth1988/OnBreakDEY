﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;


namespace BibliotecaNegocio
{
    //cadena de conexión Johana desktop-4l5hcap\sqlexpress
    public class Cliente
    {

        private String _rut;

        public String RutCliente
        {
            get { return _rut; }
            set
            {
                if (value != string.Empty && value.Length>=11 && value.Length<=12)
                {
                    _rut = value;
                }
                else
                {
                    dao.AgregarError("- Campo Rut no puede estar Vacío");
                    //throw new ArgumentException("- Campo Rut no puede estar Vacío");
                }
            }
        }

        private String _razonSocial;

        public String RazonSocial
        {
            get { return _razonSocial; }
            set
            {
                if (value != string.Empty)
                {
                    _razonSocial = value;
                }
                else
                {
                    dao.AgregarError("- Campo RazónSocial no puede estar Vacío");
                    //throw new ArgumentException("- Campo RazónSocial no puede estar Vacío");
                }

            }
        }

        private String _nombreContacto;

        public String NombreContacto
        {
            get { return _nombreContacto; }
            set
            {
                if (value != string.Empty)
                {
                    _nombreContacto = value;
                }
                else
                {
                    dao.AgregarError("- Campo Nombre Contrato no puede estar Vacío");
                    //throw new ArgumentException("- Campo Nombre Contrato no puede estar Vacío");
                }

            }
        }

        private String _mailContacto;

        public String MailContacto
        {
            get { return _mailContacto; }
            set
            {
                if (value != string.Empty)
                {
                    _mailContacto = value;
                }
                else
                {
                    dao.AgregarError("- Campo Email no puede estar Vacío");
                    //throw new ArgumentException("- Campo Email no puede estar Vacío");
                }
            }
        }

        private String _direccion;

        public String Direccion
        {
            get { return _direccion; }
            set
            {
                if (value != string.Empty)
                {
                    _direccion = value;
                }
                else
                {
                    dao.AgregarError("- Campo Dirección no puede estar Vacío");
                    //throw new ArgumentException("- Campo Dirección no puede estar Vacío");
                }
            }
        }

        private String _telefono;

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                if (value != string.Empty && value.Length >=9  && value.Length <= 12)
                {
                    _telefono = value;
                }
                else
                {
                    dao.AgregarError("- Campo Teléfono no puede estar Vacío y debe tener un largo de 9 dígitos");
                    //throw new ArgumentException("- Campo Teléfono no puede estar Vacío y debe tener un largo de 9 dígitos");
                }

            }
        }
        DaoErrores dao = new DaoErrores();
        public DaoErrores retornar() { return dao; }
        public int IdActividadEmpresa { get; set; }//foraneas
        public int IdTipoEmpresa { get; set; }//foraneas

        //creo un objeto que me permite manipular todo en la BD
        private OnBreakEntities bdd = new OnBreakEntities();

        public Cliente()
        {

        }


        //MÉTODOS CRUD
        //grabar
        public Boolean Grabar()
        {
            try
            {
                //creo un modelo de la tabla cliente
                BibliotecaDALC.Cliente cl = new BibliotecaDALC.Cliente();
                CommonBC.Syncronize(this, cl);
                bdd.Cliente.Add(cl);
                bdd.SaveChanges();

                return true;

                
            }
            catch (Exception ex)
            {

                return false;
                Logger.Mensaje(ex.Message);
            }
        }

        public bool Eliminar()
        {
            try
            {
                Contrato cont = new Contrato();
                if (cont.verificarContratos() == false)
                {
                    BibliotecaDALC.Cliente cl =
                    //bdd.Cliente.First(cli => cli.RutCliente.Equals(RutCliente));
                    bdd.Cliente.Find(RutCliente);

               
                    cont.RutCliente = cl.RutCliente;

                
                    bdd.Cliente.Remove(cl);
                    bdd.SaveChanges();


                }
                
                return true;
            }
            catch (Exception ex)
            {

                return false;
                Logger.Mensaje(ex.Message);
            }
        }

        public bool Buscar()
        {
            try
            {
                BibliotecaDALC.Cliente cl =
                bdd.Cliente.First(cli => cli.RutCliente.Equals(RutCliente));
                //bdd.Cliente.Find(RutCliente);
                /*RazonSocial = cl.RazonSocial;
                 NombreContacto = cl.NombreContacto;
                 MailContacto = cl.MailContacto;
                 Direccion = cl.Direccion;
                 Telefono = cl.Telefono;
                 IdActividadEmpresa = cl.IdActividadEmpresa;
                 IdTipoEmpresa = cl.IdTipoEmpresa;*/
                CommonBC.Syncronize(cl,this);//arregló this

                return true;

            }
            catch (Exception ex)
            {

                return false;
                Logger.Mensaje(ex.Message);
            }
        }

        public bool Read()
        {
            try
            {
                BibliotecaDALC.Cliente cli = bdd.Cliente.Find(RutCliente);
                CommonBC.Syncronize(cli, this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                Logger.Mensaje(ex.Message);
            }

        }
        public List<Cliente> ReadAll()
        {
            try
            {
                var c = from cli in bdd.Cliente
                        select new Cliente()
                        {
                            RutCliente = cli.RutCliente,
                            RazonSocial = cli.RazonSocial,
                            MailContacto = cli.MailContacto,
                            Direccion = cli.Direccion,
                            Telefono = cli.Telefono,
                            IdActividadEmpresa = cli.IdActividadEmpresa,
                            IdTipoEmpresa = cli.IdTipoEmpresa
                        };
                          return c.ToList();

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<ListaClientes> ReadAll2()
        {
            try
            {
                var c = from cli in bdd.Cliente
                        join actemp in bdd.ActividadEmpresa
                          on cli.IdActividadEmpresa equals actemp.IdActividadEmpresa
                        join temp in bdd.TipoEmpresa
                          on cli.IdTipoEmpresa equals temp.IdTipoEmpresa
                        select new ListaClientes()
                        {
                            Rut = cli.RutCliente,
                            NombreContacto = cli.NombreContacto,
                            RazonSocial = cli.RazonSocial,
                            MailContacto = cli.MailContacto,
                            Direccion = cli.Direccion,
                            Telefono=cli.Telefono,
                              ActividadEmpresa = actemp.Descripcion,
                              TipoEmpresa = temp.Descripcion
                          };
                return c.ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Modificar
        public bool Modificar()
        {
            try
            {
                //creo un modelo de la tabla cliente
                BibliotecaDALC.Cliente cli = bdd.Cliente.Find(RutCliente);
                CommonBC.Syncronize(this, cli);
                bdd.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //Filtro por Rut
        public List<ListaClientes> FiltroRut(string rut)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            var cl = from cli in bdd.Cliente
                     join temp in bdd.TipoEmpresa
                     on cli.IdTipoEmpresa equals temp.IdTipoEmpresa
                     join acti in bdd.ActividadEmpresa 
                     on cli.IdActividadEmpresa equals acti.IdActividadEmpresa
                     where cli.RutCliente == rut
                     select new ListaClientes()
                     {
                         RazonSocial = cli.RazonSocial,
                         Direccion = cli.Direccion,
                         MailContacto = cli.MailContacto,
                         NombreContacto = cli.NombreContacto,
                         Rut = cli.RutCliente,
                         Telefono = cli.Telefono,
                         ActividadEmpresa = acti.Descripcion,
                         TipoEmpresa = temp.Descripcion
                     };
            
            return cl.ToList();
        }

        //Filtrar por tipo de empresa
        public List<ListaClientes> FiltroEmp(string tip)
        {
            var emp = from cli in bdd.Cliente
                     join temp in bdd.TipoEmpresa
                     on cli.IdTipoEmpresa equals temp.IdTipoEmpresa
                     join acti in bdd.ActividadEmpresa 
                     on cli.IdActividadEmpresa equals acti.IdActividadEmpresa
                     where temp.Descripcion == tip
                     select new ListaClientes()
                     {
                         RazonSocial = cli.RazonSocial,
                         Direccion = cli.Direccion,
                         MailContacto = cli.MailContacto,
                         NombreContacto = cli.NombreContacto,
                         Rut = cli.RutCliente,
                         Telefono = cli.Telefono,
                         ActividadEmpresa = acti.Descripcion,
                         TipoEmpresa = temp.Descripcion
                     };

            return emp.ToList(); 
        }

        //Filtrar por Actividad de la empresa
        public List<ListaClientes> FiltroAct(string act)
        {
            var actividad = from cli in bdd.Cliente
                      join temp in bdd.TipoEmpresa
                      on cli.IdTipoEmpresa equals temp.IdTipoEmpresa
                      join acti in bdd.ActividadEmpresa 
                      on cli.IdActividadEmpresa equals acti.IdActividadEmpresa
                      where acti.Descripcion == act
                      select new ListaClientes()
                      {
                          RazonSocial = cli.RazonSocial,
                          Direccion = cli.Direccion,
                          MailContacto = cli.MailContacto,
                          NombreContacto = cli.NombreContacto,
                          Rut = cli.RutCliente,
                          Telefono = cli.Telefono,
                          ActividadEmpresa = acti.Descripcion,
                          TipoEmpresa = temp.Descripcion
                      };

            return actividad.ToList();
        }

         }
    public class ListaClientes
    {
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string MailContacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TipoEmpresa { get; set; }
        public string ActividadEmpresa { get; set; }

        public ListaClientes()
        {

        }
    }

}