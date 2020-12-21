<%@ Page Language="C#" AutoEventWireup="true" Inherits="Error" Codebehind="Error.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página Error</title>
    <style type="text/css">
        .style1
        {
            font-size: x-large;
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p class="style1">
        Error en la pagina</p>
    <p class="style1">
        <asp:TextBox ID="txtError" runat="server" Height="290px" Width="757px"></asp:TextBox>
    </p>
    <div>
    
    </div>
    <asp:Button ID="btnVolver" runat="server" onclick="btnVolver_Click" 
        Text="Volver" />
    </form>
</body>
</html>
