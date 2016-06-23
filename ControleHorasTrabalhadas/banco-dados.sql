-- --------------------------------------------------------
-- Versão do servidor:           5.6.17 - MySQL Community Server (GPL)
-- Criado por bonus630
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Copiando estrutura do banco de dados para controle_horas_trabalhadas
CREATE DATABASE IF NOT EXISTS `controle_horas_trabalhadas` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `controle_horas_trabalhadas`;


-- Copiando estrutura para tabela controle_horas_trabalhadas.funcionarios
CREATE TABLE IF NOT EXISTS `funcionarios` (
  `funcionario_id` int(4) NOT NULL AUTO_INCREMENT,
  `funcionario_nome` varchar(40) NOT NULL DEFAULT '0',
  `funcionario_foto` varchar(60) DEFAULT NULL,
  `funcionario_ativo` char(1) NOT NULL DEFAULT 'y',
  PRIMARY KEY (`funcionario_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1003 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela controle_horas_trabalhadas.funcionarios: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `funcionarios` DISABLE KEYS */;
INSERT IGNORE INTO `funcionarios` (`funcionario_id`, `funcionario_nome`, `funcionario_foto`, `funcionario_ativo`) VALUES
	(1, 'Sistema', '', 'n'),
	(1000, 'admin', '', 'y');
/*!40000 ALTER TABLE `funcionarios` ENABLE KEYS */;


-- Copiando estrutura para tabela controle_horas_trabalhadas.horarios
CREATE TABLE IF NOT EXISTS `horarios` (
  `hora_id` int(11) NOT NULL AUTO_INCREMENT,
  `hora_e` datetime DEFAULT NULL,
  `hora_s` datetime DEFAULT NULL,
  `funcionario_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`hora_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela controle_horas_trabalhadas.horarios: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `horarios` DISABLE KEYS */;
/*!40000 ALTER TABLE `horarios` ENABLE KEYS */;


-- Copiando estrutura para tabela controle_horas_trabalhadas.periodos
CREATE TABLE IF NOT EXISTS `periodos` (
  `periodo_id` int(11) NOT NULL AUTO_INCREMENT,
  `periodo_inicio` datetime DEFAULT NULL,
  `periodo_fim` datetime DEFAULT NULL,
  `periodo_data_pagamento` date DEFAULT NULL,
  `funcionario_id` int(4) DEFAULT '0',
  `periodo_status` char(1) DEFAULT 'n',
  `periodo_valor_hora` decimal(10,2) DEFAULT '0.00',
  PRIMARY KEY (`periodo_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela controle_horas_trabalhadas.periodos: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `periodos` DISABLE KEYS */;
INSERT IGNORE INTO `periodos` (`periodo_id`, `periodo_inicio`, `periodo_fim`, `periodo_data_pagamento`, `funcionario_id`, `periodo_status`, `periodo_valor_hora`) VALUES
	(1, '2015-01-26 17:37:37', NULL, NULL, 1000, 'n', 0.00);
/*!40000 ALTER TABLE `periodos` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
