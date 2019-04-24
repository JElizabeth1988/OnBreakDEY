using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClase
{
    public class Evento
    {
        public enum TipoEvento
        {
            Matrimonio, Cumpleaños, Bautizo, Graduacion, Gala, Aniversario, BabyShower
        }

        private int _id;
        public TipoEvento NombreEvento { get; set; }
        //private string _nombreTipoEvento;
        private int _valorBase;
        private int _personalBase;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        //public string NombreTipoEvento
        //{
        //    get { return _nombreTipoEvento; }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            _nombreTipoEvento = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("- Campo Nombre Evento no puede estar Vacío");
        //        }
        //    }
        //} 

        //conectar nombre que se guarde AQUI al combobox de CONTRATO

        //Cálculo valor Contrato

        public int ValorBase
        {
            get { return _valorBase; }
            set
            {
                if (value>=0)
                {
                    _valorBase = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Valor Base debe ser mayor o igual a 0");
                }
            }
        }

        public int PersonalBase
        {
            get { return _personalBase; }
            set
            {
                if (value >= 0)
                {
                    _personalBase = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Personal Base debe ser mayor o igual a 0");
                }
            }
        }



        public Evento(String nombreTipoEvento,int valorBase,int personalBase)
        {
            NombreTipoEvento = nombreTipoEvento;
            ValorBase = valorBase;
            PersonalBase = personalBase;
        }

        public Evento()
        {

        }
       


    }
}
