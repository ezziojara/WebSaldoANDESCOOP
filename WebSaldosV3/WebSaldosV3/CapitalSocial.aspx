<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="CapitalSocial" Title="Capital Social" Codebehind="CapitalSocial.aspx.cs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
    <style type="text/css">
        .style20
        {
            height: 23px;
        }
        .style21
        {
            font-family: "Arial Black";
            font-size: small;
            color: #FFFFFF;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;" class="style17" >
    <tr align="left">
        <td align="left" bgcolor="#009933" class="style18">
            Saldo&nbsp;</td>
        <td align="left" bgcolor="#CCFFCC">
            <asp:Label ID="LblSaldos" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="left">
        <td align="left" bgcolor="White" class="style18" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="justify" colspan="2" width="100%">
<asp:XmlDataSource ID="XmlDSCapital" runat="server" EnableCaching="False"></asp:XmlDataSource>
    <asp:GridView ID="gvCapitalSocial" runat="server" Width="100%" 
    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
                Font-Strikeout="False">
        <RowStyle BackColor="#E3EAEB" />
    <Columns>
        <asp:BoundField DataField="cComprobante" HeaderText="Comprobante" 
            SortExpression="cComprobante" />
        <asp:BoundField DataField="tTipoMov" HeaderText="Tipo Movimiento" />
        <asp:BoundField DataField="fMovCapital" HeaderText="Fecha" />
        <asp:BoundField DataField="vMonto" HeaderText="Monto" />
        <asp:BoundField DataField="vSaldo" HeaderText="Saldo" />
        <asp:BoundField DataField="tEstado" HeaderText="Estado" />
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
    <tr>
        <td colspan="2" align="center">
            <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>


