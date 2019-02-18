<?php
	require_once '../conexao/conexao.php';
	
	$login = mysqli_escape_string($connect, $_GET['login']);
	$senha = mysqli_escape_string($connect, $_GET['senha']);
	$senha = md5($senha);

	$sql = mysqli_query($connect,"SELECT * FROM usuarios WHERE login = '$login' AND senha = '$senha'") or die("Erro ao execultar consulta");
	if($sql){
		$dados = mysqli_num_rows($sql);
		if($dados == 1){
			echo '1';
		}else{
			echo '0';
		}
	}

	mysqli_close($connect);
?>