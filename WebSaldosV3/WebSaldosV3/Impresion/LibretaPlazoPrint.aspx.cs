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

public partial class Impresion_LibretaPlazoPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            //carga Cabecera
            //Formatos objfor = new Formatos();
            //Session["PaginaActivaOrigen"] = objfor.NombrePagina();
            //Session["PaginaActiva"] = "Libreta a Plazo";
            Formatos objfor = new Formatos();
            lblTituloPagina.Text = objfor.NombrePaginaFormateada(Session["PaginaActivaOrigen"].ToString());

            lblNombre.Text = Session["NombreCompleto"].ToString();
            lblRut.Text = Session["RutFormateado"].ToString();
            //LblSaldos.Text = Session["vSaldoLibretaPlazo"].ToString(); 

            string strParamp = "<Parametros>";
            strParamp = strParamp + "<iPersona>" + Session["IdCliente"].ToString() + "</iPersona>";
            //strParamp = strParamp + "<iPersona>" + "105300" + "</iPersona>";
            strParamp = strParamp + "<cTablaEstado>" + 11 + "</cTablaEstado>";
            strParamp = strParamp + "<cEstado>" + 1 + "</cEstado>";
            strParamp = strParamp + "<cEstado2>2</cEstado2>";
            strParamp = strParamp + "</Parametros>";
            Service objserv = new Service();
            string xmlSalida = objserv.ConsultaSaldosSocio(strParamp, 2);

            Formatos objFormatos = new Formatos();

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xmlSalida);

            string vSaldoLibreta = "";
            XmlNodeList lista2 = xDoc.GetElementsByTagName("Libreta");
            foreach (XmlElement nodo in lista2)
            {
                vSaldoLibreta = objFormatos.FormateaNumero(nodo.GetAttribute("vSaldoLibreta"));
                nodo.SetAttribute("vSaldoLibreta", vSaldoLibreta);//CapInsoluto);

            }

            LblSaldos.Text = vSaldoLibreta;
            xmlSalida = xDoc.InnerXml;

            /*iCuenta
        NombreProducto
        fApertura
        DescEstadoCuenta
        vSaldoLibreta*/

            xdsLibreta.Data = xmlSalida;
            xdsLibreta.XPath = (string.Format("/Libretas/Libreta"));
            gvListaLibreta.DataSource = xdsLibreta;
            gvListaLibreta.DataBind();

        }
    }
}
