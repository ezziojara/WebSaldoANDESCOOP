<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="CreditoAutomatico" Title="Credito Automatico" Codebehind="CreditoAutomatico.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style17" style="width:100%;">
    <tr>
        <td align="left" bgcolor="#009933" class="style18">
            Saldo</td>
        <td align="left" bgcolor="#CCFFCC">
            <asp:Label ID="LblSaldos" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
<asp:XmlDataSource ID="xdsAutomatico" runat="server" EnableCaching="False"></asp:XmlDataSource>
            <asp:GridView ID="gvAutomatico" runat="server" CellPadding="4" 
    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="100%">
    <RowStyle BackColor="#E3EAEB" />
                <Columns>
                    <asp:BoundField DataField="iCuenta" HeaderText="Cuenta" />
                    <asp:BoundField DataField="vCupo" HeaderText="Cupo" />
                    <asp:BoundField DataField="vCupoUtilizado" HeaderText="Cupo Utilizado" />
                    <asp:BoundField DataField="vCupoDisponible" HeaderText="Cupo Disponible" />
                    <asp:BoundField DataField="fFechaActivacion" HeaderText="Fecha Activacion" />
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
        <td align="center" colspan="2">
            <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

