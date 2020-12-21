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
using System.Net;
using ModuloIntermedio;

public partial class IngresoSocio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       //Para pruebas internas
        Session["IpServidor"] = "172.16.10.109";
       //Para IpExterna 
        //Session["IpServidor"] = "190.8.79.85";
        //130754457 1111 --para pruebas
         //Andescoop  usuario “103221781”, contraseña “1111”. 
       
    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtIngresoRut.Text == "")
            {
                return;
            }
            Formatos objFor = new Formatos();
            string crut = "";
            string pasww;

            Validaciones objValida = new Validaciones();
            string RutValidado = objValida.ValidaRut(txtIngresoRut.Text);
            txtIngresoRut.Text = RutValidado;
            Session["RutFormateado"] = RutValidado;
            if (RutValidado == "n")
            {
                Response.Write("<script>alert('Rut no valido')</script>");
                txtIngresoRut.Text = "";
            }
            else
            {
                crut = objFor.QuitaFormatoRut(txtIngresoRut.Text);

                txtIngresoRut.Text = Session["RutFormateado"].ToString();
                pasww = txtPasword.Text;
                string strXmlAutentica;
                //<ParametrosIn Rut="1106757" Paswword="1111" />
                //11067573
                strXmlAutentica = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
                strXmlAutentica = "<ParametrosIn Rut=\"" + crut + "\" Password=\"" + pasww + "\" />";

                //localhost.Service objService = new localhost.Service();
                //string XmlAutentica = objService.AutenticaUsuario(crut, pasww);

                Service objService = new Service();
                Encripta objEnc = new Encripta();
                string rutencr = objEnc.Encrit(pasww);
                string XmlAutentica = objService.AutenticaUsuario(crut, pasww);
                //string XmlAutentica = "<ParametrosOut><Autorizacion cCodigo=\"0\" Mensaje=\"Autorizado\"/><Perfiles><Perfil cPerfil=\"1\" tPetfil=\"Socio\"/><Perfil cPerfil=\"2\" tPetfil=\"Ahorrante\"/></Perfiles></ParametrosOut>";
                txtPasword.Text = XmlAutentica;
                ////////////////////////
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(XmlAutentica);
                string strMensaje = "";
                string strcCodigo = "";
                XmlNodeList lista = xDoc.GetElementsByTagName("Autorizacion");
                // XmlNodeList lista = ((XmlElement)personas[0]).GetElementsByTagName("Producto");
                foreach (XmlElement nodo in lista)
                {
                    strcCodigo = nodo.GetAttribute("cCodigo");
                    strMensaje = nodo.GetAttribute("Mensaje");
                    //cCodigo = 1 "aceptado 2 Rechazado
                }
                ////////////////////////
                string prueba = strcCodigo;
                if (strcCodigo == "0")
                {
                    //Response.Write("<script>alert('Socio existe')</script>");
                    //carga variables de session
                    string strXmlPersonas = objService.TraePersonas(Int32.Parse(crut));

                    xDoc.LoadXml(strXmlPersonas);

                    string idCliente = "";
                    string NombreCompleto = "";
                    string NumeroControl = "";
                    XmlNodeList lista2 = xDoc.GetElementsByTagName("Persona");
                    XmlNodeList lista3 = ((XmlElement)lista2[0]).GetElementsByTagName("DatosPersonales");

                    foreach (XmlElement nodo in lista3)
                    {
                        XmlNodeList idCliente2 = nodo.GetElementsByTagName("IdCliente");
                        idCliente = idCliente2[0].InnerText;
                        XmlNodeList objNombre = nodo.GetElementsByTagName("NombreCompleto");
                        NombreCompleto = objNombre[0].InnerText;
                        XmlNodeList objControl = nodo.GetElementsByTagName("cControl");
                        NumeroControl = objControl[0].InnerText;

                    }
                    //Response.Write (NumeroControl);
                    //cargado Session["RutFormateado"];
                    Session["NombreCompleto"] = NombreCompleto;
                    Session["IdCliente"] = idCliente;
                    Session["PaginaActiva"] = "1";

                    Session["CargaPagina"] = "1";

                    //fin carga
                    //if (Int32.Parse(NumeroControl) == 1)
                    //    Response.Redirect("CambioPasword.aspx");

                    Response.Redirect("CargaSaldos.aspx?crut=" + crut);

                    //Response.Redirect("FondoInicio.aspx?crut=" + crut);
                }
                else
                {
                    // Response.Write("<script Language=\"javascript\" runat=\"server\">alert('Socio no existe');window.location.href='http://" + Session["IpServidor"].ToString() +"/sitiowebandescoop/default.aspx';</script>");
                    Response.Write("<script>alert('Usuario Incorrecto');window.location='default.aspx';</script>");
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "MensageTransaccionRuta('Usuario Incorrecto','default.aspx');", true);
                    return;
                }


                txtIngresoRut.Text = "";
                txtPasword.Text = "";
                txtPasword.Focus();
            }

          

        }
        catch (Exception ex) {

            Response.Write("<script>alert('"+ex.Message.Normalize().Replace("'","") +"');window.location='default.aspx';</script>");
        

        }

        }

        



   
    protected void Button1_Click(object sender, EventArgs e)
    {
       // localhost.Service objser = new localhost.Service();
        
    }

   
}
