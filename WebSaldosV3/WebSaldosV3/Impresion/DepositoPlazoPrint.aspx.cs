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

public partial class Impresion_DepositoPlazoPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Formatos objfor = new Formatos();
        lblTituloPagina.Text = objfor.NombrePaginaFormateada(Session["PaginaActivaOrigen"].ToString());
        
        lblNombre.Text = Session["NombreCompleto"].ToString();
        lblRut.Text = Session["RutFormateado"].ToString();

        //LblSaldos.Text = Session["vSaldoDeposito"].ToString();

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
          string vMontoInicial_Pesos = "";
          string vMontoFinal_Pesos = "";

          XmlNodeList lista2 = xDoc.GetElementsByTagName("Deposito");
        int SaldoDeposito =0 ;
          foreach (XmlElement nodo in lista2)
          {
              SaldoDeposito = SaldoDeposito + Int32.Parse(nodo.GetAttribute("vMontoFinal_Pesos"));

              vMontoInicial_Pesos = objFormatos.FormateaNumero(nodo.GetAttribute("vMontoInicial_Pesos"));
              vMontoFinal_Pesos = objFormatos.FormateaNumero(nodo.GetAttribute("vMontoFinal_Pesos"));

              nodo.SetAttribute("vMontoInicial_Pesos", vMontoInicial_Pesos);//CapInsoluto);
              nodo.SetAttribute("vMontoFinal_Pesos", vMontoFinal_Pesos);

          }

          LblSaldos.Text = objFormatos.FormateaNumero(SaldoDeposito.ToString());

          xmlSalida = xDoc.InnerXml;
          
        
  /*iCuenta
  NombreProducto
  fApertura
  fFechaTermino
  vMontoInicial_Pesos
  vMontoFinal_Pesos
  DescEstadoDesposito*/
        

        xdsDeposito.Data = xmlSalida;
        xdsDeposito.XPath = (string.Format("/DepositoPlazo/Deposito"));
        gvDeposito.DataSource = xdsDeposito;
        gvDeposito.DataBind();

       
   
    }
}
