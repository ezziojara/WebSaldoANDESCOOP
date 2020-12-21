<%@ Page Language="C#" AutoEventWireup="true" Inherits="ImprimeCred" Codebehind="ImprimeCred.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script>
window.print();
</script>
    <title>Página sin título</title>
    <style type="text/css">

        .style7
        {
            font-family: "Arial Black";
            font-size: x-small;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
    <table style="width:100%;">
        <tr>
            <td align="center" class="style17">
                Nombre :
                <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="style17">
&nbsp;&nbsp;&nbsp;&nbsp; RUT&nbsp;&nbsp; :
                <asp:Label ID="lblRut" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="style17">
&nbsp;&nbsp;&nbsp; Saldo :
                <asp:Label ID="lblSaldo" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvCredCuotas" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" Font-Names="Arial" Font-Size="Smaller" ForeColor="#333333" 
    GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="iColocacion" 
                DataNavigateUrlFormatString="CreditoCuotas2.aspx?IColocacion={0}&amp;op=7" 
                DataTextField="iColocacion" HeaderText="Colocacion" />
            <asp:BoundField DataField="fApertura" HeaderText="fApertura" />
            <asp:BoundField DataField="fCierre" HeaderText="fCierre" />
            <asp:BoundField ApplyFormatInEditMode="True" DataField="vMontoTotal" 
                DataFormatString="{0:C}" HeaderText="vMontoTotal" HtmlEncode="False" 
                HtmlEncodeFormatString="False" />
            <asp:BoundField DataField="NombreProducto" HeaderText="NombreProducto" />
            <asp:BoundField ApplyFormatInEditMode="True" DataField="Estado" 
                HeaderText="Estado" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
                <input id="Imprimir" type="button" value="Print" onclick="window.print();"><asp:XmlDataSource ID="xdsCredCuotas" runat="server"></asp:XmlDataSource>
                

--------------------------------------------------------------------------------

            </td>
        </tr>
    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
