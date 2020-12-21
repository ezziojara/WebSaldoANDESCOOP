using System;
using System.Collections.Generic;
using System.Text;

namespace ModuloIntermedio
{
    public class Perfiles
    {
        public String TraePerfilesInter()
        {


            Datos objDatos = new Datos();
            string xml = "<Producto Referencia=\"51\" op=\"1\"/>";
            String xmlPerfiles = objDatos.TraePerfiles(xml);
            xmlPerfiles = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + "<Perfiles>" + xmlPerfiles + "</Perfiles>";
            return xmlPerfiles;

            //return objReferencia.Prueba(xml);
            
            
        }
    }
}
