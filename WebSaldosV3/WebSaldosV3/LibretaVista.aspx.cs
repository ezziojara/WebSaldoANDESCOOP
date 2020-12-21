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

public partial class LibretaVista : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["producto"] = "Libreta Vista";
            Session["producto"] = "Cuenta Vista";
            //carga Cabecera
            Formatos objfor = new Formatos();
            Session["PaginaActivaOrigen"] = objfor.NombrePagina();
            Session["PaginaActiva"] = "Cuenta Vista";

            Session["cargaPag"] = "0";

            //lblNombre.Text = Session["NombreCompleto"].ToString();
            //lblRut.Text = Session["RutFormateado"].ToString();
            //lblSaldo.Text = Session["vSaldoLibretaVista"].ToString(); 
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
            string contMov = "";

            XmlNodeList lista1 = xDoc.GetElementsByTagName("CtaVista");
            int saldoVista = 0;
            foreach (XmlElement nodo1 in lista1)
            {
                saldoVista = Int32.Parse(nodo1.GetAttribute("vMontoSaldo"));
            }

            lblSaldo.Text = objFormatos.FormateaNumero(saldoVista.ToString());


            XmlNodeList lista2 = xDoc.GetElementsByTagName("MovCtaVista");
            foreach (XmlElement nodo in lista2)
            {
                vMonto = objFormatos.FormateaNumero(nodo.GetAttribute("vMonto"));
                vSaldo = objFormatos.FormateaNumero(nodo.GetAttribute("vSaldo"));
                contMov = nodo.GetAttribute("vMonto");
                nodo.SetAttribute("vMonto", vMonto);//CapInsoluto);
                nodo.SetAttribute("vSaldo", vSaldo);
            }

            xmlSalida = xDoc.InnerXml;
            //string xmlSalida = objService.ConsultaSaldosSocio("<Parametros iPersona= \"" + idCliente + "\"/>", 1);
            //xmlSalida = "<CAPITAL>" + strXML_encabezado + xmlSalida + "</CAPITAL>";
            //Response.Write (contMov);




            if (saldoVista == 0)
            {
                Session["cargaPag"] = "2";
                lblSinMovimiento.Visible = true;
                lblSinMovimiento.Text = "No tiene saldos para este Producto";
            }
            else
            {
                if (contMov == "")
                {
                    Session["cargaPag"] = "2";
                    lblSinMovimiento.Visible = true;
                    lblSinMovimiento.Text = "No tiene Movimientos en la cuenta";
                    //Response.Write ("<script>alert('el socio no tiene movimientos');</script>");

                }
            }
            xdsVista.Data = xmlSalida;
            xdsVista.XPath = (string.Format("/CtaVista/MovCtaVista"));
            gvVista.DataSource = xdsVista;
            gvVista.DataBind();

        }
        catch (Exception ex)
        {
            Response.Redirect("Defaultv3.aspx");
        }


    }
}
