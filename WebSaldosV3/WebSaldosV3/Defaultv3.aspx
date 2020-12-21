<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defaultv3.aspx.cs" Inherits="Defaultv3" %>

<!DOCTYPE HTML>
<html>
<head>
<meta http-equiv="Expires" content="0" />
<meta http-equiv="Pragma" content="no-cache" />
<meta http-equiv="Cache-Control" content ="no-cache"/>
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

    if (history.forward(1)) {
        location.replace(history.forward(1))
    }

    
        if (window.history) {
        function noBack(){window.history.forward()}
        noBack();
        window.onload=noBack;

        window.onpageshow=function(evt){if(evt.persisted)noBack()}
        window.onunload=function(){void(0)}

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
  
   <asp:TextBox ID="txtIngresoRut"  runat="server"  >85185276</asp:TextBox>
      
    
    <label>Contraseña</label>
   
    <asp:TextBox ID="txtPasword" runat="server" TextMode="Password" ></asp:TextBox></br></br></br>
  
            
  <asp:Button ID="submit" name="submit" runat="server" onclick="btnIngresar_Click"   Text="Aceptar"  />
            
   
  
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
