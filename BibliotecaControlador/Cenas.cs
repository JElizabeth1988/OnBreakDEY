using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaControlador
{
    public class Cenas
    {
        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private int _idTipoAmbientacion;

        public int IdTipoAmbientacion //foranea
        {
            get { return _idTipoAmbientacion; }
            set { _idTipoAmbientacion = value; }
        }

        private bool _musicaAmbiental;

        public bool MusicaAmbiental
        {
            get { return _musicaAmbiental; }
            set { _musicaAmbiental = value; }
        }

        private bool _localOnBreak;

        public bool LocalOnBreak
        {
            get { return _localOnBreak; }
            set { _localOnBreak = value; }

    }

        private bool _otroLocalOnbreak;

        public bool OtroLocalOnBreak
        {
            get { return _otroLocalOnbreak; }
            set { _otroLocalOnbreak = value; }
        }

        private double _valorArriendo;

        public double ValorArriendo
        {
            get { return _valorArriendo; }
            set { _valorArriendo = value; }
        }


        private OnBreakEntities bdd = new OnBreakEntities();

        public Cenas()
        {

        }

        public bool Read()
        {
            try
            {
                BibliotecaDALC.Cenas cen = bdd.Cenas
                .First(c => c.Numero == Numero);
                IdTipoAmbientacion = cen.IdTipoAmbientacion;
                MusicaAmbiental = cen.MusicaAmbiental;
                LocalOnBreak = cen.LocalOnBreak;
                OtroLocalOnBreak = cen.OtroLocalOnBreak;
                ValorArriendo = cen.ValorArriendo;
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Cenas> ReadAll()
        {
            try
            {
                List<Cenas> lista = new List<Cenas>();
                var lista_cen_bdd = bdd.Cenas.ToList();
                foreach (BibliotecaDALC.Cenas item in lista_cen_bdd)
                {
                    Cenas cen = new Cenas();
                    cen.Numero = item.Numero;
                    cen.IdTipoAmbientacion = cen.IdTipoAmbientacion;
                    cen.MusicaAmbiental= item.MusicaAmbiental;
                    cen.LocalOnBreak = item.LocalOnBreak;
                    cen.OtroLocalOnBreak = item.OtroLocalOnBreak;
                    cen.ValorArriendo = item.ValorArriendo;
                    lista.Add(cen);
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
