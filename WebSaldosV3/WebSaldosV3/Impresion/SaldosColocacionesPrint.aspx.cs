﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class Impresion_SaldosColocacionesPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Formatos objfor = new Formatos();
        lblTituloPagina.Text = objfor.NombrePaginaFormateada(Session["PaginaActivaOrigen"].ToString());

        lblNombre.Text = Session["NombreCompleto"].ToString();
        lblRut.Text = Session["RutFormateado"].ToString();
        string dia = System.DateTime.Now.ToString("dd");
        string mes = System.DateTime.Now.ToString("MM");
        string ano = System.DateTime.Now.ToString("yyyy");
        lblFecha.Text = dia + "-" + mes + "-" + ano;
        //lblhora.Text = System.DateTime.Now.ToString("HH:mm:ss");

        lblCredCuota.Text = Session["SaldoCredCuota"].ToString();
        lblCredExtraor.Text = Session["SaldoCredExtra"].ToString();
        lblCredAutomatico.Text = Session["SaldoCredAuto"].ToString();
        lblCastigo.Text = Session["SaldoCastigo"].ToString();
        lblTotal.Text = Session["SaldoTotalColocaciones"].ToString();

    }
    
}
