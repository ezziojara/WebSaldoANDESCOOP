<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="SaldosColocaciones" Title="Saldo Colocaciones" Codebehind="SaldosColocaciones.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;" align="center" class="style4">
    <tr bgcolor="#66CCFF">
        <td align="left" class="style18" bgcolor="#009933">
            Nombre
            </td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="right">
        <td align="left" class="style18" bgcolor="#009933">
            RUT
            </td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblRut" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Fecha</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblFecha" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            &nbsp;</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            &nbsp;</td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Credito en Cuotas</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblCredCuota" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
                        Credito Extraordinario</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblCredExtraor" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Credito Automatico&nbsp; </td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblCredAutomatico" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Castigo </td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblCastigo" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="center" class="style17">
            &nbsp;</td>
        <td class="style17">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" class="style18" bgcolor="#009933">
            Total Colocaciones</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            &nbsp;</td>
        <td align="center">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

