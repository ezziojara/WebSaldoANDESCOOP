<%@ Page Language="C#" AutoEventWireup="true" Inherits="WebSaldosV3.CambioPasword" Codebehind="CambioPasword.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ingreso Socio</title>
      <script type="text/javascript">
          function MensageTransaccionRuta(mensaje, ruta) {
              alert(mensaje);
              window.location = ruta;
          }
          function MensageTransaccion(mensaje) {
              alert(mensaje);

          }

    </script>
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
        .style11
        {
            font-size: small;
            color: #FFFFFF;
            height: 26px;
            border-left-color: #ACA899;
            border-right-color: #C0C0C0;
            border-top-color: #ACA899;
            border-bottom-color: #C0C0C0;
        }
        .style12
        {
            height: 13px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
     <table style="width:60%;">
     <tr>
     <td align="center">
         <asp:ImageButton ID="ImageButton1" runat="server" 
             ImageUrl="~/imagenes/cabeceraconcredito.png" Width="400px" Height="91px" />
         </td>
     </tr>
    <tr><td>
        <table align="center" class="style8" style="width:60%;" bgcolor="#3C8AAF" 
        cellpadding="0" cellspacing="0">
            <tr>
                <td class="style6" align="center" colspan="2">
                    <span class="style11">Modificación Password</span>
                    </td>
            </tr>
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
                    
                &nbsp;</td>
                <td>
                    <asp:Label ID="lblRut" runat="server" ForeColor="#FFFFCC" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <span class="style9">&nbsp;&nbsp; </span></td>
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
                <td align="right" class="style12">
                </td>
                <td class="style12">
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" 
                        Text="Ingrese Password Nueva&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;" 
                        ForeColor="#FFFFCC"></asp:Label>
                </td>
                <td class="style8">
                <asp:TextBox ID="txtPaswordCambio1" runat="server" TextMode="Password" 
                        Width="110px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label4" runat="server" 
                        Text="Repita Password Nueva&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;" 
                        ForeColor="#FFFFCC"></asp:Label>
                </td>
                <td class="style8">
                <asp:TextBox ID="txtPaswordCambio2" runat="server" TextMode="Password" 
                        Width="110px"></asp:TextBox>
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
                <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                    Text="Cambiar Password" Width="94px" BackColor="#336600" Font-Names="Arial Black" 
                        Font-Size="Smaller" ForeColor="White" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
        </td></tr>
   
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
        <tr><td>
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

    </td>
    </tr>
    </table>

     </form>
</body>
</html>
