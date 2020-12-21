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

namespace WebSaldosV3
{
    public partial class Castigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["producto"] = "Castigos";
                
                //carga Cabecera
                Formatos objfor = new Formatos();
                Session["PaginaActivaOrigen"] = objfor.NombrePagina();
                Session["PaginaActiva"] = "Castigos de Colocaciones";
              //  lblNombre.Text = Session["NombreCompleto"].ToString();
               // lblRut.Text = Session["RutFormateado"].ToString();
                //lblSaldo.Text = Session["SaldoCastigo"].ToString();

                Session["cargaPag"] = "0";

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

                String isbn = "gvColocaciones.DataKeys[GVListarXml.SelectedIndex].Value";

                /*xdsCredCuotas.Data = InfoParamXML;
                xdsCredCuotas.XPath = (string.Format("/Colocaciones/col[@cEstadoColocacion=\"1\" or @cEstadoColocacion=\"2\"]", isbn));
                gvCredCuotas.DataSource = xdsCredCuotas;
                gvCredCuotas.DataBind();*/

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(InfoParamXML);
                XmlNodeList lista2 = xDoc.GetElementsByTagName("Colocaciones");
                XmlNodeList lista3 = ((XmlElement)lista2[0]).GetElementsByTagName("col");
                DataTable dt = new DataTable("Table1");
                dt.Columns.Add("iColocacion");
                dt.Columns.Add("fApertura");
                dt.Columns.Add("fCierre");
                dt.Columns.Add("vMontoTotal");
                //dt.Columns.Add("SaldoInsoluto");
                dt.Columns.Add("NombreProducto");
                dt.Columns.Add("Estado");
                dt.Columns.Add("cAmortizacion");
                //dt.Columns.Add("cpagare");

                int SaldoCastigo = 0;
                Formatos objFormatos = new Formatos();
                foreach (XmlElement nodo in lista3)
                {

                    if (nodo.GetAttribute("cTipoCalculo") != "2")
                    {
                        SaldoCastigo = SaldoCastigo + Int32.Parse(nodo.GetAttribute("SaldoCapital"));
                        dt.Rows.Add(nodo.GetAttribute("iColocacion"), nodo.GetAttribute("fApertura"), nodo.GetAttribute("fCierre"), objFormatos.FormateaNumero(nodo.GetAttribute("vMontoTotal"))
                        , nodo.GetAttribute("NombreProducto"), nodo.GetAttribute("EstadoColocacion"), nodo.GetAttribute("cAmortizacion"));// (nodo.GetAttribute("cCuota"));
                    }


                }

                lblSaldo.Text =  objFormatos.FormateaNumero(SaldoCastigo.ToString());

                gvCredCuotas.DataSource = dt;
                gvCredCuotas.DataBind();

                if (SaldoCastigo == 0)
                {
                    Session["cargaPag"] = "2";
                    lblError.Visible = true;
                    lblError.Text = "No tiene saldos para este Producto";
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("Defaultv3.aspx");
            }


        }

    }
}