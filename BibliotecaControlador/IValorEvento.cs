using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaNegocio
{
    interface IValorEvento
    {
        Double ValorBaseEvento();
        Double RecargoAsistentes();
        Double RecargoPersonal();
        Double MusicaCo();
        Double AmbientacionCo();
        Double ValorFinalCo();
        Double MusicaCe();
        Double AmbientacionCe();
        Double Local();
        Double ValorFinalCe();
    }
}
