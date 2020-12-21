<%@ Page Language="C#" AutoEventWireup="true" Inherits="Impresion_CredExtraordinario2Print" Codebehind="CredExtraordinario2Print.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    
    </div>
    <table style="width:100%;">
    <tr>
        <td>
            <table style="width:100%;" align="left" border="1">
        <tr>
            <td align="center" class="style17" colspan="2" width="25%">
                <asp:Label ID="lblTituloPagina" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style17" width="25%">
                Nombre</td>
            <td align="left" class="style17" width="75%">
                <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style17">
                RUT</td>
            <td align="left" class="style17">
                <asp:Label ID="lblRut" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr align="left">
            <td align="left" class="style17">
                Saldo</td>
            <td align="left" class="style17">
                <asp:Label ID="lblSaldo" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style17">
                Numero Credito</td>
            <td align="left" class="style17">
                <asp:Label ID="lblnCredito" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style17">
                TipoCredito</td>
            <td align="left" class="style17">
                <asp:Label ID="lblTipoCredito" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style17">
                Frecuencia de Cuotas</td>
            <td align="left" class="style17">
                <asp:Label ID="lblFrecuencia" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
        </td>
    </tr>
    <tr>
        <td align="center" class="style17">
<asp:XmlDataSource ID="xdsCredCuotas1" runat="server" EnableCaching="False"></asp:XmlDataSource>
            <asp:GridView ID="gvCredCuotas1" runat="server" AutoGenerateColumns="False" 
                Width="100%">
    <Columns>
        <asp:BoundField DataField="cCuota" HeaderText="Numero de Cuota" />
        <asp:BoundField DataField="fVencimiento" HeaderText="Fecha Vencimiento" />
        <asp:BoundField DataField="vValorCuota" HeaderText="Monto Cuota" />
        <asp:BoundField DataField="vCapitalPagado" HeaderText="Capital" />
        <asp:BoundField DataField="vInteres" HeaderText="Interes" />
        <asp:BoundField DataField="vInteresMoratorio" HeaderText="Interes Moratorio" />
        <asp:BoundField DataField="vGastoCobranza" HeaderText="Interes Penal" />
        <asp:BoundField DataField="DescEstadoCuota" HeaderText="Estado Cuota" />
        <asp:BoundField DataField="vValorCuotaUF" HeaderText="Monto Total" />
    </Columns>
</asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="center" class="style17">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="style17">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="style8">
            <span class="style10" 
                style="font-family: arial, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">
            Andescoop® Ltda.</span></tr>
</table>
    </form>
</body>
</html>
