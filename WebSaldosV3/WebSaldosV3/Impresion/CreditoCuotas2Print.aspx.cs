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

public partial class Impresion_CreditoCuotas2Print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //carga Cabecera
        //Formatos objfor = new Formatos();
        //Session["PaginaActivaOrigen"] = objfor.NombrePagina();
        //Session["PaginaActiva"] = "Movimientos Credito en Cuotas";
        Formatos objfor = new Formatos();
        lblTituloPagina.Text = objfor.NombrePaginaFormateada(Session["PaginaActivaOrigen"].ToString());


        lblNombre.Text = Session["NombreCompleto"].ToString();
        lblRut.Text = Session["RutFormateado"].ToString();
        //lblSaldo.Text = Session["SaldoCredCuota"].ToString(); 

        //CreditoCuotas2.aspx?IColocacion={0}&op=7&Nommbre={1}&cAmortizacion={2}
        lblnCredito.Text = Session["IColocacion"].ToString();
        lblTipoCredito.Text = Session["Nommbre"].ToString();
        lblFrecuencia.Text = Session["cAmortizacion"].ToString();
                
        // Response.Write("<script>alert ('Auipase')</script>");
        Service objService = new Service();
        string strXML = "<Parametros>";
        strXML = strXML + "<iPersona>" + Session["IdCliente"].ToString() + "</iPersona>";
        strXML = strXML + "<cTablaEstado>33</cTablaEstado>";
        strXML = strXML + "<Estados>";
        strXML = strXML + "<Estado codigo=\"5\"/>";
        strXML = strXML + "<Estado codigo=\"1\"/>";
        strXML = strXML + "</Estados>";
        strXML = strXML + "</Parametros>";

        //string aca = "pase por aca";
        string InfoParamXML = objService.ConsultaSaldosSocio(strXML, 7);

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
        string colo = Session["IColocacion"].ToString(); ;
        string colo2 = "";
        foreach (XmlElement nodo in lista2)
        {

            if (nodo.GetAttribute("iColocacion") == Session["IColocacion"].ToString())
            {
                lblSaldo.Text = objFormatos.FormateaNumero(nodo.GetAttribute("SaldoCapital"));
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



        xdsCredCuotas1.Data = InfoParamXML2;
        xdsCredCuotas1.XPath = (string.Format("/Colocaciones/col[@iColocacion=" + Session["IColocacion"].ToString() + "]/c[@cEstadoCuota=\"1\" or @cEstadoCuota=\"3\"]"));
        gvCredCuotas1.DataSource = xdsCredCuotas1;
        gvCredCuotas1.DataBind();




    }
}
