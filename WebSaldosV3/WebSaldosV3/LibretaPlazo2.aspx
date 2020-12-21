<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="LibretaPlazo2" Title="Detalle Libreta Plazo" Codebehind="LibretaPlazo2.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style19
    {
        font-family: "Arial Black";
        width: 761px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;" class="style17">
    <tr>
        <td align="left" bgcolor="#009933" class="style18">
            Saldo</td>
        <td align="left" bgcolor="#CCFFCC">
            <asp:Label ID="LblSaldos" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" bgcolor="White" class="style18" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <asp:XmlDataSource ID="xdsLibreta" runat="server" EnableCaching="False"></asp:XmlDataSource>
    <asp:GridView ID="gvListaLibreta" runat="server" CellPadding="4" 
    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="100%" HorizontalAlign="Left">
        <RowStyle BackColor="#E3EAEB" />
        <Columns>
            <asp:BoundField DataField="DescTipoMov" HeaderText="TipoMovimiento" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="fFechaPago" HeaderText="Fecha Movimiento" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="vValorMovimiento" HeaderText="Monto" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="vSaldo" HeaderText="Saldo" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="DescEstadoPago" HeaderText="Estado" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="iComprobanteCaja" HeaderText="Comprobante Caja" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#009933" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>

