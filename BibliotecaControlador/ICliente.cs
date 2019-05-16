using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClase;

namespace BibliotecaControlador
{
    interface ICliente//Se Definen Los Métodos
    {
        bool Grabar(Cliente cl);
        bool Eliminar(String rut);
        Cliente Buscar(String rut);
        bool Modificar(Cliente nuevo_cliente);//ingreso nuevo cliente donde su rut se mantiene
        List<Cliente> Lista();
    }
}
