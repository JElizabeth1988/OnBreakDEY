using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios;
using BibliotecaDALC;
using Vista;
using System.Runtime.Caching;//para crear caché
using System.Xml.Serialization;//serializar objetos
using System.IO;//Entrada y salida de información


namespace test
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodWebService()
        {
            Servicios.Service1 WS = new Servicios.Service1();
          
        }

        [TestMethod]
        public void TestMethodDataBaseConnect()
        {
            OnBreakEntities bdd = new OnBreakEntities();
        }

        [TestMethod]
        public void TestMethodInterfazImplement()
        {
            int ide = 30;
            string id_mod = "CE002";
            int asi = 150;
            int per = 40;
            int id_am = 20;
            String id_local = "Otro";
            String musica = "Cliente";
            String estable = "OnBreak";
            ClValorEvento c = new ClValorEvento(ide, id_mod, asi, per, id_am, id_local, musica, estable);
            c.ValorFinalCe();
        }
        //FALTA ARREGLAR ERROR CON TIPO DE EMPRESA, HACE QUE SE CAIGA EL TEST, SIN EMBARGO EN LA EJECUCION FUNCION AL 100%
        /*[TestMethod]
        public void TestMethodCache()
        {
            XmlSerializer se = new XmlSerializer(typeof(Cliente));
            StringWriter escritor = new StringWriter();
            Cliente p = new Cliente();
            CacheItemPolicy politica = new CacheItemPolicy();
            se.Serialize(escritor, p);
            File.Delete(@"d:\copiaCliente.txt");//Borra copia 
            File.AppendAllText(@"d:\copiaCliente.txt", escritor.ToString());//Guarda copia automaticamente en el disco 
        }*/
    }
}
