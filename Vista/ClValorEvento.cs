using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaNegocio;
namespace Vista
{
    class ClValorEvento : IValorEvento
    {

        public int IdE;

        public String IdM;

        public int asist;

        public int personal;

        public int IdA;

        public int IdLocal;

        public String musica;

        public String local;

        public ClValorEvento(int ideve, String idmod, int asis, int pers, int idam, String idlocal, String music, String establecimiento)
        {
            IdE = ideve;
            IdM = idmod;
            asist = asis;
            personal = pers;
            IdA = idam;
            musica = music;
            local = establecimiento;
        }

        public Double RecargoAsistentes()
        {
            Double RecAsis = 0;
            try
            {
                if (IdE == 10)
                {
                    if (asist >= 1 && asist <= 20)
                    {
                        RecAsis = 3;
                        return RecAsis;
                    }
                    if (asist >= 21 && asist <= 50)
                    {
                        RecAsis = 5;
                        return RecAsis;
                    }
                    if (asist >= 51)
                    {
                        RecAsis = 5;
                        int Adiconal = ((int)(asist - 50) / 20) * 2;
                        return RecAsis + Adiconal;
                    }
                }
                if (IdE == 20)
                {
                    if (asist >= 1 && asist <= 20)
                    {
                        RecAsis = 4;
                        return RecAsis;
                    }
                    if (asist >= 21 && asist <= 50)
                    {
                        RecAsis = 6;
                        return RecAsis;
                    }
                    if (asist >= 51)
                    {
                        RecAsis = 6;
                        int Adiconal = ((int)((asist - 50) / 20)) * 2;
                        return RecAsis + Adiconal;
                    }
                }
                if (IdE == 30)
                {
                    if (asist >= 1 && asist <= 20)
                    {
                        RecAsis = 1.5;
                        return RecAsis;
                    }
                    if (asist >= 21 && asist <= 50)
                    {
                        RecAsis = 1.2;
                        return RecAsis;
                    }
                    if (asist >= 51)
                    {
                        RecAsis = asist;
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
                if (IdE == 10)
                {
                    if (personal == 2)
                    {
                        RecPers = 2;
                        return RecPers;
                    }
                    if (personal == 3)
                    {
                        RecPers = 3;
                        return RecPers;
                    }
                    if (personal == 4)
                    {
                        RecPers = 3.5;
                        return RecPers;
                    }
                    if (personal >= 5)
                    {
                        RecPers = 3.5;
                        Double Adiconal = ((int)((personal - 50) / 20)) * 0.5;
                        return RecPers + Adiconal;
                    }
                }
                if (IdE == 20)
                {
                    if (personal == 2)
                    {
                        RecPers = 2;
                        return RecPers;
                    }
                    if (personal == 3)
                    {
                        RecPers = 3;
                        return RecPers;
                    }
                    if (personal == 4)
                    {
                        RecPers = 3.5;
                        return RecPers;
                    }
                    if (personal >= 5)
                    {
                        RecPers = 3.5;
                        Double Adiconal = ((int)((personal - 50) / 20)) * 0.5;
                        return RecPers + Adiconal;
                    }
                }
                if (IdE == 30)
                {
                    if (personal == 2)
                    {
                        RecPers = 2;
                        return RecPers;
                    }
                    if (personal == 3)
                    {
                        RecPers = 3;
                        return RecPers;
                    }
                    if (personal == 4)
                    {
                        RecPers = 5;
                        return RecPers;
                    }
                    if (personal >= 5)
                    {
                        RecPers = 5;
                        Double Adiconal = ((int)((personal - 50) / 20)) * 0.5;
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
                if (IdE == 10)
                {
                    if (IdM == "CB001")
                    {
                        ValorBas = 3;
                        return ValorBas;
                    }
                    if (IdM == "CB002")
                    {
                        ValorBas = 8;
                        return ValorBas;
                    }
                    if (IdM == "CB003")
                    {
                        ValorBas = 12;
                        return ValorBas;
                    }
                }
                if (IdE == 20)
                {
                    if (IdM == "CO001")
                    {
                        ValorBas = 6;
                        return ValorBas;
                    }
                    if (IdM == "CO002")
                    {
                        ValorBas = 10;
                        return ValorBas;
                    }
                }
                if (IdE == 30)
                {
                    if (IdM == "CE001")
                    {
                        ValorBas = 25;
                        return ValorBas;
                    }
                    if (IdM == "CE002")
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

        public Double ValorFinalCB()
        {
            Double CbParcial = 0;
            try
            {
                CbParcial = ValorBaseEvento() + RecargoAsistentes() + RecargoPersonal();
                return CbParcial;
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
                if (IdA == 10)
                {

                    ValorAmb = 2;
                    return ValorAmb;
                }
                if (IdA == 20)
                {
                    ValorAmb = 5;
                    return ValorAmb;
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
                if (musica == "Ambiental" || musica == "Cliente")
                {
                    ValMusic = 1;
                    return ValMusic;
                }
                return ValMusic;
            }
            catch (Exception exe)
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

                if (musica == "Ambiental" || musica == "Cliente")
                {
                    ValorMusicCe = 1.5;
                    return ValorMusicCe;
                }

                return ValorMusicCe;
            }
            catch (Exception exe)
            {

                return 0;
            }
        }

        public Double AmbientacionCe()
        {
            Double ValAmbCe = 0;
            try
            {
                if (IdA == 10)
                {

                    ValAmbCe = 2;
                    return ValAmbCe;
                }
                if (IdA == 20)
                {
                    ValAmbCe = 5;
                    return ValAmbCe;
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
                if (local == "OnBreak" && asist <= 50)
                {
                    ValLoca = 9 + (0 * 1.05);
                    return ValLoca;
                }
                if (local == "OnBreak" && asist <= 50)
                {
                    ValLoca = 0 + (0 * 1.05);
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
