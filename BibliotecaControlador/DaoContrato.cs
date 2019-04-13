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
        private List<Contrato> contratos;

        public DaoContrato()
        {

            if (contratos == null)
                contratos = new List<Contrato>();
        }

        //metodos crud
        //método guardar
        public bool Agregar(Contrato con)
        {
            if (ExistePersona(con.Numero) == false)
            {
                contratos.Add(con); return true;
            }
            return false;

        }

        private bool ExistePersona(string num)
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

        //método listar
        public List<Contrato> Listar()
        {
            return contratos;
        }


    }

}


