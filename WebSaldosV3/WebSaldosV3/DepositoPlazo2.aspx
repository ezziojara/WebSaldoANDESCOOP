<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="DepositoPlazo2" Title="Página sin título" Codebehind="DepositoPlazo2.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style17" style="width:100%;">
    <tr>
        <td align="center">
            Saldo&nbsp;&nbsp;&nbsp; :
            <asp:Label ID="LblSaldos" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:XmlDataSource ID="xdsDeposito" runat="server" EnableCaching="False"></asp:XmlDataSource>
            <asp:GridView ID="gvDeposito" runat="server" CellPadding="4" 
    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                <RowStyle BackColor="#E3EAEB" />
                <Columns>
                    <asp:BoundField DataField="iComprobanteCaja" HeaderText="Comprobante Caja" />
                    <asp:BoundField DataField="fFechaPago" HeaderText="Fecha Pago" />
                    <asp:BoundField DataField="vMontorMovimiento" HeaderText="Monto Movimiento" />
                    <asp:BoundField DataField="DescTipoMovimiento" 
                        HeaderText="DescTipoMovimiento" />
                    <asp:BoundField DataField="DescEstadoPago" HeaderText="Descripcion" />
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
        </td>
    </tr>
</table>
</asp:Content>

