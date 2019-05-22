using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{
    public class TipoEvento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        private OnBreakEntities bdd = new OnBreakEntities();

        public TipoEvento()
        {

        }

        public bool Read()
        {
            try
            {
                BibliotecaDALC.ModalidadServicio mod = bdd.ModalidadServicio.Find(Id);
                CommonBC.Syncronize(mod, this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<TipoEvento> ReadAll()
        {
            try
            {
                List<TipoEvento> lista = new List<TipoEvento>();
                var lista_tipo_bdd = bdd.TipoEvento.ToList();
                foreach (BibliotecaDALC.TipoEvento item in lista_tipo_bdd)
                {
                    TipoEvento tipo = new TipoEvento();
                    tipo.Id = item.IdTipoEvento;
                    tipo.Descripcion = item.Descripcion;
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
