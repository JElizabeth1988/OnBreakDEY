using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BibliotecaClase;


namespace BibliotecaControlador
{
    public class DaoContrato
    {
        private static List<Contrato> contratos;
        private static List<Cliente> clientes;
       

        //PATRON SINGLETON
        public DaoContrato()
        {

            if (contratos == null)
            {
                contratos = new List<Contrato>();
            }

        }

        //METODOS CRUD

        //METODO GUARDAR-------------------------
        public bool Agregar(Contrato con)
        {
            if (ExisteContrato(con.Numero) == false)
            {
                contratos.Add(con); return true;
            }
            return false;

        }

        private bool ExisteContrato(string num)
        {
            foreach (Contrato item in contratos)
            {
                if (item.Numero.Equals(num))
                {
                    return true;
                }
            }
            return false;
        }

        //METODO LISTAR--------------------------
        public List<Contrato> Listar()
        {
            return contratos;
        }

        //BUSCAR----------------------------------
        public Contrato BuscarContrato(string numero)
        {
            foreach (Contrato item in contratos)
            {
                if (item.Numero.Equals(numero))
                {
                    return item;
                }
            }
            return null;
        }

        //FILTRO---------------------------------

        //POR NUMERO
        public List<Contrato> FiltroNum(String numero)
        {
            List<Contrato> lco = contratos.Where(x=> x.Numero == numero).ToList();
            return lco;
        }

        //POR RUT
        public List<Cliente> FiltroRut(String rut)
        {
            List<Cliente> lcl = clientes.Where(x => x.Rut == rut).ToList();
            return lcl;
        }

        //POR TIPO CONTRATO
        public List<Contrato> FiltroCon(TipoEvento evento)
        {
            List<Contrato> lcon = contratos.Where(x => x.Evento == evento).ToList();
            return lcon;
        }


        //MODIFICAR
        public bool Modificar(Contrato nuevo_con)
        {
            foreach (Contrato item in contratos)
            {
                if (item.Numero.Equals(nuevo_con.Numero))
                {
                    contratos.Remove(item);
                    contratos.Add(nuevo_con);
                    return true;
                }
            }
            return false;
        }
    }




}


