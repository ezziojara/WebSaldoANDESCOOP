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

public partial class Impresion_LibretaPlazo2Print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  //carga Cabecera
        Formatos objfor = new Formatos();
        Session["PaginaActivaOrigen"] = objfor.NombrePagina();
        Session["PaginaActiva"] = "Movimientos Libreta a Plazo";
                
        lblTituloPagina.Text = objfor.NombrePaginaFormateada(Session["PaginaActivaOrigen"].ToString());

        lblNombre.Text = Session["NombreCompleto"].ToString();
        lblRut.Text = Session["RutFormateado"].ToString();
        // LblSaldos.Text = Session["vSaldoLibretaPlazo"].ToString();
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
        int indice = 0;

        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml(xmlSalida);

        string vValorMovimiento = "";
        string vSaldo = "";
        XmlNodeList lista2 = xDoc.GetElementsByTagName("Libreta");
        foreach (XmlElement nodo in lista2)
        {
            //Request.QueryString["iCuenta"].ToString()
            if (nodo.GetAttribute("iCuenta") == Session["iCuentaLibretaPlazo"].ToString())
            {
                XmlNodeList lista3 = ((XmlElement)lista2[indice]).GetElementsByTagName("MovLibreta");
                foreach (XmlElement nodo2 in lista3)
                {
                    vValorMovimiento = objFormatos.FormateaNumero(nodo2.GetAttribute("vValorMovimiento"));
                    vSaldo = objFormatos.FormateaNumero(nodo2.GetAttribute("vSaldo"));
                    nodo2.SetAttribute("vValorMovimiento", vValorMovimiento);//CapInsoluto);
                    nodo2.SetAttribute("vSaldo", vSaldo);//CapInsoluto);
                }
            }
        indice = indice + 1;

        }

        LblSaldos.Text = vSaldo;

        xmlSalida = xDoc.InnerXml;

           /*mov
DescTipoMov
fFechaPago
vValorMovimiento
vSaldo
DescEstadoPago*/

        xdsLibreta.Data = xmlSalida;
        xdsLibreta.XPath = (string.Format("/Libretas/Libreta[@iCuenta=" + Session["iCuentaLibretaPlazo"].ToString() + "]/MovLibreta"));
        gvListaLibreta.DataSource = xdsLibreta;
        gvListaLibreta.DataBind();



    }
    }

