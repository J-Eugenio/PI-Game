SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  `nome` varchar(120) NOT NULL,
  `sobrenome` varchar(150) NOT NULL,
  `idade` int(11) NOT NULL,
  `login` varchar(12)  NOT NULL,
  `senha` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
CREATE TABLE `pontuacao` (
	`idPontuacao` INT PRIMARY KEY AUTO_INCREMENT,
	`fase` VARCHAR (10),
	`qtdMonstro` INT(2),
	`pontuacao` INT (4),
	`pontuacaoPuzzle` INT (4),
	`tentativasPuzzle` INT (2),
	idUsuario INT
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

ALTER TABLE `pontuacao` ADD CONSTRAINT `idUsuario_id` FOREIGN KEY (`idUsuario`) REFERENCES `usuarios`(`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;