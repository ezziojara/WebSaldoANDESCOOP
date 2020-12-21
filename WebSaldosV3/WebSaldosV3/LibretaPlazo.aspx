<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="LibretaPlazo" Title="Libreta Plazo" Codebehind="LibretaPlazo.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  style="width:100%;" class="style17">
    <tr>
        <td>
            <table style="width:100%;" >
    <tr>
        <td align="left" bgcolor="#009933" class="style18">
            Saldo</td>
        <td align="left" bgcolor="#CCFFCC" class="style17">
            <asp:Label ID="LblSaldos" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" bgcolor="White" class="style18" colspan="2">
            &nbsp;</td>
    </tr>
</table>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center">
            <asp:XmlDataSource ID="xdsLibreta" runat="server" EnableCaching="False"></asp:XmlDataSource>
    <asp:GridView ID="gvListaLibreta" runat="server" CellPadding="4" GridLines="None" 
                AutoGenerateColumns="False" Width="100%" ForeColor="#333333">
        <RowStyle BackColor="#E3EAEB" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="iCuenta" 
                DataNavigateUrlFormatString="LibretaPlazo2.aspx?iCuenta={0}" 
                DataTextField="iCuenta" HeaderText="Cuenta" />
            <asp:BoundField DataField="NombreProducto" HeaderText="Nombre Producto" />
            <asp:BoundField DataField="fApertura" HeaderText="Fecha Apertura" />
            <asp:BoundField DataField="DescEstadoCuenta" HeaderText="Estado" />
            <asp:BoundField DataField="vSaldoLibreta" HeaderText="Saldo Libreta" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#009933" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
            <br />
                <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

