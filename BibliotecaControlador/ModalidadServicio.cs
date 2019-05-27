using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{
    public class ModalidadServicio
    {
        public string Id { get; set; }
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
                .First(t => t.IdModalidad==Id);
                 Nombre = tipo.Nombre;
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //ReadAll
        public List<ModalidadServicio> ReadAll()
        {
            try
            {
                var c = from mod in bdd.ModalidadServicio
                        join tip in bdd.TipoEvento
                        on mod.IdTipoEvento equals tip.IdTipoEvento
                        select new ModalidadServicio()
                        {
                            Id=mod.IdModalidad,
                            IdtipoEvento = tip.IdTipoEvento,
                            Nombre = mod.Nombre,
                            ValorBase = mod.ValorBase,
                            PersonalBase = mod.PersonalBase,
                        };
                return c.ToList();

            }
            catch (Exception ex)
            {

                return null;
            }
        }

    }

}

  

   

