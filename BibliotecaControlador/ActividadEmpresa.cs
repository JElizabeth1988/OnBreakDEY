using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaNegocio
{
    public class ActividadEmpresa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        private OnBreakEntities bdd = new OnBreakEntities();

        public ActividadEmpresa()
        {

        }
        public bool Read()
        {
            try
            {
                BibliotecaDALC.ActividadEmpresa act = bdd.
                    ActividadEmpresa.First(a => a.IdActividadEmpresa==Id);
                Descripcion = act.Descripcion;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ActividadEmpresa> ReadAll()
        {
            try
            {
                List<ActividadEmpresa> lista = new List<ActividadEmpresa>();
                var lista_act_bdd = bdd.ActividadEmpresa.ToList();
                foreach (BibliotecaDALC.ActividadEmpresa item in lista_act_bdd)
                {
                    ActividadEmpresa act = new ActividadEmpresa();
                    act.Id = item.IdActividadEmpresa;
                    act.Descripcion = item.Descripcion;
                    lista.Add(act);
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

