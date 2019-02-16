<?php
	require_once '../conexao/conexao.php';
	$senha = md5("Admin");
	$sql = "INSERT INTO usuarios(nome, sobrenome, idade, login, senha) VALUES('test', 'silva', 12, 'Admin', '$senha')";
	$insert = mysqli_query($connect, $sql);
	mysqli_close($connect);
?>