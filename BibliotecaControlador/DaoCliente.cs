using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BibliotecaClase;

namespace BibliotecaControlador
{
    public class DaoCliente
    {
        private static List<Cliente> clientes;

        public DaoCliente()
        {
            if (clientes == null)
            {
                clientes = new List<Cliente>();
            }
        }

        //metodos customer C.R.U.D.
        // Agregar
        public bool Agregar(Cliente cli)
        {
            if (ExisteCliente(cli.Rut) == false)
            {
                clientes.Add(cli); return true;
            }
            return false;
           

        }

        //se creo con la ampolleta para comprobar si existe o no el cliente
        private bool ExisteCliente(string rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(rut))
                {
                    return true;
                }
            }
            return false;
        }

        //Listar
        public List<Cliente> Listar()
        {
            return clientes;
        }

        //Eliminar
       public bool Eliminar( String rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(rut))
                {
                    clientes.Remove(item);
                    return true;
                }
            }
            return false;

         }

        //Buscar
        public Cliente Buscar(string rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(rut))
                {
                    return item;
                }
            }
            return null;
        }

        //Filtrar por rut 
        public List<Cliente> Filtro(string rut)
        {
            List<Cliente> cl = clientes.Where(x => x.Rut == rut).
                ToList();
            return cl;
        }

        //Filtrar por tipo de empresa
        public List<Cliente> Filtro(TipoEmpresa tipo)
        {
            List<Cliente> cl = clientes.Where(x => x.Empresa == tipo).
                ToList();
            return cl;
        }

        //Filtrar por Actividad de la empresa
        public List<Cliente> Filtro(ActividadEmpresa act)
        {
            List<Cliente> cl = clientes.Where(x => x.Actividad == act).
                ToList();
            return cl;
        }

        //Modificar
        public bool Modificar(Cliente nuevoCliente)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(nuevoCliente.Rut))
                {
                    clientes.Remove(item);//remueve el cliente
                    clientes.Add(nuevoCliente);//agrega los nuevos datos
                    return true;
                }
            }
            return false;
        }

        //BUSCAR CLIENTE (CAMILA - CREAR CONTRATO)
        public Cliente BuscarCliente(string rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(rut))
                {
                    return item;
                }
            }
            return null;
        }


    }
}
