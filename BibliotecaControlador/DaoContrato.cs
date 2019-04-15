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

        //PATRON SINGLETON
        public DaoContrato()
        {

            if (contratos == null)
            {
                contratos = new List<Contrato>();
            }
               
        }

        //METODOS CRUD

        //METODO GUARDAR
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

        //METODO LISTAR
        public List<Contrato> Listar()
        {
            return contratos;
        }


    }

}


