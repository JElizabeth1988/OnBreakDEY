using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;


namespace BibliotecaControlador
{
   
    public class Cliente
    {
        private String _rut;

        public String Rut
        {
            get { return _rut; }
            set
            {
                if (value != null && value.Length>=11 && value.Length<=12)
                {
                    _rut = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Rut no puede estar Vacío");
                }
            }
        }

        private String _razonSocial;

        public String RazonSocial
        {
            get { return _razonSocial; }
            set
            {
                if (value != null)
                {
                    _razonSocial = value;
                }
                else
                {
                    throw new ArgumentException("- Campo RazónSocial no puede estar Vacío");
                }

            }
        }

        private String _nombreContacto;

        public String NombreContacto
        {
            get { return _nombreContacto; }
            set
            {
                if (value != null)
                {
                    _nombreContacto = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Nombre Contrato no puede estar Vacío");
                }

            }
        }

        private String _mailContacto;

        public String Mail
        {
            get { return _mailContacto; }
            set
            {
                if (value != null)
                {
                    _mailContacto = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Email no puede estar Vacío");
                }
            }
        }

        private String _direccion;

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

        private String _telefono;

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                if (value != null)
                {
                    _telefono = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Teléfono no puede estar Vacío y debe tener un largo de 9 dígitos");
                }

            }
        }

        public int IdActividadEmpresa { get; set; }//foraneas
        public int IdTipoEmpresa { get; set; }//foraneas

        //creao un objeto que me permite manipular todo en la BD
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

                cl.RutCliente = Rut;
                cl.RazonSocial = RazonSocial;
                cl.NombreContacto = NombreContacto;
                cl.MailContacto = Mail;
                cl.Direccion = Direccion;
                cl.Telefono = Telefono;
                cl.IdActividadEmpresa = IdActividadEmpresa;
                cl.IdTipoEmpresa = IdTipoEmpresa;
                
                bdd.Cliente.Add(cl);
                bdd.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Eliminar()
        {
            try
            {
                BibliotecaDALC.Cliente cl =
                bdd.Cliente.First(cli => cli.RutCliente.Equals(Rut));

                bdd.Cliente.Remove(cl);
                bdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Buscar()
        {
            try
            {
                BibliotecaDALC.Cliente cl =
                    bdd.Cliente.First(cli => cli.RutCliente.Equals(Rut));

                RazonSocial = cl.RazonSocial;
                NombreContacto = cl.NombreContacto;
                Mail = cl.MailContacto;
                Direccion = cl.Direccion;
                Telefono = cl.Telefono;
                IdActividadEmpresa = cl.IdActividadEmpresa;
                IdTipoEmpresa = cl.IdTipoEmpresa;

                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Read()
        {
            try
            {
                BibliotecaDALC.Cliente cli = bdd.Cliente.Find(Rut);
                CommonBC.Syncronize(cli, this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
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

}