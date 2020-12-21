<%@ Page Language="C#" AutoEventWireup="true" Inherits="Impresion_SaldosCaptacionesPrint" Codebehind="SaldosCaptacionesPrint.aspx.cs" %>

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

        .style4
        {
            font-family: Arial;
            font-size: small;
        }
         .style18
        {
            font-family: "Arial Black";
            font-size: x-small;
            color: #FFFFFF;
        }
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
    
        <table style="width:80%;" align="center" class="style4" border="1">
    <tr bgcolor="#66CCFF">
        <td align="center" class="style18" bgcolor="#009933" width="40%" colspan="2">
            <asp:Label ID="lblTituloPagina" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr bgcolor="#66CCFF">
        <td align="left" class="style18" bgcolor="White" width="40%">
            &nbsp;</td>
        <td align="left" class="style17" bgcolor="White">
            &nbsp;</td>
    </tr>
    <tr bgcolor="#66CCFF">
        <td align="left" class="style18" bgcolor="#009933" width="40%">
            Nombre</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="right">
        <td align="left" class="style18" bgcolor="#009933">
            RUT</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblRut" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Fecha</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblFecha" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="White">
            &nbsp;</td>
        <td align="left" class="style17" bgcolor="White">
            &nbsp;</td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Saldo Capital</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblSaldoCapital" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Saldo Libreta Vista</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblLibretaVista" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Saldos Libreta Plazo</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblLibretaPlazo" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Saldo Deposito Plazo</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblDeposito" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="center" class="style17">
            &nbsp;</td>
        <td class="style17">
            &nbsp;</td>
    </tr>
    <tr bgcolor="#F4F4F4">
        <td align="left" class="style18" bgcolor="#009933">
            Total Colocaciones :
        </td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2" class="style8">
            <span class="style10" 
                style="font-family: arial, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">
            Andescoop® Ltda.</span></td>
    </tr>
</table>
    
    </div>
    </form>
</body>
</html>
