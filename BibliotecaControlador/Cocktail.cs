using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{
    public class Cocktail
    {
        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private int _idTipoAmbientacion; //foranea

        public int IdTipoAmbientacion
        {
            get { return _idTipoAmbientacion; }
            set { _idTipoAmbientacion = value; }
        }


        private bool _ambientacion;

        public bool Ambientacion
        {
            get { return _ambientacion; }
            set { _ambientacion = value; }
        }

        private bool _musicaAmbiental;

        public bool MusicaAmbiental
        {
            get { return _musicaAmbiental; }
            set { _musicaAmbiental = value; }
        }

        private bool _musicaCliente;

        public bool MusicaCliente
        {
            get { return _musicaCliente; }
            set { _musicaCliente = value; }
        }

        private OnBreakEntities bdd = new OnBreakEntities();
        public Cocktail()
        {

        }

        public bool Read()
        {
            try
            {
                BibliotecaDALC.Cocktail co = bdd.
                   Cocktail.First(c => c.Numero == Numero);
                IdTipoAmbientacion= co.IdTipoAmbientacion;
                Ambientacion = co.Ambientacion;
                MusicaAmbiental = co.MusicaAmbiental;
                MusicaCliente = co.MusicaCliente;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Cocktail> ReadAll()
        {
            try
            {
                List<Cocktail> lista = new List<Cocktail>();
                var lista_co_bdd = bdd.Cocktail.ToList();
                foreach (BibliotecaDALC.Cocktail item in lista_co_bdd)
                {
                    Cocktail co = new Cocktail();
                    co.Numero = item.Numero;
                    co.IdTipoAmbientacion = item.IdTipoAmbientacion;
                    co.Ambientacion = item.Ambientacion;
                    co.MusicaAmbiental = item.MusicaAmbiental;
                    co.MusicaCliente = item.MusicaCliente;
                    lista.Add(co);
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
