using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{
    public class TipoAmbientacion
    {
        private int _idTipoAmbientacion;

        public int IdTipoAmbientacion
        {
            get { return _idTipoAmbientacion; }
            set { _idTipoAmbientacion = value; }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private OnBreakEntities bdd = new OnBreakEntities();

        public TipoAmbientacion()
        {

        }

        public bool Read()
        {
            try
            {
                BibliotecaDALC.TipoAmbientacion tipo = bdd.
                    TipoAmbientacion.First(t => t.IdTipoAmbientacion == IdTipoAmbientacion);
                Descripcion = tipo.Descripcion;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<TipoAmbientacion> ReadAll()
        {
            try
            {
                List<TipoAmbientacion> lista = new List<TipoAmbientacion>();
                var lista_tipo_bdd = bdd.TipoAmbientacion.ToList();
                foreach (BibliotecaDALC.TipoAmbientacion item in lista_tipo_bdd)
                {
                    TipoAmbientacion tipo = new TipoAmbientacion();
                    tipo.IdTipoAmbientacion = item.IdTipoAmbientacion;
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
