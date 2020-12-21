<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="CreditoCuotas" Title="Credito Cuotas" Codebehind="CreditoCuotas.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="left" class="style18" bgcolor="#009933" width="25%">
                Saldo
                </td>
            <td align="left" class="style17" width="50%" bgcolor="#CCFFCC">
                <asp:Label ID="lblSaldo" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style18" bgcolor="White" width="25%" colspan="2" 
                style="width: 75%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style17" colspan="2">
                <asp:GridView ID="gvCredCuotas" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" ForeColor="#333333" 
    GridLines="None" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="iColocacion,NombreProducto,cAmortizacion,vAmortizacion" 
                DataNavigateUrlFormatString="CreditoCuotas2.aspx?IColocacion={0}&amp;op=7&amp;Nommbre={1}&amp;cAmortizacion={2}&amp;vAmortizacion={3}" 
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
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#009933" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>
                </td>
        </tr>
        <tr>
            <td align="justify" class="style17">
                <asp:XmlDataSource ID="xdsCredCuotas" runat="server" EnableCaching="False"></asp:XmlDataSource>
                

            </td>
           
        </tr>
        <tr>
            <td colspan="2" align="center" class="style17">
                <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

