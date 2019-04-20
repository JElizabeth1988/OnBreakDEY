using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClase;

namespace BibliotecaControlador
{
   public class DaoEvento
    {

        private static List<Evento> eventos;


        //PATRON SINGLETON
        public DaoEvento()
        {

            if (eventos == null)
            {
                eventos = new List<Evento>();
            }

        }

        //METODOS CRUD

        //METODO GUARDAR-------------------------
        public bool Agregar(Evento even)
        {
            if (ExisteContrato(even.Id) == false)
            {
                eventos.Add(even); return true;
            }
            return false;

        }

        private bool ExisteContrato(int id)
        {
            foreach (Evento item in eventos)
            {
                if (item.Id.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
