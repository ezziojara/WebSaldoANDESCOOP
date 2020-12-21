<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="WebSaldosV3.Castigos" Title="Castigos" Codebehind="Castigos.aspx.cs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
      /* .style13
        {
            font-family: "Arial Black";
            font-size: x-small;
            height: 18px;
        }*/
        .style17
        {
            font-family: "Arial Black";
            font-size: x-small;
            width: 536px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%; ">
        <tr>
            <td align="left" class="style18" bgcolor="#009933">
                Saldo</td>
            <td align="left" class="style17" bgcolor="#CCFFCC">
                <asp:Label ID="lblSaldo" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style18" bgcolor="White" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style17" colspan="2">
                <asp:GridView ID="gvCredCuotas" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" ForeColor="#333333" 
    GridLines="None" Width="100%">
        <RowStyle BackColor="#E3EAEB" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="iColocacion,NombreProducto,cAmortizacion" 
                DataNavigateUrlFormatString="Castigos2.aspx?IColocacion={0}&amp;op=7&amp;Nommbre={1}&amp;cAmortizacion={2}" 
                DataTextField="iColocacion" HeaderText="Numero Credito" />
            <asp:BoundField DataField="fCierre" HeaderText="Fecha de Cierre" />
            <asp:BoundField ApplyFormatInEditMode="True" DataField="vMontoTotal" 
                DataFormatString="{0:C}" HeaderText="Monto Credito" HtmlEncode="False" 
                HtmlEncodeFormatString="False" />
            <asp:BoundField DataField="NombreProducto" HeaderText="NombreProducto" />
            <asp:BoundField ApplyFormatInEditMode="True" DataField="Estado" 
                HeaderText="Estado" />
            <asp:BoundField DataField="cAmortizacion" Visible="False" />
        </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#009933" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>
                <asp:XmlDataSource ID="xdsCredCuotas" runat="server" EnableCaching="False"></asp:XmlDataSource>
                

            </td>
        </tr>
        <tr>
            <td align="center" class="style17" colspan="2">
                <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
                

            </td>
        </tr>
</table>
</asp:Content>

