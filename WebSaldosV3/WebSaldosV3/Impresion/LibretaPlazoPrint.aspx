<%@ Page Language="C#" AutoEventWireup="true" Inherits="Impresion_LibretaPlazoPrint" Codebehind="LibretaPlazoPrint.aspx.cs" %>

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
        .style3
        {
            font-family: "Arial Black";
        }
        .style8
        {
            width: 7px;
        }
        .style9
        {
            height: 18px;
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
    
    <table class="style17" style="width:100%;">
    <tr>
        <td>
            <table style="width:100%;" class="style17" border="1">
    <tr>
        <td align="center" class="style3" colspan="2" width="25%">
            <asp:Label ID="lblTituloPagina" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" class="style3" width="25%">
            Nombre</td>
        <td align="left" class="style3" width="75%">
            <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" class="style9">
            Rut</td>
        <td align="left" class="style9">
            <asp:Label ID="lblRut" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left">
            Saldo</td>
        <td align="left">
            <asp:Label ID="LblSaldos" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:XmlDataSource ID="xdsLibreta" runat="server" EnableCaching="False"></asp:XmlDataSource>
    <asp:GridView ID="gvListaLibreta" runat="server" AutoGenerateColumns="False" 
                Width="100%">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="iCuenta" 
                DataNavigateUrlFormatString="LibretaPlazo2.aspx?iCuenta={0}" 
                DataTextField="iCuenta" HeaderText="Cuenta" />
            <asp:BoundField DataField="NombreProducto" HeaderText="Nombre Producto" />
            <asp:BoundField DataField="fApertura" HeaderText="Fecha Apertura" />
            <asp:BoundField DataField="DescEstadoCuenta" HeaderText="Estado" />
            <asp:BoundField DataField="vSaldoLibreta" HeaderText="Saldo Libreta" />
        </Columns>
    </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="center">
            <span class="style10" 
                style="font-family: arial, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">
            Andescoop® Ltda.</span></td>
    </tr>
</table>
    
    </div>
    </form>
</body>
</html>
