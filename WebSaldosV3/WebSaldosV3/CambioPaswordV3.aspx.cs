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

public partial class CambioPaswordV3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblRut.Text = Session["RutFormateado"].ToString();

    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            string cRutsindigito = Session["RutFormateado"].ToString().Replace("-", "");
            cRutsindigito = cRutsindigito.Replace(".", "");
            //Response.Write (Session["RutFormateado"].ToString());
            //Response.Write (cRutsindigito);
            if (cRutsindigito == "")
            {
                return;
            }
            if (txtPaswordCambio1.Text == "")
            {
                //Response.Write("<script>alert('debe ingresar paswword');window.location.href='http://" + Session["IpServidor"].ToString() + "/sitiowebandescoop/CambioPasword.aspx'</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "MensageTransaccion('Debe ingresar paswword','CambioPaswordV3.aspx');", true);
                txtPaswordCambio1.Focus();
                return;
            }
            if (txtPaswordCambio2.Text == "")
            {
                //  Response.Write("<script>alert('debe ingresar paswword');window.location.href='http://" + Session["IpServidor"].ToString() + "/sitiowebandescoop/CambioPasword.aspx'</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "MensageTransaccion('Debe ingresar paswword','CambioPaswordV3.aspx');", true);
                txtPaswordCambio2.Focus();
                return;
            }
            if (txtPaswordCambio2.Text != txtPaswordCambio1.Text)
            {
                // Response.Write("<script>alert('la clave ingresada no coincide');window.location.href='http://" + Session["IpServidor"].ToString() + "/sitiowebandescoop/CambioPasword.aspx'</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "MensageTransaccionRuta('la clave ingresada no coincide','Defaultv3.aspx');", true);
                txtPaswordCambio2.Focus();
                return;
            }


            Formatos objFor = new Formatos();
            string crut = "";
            string pasww;

            Validaciones objValida = new Validaciones();
            string RutValidado = objValida.ValidaRut(cRutsindigito);
            cRutsindigito = RutValidado;
            Session["RutFormateado"] = RutValidado;
            if (RutValidado == "n")
            {
                // Response.Write(cRutsindigito);
                Response.Write("<script>alert('Rut no valido')</script>");
                cRutsindigito = "";

            }
            else
            {
                crut = objFor.QuitaFormatoRut(cRutsindigito);


                cRutsindigito = Session["RutFormateado"].ToString();
                pasww = txtPasword.Text;
                string strXmlAutentica;
                //<ParametrosIn Rut="1106757" Paswword="1111" />
                //11067573
                strXmlAutentica = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
                strXmlAutentica = "<ParametrosIn Rut=\"" + crut + "\" Password=\"" + pasww + "\" />";

                Service objService = new Service();
                string XmlAutentica = objService.AutenticaUsuario(crut, pasww);
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
                    XmlNodeList lista2 = xDoc.GetElementsByTagName("Persona");
                    XmlNodeList lista3 = ((XmlElement)lista2[0]).GetElementsByTagName("DatosPersonales");

                    foreach (XmlElement nodo in lista3)
                    {
                        XmlNodeList idCliente2 = nodo.GetElementsByTagName("IdCliente");
                        idCliente = idCliente2[0].InnerText;
                        XmlNodeList objNombre = nodo.GetElementsByTagName("NombreCompleto");
                        NombreCompleto = objNombre[0].InnerText;

                    }

                    //cargado Session["RutFormateado"];
                    //Session["NombreCompleto"] = NombreCompleto;
                    //Session["IdCliente"] = idCliente;
                    //Session["PaginaActiva"] = "1";

                    //Session["CargaPagina"] = "1";


                    //fin carga
                    //Inicio Carga nueva pasword
                    string paswwModificar = txtPaswordCambio2.Text;
                    string strXmlModifica = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
                    strXmlModifica = "<usuario iPersona=\"" + idCliente + "\" 	nPassword=\"" + paswwModificar + "\" nPasswordnoencriptada=\"" + paswwModificar + "\" cTablaEstado=\"242\" 	cEstado=\"1\" 	tAccion=\"2\" 	Persona=\"1\" 	cSucursal=\"1\" tObservacion=\"\"  />";
                    Boolean res = false;
                    res = objService.ModificaUsuario(strXmlModifica);
                    if (res)
                    {
                        //Response.Write("<script>alert('los datos fueron Modificados correctamente');window.location.href='http://localhost/sitiowebandescoop/default.aspx';</script>");
                        //Response.Write("<script>alert('los datos fueron Modificados correctamente');window.location.href='default.aspx';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "MensageTransaccionRuta('los datos fueron Modificados correctamente','defaultv3.aspx');", true);

                    }

                    else
                    {
                        //Response.Write("<script>alert('hubo un error comuniquese con su administrador');window.location.href='http://" + Session["IpServidor"].ToString() + "/sitiowebandescoop/default.aspx';</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "MensageTransaccionRuta('hubo un error comuniquese con su administrador','Defaultv3.aspx');", true);
                    }

                    // Response.Redirect("CargaSaldos.aspx?crut=" + crut);
                    //Response.Redirect("FondoInicio.aspx?crut=" + crut);
                }
                else
                {
                    //Response.Write("<script>alert('Socio no existe');window.location.href='http://" + Session["IpServidor"].ToString() + "/sitiowebandescoop/default.aspx';</script>");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "MensageTransaccionRuta('Socio no existe','Defaultv3.aspx');", true);
                }

                cRutsindigito = "";
                txtPasword.Text = "";
                txtPasword.Focus();
            }

            cRutsindigito = "";
            Session["RutFormateado"] = RutValidado;
            txtPasword.Focus();

        }
        catch (Exception ex)
        {
            Response.Redirect("Defaultv3.aspx");
        }

    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        // localhost.Service objser = new localhost.Service();

    }
   

}
