using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaNegocio
{
    public class ClValorEvento : IValorEvento
    {
        private Contrato ContratoTemp;

        private Cenas CenaTemp;

        private Cocktail CocktailTemp;

        public ClValorEvento(Contrato c, Cenas ce, Cocktail co)
        {
            ContratoTemp = c;
            CenaTemp = ce;
            CocktailTemp = co;
        }

        public Double RecargoAsistentes()
        {
            Double RecAsis = 0;
            try
            {
                if (ContratoTemp.IdTipoEvento == 10)
                {
                    if (ContratoTemp.Asistentes >= 1 && ContratoTemp.Asistentes <= 20)
                    {
                        RecAsis = 3;
                        return RecAsis;
                    }
                    if (ContratoTemp.Asistentes >= 21 && ContratoTemp.Asistentes <= 50)
                    {
                        RecAsis = 5;
                        return RecAsis;
                    }
                    if (ContratoTemp.Asistentes >= 51)
                    {
                        RecAsis = 5;
                        int Adiconal = ((int)((ContratoTemp.Asistentes - 50) / 20)) * 2;
                        return RecAsis + Adiconal;
                    }
                }
                if (ContratoTemp.IdTipoEvento == 20)
                {
                    if (ContratoTemp.Asistentes >= 1 && ContratoTemp.Asistentes <= 20)
                    {
                        RecAsis = 4;
                        return RecAsis;
                    }
                    if (ContratoTemp.Asistentes >= 21 && ContratoTemp.Asistentes <= 50)
                    {
                        RecAsis = 6;
                        return RecAsis;
                    }
                    if (ContratoTemp.Asistentes >= 51)
                    {
                        RecAsis = 6;
                        int Adiconal = ((int)((ContratoTemp.Asistentes - 50) / 20)) * 2;
                        return RecAsis + Adiconal;
                    }
                }
                if (ContratoTemp.IdTipoEvento == 30)
                {
                    if (ContratoTemp.Asistentes >= 1 && ContratoTemp.Asistentes <= 20)
                    {
                        RecAsis = 1.5;
                        return RecAsis;
                    }
                    if (ContratoTemp.Asistentes >= 21 && ContratoTemp.Asistentes <= 50)
                    {
                        RecAsis = 1.2;
                        return RecAsis;
                    }
                    if (ContratoTemp.Asistentes >= 51)
                    {
                        RecAsis = ContratoTemp.Asistentes;
                        return RecAsis;
                    }
                }
                return RecAsis;
            }
            catch (Exception exe)
            {

                return 0;
            }
        }

        public Double RecargoPersonal()
        {
            Double RecPers = 0;
            try
            {
                if (ContratoTemp.IdTipoEvento == 10)
                {
                    if (ContratoTemp.PersonalAdicional == 2)
                    {
                        RecPers = 2;
                        return RecPers;
                    }
                    if (ContratoTemp.PersonalAdicional == 3)
                    {
                        RecPers = 3;
                        return RecPers;
                    }
                    if (ContratoTemp.PersonalAdicional == 4)
                    {
                        RecPers = 3.5;
                        return RecPers;
                    }
                    if (ContratoTemp.Asistentes >= 5)
                    {
                        RecPers = 3.5;
                        Double Adiconal = ((int)((ContratoTemp.Asistentes - 50) / 20)) * 0.5;
                        return RecPers + Adiconal;
                    }
                }
                if (ContratoTemp.IdTipoEvento == 20)
                {
                    if (ContratoTemp.PersonalAdicional == 2)
                    {
                        RecPers = 2;
                        return RecPers;
                    }
                    if (ContratoTemp.PersonalAdicional == 3)
                    {
                        RecPers = 3;
                        return RecPers;
                    }
                    if (ContratoTemp.PersonalAdicional == 4)
                    {
                        RecPers = 3.5;
                        return RecPers;
                    }
                    if (ContratoTemp.Asistentes >= 5)
                    {
                        RecPers = 3.5;
                        Double Adiconal = ((int)((ContratoTemp.Asistentes - 50) / 20)) * 0.5;
                        return RecPers + Adiconal;
                    }
                }
                if (ContratoTemp.IdTipoEvento == 30)
                {
                    if (ContratoTemp.PersonalAdicional == 2)
                    {
                        RecPers = 2;
                        return RecPers;
                    }
                    if (ContratoTemp.PersonalAdicional == 3)
                    {
                        RecPers = 3;
                        return RecPers;
                    }
                    if (ContratoTemp.PersonalAdicional == 4)
                    {
                        RecPers = 5;
                        return RecPers;
                    }
                    if (ContratoTemp.Asistentes >= 5)
                    {
                        RecPers = 5;
                        Double Adiconal = ((int)((ContratoTemp.Asistentes - 50) / 20)) * 0.5;
                        return RecPers + Adiconal;
                    }
                }
                return RecPers;
            }
            catch (Exception exe)
            {

                return 0;
            }
        }

        public Double ValorBaseEvento()
        {
            Double ValorBas = 0;
            try
            {
                if (ContratoTemp.IdTipoEvento == 10)
                {
                    if (ContratoTemp.IdModalidad == "CB001")
                    {
                        ValorBas = 3;
                        return ValorBas;
                    }
                    if (ContratoTemp.IdModalidad == "CB002")
                    {
                        ValorBas = 8;
                        return ValorBas;
                    }
                    if (ContratoTemp.IdModalidad == "CB003")
                    {
                        ValorBas = 12;
                        return ValorBas;
                    }
                }
                if (ContratoTemp.IdTipoEvento == 20)
                {
                    if (ContratoTemp.IdModalidad == "CO001")
                    {
                        ValorBas = 6;
                        return ValorBas;
                    }
                    if (ContratoTemp.IdModalidad == "CO002")
                    {
                        ValorBas = 10;
                        return ValorBas;
                    }
                }
                if (ContratoTemp.IdTipoEvento == 30)
                {
                    if (ContratoTemp.IdModalidad == "CE001")
                    {
                        ValorBas = 25;
                        return ValorBas;
                    }
                    if (ContratoTemp.IdModalidad == "CE002")
                    {
                        ValorBas = 35;
                        return ValorBas;
                    }
                }
                return ValorBas;
            }
            catch (Exception exe)
            {

                return 0;
            }
        }

        public Double AmbientacionCo()
        {
            Double ValorAmb = 0;
            try
            {
                if (CocktailTemp.Ambientacion != false)
                {
                    if (CocktailTemp.IdTipoAmbientacion == 10)
                    {
                        ValorAmb = 2;
                        return ValorAmb;
                    }
                    if (CocktailTemp.IdTipoAmbientacion == 20)
                    {
                        ValorAmb = 5;
                        return ValorAmb;
                    }
                }
                return ValorAmb;
            }
            catch (Exception exe)
            {

                return 0;
            }
        }

        public Double MusicaCo()
        {
            Double ValMusic = 0;
            try
            {
                if (CocktailTemp.MusicaAmbiental != false)
                {
                    ValMusic = 1;
                    return ValMusic;
                }
                return ValMusic;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public Double ValorFinalCo()
        {
            Double Final = 0;
            try
            {
                Final
                    = RecargoPersonal() + ValorBaseEvento()
                    + RecargoAsistentes() + AmbientacionCo()
                    + MusicaCo();
                return Final;
            }
            catch (Exception)
            {

                return Final;
            }
        }

        public Double MusicaCe()
        {
            Double ValorMusicCe = 0;
            try
            {

                if (CenaTemp.MusicaAmbiental != false)
                {
                    ValorMusicCe = 1.5;
                    return ValorMusicCe;
                }

                return ValorMusicCe;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public Double AmbientacionCe()
        {
            Double ValAmbCe = 0;
            try
            {
                if (CenaTemp.MusicaAmbiental != false)
                {
                    if (CenaTemp.IdTipoAmbientacion == 10)
                    {
                        ValAmbCe = 3;
                        return ValAmbCe;
                    }
                    if (CenaTemp.IdTipoAmbientacion == 20)
                    {
                        ValAmbCe = 5;
                        return ValAmbCe;
                    }
                }
                return ValAmbCe;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public Double Local()
        {
            Double ValLoca = 0;
            try
            {
                if (CenaTemp.LocalOnBreak != false && CenaTemp.OtroLocalOnBreak != true && ContratoTemp.Asistentes <= 50)
                {
                    ValLoca = 9 + (CenaTemp.ValorArriendo * 1.05);
                    return ValLoca;
                }
                if (CenaTemp.LocalOnBreak != true && CenaTemp.OtroLocalOnBreak != false && ContratoTemp.Asistentes > 50)
                {
                    ValLoca = 0 + (CenaTemp.ValorArriendo * 1.05);
                    return ValLoca;
                }
                return ValLoca;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public Double ValorFinalCe()
        {
            Double ValorParcialCe
                = RecargoAsistentes() + RecargoPersonal()
                + ValorBaseEvento() + AmbientacionCe()
                + MusicaCe() + Local();
            return ValorParcialCe;
        }
    }
}