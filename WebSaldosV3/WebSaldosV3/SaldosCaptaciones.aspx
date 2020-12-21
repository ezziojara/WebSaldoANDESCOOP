<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="SaldosCaptaciones" Title="Saldos Captaciones" Codebehind="SaldosCaptaciones.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;" align="center" class="style4">
    <tr bgcolor="#66CCFF">
        <td align="left" class="style18" bgcolor="#009933" width="25%">
            Nombre</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="right">
        <td align="left" class="style18" bgcolor="#009933">
            RUT</td>
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
        <td align="left" class="style18" bgcolor="White">
            &nbsp;</td>
        <td align="left" class="style17" bgcolor="White">
            &nbsp;</td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Saldo Capital</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblSaldoCapital" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Saldo Libreta Vista</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblLibretaVista" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Saldos Libreta Plazo</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblLibretaPlazo" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="left" class="style18" bgcolor="#009933">
            Saldo Deposito Plazo</td>
        <td align="left" class="style17" bgcolor="#F4F4F4">
            <asp:Label ID="lblDeposito" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr align="center">
        <td align="center" class="style17">
            &nbsp;</td>
        <td class="style17">
            &nbsp;</td>
    </tr>
    <tr bgcolor="#F4F4F4">
        <td align="left" class="style18" bgcolor="#009933">
            Total Captaciones :
        </td>
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

