<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Castigo2" Title="Detalle Castigo" Codebehind="Castigos2.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style10
    {
        font-family: "Arial Black";
        font-size: x-small;
        height: 181px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td align="left" class="style18" bgcolor="#009933">
                            &nbsp;Saldo</td>
                        <td align="left" class="style17" bgcolor="#CCFFCC">
                            <asp:Label ID="lblSaldo" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style18" bgcolor="#009933">
                            Numero Credito</td>
                        <td align="left" class="style17" bgcolor="#CCFFCC">
                            <asp:Label ID="lblnCredito" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style18" bgcolor="#009933">
                            TipoCredito</td>
                        <td align="left" class="style17" bgcolor="#CCFFCC">
                            <asp:Label ID="lblTipoCredito" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style18" bgcolor="#009933">
                            Frecuencia de Cuotas</td>
                        <td align="left" class="style17" bgcolor="#CCFFCC">
                            <asp:Label ID="lblFrecuencia" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style18" bgcolor="White" colspan="2">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" class="style17">
                <asp:XmlDataSource ID="xdsCredCuotas1" runat="server" EnableCaching="False">
                </asp:XmlDataSource>
                <asp:GridView ID="gvCredCuotas1" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" ForeColor="#333333" 
    GridLines="None" Width="100%">
                    <RowStyle BackColor="#E3EAEB" />
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
                <br />
                <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
                

            </td>
        </tr>
    </table>
</asp:Content>

