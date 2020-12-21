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
    public partial class CargaSaldos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                Session["producto"] = "";
                //Instancia Funciones
                Formatos objFormatos = new Formatos();
                Service objService = new Service();

                // objService.cargaMasiva();

                //Carga saldos
                //Capital Social

                int TotalSaldosCaptaciones = 0;
                string xmlCapSocial = objService.ConsultaSaldosSocio("<Parametros iPersona= \"" + Session["IdCliente"].ToString() + "\"/>", 1);
                //   string xmlCapSocial = objService.ConsultaSaldosSocio("<Parametros iPersona= \"" + "105300" + "\"/>", 1);
                string vSaldoCapital = "";
                int vsaldocapitaltotal = 0;
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xmlCapSocial);

                XmlNodeList lista2 = xDoc.GetElementsByTagName("Saldos");
                foreach (XmlElement nodo in lista2)
                {
                    vSaldoCapital = objFormatos.FormateaNumero(nodo.GetAttribute("vTotal"));
                    vsaldocapitaltotal = Int32.Parse(nodo.GetAttribute("vTotal"));
                }
                Session["vSaldoCapital"] = vSaldoCapital;
                TotalSaldosCaptaciones = vsaldocapitaltotal;

                //Libreta Plazo
                string xmlLplazo = "<Parametros>";
                xmlLplazo = xmlLplazo + "<iPersona>" + Session["IdCliente"].ToString() + "</iPersona>";
                //xmlLplazo = xmlLplazo + "<iPersona>" + "105300" + "</iPersona>";
                xmlLplazo = xmlLplazo + "<cTablaEstado>" + 11 + "</cTablaEstado>";
                xmlLplazo = xmlLplazo + "<cEstado>" + 1 + "</cEstado>";
                xmlLplazo = xmlLplazo + "<cEstado2>2</cEstado2>";
                xmlLplazo = xmlLplazo + "</Parametros>";
                xmlLplazo = objService.ConsultaSaldosSocio(xmlLplazo, 2);

                xDoc.LoadXml(xmlLplazo);
                int vSaldoLibreta = 0;
                string vSaldoLibretaFinal = "";

                lista2 = xDoc.GetElementsByTagName("Libreta");
                foreach (XmlElement nodo3 in lista2)
                {
                    vSaldoLibreta = vSaldoLibreta + Int32.Parse(nodo3.GetAttribute("vSaldoLibreta"));
                }
                vSaldoLibretaFinal = objFormatos.FormateaNumero(vSaldoLibreta.ToString());
                Session["vSaldoLibretaPlazo"] = vSaldoLibretaFinal;
                TotalSaldosCaptaciones = TotalSaldosCaptaciones + vSaldoLibreta;

                //Libreta Vista
                string strParamaVista = "<Parametros ";
                strParamaVista = strParamaVista + "iCliente=\"" + Session["IdCliente"].ToString() + "\" />";
                //strParamaVista = strParamaVista + "iCliente=\"" + "100004" + "\" />";
                string xmlLvista = objService.ConsultaSaldosSocio(strParamaVista, 3);

                xDoc.LoadXml(xmlLvista);

                string vMonto = "";
                string vSaldo = "";
                int VsaldoVista = 0;

                XmlNodeList lista3 = xDoc.GetElementsByTagName("CtaVista");
                foreach (XmlElement nodo3 in lista3)
                {
                    vSaldo = objFormatos.FormateaNumero(nodo3.GetAttribute("vMontoSaldo"));
                    VsaldoVista = Int32.Parse(nodo3.GetAttribute("vMontoSaldo"));
                }
                Session["vSaldoLibretaVista"] = vSaldo;
                TotalSaldosCaptaciones = TotalSaldosCaptaciones + VsaldoVista;

                //Deposito Plazo
                string strParamdPlazo = "<Parametros iCliente=\"" + Session["IdCliente"].ToString() + "\" >";
                //string strParamdPlazo = "<Parametros iCliente=\"138687\" >";
                strParamdPlazo = strParamdPlazo + "<Estados>";
                strParamdPlazo = strParamdPlazo + "<Estado  cEstado=\"8\" />";
                strParamdPlazo = strParamdPlazo + "<Estado  cEstado=\"7\" />";
                strParamdPlazo = strParamdPlazo + "<Estado  cEstado=\"6\" />";
                strParamdPlazo = strParamdPlazo + "<Estado  cEstado=\"5\" />";
                strParamdPlazo = strParamdPlazo + "<Estado  cEstado=\"4\" />";
                strParamdPlazo = strParamdPlazo + "<Estado  cEstado=\"3\" />";
                strParamdPlazo = strParamdPlazo + "<Estado  cEstado=\"2\" />";
                strParamdPlazo = strParamdPlazo + "<Estado  cEstado=\"1\" />";
                strParamdPlazo = strParamdPlazo + "<Estado  cEstado=\"\" />";
                strParamdPlazo = strParamdPlazo + "</Estados>";
                strParamdPlazo = strParamdPlazo + "</Parametros>";
                string xmlSalida = objService.ConsultaSaldosSocio(strParamdPlazo, 4);
                xDoc.LoadXml(xmlSalida);
                int vMontoInicial_Pesos = 0;
                string vMontoFinal_Pesos = "";

                XmlNodeList lista4 = xDoc.GetElementsByTagName("Deposito");
                foreach (XmlElement nodo4 in lista4)
                {

                    if (nodo4.GetAttribute("cEstadoDeposito") == "1")
                        vMontoInicial_Pesos = vMontoInicial_Pesos + Int32.Parse(nodo4.GetAttribute("vMontoFinal_Pesos"));

                }
                vMontoFinal_Pesos = objFormatos.FormateaNumero(vMontoInicial_Pesos.ToString());
                Session["vSaldoDeposito"] = vMontoFinal_Pesos;
                TotalSaldosCaptaciones = TotalSaldosCaptaciones + vMontoInicial_Pesos;
                Session["TotalSaldosCaptaciones"] = objFormatos.FormateaNumero(TotalSaldosCaptaciones.ToString());


                //**********************************************************************************
                //COLOCACIONES
                //Credito Cuotas
                int SaldoTotalColocaciones = 0;

                string strParCredCuota = "<Parametros>";
                strParCredCuota = strParCredCuota + "<iPersona>" + Session["IdCliente"].ToString() + "</iPersona>";
                //Prueba strXML = strXML + "<iPersona>" + 104602 + "</iPersona>";
                strParCredCuota = strParCredCuota + "<cTablaEstado>33</cTablaEstado>";
                strParCredCuota = strParCredCuota + "<Estados>";
                strParCredCuota = strParCredCuota + "<Estado codigo=\"5\"/>";
                strParCredCuota = strParCredCuota + "<Estado codigo=\"1\"/>";
                strParCredCuota = strParCredCuota + "</Estados>";
                strParCredCuota = strParCredCuota + "</Parametros>";
                string InfoParamXMLcredCuota = objService.ConsultaSaldosSocio(strParCredCuota, 7);

                xDoc.LoadXml(InfoParamXMLcredCuota);
                XmlNodeList lista5 = xDoc.GetElementsByTagName("col");
                //XmlNodeList lista6 = ((XmlElement)lista2[0]).GetElementsByTagName("col");
                int SaldoCapital = 0;
                string SaldoCapitalFinal = "";
                foreach (XmlElement nodo5 in lista5)
                {

                    SaldoCapital = SaldoCapital + Int32.Parse(nodo5.GetAttribute("SaldoCapital"));

                }
                SaldoCapitalFinal = objFormatos.FormateaNumero(SaldoCapital.ToString());
                Session["SaldoCredCuota"] = SaldoCapitalFinal;
                SaldoTotalColocaciones = SaldoCapital;

                //Credito Extraordinario
                string strParCredExtra = "<Parametros>";
                strParCredExtra = strParCredExtra + "<iPersona>" + Session["IdCliente"].ToString() + "</iPersona>";
                //Prueba strXML = strXML + "<iPersona>" + 104602 + "</iPersona>";
                strParCredExtra = strParCredExtra + "<cTablaEstado>33</cTablaEstado>";
                strParCredExtra = strParCredExtra + "<Estados>";
                strParCredExtra = strParCredExtra + "<Estado codigo=\"5\"/>";
                strParCredExtra = strParCredExtra + "<Estado codigo=\"1\"/>";
                strParCredExtra = strParCredExtra + "</Estados>";
                strParCredExtra = strParCredExtra + "</Parametros>";
                string InfoParamXMLcredExtra = objService.ConsultaSaldosSocio(strParCredExtra, 7);

                xDoc.LoadXml(InfoParamXMLcredExtra);
                XmlNodeList lista6 = xDoc.GetElementsByTagName("col");
                //XmlNodeList lista6 = ((XmlElement)lista2[0]).GetElementsByTagName("col");
                int SaldoCapitalExtra = 0;
                string SaldoCapitalFinalExtra = "";
                foreach (XmlElement nodo6 in lista6)
                {
                    if (nodo6.GetAttribute("cTipoCalculo") == "2")
                        SaldoCapitalExtra = SaldoCapitalExtra + Int32.Parse(nodo6.GetAttribute("SaldoCapital"));
                }
                SaldoCapitalFinalExtra = objFormatos.FormateaNumero(SaldoCapitalExtra.ToString());
                Session["SaldoCredExtra"] = SaldoCapitalFinalExtra;
                SaldoTotalColocaciones = SaldoTotalColocaciones + SaldoCapitalExtra;

               



                Session["SaldoCredAuto"] = "0";
                //Credito Automatico
                /*     string strParamaAutomat = "<Parametros ";
                     //strParamaAutomat = strParamaAutomat + "iCliente=\"" + Session["IdCliente"] + "\" " + "cEstado=\"" + "99" + "\" />";
                     strParamaAutomat = strParamaAutomat + "iCliente=\"" + "117630" + "\" " + "cEstado=\"" + "99" + "\" />";

                     Service objserv = new Service();
                     string xmlSalidaAutomat = objserv.ConsultaSaldosSocio(strParamaAutomat, 8);
                     xmlSalidaAutomat = "<Automatico>" + xmlSalidaAutomat + "</Automatico>";
                                    
                     xDoc.LoadXml(xmlSalidaAutomat);

                     XmlNodeList lista8 = xDoc.GetElementsByTagName("Cta");
                     int saldoCredAut = 0;
                     string saldoCredAutTotal = "";

                     foreach (XmlElement nodo8 in lista8)
                     {
            
                         saldoCredAut = saldoCredAut + Int32.Parse(nodo8.GetAttribute("vCupo").Replace(".00","")) - Int32.Parse(nodo8.GetAttribute("vCupoUtilizado").Replace(".00",""));
                     }
                     Session["SaldoCredAuto"] = objFormatos.FormateaNumero(saldoCredAut.ToString());
                     SaldoTotalColocaciones = SaldoTotalColocaciones + saldoCredAut;
             */
                //Castigos
                string strXMLcas = "<Parametros>";
                strXMLcas = strXMLcas + "<iPersona>" + Session["IdCliente"].ToString() + "</iPersona>";
                //strXMLcas = strXMLcas + "<iPersona>" + 137826 + "</iPersona>";

                strXMLcas = strXMLcas + "<cTablaEstado>33</cTablaEstado>";
                strXMLcas = strXMLcas + "<Estados>";
                strXMLcas = strXMLcas + "<Estado codigo=\"5\"/>";
                strXMLcas = strXMLcas + "<Estado codigo=\"1\"/>";
                strXMLcas = strXMLcas + "</Estados>";
                strXMLcas = strXMLcas + "</Parametros>";
                string InfoParamXMLcas = objService.ConsultaSaldosSocio(strXMLcas, 11);
                xDoc.LoadXml(InfoParamXMLcas);
                XmlNodeList lista11 = xDoc.GetElementsByTagName("col");
                //XmlNodeList lista6 = ((XmlElement)lista2[0]).GetElementsByTagName("col");
                int SaldoCastigo = 0;
                string SaldoCapitalFinalCastigo = "";
                foreach (XmlElement nodo11 in lista11)
                {
                    SaldoCastigo = SaldoCastigo + Int32.Parse(nodo11.GetAttribute("SaldoCapital"));
                }
                SaldoCapitalFinalCastigo = objFormatos.FormateaNumero(SaldoCastigo.ToString());
                Session["SaldoCastigo"] = SaldoCapitalFinalCastigo;
                SaldoTotalColocaciones = SaldoTotalColocaciones + SaldoCastigo;




                /*Session["SaldoCredCuota"]
                Session["SaldoCredExtra"]
                Session["SaldoCredAuto"] */
                Session["SaldoTotalColocaciones"] = objFormatos.FormateaNumero(SaldoTotalColocaciones.ToString());


                Session["cargaPag"] = 1;
                Response.Redirect("FondoInicio.aspx?cargaPag=1",false);

            //}
            //catch (Exception ex)
            //{
            //    Response.Redirect("Defaultv3.aspx?error=" + ex.Message);
            //}
        }
    }

}