using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{
    public class CofeeBreak
    {
        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }


        private bool _vegetariana;

        public bool Vegetariana
        {
            get { return _vegetariana; }
            set { _vegetariana = value; }
        }

        private OnBreakEntities bdd = new OnBreakEntities();
        public CofeeBreak()
        {
                
        }

        public bool Read()
        {
            try
            {
                BibliotecaDALC.CoffeeBreak co = bdd.
                    CoffeeBreak.First(c => c.Numero == Numero);
                Vegetariana = co.Vegetariana;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<CoffeeBreak> ReadAll()
        {
            try
            {
                List<CoffeeBreak> lista = new List<CoffeeBreak>();
                var lista_co_bdd = bdd.CoffeeBreak.ToList();
                foreach (BibliotecaDALC.CoffeeBreak item in lista_co_bdd)
                {
                    CoffeeBreak co = new CoffeeBreak();
                    co.Numero = item.Numero;
                    co.Vegetariana = item.Vegetariana;
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
