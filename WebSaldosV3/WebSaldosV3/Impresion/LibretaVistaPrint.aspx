﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="Impresion_LibretaVistaPrint" Codebehind="LibretaVistaPrint.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript">
function Imprime()
{
window.print();
window.history.back();
}
</script>
    <title> <% Formatos objFor = new Formatos();
       Response.Write(objFor.NombrePaginaFormateada(Session["PaginaActivaOrigen"].ToString()));   %>
    </title>
    <style type="text/css">

        .style7
        {
            font-family: "Arial Black";
            font-size: x-small;
        }
        .style8
        {
            border-style: none;
            font-family: "Arial";
            font-size: xx-small;
        }
        .style9
        {
            font-family: "Arial";
            font-size: xx-small;
        }
        .style10
        {
            font-size: small;
        }
        </style>
</head>
<% if (Request.QueryString["opcionExel"] == "1")
   {%>
<body>
<%Response.ContentType = "application/vnd.ms-excel";
  Response.AddHeader("Content-Disposition", "attachment;filename=Formulario_04.xls;");
  Response.AddHeader("pragma", "no-cache");
  Response.Expires = -1;
  Response.Buffer =   false;
  Server.ScriptTimeout=180000;
  Response.AddHeader("pragma", "no-cache");
   }
   else
   {%>
<body onload="Imprime()">
<%}%>
    <form id="form1" runat="server">
    <div>
    
    <table style="width:100%;" border="1">
    <tr>
            <td align="center" class="style17" colspan="2">
                <asp:Label ID="lblTituloPagina" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    <tr>
            <td align="left" class="style17" width="25%">
                Nombre</td>
            <td align="left" class="style17">
                <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    <tr>
            <td align="left" class="style17">
                &nbsp;&nbsp;RUT&nbsp;</td>
            <td align="left" class="style17">
                <asp:Label ID="lblRut" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    <tr>
            <td align="left" class="style17">
                Saldo</td>
            <td align="left" class="style17">
                <asp:Label ID="lblSaldo" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    <tr>
        <td align="center" class="style17" colspan="2">
            <asp:GridView ID="gvVista" runat="server" AutoGenerateColumns="False" 
                Width="100%">
                <Columns>
                    <asp:BoundField DataField="iComprobante" HeaderText="Comprobante" />
                    <asp:BoundField DataField="fMovimiento" HeaderText="Fecha Movimiento" />
                    <asp:BoundField DataField="DescEstadoMov" HeaderText="Tipo Movimiento" />
                    <asp:BoundField DataField="vMonto" HeaderText="Monto" />
                    <asp:BoundField DataField="vSaldo" HeaderText="Saldo" />
                </Columns>
</asp:GridView>
<asp:XmlDataSource ID="xdsVista" runat="server"></asp:XmlDataSource>
        </td>
    </tr>
    <tr>
        <td align="center" class="style17" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="style8" colspan="2">
            <span class="style10" 
                style="font-family: arial, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">
            Andescoop® Ltda.</span></td>
    </tr>
</table>
    
    </div>
    </form>
</body>
</html>
