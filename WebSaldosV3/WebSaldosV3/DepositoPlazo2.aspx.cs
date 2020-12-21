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

public partial class DepositoPlazo2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //carga Cabecera
            //Session["PaginaActiva"] = objfor.NombrePagina();
            Session["PaginaActiva"] = "Movimientos Deposito a Plazo";

            //lblNombre.Text = Session["NombreCompleto"].ToString();
            //lblRut.Text = Session["RutFormateado"].ToString();
            //LblSaldos.Text = Session["vSaldoCapital"].ToString();

            Session["cargaPag"] = "0";


            string strParam = "<Parametros iCliente=\"" + Session["idCliente"] + "\" >";
            //string strParam = "<Parametros iCliente=\"138687\" >";
            strParam = strParam + "<Estados>";

            strParam = strParam + "<Estado  cEstado=\"8\" />";
            strParam = strParam + "<Estado  cEstado=\"7\" />";
            strParam = strParam + "<Estado  cEstado=\"6\" />";
            strParam = strParam + "<Estado  cEstado=\"5\" />";
            strParam = strParam + "<Estado  cEstado=\"4\" />";
            strParam = strParam + "<Estado  cEstado=\"3\" />";
            strParam = strParam + "<Estado  cEstado=\"2\" />";
            strParam = strParam + "<Estado  cEstado=\"1\" />";
            strParam = strParam + "<Estado  cEstado=\"\" />";
            strParam = strParam + "</Estados>";
            strParam = strParam + "</Parametros>";

            Service objserv = new Service();
            string xmlSalida = objserv.ConsultaSaldosSocio(strParam, 4);

            Formatos objFormatos = new Formatos();

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xmlSalida);
            string vMontorMovimiento = "";
            int indice = 0;

            XmlNodeList lista2 = xDoc.GetElementsByTagName("Deposito");
            foreach (XmlElement nodo in lista2)
            {
                if (nodo.GetAttribute("iSecuencia") == Request.QueryString["iSecuencia"])
                {
                    XmlNodeList lista3 = ((XmlElement)lista2[indice]).GetElementsByTagName("DetalleDep");
                    foreach (XmlElement nodo2 in lista3)
                    {
                        vMontorMovimiento = objFormatos.FormateaNumero(nodo2.GetAttribute("vMontorMovimiento"));
                        nodo2.SetAttribute("vMontorMovimiento", vMontorMovimiento);//CapInsoluto);
                    }
                }
                indice = indice + 1;
            }

            /*InfoParamXML = xDoc.InnerXml;
            string InfoParamXML2 = InfoParamXML;*/

            xmlSalida = xDoc.InnerXml;


            /*  fFechaPago
         vMontorMovimiento
         DescTipoMovimiento
         DescEstadoPago
         iComprobanteCaja*/

            xdsDeposito.Data = xmlSalida;
            xdsDeposito.XPath = (string.Format("/DepositoPlazo/Deposito[@iSecuencia=" + Request.QueryString["iSecuencia"].ToString() + "]/DetalleDep"));
            gvDeposito.DataSource = xdsDeposito;
            gvDeposito.DataBind();


        }
        catch (Exception ex)
        {
            Response.Redirect("Defaultv3.aspx");
        }

    }
}
