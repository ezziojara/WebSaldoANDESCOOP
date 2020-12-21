<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioPaswordV3.aspx.cs" Inherits="CambioPaswordV3" %>

<!DOCTYPE HTML>
<html>
<head>
<meta charset="UTF-8">
<title>Andescoop</title>
<link rel="stylesheet" type="text/css" href="online.css">
<script type="text/javascript">
    function MensageTransaccionRuta(mensaje, ruta) {
        alert(mensaje);
        window.location = ruta;
    }
    function MensageTransaccion(mensaje) {
        alert(mensaje);

    }

    </script>

</head>

<body>

<div id="contenedor">
	<header>
     <img src="imagenes/header.gif"></header>
  
    
    <div id="online">
    <div id="banner">
    <img src="imagenes/online.png">
    
    </div><!-- fin cabecera -->
     
    <div class="central">
    

 <center><h3>DATOS DEL USUARIO</h3></center>
<form id="form1" runat="server">
     <center>   
    <label>Usuario</label>
  
   <asp:TextBox ID="lblRut"  runat="server"  >85185276</asp:TextBox>
      
    
    <label>Contraseña</label>
   
    <asp:TextBox ID="txtPasword" runat="server" TextMode="Password"></asp:TextBox></br></br></br>

     <label>Nueva Contraseña</label>
     <asp:TextBox ID="txtPaswordCambio1" runat="server" TextMode="Password"></asp:TextBox></br></br></br>

     <label>Repita Contraseña</label>
     <asp:TextBox ID="txtPaswordCambio2" runat="server" TextMode="Password" ></asp:TextBox></br></br></br>
  
  
      <asp:Button ID="submit" name="submit" runat="server" onclick="btnModificar_Click" 
                    Text="Cambiar Password" />
            
   
  
     </center>   
</form>
	<br>
	<%--<a href="#">Si olvidaste tu contraseña click acá</a>--%>
    </div>


    
    <footer>
    Copyright &copy; 2014. Todos los derechos reservados Andescoop Ltda. Diseñado por Oligrafic S.A. <br/>
    OFICINAS: Casa Matriz, Las Heras #358 Los Andes - La Ligua, Diego Portales #738 La Ligua - San Felipe, Salinas #982 San Felipe -  Silva #275 Petorca. 
    </footer>


    
    </div>
    
</div>


</body>

</html>
