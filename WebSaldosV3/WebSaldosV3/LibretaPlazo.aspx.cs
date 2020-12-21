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

public partial class LibretaPlazo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            Session["producto"] = "Libreta Plazo";
            //carga Cabecera
            Formatos objfor = new Formatos();
            Session["PaginaActivaOrigen"] = objfor.NombrePagina();
            Session["PaginaActiva"] = "Libreta a Plazo";

            Session["cargaPag"] = "0";

            //lblNombre.Text = Session["NombreCompleto"].ToString();
            //lblRut.Text = Session["RutFormateado"].ToString();
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

            int vSaldoLibreta = 0;
            XmlNodeList lista2 = xDoc.GetElementsByTagName("Libreta");
            foreach (XmlElement nodo in lista2)
            {
                vSaldoLibreta = vSaldoLibreta + Int32.Parse(nodo.GetAttribute("vSaldoLibreta"));
                //vSaldoLibreta = objFormatos.FormateaNumero(nodo.GetAttribute("vSaldoLibreta"));
                nodo.SetAttribute("vSaldoLibreta", objFormatos.FormateaNumero(nodo.GetAttribute("vSaldoLibreta")));//CapInsoluto);

            }

            LblSaldos.Text = objFormatos.FormateaNumero(vSaldoLibreta.ToString());
            xmlSalida = xDoc.InnerXml;

            if (vSaldoLibreta == 0)
            {
                Session["cargaPag"] = "2";
                lblError.Visible = true;
                lblError.Text = "No tiene saldos para este Producto";
            }

            /*iCuenta
        NombreProducto
        fApertura
        DescEstadoCuenta
        vSaldoLibreta*/

            xdsLibreta.Data = xmlSalida;
            xdsLibreta.XPath = (string.Format("/Libretas/Libreta"));
            gvListaLibreta.DataSource = xdsLibreta;
            gvListaLibreta.DataBind();

            xdsLibreta = null;

        }
        catch (Exception ex)
        {
            Response.Redirect("Defaultv3.aspx");
        }
    }
}
