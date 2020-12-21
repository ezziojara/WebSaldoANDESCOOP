using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml;

/// <summary>
/// Descripción breve de Transforma
/// </summary>
public class Transforma
{
    //*******************************************************************
    //Metodo: Transformar
    //Funcionalidad : Transforma Un XML de Entrada en un XSL de salida
    //Entrada : String XML con valores, String Xsl con nombre del archivo Xsl
    //Salida : string con direccion Url del archivo Transformado
    //Creado : 22/12/2010 por cesar reyes
    //Modificado ;
    //*******************************************************************
    public String Transformar(String xml, String xsl)
    {
        XslTransform myXslTransform = new XslTransform();
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml(xml);
        xDoc.Save("/inetpub/wwwroot/SitioWebAndesCoop/XSL/xml1.xml");
        myXslTransform.Load("/inetpub/wwwroot/SitioWebAndesCoop/XSL/" + xsl);
        string xml1 = "/inetpub/wwwroot/SitioWebAndesCoop/XSL/xml1.xml";
        string Salida = "/inetpub/wwwroot/SitioWebAndesCoop/XSL/ISBNBookList.html";
        myXslTransform.Transform(xml1, Salida);
        return "http://172.16.10.101/SitioWebAndesCoop/XSL/ISBNBookList.html";
    }
}
