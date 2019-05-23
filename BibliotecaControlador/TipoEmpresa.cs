using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;



namespace BibliotecaNegocio
{
    public class TipoEmpresa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        private OnBreakEntities bdd = new OnBreakEntities();

        public TipoEmpresa()
        {

        }

        public bool Read()
        {
            try
            {
                BibliotecaDALC.TipoEmpresa tipo = bdd.
                    TipoEmpresa.First(t => t.IdTipoEmpresa==Id);
                Descripcion = tipo.Descripcion;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<TipoEmpresa> ReadAll()
        {
            try
            {
                List<TipoEmpresa> lista = new List<TipoEmpresa>();
                var lista_tipo_bdd = bdd.TipoEmpresa.ToList();
                foreach (BibliotecaDALC.TipoEmpresa item in lista_tipo_bdd)
                {
                    TipoEmpresa tipo = new TipoEmpresa();
                    tipo.Id = item.IdTipoEmpresa;
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
