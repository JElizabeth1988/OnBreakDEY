using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClase;
using System.Data.SqlClient;//cliente sql
using System.Data;

namespace BibliotecaControlador
{
    public class DaoCliente : ICliente

    {
        private SqlConnection _cone;

        public DaoCliente()
        {
            _cone = new Conexion().GetConexion();
        }

        //metodos customer C.R.U.D.
        // Agregar
        public bool Grabar(Cliente cli)
        {
            try
            {
                String sql = "INSERT INTO CLIENTE VALUES(@RUT, @RAZSO, @NOM, @MAI, @DIR, @TEL, @IDAE, @IDTE)";
                SqlCommand cmd = new SqlCommand(sql, _cone);
                cmd.Parameters.Add(new SqlParameter("@RUT", SqlDbType.NVarChar, 10))
                    .Value = cli.Rut;
                cmd.Parameters.Add(new SqlParameter("@RAZSO", SqlDbType.NVarChar, 50))
                    .Value = cli.RazonSocial;
                cmd.Parameters.Add(new SqlParameter("@NOM", SqlDbType.NVarChar, 50))
                    .Value = cli.NombreContacto;
                cmd.Parameters.Add(new SqlParameter("@MAI", SqlDbType.NVarChar, 30))
                    .Value = cli.Mail;
                cmd.Parameters.Add(new SqlParameter("@DIR", SqlDbType.NVarChar, 30))
                    .Value = cli.Direccion;
                cmd.Parameters.Add(new SqlParameter("@TEL", SqlDbType.NVarChar, 15))
                    .Value = cli.Telefono;
                ////Preguntar como guardar foraneas
                cmd.Parameters.Add(new SqlParameter("@IDAE", SqlDbType.Int))
                     .Value = cli.IdActividadEmpresa;
                cmd.Parameters.Add(new SqlParameter("@IDTE", SqlDbType.Int))
                    .Value = cli.IdTipoEmpresa;

                _cone.Open();
                int contador = cmd.ExecuteNonQuery();//istruccion directa que no devuelve filas
                _cone.Close();
                return contador > 0;//si retorna cero es falso si es mayor a cero es true
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        //Listar
        /*public List<Cliente> Listar()
        {
            return ;
        }*/

        //Eliminar
        public bool Eliminar(string rut)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_eliminar";
                cmd.Parameters.Add(new SqlParameter("@rut", SqlDbType.NVarChar, 10)).Value = rut;
                _cone.Open();
                int cant = cmd.ExecuteNonQuery();
                _cone.Close();
                return cant > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        //Buscar
        public Cliente Buscar(string rut)
        {
            try
            {
                String sql = "select * from persona where rut = @rut";
                SqlCommand cmd = new SqlCommand(sql, _cone);
                cmd.Parameters.Add(new SqlParameter("@rut", SqlDbType.NVarChar, 45)).Value = rut;
                _cone.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                Cliente cli = null;
                while (rd.Read())
                {
                    cli = new Cliente();
                    cli.Rut = rd[0].ToString();
                    cli.RazonSocial = rd[1].ToString();
                    cli.NombreContacto = rd[2].ToString();
                    cli.Mail = rd[3].ToString();
                    cli.Direccion = rd[4].ToString();
                    cli.Telefono = rd[5].ToString();
                    cli.IdActividadEmpresa = int.Parse(rd[6].ToString());
                    cli.IdTipoEmpresa = int.Parse(rd[7].ToString());


                }

                _cone.Close();
                return cli;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        //Filtrar por rut 
        public List<Cliente> FiltroRut(string rut)
        {
            List<Cliente> cl = clientes.Where(x => x.Rut == rut).
                ToList();
            return cl;
        }

        //Filtrar por tipo de empresa
        public List<Cliente> FiltroEmp(TipoEmpresa tipo)
        {
            List<Cliente> cl = clientes.Where(x => x.Empresa == tipo).
                ToList();
            return cl;
        }

        //Filtrar por Actividad de la empresa
        public List<Cliente> FiltroAct(ActividadEmpresa act)
        {
            List<Cliente> cl = clientes.Where(x => x.Actividad == act).
                ToList();
            return cl;
        }

        //Modificar
        public bool Modificar(Cliente nuevoCliente)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(nuevoCliente.Rut))
                {
                    clientes.Remove(item);//remueve el cliente
                    clientes.Add(nuevoCliente);//agrega los nuevos datos
                    return true;
                }
            }
            return false;
        }

        //BUSCAR CLIENTE (CAMILA - CREAR CONTRATO)
        public Cliente BuscarCliente(string rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(rut))
                {
                    return item;
                }
            }
            return null;
        }


        public List<Cliente> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
