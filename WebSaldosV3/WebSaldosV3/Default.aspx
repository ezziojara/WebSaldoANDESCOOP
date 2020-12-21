<%@ Page Language="C#" AutoEventWireup="true" Inherits="IngresoSocio" Codebehind="Default.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<% if (Request.QueryString["cerrarpagina"] == "si")
   {%>
    
 <script type="text/javascript">
     window.close();
 </script>
  
 <% } %>

 <script type="text/javascript">
     function MensageTransaccionRuta(mensaje, ruta) {
         alert(mensaje);
         window.location = ruta;
     }
     function MensageTransaccion(mensaje) {
         alert(mensaje);

     }

    </script>
 <head runat="server">
    <title>Ingreso Socio</title>
    <style type="text/css">
         .style8
        {
            font-family: "Arial Black";
            font-size: x-small;
        }
        .style6
        {
            height: 26px;
        }
        .style7
        {
            height: 29px;
             font-family: "Arial Black";
            font-size: x-small;
        }
        .style9
        {
            color: #FFFFFF;
        }
        .style10
        {
            height: 29px;
            font-family: Arial;
            font-size: x-small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table width="30%" align="center"><tr><td>
     <table style="width:100%;">
     <tr>
     <td>
         <asp:ImageButton ID="ImageButton1" runat="server" 
             ImageUrl="~/imagenes/cabeceraconcredito.png" Width="100%" 
             Height="101px" />
         </td>
     </tr>
     </table>
        <table align="center" class="style8" style="width:100%;" bgcolor="#3C8AAF" 
        cellpadding="0" cellspacing="0">
            <tr>
                <td class="style17">
                    </td>
                <td class="style17">
                    </td>
            </tr>
            <tr>
             
                <td align="right" class="style6">
                    <asp:Label ID="Label1" runat="server" 
                        Text="Ingrese RUT&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;" ForeColor="#CCFFCC"></asp:Label>
                    </font>
                &nbsp;</td>
                <td>
                <asp:TextBox ID="txtIngresoRut"  runat="server"  Width="110px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <span class="style9">&nbsp;&nbsp; (ej</span> <span class="style9">126859457)</span></td>
            </tr>
            <tr>
                <td align="right" class="style6">
                    <asp:Label ID="Label2" runat="server" 
                        Text="Ingrese Password&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;" 
                        ForeColor="#FFFFCC"></asp:Label>
                </td>
                <td class="style6">
                <asp:TextBox ID="txtPasword" runat="server" TextMode="Password" Width="110px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style8">
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnIngresar" runat="server" onclick="btnIngresar_Click" 
                    Text="Ingresar" Width="94px" BackColor="#006699" Font-Names="Arial Black" 
                        Font-Size="Smaller" ForeColor="White" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                
            </tr>
        </table>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center" class="style10">
                ®2011 - Todos los derechos reservados.</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    </td></tr></table>
</body>
</html>
