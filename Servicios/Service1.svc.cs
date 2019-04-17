using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public double Uf()
        {
            /////
            ClDatos datos;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://mindicador.cl/api/uf"); //crear peticion
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //recupera la respuesta
            Stream stream = response.GetResponseStream(); //recivo esa respuesta
            StreamReader stream_reader = new StreamReader(stream); //leo esa respuesta
            var json = stream_reader.ReadToEnd(); //hasta el final
            datos = JsonConvert.DeserializeObject<ClDatos>(json); //lo convierto en un objeto JSON



            string uf = "";
            //string fecha = "";
            foreach (Serie item in datos.serie)
            {
                uf = item.valor;
                //fecha = item.fecha;
            }
            uf = uf.Replace('.', ',');
            double valor_uf = double.Parse(uf); //ahora se puede usar para calculo!!!!!!!!!!!!!!!!!!

            return valor_uf;
        }
    }
}
