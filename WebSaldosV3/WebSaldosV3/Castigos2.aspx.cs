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

public partial class Castigo2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //carga Cabecera
            Formatos objfor = new Formatos();
            Session["PaginaActivaOrigen"] = objfor.NombrePagina();
            Session["PaginaActiva"] = "Movimientos Castigos";
            Session["cargaPag"] = "0";

            // lblNombre.Text = Session["NombreCompleto"].ToString();
            // lblRut.Text = Session["RutFormateado"].ToString();
            //lblSaldo.Text = Session["SaldoCastigo"].ToString();

            //CreditoCuotas2.aspx?IColocacion={0}&op=7&Nommbre={1}&cAmortizacion={2}
            lblnCredito.Text = Request.QueryString["IColocacion"];
            lblTipoCredito.Text = Request.QueryString["Nommbre"].ToString();
            lblFrecuencia.Text = Request.QueryString["cAmortizacion"];

            Session["IColocacion"] = Request.QueryString["IColocacion"];
            Session["Nommbre"] = Request.QueryString["Nommbre"].ToString();
            Session["cAmortizacion"] = Request.QueryString["cAmortizacion"];


            // Response.Write("<script>alert ('Auipase')</script>");
            Service objService = new Service();
            string strXML = "<Parametros>";
            strXML = strXML + "<iPersona>" + Session["IdCliente"].ToString() + "</iPersona>";
            //strXML = strXML + "<iPersona>" + 137826 + "</iPersona>";
            strXML = strXML + "<cTablaEstado>33</cTablaEstado>";
            strXML = strXML + "<Estados>";
            strXML = strXML + "<Estado codigo=\"5\"/>";
            strXML = strXML + "<Estado codigo=\"1\"/>";
            strXML = strXML + "</Estados>";
            strXML = strXML + "</Parametros>";

            //string aca = "pase por aca";
            string InfoParamXML = objService.ConsultaSaldosSocio(strXML, 11);

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(InfoParamXML);

            XmlNodeList lista2 = xDoc.GetElementsByTagName("col");
            Formatos objFormatos = new Formatos();
            string CapInsoluto = "";
            string interes = "";
            string saldoCapital = "";
            int MontoTotal = 0;

            int indice = 0;
            int ind = 0;
            string colo = Request.QueryString["iColocacion"].ToString();
            string colo2 = "";
            int SaldoCastigo = 0;
            foreach (XmlElement nodo in lista2)
            {

                if (nodo.GetAttribute("iColocacion") == Request.QueryString["iColocacion"].ToString())
                {
                    SaldoCastigo = SaldoCastigo + Int32.Parse(nodo.GetAttribute("SaldoCapital"));
                    colo2 = nodo.GetAttribute("iColocacion");
                    XmlNodeList lista3 = ((XmlElement)lista2[indice]).GetElementsByTagName("c");
                    foreach (XmlElement nodo2 in lista3)
                    {
                        MontoTotal = Int32.Parse(nodo2.GetAttribute("vCapitalPagado")) + Int32.Parse(nodo2.GetAttribute("vInteres")) + Int32.Parse(nodo2.GetAttribute("vGastoCobranza")) + Int32.Parse(nodo2.GetAttribute("vInteresMoratorio"));

                        CapInsoluto = objFormatos.FormateaNumero((Int32.Parse(nodo2.GetAttribute("vInteres")) + Int32.Parse(nodo2.GetAttribute("vCapitalPagado"))).ToString());
                        interes = objFormatos.FormateaNumero(nodo2.GetAttribute("vInteres"));
                        saldoCapital = objFormatos.FormateaNumero(nodo2.GetAttribute("vCapitalPagado"));
                        nodo2.SetAttribute("vValorCuota", CapInsoluto);//CapInsoluto);
                        nodo2.SetAttribute("vInteres", interes);
                        nodo2.SetAttribute("vCapitalPagado", saldoCapital);
                        nodo2.SetAttribute("vValorCuotaUF", objFormatos.FormateaNumero(MontoTotal.ToString()));
                    }

                }

                indice = indice + 1;
            }
            InfoParamXML = xDoc.InnerXml;
            string InfoParamXML2 = InfoParamXML;

            lblSaldo.Text = objFormatos.FormateaNumero(SaldoCastigo.ToString());

            if (SaldoCastigo == 0)
            {
                Session["cargaPag"] = "2";
                lblError.Visible = true;
                lblError.Text = "No tiene saldos para este Producto";
            }

            xdsCredCuotas1.Data = InfoParamXML2;
            xdsCredCuotas1.XPath = (string.Format("/Colocaciones/col[@iColocacion=" + Request.QueryString["iColocacion"] + "]/c[@cEstadoCuota=\"1\" or @cEstadoCuota=\"3\"]"));
            gvCredCuotas1.DataSource = xdsCredCuotas1;
            gvCredCuotas1.DataBind();


        }
        catch (Exception ex)
        {
            Response.Redirect("Defaultv3.aspx");
        }

    }
    
}
