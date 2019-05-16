using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace BibliotecaControlador
{
    public class Conexion
    {
        private static SqlConnection cone;
        private String _cadena = "Data Source=.;Initial Catalog=OnBreak;Persist Security Info=True;User ID=sa;Password=Duocadmin2019"";

        public Conexion()
        {
            if (cone == null)
            {
                cone = new SqlConnection(_cadena);
            }
        }

        public SqlConnection GetConexion()
        {
            return cone;
        }
    }
}
