<?php
	$server = "localhost";
	$usuario = "root";
	$senha = "";
	$db = "pi";
	$connect = mysqli_connect($server, $usuario, $senha, $db) or die("Erro ao conectar no Banco");
?>