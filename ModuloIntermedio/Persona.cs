using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ModuloIntermedio
{
    public class Persona
    {
        public String TraePersona(int lgnRut)
        {
            try
            {
                Datos objDatos = new Datos();
                //comPersona.Persona objPersona = new comPersona.Persona();
                return objDatos.TraePersona(lgnRut);
                        

            }catch (Exception ex)
            {
                return ex.ToString();
            }

        }

          public string AutenticaUsuario(string xml)
        {
                //return "<?xml version=\"1.0\" encoding=\"utf-8\" ?><ParametrosOut><Autorizacion cCodigo=\"1\" tMensaje=\"Autorizado\"/><Perfiles><Perfil cPerfil=\"1\" tPetfil=\"Socio\"/><Perfil cPerfil=\"2\" tPetfil=\"Ahorrante\"/></Perfiles> </ParametrosOut>";
                //return xml;
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xml);

                string strPassword = "";
                XmlNodeList lista = xDoc.GetElementsByTagName("ParametrosIn");
                // XmlNodeList lista = ((XmlElement)personas[0]).GetElementsByTagName("Producto");
                foreach (XmlElement nodo in lista)
                {
                    strPassword = nodo.GetAttribute("Password");
                }

                //comEncriptador.Encriptador objEncript = new comEncriptador.Encriptador();
                Encripta objEncript = new Encripta();
                object w = 1;
                //strPassword = objEncript.Encriptador(strPassword, ref w);
               //strPassword = objEncript.Encrit(strPassword);

                xDoc.LoadXml(xml);
                XmlNodeList listaiTrans = xDoc.GetElementsByTagName("ParametrosIn");
                // XmlNodeList lista = ((XmlElement)personas[0]).GetElementsByTagName("Producto");
                foreach (XmlElement nodo in listaiTrans)
                {
                    nodo.SetAttribute("Password", strPassword);
                }
                xml = xDoc.InnerXml;

                // comAutentica.Autentica_Ctr objAuten = new comAutentica.Autentica_Ctr();

                //return objAuten.prueba();
                Datos objDatos = new Datos();
                string strXmlSalidaAutentica = objDatos.AutenticaSocio(xml);

                strXmlSalidaAutentica = "<?xml version=\"1.0\" encoding=\"utf-8\"?><ParametrosOut>" + strXmlSalidaAutentica + "</ParametrosOut>";

               return strXmlSalidaAutentica;
       
        }
        public Boolean ModificaUsuario(string xml)
        {
            try
            {
                //return "<?xml version=\"1.0\" encoding=\"utf-8\" ?><ParametrosOut><Autorizacion cCodigo=\"1\" tMensaje=\"Autorizado\"/><Perfiles><Perfil cPerfil=\"1\" tPetfil=\"Socio\"/><Perfil cPerfil=\"2\" tPetfil=\"Ahorrante\"/></Perfiles> </ParametrosOut>";
                //return xml;
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xml);

                string strPassword = "";
                XmlNodeList lista = xDoc.GetElementsByTagName("usuario");
                // XmlNodeList lista = ((XmlElement)personas[0]).GetElementsByTagName("Producto");
                foreach (XmlElement nodo in lista)
                {
                    strPassword = nodo.GetAttribute("nPassword");

                }

                //comEncriptador.Encriptador objEncript = new comEncriptador.Encriptador();
                Encripta objEncript = new Encripta();
                object w = 1;
          //      strPassword = objEncript.Encrit(strPassword);

                xDoc.LoadXml(xml);
                XmlNodeList listaiTrans = xDoc.GetElementsByTagName("usuario");
                // XmlNodeList lista = ((XmlElement)personas[0]).GetElementsByTagName("Producto");
                foreach (XmlElement nodo in listaiTrans)
                {
                    nodo.SetAttribute("nPassword", strPassword);
                }
                xml = xDoc.InnerXml;

                Datos objDatos = new Datos();
                Boolean res = objDatos.ModificaSocio(xml);
                return res;
            }
            catch (Exception Ex)
            {
                //return Ex.ToString();
                return false;
            }

        }

       
    }
}
