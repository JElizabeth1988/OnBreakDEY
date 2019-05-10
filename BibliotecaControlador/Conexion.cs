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
        //falta data source catalogo usuario y contraseña
        private String _cadena = "Data Source=;Initial Catalog=;Persist Security Info=True;User ID=;Password=";

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
