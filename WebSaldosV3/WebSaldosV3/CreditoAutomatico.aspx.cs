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

public partial class CreditoAutomatico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["producto"] = "Crédito Automatico";
            //carga Cabecera
            Formatos objfor = new Formatos();
          
            Session["PaginaActivaOrigen"] = objfor.NombrePagina();
            Session["PaginaActiva"] = "Credito Automatico";

            Session["cargaPag"] = "0";

            LblSaldos.Text ="0"; 
            string strParama = "<Parametros ";
            strParama = strParama + "iCliente=\"" + Session["IdCliente"] + "\" " + "cEstado=\"" + "99" + "\" />";
            //strParama = strParama + "iCliente=\"" + "117630" + "\" " + "cEstado=\"" + "99" + "\" />";



            Service objserv = new Service();
            string xmlSalida = objserv.ConsultaSaldosSocio(strParama, 8);
            xmlSalida = "<Automatico>" + xmlSalida + "</Automatico>";

            string vCupo = "";
            string vCupoUtilizado = "";
            string vCupoDisponible = "";

            Formatos objFormatos = new Formatos();

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xmlSalida);

            XmlNodeList lista2 = xDoc.GetElementsByTagName("Cta");

            foreach (XmlElement nodo in lista2)
            {
                vCupo = objFormatos.FormateaNumero(nodo.GetAttribute("vCupo"));
                vCupoUtilizado = objFormatos.FormateaNumero(nodo.GetAttribute("vCupoUtilizado"));
                vCupoDisponible = objFormatos.FormateaNumero(nodo.GetAttribute("vCupoDisponible"));

                nodo.SetAttribute("vCupo", vCupo);//CapInsoluto);
                nodo.SetAttribute("vCupoUtilizado", vCupoUtilizado);
                nodo.SetAttribute("vCupoDisponible", vCupoDisponible);

            }

            LblSaldos.Text = vCupoDisponible;
            xmlSalida = xDoc.InnerXml;
            //string xmlSalida = objService.ConsultaSaldosSocio("<Parametros iPersona= \"" + idCliente + "\"/>", 1);


            //xmlSalida = "<CAPITAL>" + strXML_encabezado + xmlSalida + "</CAPITAL>";


            /*iCuenta
    vCupo
    vCupoUtilizado
    vCupoDisponible
    fFechaActivacion*/


            xdsAutomatico.Data = xmlSalida;


            xdsAutomatico.XPath = (string.Format("Automatico/Cta"));
            gvAutomatico.Visible = true;
            gvAutomatico.DataSource = xdsAutomatico;
            gvAutomatico.DataBind();


            //if (Session["SaldoCredAuto"].ToString() == "$0")
            //{
                gvAutomatico.Visible = false;
                Session["cargaPag"] = "2";
                lblError.Visible = true;
                lblError.Text = "No tiene saldos para este Producto";
            //}

            
        }
        catch (Exception ex)
        {

            Response.Redirect("Defaultv3.aspx");
        }

       
    }

}
