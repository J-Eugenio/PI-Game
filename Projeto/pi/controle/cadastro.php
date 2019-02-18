<?php
	require_once '../conexao/conexao.php';
	$nome = mysqli_escape_string($connect, $_GET['nome']);
	$sobrenome = mysqli_escape_string($connect, $_GET['sobrenome']);
	$idade = mysqli_escape_string($connect, $_GET['idade']);
	$login = mysqli_escape_string($connect, $_GET['login']);
	$senha = mysqli_escape_string($connect, $_GET['senha']);
	$senha = md5($senha);
	$sql = "INSERT INTO usuarios(nome, sobrenome, idade, login, senha) VALUES('$nome', '$sobrenome', '$idade', '$login', '$senha')";
	$insert = mysqli_query($connect, $sql);
	if($insert){
		echo '1';
	}else{
		echo '0';
	}
	mysqli_close($connect);
?>