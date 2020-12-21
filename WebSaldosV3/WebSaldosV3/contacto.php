<?php

$nombre = $_POST['nombre'];
$apellido = $_POST['apellido'];
$email = $_POST['email'];
$telefono = $_POST['telefono'];
$empresa = $_POST['empresa'];
$mensaje = $_POST['mensaje'];
$from = 'www.aeroinca.cl';
$to = 'contacto@andescoop.cl';
$subject = 'Se ha enviado un mensaje';

$body = "Enviado por: $nombre\n E-Mail: $email\n Telefono: $telefono\n Mensaje:\n $mensaje";

if ($_POST['submit']) {
if (mail ($to, $subject, $body, $from)) {
echo '

Tu mensaje se ha enviado

';
} else {
echo '

Algo no está bien. Intentalo de nuevo

';
}
}
  ?>