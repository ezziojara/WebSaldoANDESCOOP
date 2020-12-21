<%@ Page Language="C#" AutoEventWireup="true" Inherits="Impresion_LibretaPlazo2Print" Codebehind="LibretaPlazo2Print.aspx.cs" %>

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
            height: 9px;
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
    
        <table style="width:100%;" class="style17" border="1">
    <tr>
        <td align="center" class="style3" width="50%" colspan="2">
            <asp:Label ID="lblTituloPagina" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" class="style3" width="25%">
            &nbsp;Nombre :</td>
        <td align="left" class="style3" width="75%">
            <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" class="style8">
            &nbsp;Rut&nbsp; :</td>
        <td align="left" class="style8">
            <asp:Label ID="lblRut" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left">
            Saldo&nbsp;:</td>
        <td align="left">
            <asp:Label ID="LblSaldos" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:XmlDataSource ID="xdsLibreta" runat="server"></asp:XmlDataSource>
    <asp:GridView ID="gvListaLibreta" runat="server" AutoGenerateColumns="False" 
                Width="100%">
        <Columns>
            <asp:BoundField DataField="DescTipoMov" HeaderText="TipoMovimiento" />
            <asp:BoundField DataField="fFechaPago" HeaderText="Fecha Movimiento" />
            <asp:BoundField DataField="vValorMovimiento" HeaderText="Monto" />
            <asp:BoundField DataField="vSaldo" HeaderText="Saldo" />
            <asp:BoundField DataField="DescEstadoPago" HeaderText="Estado" />
        </Columns>
    </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <span class="style10" 
                style="font-family: arial, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">
            Andescoop® Ltda.</span></td>
    </tr>
</table>
    
    </div>
    </form>
</body>
</html>
