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

public partial class Impresion_CapitalPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //carga Cabecera
       // Session["PaginaActivaOrigen"] = objfor.NombrePagina();
       // Session["PaginaActiva"] = "Capital Social";
        Formatos objfor = new Formatos();
        lblTituloPagina.Text = objfor.NombrePaginaFormateada(Session["PaginaActivaOrigen"].ToString());
        lblNombre.Text = Session["NombreCompleto"].ToString();
        lblRut.Text = Session["RutFormateado"].ToString();
        //LblSaldos.Text = Session["vSaldoCapital"].ToString(); 

        string vMonto = "";
        string vSaldo = "";
        Service objService = new Service();
        Formatos objFormatos = new Formatos();
        string xmlSalida = objService.ConsultaSaldosSocio("<Parametros iPersona= \"" + Session["IdCliente"].ToString() + "\"/>", 1);

        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml(xmlSalida);

        XmlNodeList lista2 = xDoc.GetElementsByTagName("Capital");

        foreach (XmlElement nodo in lista2)
        {
            vMonto = objFormatos.FormateaNumero(nodo.GetAttribute("vMonto"));
            vSaldo = objFormatos.FormateaNumero(nodo.GetAttribute("vSaldo"));

            nodo.SetAttribute("vMonto", vMonto);//CapInsoluto);
            nodo.SetAttribute("vSaldo", vSaldo);

        }

        lista2 = xDoc.GetElementsByTagName("Saldos");
        int vsaldocapitaltotal = 0;
        foreach (XmlElement nodo in lista2)
        {
            vsaldocapitaltotal = Int32.Parse(nodo.GetAttribute("vTotal"));

        }


        LblSaldos.Text = objFormatos.FormateaNumero(vsaldocapitaltotal.ToString());

        xmlSalida = xDoc.InnerXml;
        //string xmlSalida = objService.ConsultaSaldosSocio("<Parametros iPersona= \"" + idCliente + "\"/>", 1);


        //xmlSalida = "<CAPITAL>" + strXML_encabezado + xmlSalida + "</CAPITAL>";
        String isbn = "gvColocaciones.DataKeys[GVListarXml.SelectedIndex].Value";

        XmlDSCapital.Data = xmlSalida;
        XmlDSCapital.XPath = (string.Format("/Saldos/Movimientos/Capital", isbn));
        gvCapitalSocial.DataSource = XmlDSCapital;
        gvCapitalSocial.DataBind();

        //Response.Redirect("http://localhost/SitioWebAndesCoop/" + Session["PaginaActivaOrigen"].ToString());
       
    }
}
