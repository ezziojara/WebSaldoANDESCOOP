using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace WebSaldosV3
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
        
                lblnombresocio.Text = "Socio: " + Session["NombreCompleto"].ToString();
                lblrutsocio.Text =    "RUT  : " + Session["RutFormateado"].ToString();
                lblproducto.Text = Session["producto"].ToString().ToUpper();
                //if (Request.QueryString["cargaPag"] == "1")
                if (Session["cargaPag"].ToString() == "1")
                {
                    btnvolver.Visible = false;
                    btnImprime.Visible = false;
                    ImageButton3.Visible = false;
                    ImageButton4.Visible = false;
                    lblproducto.Visible = false;
                }
                if (Session["cargaPag"].ToString() == "0")
                {
                    btnvolver.Visible = true;
                    btnImprime.Visible = false;
                    ImageButton3.Visible = true;
                    ImageButton4.Visible = true;
                    lblproducto.Visible = true;
                }

                if (Session["cargaPag"].ToString() == "2")
                {
                    btnvolver.Visible = true;
                    btnImprime.Visible = false;
                    ImageButton3.Visible = false;
                    ImageButton4.Visible = false;
                    lblproducto.Visible = true;
                }
                
                

                if (Session["NombreCompleto"] == "")
                    Response.Redirect("Error.aspx");
                Formatos objfor = new Formatos();
                //Session["PaginaActivaOrigen"] = objfor.NombrePagina();
                lblTituloPagina.Text = objfor.NombrePaginaFormateada(Session["PaginaActivaOrigen"].ToString());

                lblPaginaActiva.Text = Session["PaginaActiva"].ToString();


                lblNombre.Text = Session["NombreCompleto"].ToString();
                lblRut.Text = Session["RutFormateado"].ToString();
                string dia = System.DateTime.Now.ToString("dd");
                string mes = System.DateTime.Now.ToString("MM");
                string ano = System.DateTime.Now.ToString("yyyy");
                lblFecha.Text = dia + "-" + mes + "-" + ano;
                lblhora.Text = System.DateTime.Now.ToString("HH:mm:ss");



                int intMes = Int32.Parse(mes);
                string strMes = "";

                switch (intMes)
                {
                    case 1:
                        strMes = "Enero";
                        break;
                    case 2:
                        strMes = "Febrero";
                        break;
                    case 3:
                        strMes = "Marzo";
                        break;
                    case 4:
                        strMes = "abril";
                        break;
                    case 5:
                        strMes = "mayo";
                        break;
                    case 6:
                        strMes = "junio";
                        break;
                    case 7:
                        strMes = "julio";
                        break;
                    case 8:
                        strMes = "agosto";
                        break;
                    case 9:
                        strMes = "septiembre";
                        break;
                    case 10:
                        strMes = "octubre";
                        break;
                    case 11:
                        strMes = "noviembre";
                        break;
                    case 12:
                        strMes = "diciembre";
                        break;

                }

                //lblMesStr.Text = strMes;

            }
            catch (Exception ex)
            {
                Response.Redirect("Defaultv3.aspx");

            }

        }
        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["PaginaActivaOrigen"] = "";
            Session["PaginaActiva"] = "";
            Session["ImprimePagina"] = "";

            Session["NombreCompleto"] = "";
            Session["RutFormateado"] = "";
            Response.Redirect("Default.aspx?cerrarpagina=si");

        }
        protected void btnImprime_Click(object sender, EventArgs e)
        {
            Formatos objFor = new Formatos();
            string pexel = "";
            string PaginaImprimir1 = Session["PaginaActivaOrigen"].ToString();
            //string PaginaImprimir2 = objFor.ImprimePagina(PaginaImprimir1, pexel, Session["IpServidor"].ToString());
            string PaginaImprimir2 = objFor.ImprimePagina(PaginaImprimir1, pexel, Session["IpServidor"].ToString());
            PaginaImprimir2 = PaginaImprimir2;
            Response.Redirect(PaginaImprimir2);

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Formatos objFor = new Formatos();
            string pexel = "";
            string PaginaImprimir1 = Session["PaginaActivaOrigen"].ToString();
            //string PaginaImprimir2 = objFor.ImprimePagina(PaginaImprimir1, pexel, Session["IpServidor"].ToString());
            //string PaginaImprimir2 = objFor.ImprimePagina(PaginaImprimir1, pexel, Session["IpServidor"].ToString());
            string PaginaImprimir2 = objFor.ImprimePaginav2(PaginaImprimir1, pexel, Session["IpServidor"].ToString());
            //Response.Redirect(PaginaImprimir2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.open('" + PaginaImprimir2 + "');", true);
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Formatos objFor = new Formatos();
            string pexel = "1";
            string PaginaImprimir1 = Session["PaginaActivaOrigen"].ToString();
            //string PaginaImprimir2 = objFor.ImprimePagina(PaginaImprimir1, pexel, Session["IpServidor"].ToString());
            string PaginaImprimir2 = objFor.ImprimePagina(PaginaImprimir1, pexel, Session["IpServidor"].ToString());
            PaginaImprimir2 = PaginaImprimir2;
            Response.Redirect(PaginaImprimir2);

        }
        protected void btnModificarPasword_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioPasword.aspx");
        }
    }
}