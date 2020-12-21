using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using ModuloIntermedio;

public partial class Impresion_LibretaVistaPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //carga Cabecera
        Formatos objfor = new Formatos();
        //Session["PaginaActivaOrigen"] = objfor.NombrePagina();
        //Session["PaginaActiva"] = "Libreta Vista";
                
        lblTituloPagina.Text = objfor.NombrePaginaFormateada(Session["PaginaActivaOrigen"].ToString());

        lblNombre.Text = Session["NombreCompleto"].ToString();
        lblRut.Text = Session["RutFormateado"].ToString();
        lblSaldo.Text = Session["vSaldoLibretaVista"].ToString(); 
        string strParama = "<Parametros ";
        strParama = strParama + "iCliente=\"" + Session["IdCliente"] + "\" />";
        //strParama = strParama + "iCliente=\"" + "100004" + "\" />";


        Service objserv = new Service();
        string xmlSalida = objserv.ConsultaSaldosSocio(strParama, 3);

        /*fMovimiento,DescEstadoMov,vMonto,vSaldo,tGlosa*/

        Formatos objFormatos = new Formatos();

        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml(xmlSalida);

        string vMonto = "";
        string vSaldo = "";

        XmlNodeList lista2 = xDoc.GetElementsByTagName("MovCtaVista");
        foreach (XmlElement nodo in lista2)
        {
            vMonto = objFormatos.FormateaNumero(nodo.GetAttribute("vMonto"));
            vSaldo = objFormatos.FormateaNumero(nodo.GetAttribute("vSaldo"));
            nodo.SetAttribute("vMonto", vMonto);//CapInsoluto);
            nodo.SetAttribute("vSaldo", vSaldo);
        }

        xmlSalida = xDoc.InnerXml;
        //string xmlSalida = objService.ConsultaSaldosSocio("<Parametros iPersona= \"" + idCliente + "\"/>", 1);


        //xmlSalida = "<CAPITAL>" + strXML_encabezado + xmlSalida + "</CAPITAL>";


        xdsVista.Data = xmlSalida;
        xdsVista.XPath = (string.Format("/CtaVista/MovCtaVista"));
        gvVista.DataSource = xdsVista;
        gvVista.DataBind();




    }
   
}
