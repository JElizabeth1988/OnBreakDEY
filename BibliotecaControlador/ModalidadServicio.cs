using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaControlador
{
    public class ModalidadServicio
    {
        public int Id { get; set; }
        public int IdtipoEvento { get; set; }//foranea

        public string Nombre { get; set; }

        public double ValorBase { get; set; }

        public int PersonalBase{ get; set; }

        private OnBreakEntities bdd = new OnBreakEntities();

        public bool Read()
        {
            try
            {
                BibliotecaDALC.ModalidadServicio tipo = bdd.ModalidadServicio
                .First(t => t.Nombre.Equals(Nombre));
                Id = tipo.IdModalidad;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ModalidadServicio> ReadAll()
        {
            try
            {
                List<ModalidadServicio> lista = new List<ModalidadServicio>();
                var lista_tipo_bdd = bdd.ModalidadServicio.ToList();
                foreach (BibliotecaDALC.ModalidadServicio item in lista_tipo_bdd)
                {
                    ModalidadServicio tipo = new ModalidadServicio();
                    tipo.Id = item.IdModalidad;
                    tipo.Nombre = item.Nombre;
                    lista.Add(tipo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }

}

  

   
}
