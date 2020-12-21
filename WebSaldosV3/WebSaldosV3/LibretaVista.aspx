<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="LibretaVista" Title="Libreta Vista" Codebehind="LibretaVista.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
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
            <asp:GridView ID="gvVista" runat="server" CellPadding="4" ForeColor="#333333" 
    GridLines="None" AutoGenerateColumns="False" Width="100%">
    <RowStyle BackColor="#E3EAEB" />
                <Columns>
                    <asp:BoundField DataField="iComprobante" HeaderText="Comprobante" />
                    <asp:BoundField DataField="fMovimiento" HeaderText="Fecha Movimiento" />
                    <asp:BoundField DataField="DescTipoMov" HeaderText="Tipo Movimiento" />
                    <asp:BoundField DataField="vMonto" HeaderText="Monto" />
                    <asp:BoundField DataField="vSaldo" HeaderText="Saldo" />
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
<asp:XmlDataSource ID="xdsVista" runat="server" EnableCaching="False"></asp:XmlDataSource>
            <asp:Label ID="lblSinMovimiento" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

