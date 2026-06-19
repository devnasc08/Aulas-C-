-- MySQL dump 10.13  Distrib 8.0.44, for Win64 (x86_64)
--
-- Host: 10.91.47.67    Database: flow_academy
-- ------------------------------------------------------
-- Server version	5.5.5-10.11.14-MariaDB-0+deb12u2

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alerta_risco`
--

DROP TABLE IF EXISTS `alerta_risco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alerta_risco` (
  `id_alerta` int(11) NOT NULL AUTO_INCREMENT,
  `id_matricula` int(11) NOT NULL,
  `tipo_risco` enum('nota','frequencia','ambos') NOT NULL,
  `score` decimal(5,2) NOT NULL,
  `status` enum('pendente','analisado','arquivado') DEFAULT 'pendente',
  PRIMARY KEY (`id_alerta`),
  KEY `id_matricula` (`id_matricula`),
  CONSTRAINT `alerta_risco_ibfk_1` FOREIGN KEY (`id_matricula`) REFERENCES `matriculas` (`id_matricula`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alerta_risco`
--

LOCK TABLES `alerta_risco` WRITE;
/*!40000 ALTER TABLE `alerta_risco` DISABLE KEYS */;
/*!40000 ALTER TABLE `alerta_risco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alunos`
--

DROP TABLE IF EXISTS `alunos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alunos` (
  `id_aluno` int(11) NOT NULL AUTO_INCREMENT,
  `id_usuario` int(11) NOT NULL,
  `matricula` varchar(30) NOT NULL,
  `cpf` varchar(14) NOT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `data_nascimento` date DEFAULT NULL,
  `endereco` varchar(255) DEFAULT NULL,
  `status_academico` enum('regular','trancado','jubilado','evadido') DEFAULT 'regular',
  PRIMARY KEY (`id_aluno`),
  UNIQUE KEY `id_usuario` (`id_usuario`),
  UNIQUE KEY `matricula` (`matricula`),
  UNIQUE KEY `cpf` (`cpf`),
  CONSTRAINT `alunos_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alunos`
--

LOCK TABLES `alunos` WRITE;
/*!40000 ALTER TABLE `alunos` DISABLE KEYS */;
INSERT INTO `alunos` VALUES (1,8,'2026-0014','123.456.789-10','(11) 98888-1015','2006-03-18','Rua das Palmeiras, 120','regular'),(2,9,'2026-0021','987.654.321-10','(11) 97777-2020','2006-03-18','Rua das Palmeiras, 120','regular'),(3,10,'2026-8238','899.543.201-79','(11) 96584-2885','2007-02-12','rua irineu 225','regular'),(4,11,'2026-7101','014.725.896-35','(15) 2102-7293','2004-09-18','rua berim 134','regular'),(5,13,'2026-4681','111.222.333-44','(11) 9999-8787','2007-12-21','rua irineu 226','regular'),(6,14,'2026-4888','986.532.147-55','(11) 91111-2335','2006-08-29','Rua leandro leo 959','regular'),(7,18,'2026-4745','753.951.456-25','(11) 97825-6984','2008-11-19','rua xavis 2','regular'),(8,21,'2026-4110','159.753.981-54','(11) 97475-8123','2000-12-10','Rua Lucas xaves 123','regular');
/*!40000 ALTER TABLE `alunos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cursos`
--

DROP TABLE IF EXISTS `cursos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cursos` (
  `id_curso` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(120) NOT NULL,
  `descricao` text DEFAULT NULL,
  `carga_horaria` int(11) NOT NULL,
  `status` enum('ativo','inativo') DEFAULT 'ativo',
  PRIMARY KEY (`id_curso`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cursos`
--

LOCK TABLES `cursos` WRITE;
/*!40000 ALTER TABLE `cursos` DISABLE KEYS */;
INSERT INTO `cursos` VALUES (1,'Tecnico em Informatica','Curso tecnico com foco em sistemas web e banco de dados.',1200,'ativo'),(2,'Tecnico em Administração','Você aprenderá sobre gestão de recursos humanos, financeiros e materiais, atuando com ações de planejamento estratégico, logística, marketing, finanças e gestão da qualidade.',1200,'ativo'),(3,'Técnico em Contabilidade','Você aprenderá a auxiliar em rotinas contábeis, processos fiscais e patrimoniais, atuando com demandas financeiras, trabalhistas e previdenciárias.',1000,'ativo'),(4,'Técnico em Estética','Você aprenderá a realizar procedimentos faciais e corporais, avaliar as condições da pele e usar as técnicas mais adequadas para cada caso.',1200,'ativo'),(5,'Tecnico em enfermagem','Você aprenderá a promover a recuperação da saúde, administrar medicamentos, monitorar as condições clínicas e prestar cuidados de higiene, conforto e segurança de pacientes.',1200,'ativo'),(6,'Técnico em Finanças','Você aprenderá diferentes tipos de rotinas financeiras, realizando planejamentos, relatórios e orçamentos.',800,'ativo'),(7,'Técnico em Computação Gráfica','Você aprenderá a desenvolver projetos gráficos, criar e gerar conteúdo audiovisual, fazer desenho técnico 2D, modelagem 3D, usando ferramentas de animação e edição de vídeos.',1000,'ativo');
/*!40000 ALTER TABLE `cursos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disciplinas`
--

DROP TABLE IF EXISTS `disciplinas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disciplinas` (
  `id_disciplina` int(11) NOT NULL AUTO_INCREMENT,
  `id_curso` int(11) NOT NULL,
  `nome` varchar(120) NOT NULL,
  `carga_horaria` int(11) NOT NULL,
  PRIMARY KEY (`id_disciplina`),
  KEY `id_curso` (`id_curso`),
  CONSTRAINT `disciplinas_ibfk_1` FOREIGN KEY (`id_curso`) REFERENCES `cursos` (`id_curso`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=97 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disciplinas`
--

LOCK TABLES `disciplinas` WRITE;
/*!40000 ALTER TABLE `disciplinas` DISABLE KEYS */;
INSERT INTO `disciplinas` VALUES (1,1,'Logica de programacao',80),(2,1,'Banco de dados',80),(3,1,'Projeto Integrador',100),(4,2,'Auxiliar na elaboração, implementação e acompanhamento do planejamento estratégico',60),(5,2,'Auxiliar na estruturação e operacionalização de projetos',60),(6,2,'Executar atividades de suporte aos processos de recrutamento, seleção e integração de pessoas',60),(7,2,'Executar atividades de suporte à elaboração de planos de cargos e salários e ao desenvolvimento de pessoas',60),(8,2,'Executar ações relacionadas à qualidade de vida, saúde e segurança nos ambientes de trabalho',60),(9,2,'Executar atividades de suporte aos processos de admissão e demissão de pessoas',60),(10,2,'Acompanhar e executar cálculos trabalhistas',60),(11,2,'Executar atividades de suporte aos processos logísticos de gestão de materiais',60),(12,2,'Executar atividades de suporte aos processos logísticos de distribuição',60),(13,2,'Apoiar na operacionalização de ações de comércio exterior',60),(14,2,'Executar atividades de suporte às ações de marketing',60),(15,2,'Executar atividades de suporte aos processos comerciais',60),(16,2,'Executar o processo de análise de crédito e cobrança',60),(17,2,'Executar os processos referentes à tesouraria, contas a pagar e receber',60),(18,2,'Executar atividades de suporte à gestão de custos e precificação',60),(19,2,'Executar atividades de suporte à gestão da qualidade',60),(20,3,'Apoiar os processos contábeis no planejamento organizacional',60),(21,3,'Executar atividades de suporte aos processos de abertura, alteração e baixa de empresas',60),(22,3,'Executar rotinas de apoio à escrituração contábil',60),(23,3,'Executar processos fiscais e tributários',60),(24,3,'Apurar e calcular custos',60),(25,3,'Executar rotinas financeiras',60),(26,3,'Executar rotinas trabalhistas e previdenciárias',60),(27,3,'Executar rotinas de apoio aos processos de controladoria',60),(28,3,'Projeto Integrador: Técnico em Contabilidade',60),(29,4,'Realizar atividades administrativas para o trabalho em estética',60),(30,4,'Organizar o ambiente de trabalho em estética',60),(31,4,'Estabelecer estratégias de relacionamento com os clientes de estética',60),(32,4,'Avaliar as condições de saúde e hábitos de vida do cliente para a área de estética',60),(33,4,'Combinar cosméticos para uso em estética',60),(34,4,'Realizar avaliação estética facial do cliente',60),(35,4,'Realizar procedimentos para reduzir a secreção sebácea da pele da face',60),(36,4,'Realizar procedimentos estéticos faciais de renovação celular da pele',60),(37,4,'Realizar procedimentos estéticos para prevenir e amenizar o processo de formação de manchas na pele da face',60),(38,4,'Realizar procedimentos faciais em estética',60),(39,4,'Realizar avaliação estética corporal do cliente',60),(40,4,'Realizar procedimentos de relaxamento e bem-estar corporal em estética',60),(41,4,'Realizar procedimentos estéticos que favoreçam a redução da gordura subcutânea e fibro edema gelóide',60),(42,4,'Realizar procedimentos estéticos que estimulem as fibras colágenas, elásticas e o tônus muscular',60),(43,4,'Realizar procedimentos corporais em estética',60),(44,4,'Prática Profissional em Estética',60),(45,4,'Projeto Integrador: Técnico em Estética',60),(46,5,'Executar ações de prevenção, promoção, proteção, reabilitação e recuperação da saúde',60),(47,5,'Participar da implementação da sistematização da assistência de enfermagem',60),(48,5,'Administrar medicamentos, soluções e imunobiológicos',60),(49,5,'Estágio Profissional Supervisionado: promoção à saúde',60),(50,5,'Prestar cuidados de enfermagem de higiene, conforto e monitoramento das condições clínicas',60),(51,5,'Prestar assistência de enfermagem em saúde mental',60),(52,5,'Estágio Profissional Supervisionado: cuidado integral de enfermagem',60),(53,5,'Prestar assistência de enfermagem no período gestacional, parto, puerpério e ao recém-nascido',60),(54,5,'Prestar assistência de enfermagem no período perioperatório',60),(55,5,'Estágio Profissional Supervisionado: cuidado especializado de enfermagem',60),(56,5,'Projeto Integrador: Auxiliar de Enfermagem',60),(57,5,'Atuar em programas de qualidade e certificação hospitalar',60),(58,5,'Administrar medicamentos de alta vigilância e hemocomponentes',60),(59,5,'Prestar assistência de enfermagem em urgência e emergência',60),(60,5,'Prestar assistência de enfermagem em cuidados críticos',60),(61,5,'Prestar assistência de enfermagem em cuidados paliativos',60),(62,5,'Estágio Profissional Supervisionado: cuidado crítico, urgência e emergência em enfermagem',60),(63,5,'Projeto Integrador: Técnico em Enfermagem',60),(64,6,'Auxiliar a elaboração, implementação e acompanhamento do planejamento estratégico das organizações',60),(65,6,'Monitorar e controlar os processos referentes à tesouraria',60),(66,6,'Executar atividades de contas a pagar e a receber',60),(67,6,'Monitorar e organizar o processo de análise de crédito e cobrança',60),(68,6,'Apurar custos e composição de preços',60),(69,6,'Assessorar na elaboração, na implementação e no controle do orçamento empresarial',60),(70,6,'Preparar o planejamento financeiro',60),(71,6,'Projeto Integrador: Assistente de Planejamento Financeiro',60),(72,6,'Auxiliar a estruturação e operacionalização de projetos',60),(73,6,'Apoiar e controlar processos de financiamentos e investimentos',60),(74,6,'Auxiliar o planejamento e a execução de melhorias dos processos organizacionais',60),(75,6,'Auxiliar nas transações financeiras de comércio exterior e com moeda indexadora',60),(76,6,'Projeto Integrador: Técnico em Finanças',60),(77,7,'Planejar projeto visual',60),(78,7,'Manipular imagem bitmap',60),(79,7,'Desenvolver ilustração vetorial',60),(80,7,'Produzir projeto visual',60),(81,7,'Projeto Integrador: Assistente de Produção Gráfica',60),(82,7,'Planejar projeto de vídeo digital',60),(83,7,'Produzir material para áudio e vídeo digital',60),(84,7,'Editar vídeo e áudio digital',60),(85,7,'Animar elemento gráfico',60),(86,7,'Produzir efeitos visuais',60),(87,7,'Projeto Integrador: Editor de Vídeo Digital',60),(88,7,'Planejar animação',60),(89,7,'Desenvolver modelagem tridimensional',60),(90,7,'Animar elemento tridimensional',60),(91,7,'Tratar renderização de animação',60),(92,7,'Projeto Integrador: Assistente de Produção 3D',60),(93,7,'Desenhar projeto técnico bidimensional',60),(94,7,'Desenvolver projeto tridimensional',60),(95,7,'Tratar imagem para maquete eletrônica',60),(96,7,'Projeto Integrador: Desenhista de Maquete Eletrônica',60);
/*!40000 ALTER TABLE `disciplinas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `frequencia`
--

DROP TABLE IF EXISTS `frequencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `frequencia` (
  `id_frequencia` int(11) NOT NULL AUTO_INCREMENT,
  `id_matricula` int(11) NOT NULL,
  `id_disciplina` int(11) NOT NULL,
  `total_aulas` int(11) NOT NULL DEFAULT 0,
  `presencas` int(11) NOT NULL DEFAULT 0,
  `percentual` decimal(5,2) GENERATED ALWAYS AS (`presencas` / `total_aulas` * 100) VIRTUAL,
  PRIMARY KEY (`id_frequencia`),
  UNIQUE KEY `uq_matricula_frequencia` (`id_matricula`,`id_disciplina`),
  KEY `id_disciplina` (`id_disciplina`),
  CONSTRAINT `frequencia_ibfk_1` FOREIGN KEY (`id_matricula`) REFERENCES `matriculas` (`id_matricula`) ON DELETE CASCADE,
  CONSTRAINT `frequencia_ibfk_2` FOREIGN KEY (`id_disciplina`) REFERENCES `disciplinas` (`id_disciplina`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `frequencia`
--

LOCK TABLES `frequencia` WRITE;
/*!40000 ALTER TABLE `frequencia` DISABLE KEYS */;
INSERT INTO `frequencia` (`id_frequencia`, `id_matricula`, `id_disciplina`, `total_aulas`, `presencas`) VALUES (1,1,1,20,18),(2,1,2,20,17),(3,1,3,20,18),(4,2,1,20,15),(5,2,2,20,15),(6,2,3,20,15),(33,7,58,26,20);
/*!40000 ALTER TABLE `frequencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logs`
--

DROP TABLE IF EXISTS `logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `logs` (
  `id_log` int(11) NOT NULL AUTO_INCREMENT,
  `id_usuario` int(11) NOT NULL,
  `acao` varchar(255) NOT NULL,
  `ip` varchar(45) DEFAULT NULL,
  `data_evento` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`id_log`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `logs_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=237 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logs`
--

LOCK TABLES `logs` WRITE;
/*!40000 ALTER TABLE `logs` DISABLE KEYS */;
INSERT INTO `logs` VALUES (1,4,'Criou dados de teste','10.91.47.24','2026-06-12 14:03:54'),(2,4,'Login realizado','10.91.47.24','2026-06-12 14:04:57'),(3,4,'Cadastrou aluno','10.91.47.24','2026-06-12 14:08:03'),(4,4,'Logout realizado','10.91.47.24','2026-06-12 14:08:53'),(5,10,'Login realizado','10.91.47.24','2026-06-12 14:09:11'),(6,10,'Logout realizado','10.91.47.24','2026-06-12 14:45:05'),(7,4,'Login realizado','10.91.47.24','2026-06-12 14:46:04'),(8,7,'Login realizado','10.91.47.24','2026-06-12 15:57:42'),(9,7,'Logout realizado','10.91.47.24','2026-06-12 16:36:46'),(10,8,'Login realizado','10.91.47.24','2026-06-12 16:37:04'),(11,8,'Logout realizado','10.91.47.24','2026-06-12 16:48:59'),(12,4,'Login realizado','10.91.47.24','2026-06-12 16:49:18'),(13,4,'Logout realizado','10.91.47.24','2026-06-12 16:56:10'),(14,5,'Login realizado','10.91.47.24','2026-06-12 16:56:29'),(15,5,'Cadastrou curso','10.91.47.24','2026-06-12 17:15:19'),(16,5,'Logout realizado','10.91.47.24','2026-06-12 17:21:16'),(17,10,'Login realizado','10.91.47.24','2026-06-12 17:25:22'),(18,4,'Login realizado','10.91.47.24','2026-06-15 13:43:46'),(19,4,'Realizou matricula','10.91.47.24','2026-06-15 13:45:48'),(20,4,'Logout realizado','10.91.47.24','2026-06-15 13:49:20'),(21,5,'Login realizado','10.91.47.24','2026-06-15 13:49:33'),(22,4,'Criou dados de teste','10.91.47.35','2026-06-15 14:06:30'),(23,4,'Criou dados de teste','10.91.47.35','2026-06-15 14:06:41'),(24,4,'Criou dados de teste','10.91.47.35','2026-06-15 14:06:59'),(25,4,'Criou dados de teste','10.91.47.35','2026-06-15 14:07:03'),(26,8,'Login realizado','10.91.47.35','2026-06-15 14:07:22'),(27,8,'Logout realizado','10.91.47.35','2026-06-15 14:08:32'),(28,4,'Login realizado','10.91.47.35','2026-06-15 14:31:32'),(29,4,'Logout realizado','10.91.47.35','2026-06-15 14:33:35'),(30,8,'Login realizado','10.91.47.35','2026-06-15 14:33:38'),(31,5,'Logout realizado','10.91.47.24','2026-06-15 14:53:03'),(32,6,'Login realizado','10.91.47.24','2026-06-15 14:53:10'),(33,4,'Login realizado','10.91.47.24','2026-06-15 15:54:25'),(34,4,'Logout realizado','10.91.47.24','2026-06-15 15:56:47'),(35,4,'Login realizado','10.91.47.24','2026-06-15 16:00:01'),(36,4,'Cadastrou pagamento','10.91.47.24','2026-06-15 16:00:36'),(37,4,'Cadastrou curso','10.91.47.24','2026-06-15 16:04:22'),(38,4,'Cadastrou turma','10.91.47.24','2026-06-15 16:05:16'),(39,8,'Login realizado','10.91.47.35','2026-06-15 16:18:01'),(40,4,'Editou pagamento','10.91.47.24','2026-06-15 16:18:07'),(41,8,'Logout realizado','10.91.47.35','2026-06-15 16:18:16'),(42,4,'Login realizado','10.91.47.35','2026-06-15 16:18:18'),(43,4,'Cadastrou aluno','10.91.47.24','2026-06-15 16:20:26'),(44,4,'Cadastrou professor','10.91.47.24','2026-06-15 16:23:01'),(45,4,'Editou curso','10.91.47.24','2026-06-15 16:24:31'),(46,4,'Logout realizado','10.91.47.24','2026-06-15 16:30:28'),(47,10,'Login realizado','10.91.47.24','2026-06-15 16:30:47'),(48,10,'Logout realizado','10.91.47.24','2026-06-15 16:31:14'),(49,7,'Login realizado','10.91.47.24','2026-06-15 16:31:42'),(50,7,'Logout realizado','10.91.47.24','2026-06-15 16:36:14'),(51,4,'Login realizado','10.91.47.24','2026-06-15 16:37:01'),(52,4,'Editou aluno','10.91.47.24','2026-06-15 16:38:01'),(53,4,'Logout realizado','10.91.47.24','2026-06-15 16:39:29'),(54,8,'Login realizado','10.91.47.24','2026-06-15 16:39:46'),(55,8,'Logout realizado','10.91.47.24','2026-06-15 16:40:23'),(56,7,'Login realizado','10.91.47.24','2026-06-15 16:40:56'),(57,7,'Lancou nota','10.91.47.24','2026-06-15 16:42:12'),(58,7,'Registrou frequencia','10.91.47.24','2026-06-15 16:42:37'),(59,7,'Logout realizado','10.91.47.24','2026-06-15 16:43:08'),(60,8,'Login realizado','10.91.47.24','2026-06-15 16:43:40'),(61,8,'Logout realizado','10.91.47.24','2026-06-15 16:44:54'),(62,7,'Login realizado','10.91.47.24','2026-06-15 16:45:10'),(63,7,'Logout realizado','10.91.47.24','2026-06-15 16:46:56'),(64,5,'Login realizado','10.91.47.24','2026-06-15 16:47:12'),(65,5,'Editou curso','10.91.47.24','2026-06-15 16:47:45'),(66,5,'Cadastrou curso','10.91.47.24','2026-06-15 16:49:06'),(67,5,'Editou turma','10.91.47.24','2026-06-15 16:49:31'),(68,5,'Cadastrou turma','10.91.47.24','2026-06-15 16:49:58'),(69,5,'Logout realizado','10.91.47.24','2026-06-15 17:05:48'),(70,7,'Login realizado','10.91.47.24','2026-06-15 17:06:21'),(71,7,'Lancou nota','10.91.47.24','2026-06-15 17:07:13'),(72,7,'Registrou frequencia','10.91.47.24','2026-06-15 17:07:41'),(73,7,'Logout realizado','10.91.47.24','2026-06-15 17:08:04'),(74,8,'Login realizado','10.91.47.24','2026-06-15 17:08:23'),(75,8,'Logout realizado','10.91.47.24','2026-06-15 17:09:20'),(76,6,'Login realizado','10.91.47.24','2026-06-15 17:09:40'),(77,6,'Cadastrou pagamento','10.91.47.24','2026-06-15 17:10:29'),(78,6,'Logout realizado','10.91.47.24','2026-06-15 17:11:14'),(79,5,'Login realizado','10.91.47.24','2026-06-15 17:11:29'),(80,5,'Cadastrou aluno','10.91.47.24','2026-06-15 17:14:55'),(81,5,'Realizou matricula','10.91.47.24','2026-06-15 17:15:09'),(82,5,'Logout realizado','10.91.47.24','2026-06-15 17:16:47'),(83,4,'Login realizado','10.91.47.24','2026-06-15 17:16:54'),(84,4,'Logout realizado','10.91.47.24','2026-06-15 17:21:08'),(85,6,'Login realizado','10.91.47.24','2026-06-15 17:21:13'),(86,6,'Logout realizado','10.91.47.24','2026-06-15 17:21:23'),(87,5,'Login realizado','10.91.47.24','2026-06-15 17:21:39'),(88,4,'Login realizado','10.91.47.24','2026-06-16 13:51:36'),(89,4,'Cadastrou aluno','10.91.47.24','2026-06-16 13:54:41'),(90,4,'Realizou matricula','10.91.47.24','2026-06-16 13:56:35'),(91,4,'Cadastrou professor','10.91.47.24','2026-06-16 13:58:17'),(92,4,'Cadastrou professor','10.91.47.24','2026-06-16 14:03:20'),(93,4,'Editou turma','10.91.47.24','2026-06-16 14:03:50'),(94,4,'Cadastrou curso','10.91.47.24','2026-06-16 14:05:32'),(95,4,'Cadastrou turma','10.91.47.24','2026-06-16 14:07:12'),(96,4,'Editou curso','10.91.47.24','2026-06-16 14:08:57'),(97,4,'Editou turma','10.91.47.24','2026-06-16 14:09:57'),(98,4,'Editou turma','10.91.47.24','2026-06-16 14:10:18'),(99,4,'Editou curso','10.91.47.24','2026-06-16 14:10:28'),(100,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:13'),(101,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:20'),(102,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:21'),(103,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:22'),(104,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:23'),(105,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:23'),(106,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:23'),(107,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:24'),(108,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:24'),(109,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:25'),(110,4,'Editou pagamento','10.91.47.24','2026-06-16 14:21:25'),(111,4,'Logout realizado','10.91.47.24','2026-06-16 14:40:49'),(112,4,'Login realizado','10.91.47.24','2026-06-16 14:42:02'),(113,4,'Editou pagamento','10.91.47.24','2026-06-16 15:35:35'),(114,4,'Editou pagamento','10.91.47.24','2026-06-16 15:39:21'),(115,4,'Editou pagamento','10.91.47.24','2026-06-16 15:39:38'),(116,4,'Editou pagamento','10.91.47.24','2026-06-16 15:44:16'),(117,4,'Editou pagamento','10.91.47.24','2026-06-16 15:44:24'),(118,4,'Editou pagamento','10.91.47.24','2026-06-16 15:57:21'),(119,4,'Editou pagamento','10.91.47.24','2026-06-16 15:57:50'),(120,4,'Logout realizado','10.91.47.24','2026-06-16 16:05:20'),(121,4,'Login realizado','10.91.47.24','2026-06-16 16:48:42'),(122,4,'Cadastrou pagamento','10.91.47.24','2026-06-16 16:50:08'),(123,4,'Editou pagamento','10.91.47.24','2026-06-16 16:51:05'),(124,4,'Editou pagamento','10.91.47.24','2026-06-16 16:51:18'),(125,4,'Cadastrou pagamento','10.91.47.24','2026-06-16 16:52:07'),(126,4,'Cadastrou turma','10.91.47.24','2026-06-16 16:54:49'),(127,4,'Logout realizado','10.91.47.24','2026-06-16 16:56:39'),(128,14,'Login realizado','10.91.47.24','2026-06-16 17:07:24'),(129,14,'Logout realizado','10.91.47.24','2026-06-16 17:10:44'),(130,4,'Login realizado','10.91.47.24','2026-06-16 17:11:17'),(131,4,'Realizou matricula','10.91.47.24','2026-06-16 17:14:43'),(132,4,'Logout realizado','10.91.47.24','2026-06-16 17:17:16'),(133,6,'Login realizado','10.91.47.24','2026-06-16 17:17:30'),(134,6,'Logout realizado','10.91.47.24','2026-06-16 17:17:34'),(135,5,'Login realizado','10.91.47.24','2026-06-16 17:17:44'),(136,4,'Login realizado','10.91.47.24','2026-06-17 15:55:57'),(137,4,'Logout realizado','10.91.47.24','2026-06-17 15:57:36'),(138,5,'Login realizado','10.91.47.24','2026-06-17 15:57:46'),(139,5,'Logout realizado','10.91.47.24','2026-06-17 15:58:03'),(140,6,'Login realizado','10.91.47.24','2026-06-17 15:58:15'),(141,6,'Logout realizado','10.91.47.24','2026-06-17 15:58:27'),(142,5,'Login realizado','10.91.47.24','2026-06-17 15:58:45'),(143,5,'Logout realizado','10.91.47.24','2026-06-17 16:00:59'),(144,6,'Login realizado','10.91.47.24','2026-06-17 16:01:11'),(145,6,'Logout realizado','10.91.47.24','2026-06-17 16:03:56'),(146,8,'Login realizado','10.91.47.24','2026-06-17 16:04:03'),(147,8,'Logout realizado','10.91.47.24','2026-06-17 16:04:21'),(148,5,'Login realizado','10.91.47.24','2026-06-17 16:04:28'),(149,5,'Logout realizado','10.91.47.24','2026-06-17 16:07:29'),(150,6,'Login realizado','10.91.47.24','2026-06-17 16:07:58'),(151,6,'Editou pagamento','10.91.47.24','2026-06-17 16:11:10'),(152,6,'Editou pagamento','10.91.47.24','2026-06-17 16:12:27'),(153,6,'Editou pagamento','10.91.47.24','2026-06-17 16:12:42'),(154,6,'Cadastrou pagamento','10.91.47.24','2026-06-17 16:26:10'),(155,6,'Logout realizado','10.91.47.24','2026-06-17 16:29:30'),(156,13,'Login realizado','10.91.47.24','2026-06-17 16:29:49'),(157,13,'Alterou senha no primeiro acesso','10.91.47.24','2026-06-17 16:30:08'),(158,13,'Logout realizado','10.91.47.24','2026-06-17 16:37:21'),(159,6,'Login realizado','10.91.47.24','2026-06-17 16:37:38'),(160,6,'Cadastrou aluno','10.91.47.24','2026-06-17 16:41:16'),(161,6,'Editou aluno','10.91.47.24','2026-06-17 16:41:33'),(162,6,'Realizou matricula','10.91.47.24','2026-06-17 16:42:03'),(163,6,'Logout realizado','10.91.47.24','2026-06-17 16:42:37'),(164,5,'Login realizado','10.91.47.24','2026-06-17 16:42:49'),(165,5,'Logout realizado','10.91.47.24','2026-06-17 16:42:58'),(166,4,'Login realizado','10.91.47.24','2026-06-17 16:43:08'),(167,4,'Logout realizado','10.91.47.24','2026-06-17 16:49:33'),(168,15,'Login realizado','10.91.47.24','2026-06-17 16:49:54'),(169,15,'Alterou senha no primeiro acesso','10.91.47.24','2026-06-17 16:50:10'),(170,15,'Logout realizado','10.91.47.24','2026-06-17 16:51:29'),(171,4,'Login realizado','10.91.47.24','2026-06-17 16:51:44'),(172,4,'Login realizado','10.91.47.24','2026-06-18 13:54:59'),(173,4,'Logout realizado','10.91.47.24','2026-06-18 15:43:40'),(174,11,'Login realizado','10.91.47.24','2026-06-18 15:44:08'),(175,11,'Alterou senha no primeiro acesso','10.91.47.24','2026-06-18 15:46:26'),(176,11,'Logout realizado','10.91.47.24','2026-06-18 15:47:08'),(177,7,'Login realizado','10.91.47.24','2026-06-18 15:47:30'),(178,7,'Logout realizado','10.91.47.24','2026-06-18 15:59:08'),(179,5,'Login realizado','10.91.47.24','2026-06-18 15:59:22'),(180,5,'Logout realizado','10.91.47.24','2026-06-18 16:00:20'),(181,6,'Login realizado','10.91.47.24','2026-06-18 16:00:27'),(182,6,'Logout realizado','10.91.47.24','2026-06-18 16:02:19'),(183,6,'Login realizado','10.91.47.24','2026-06-18 16:02:26'),(184,6,'Logout realizado','10.91.47.24','2026-06-18 16:06:21'),(185,4,'Login realizado','10.91.47.24','2026-06-18 16:06:28'),(186,4,'Logout realizado','10.91.47.24','2026-06-18 16:06:42'),(187,5,'Login realizado','10.91.47.24','2026-06-18 16:06:54'),(188,18,'Login realizado','10.91.47.24','2026-06-18 16:51:19'),(189,18,'Alterou senha no primeiro acesso','10.91.47.24','2026-06-18 16:51:38'),(190,18,'Logout realizado','10.91.47.24','2026-06-18 16:52:39'),(191,17,'Login realizado','10.91.47.24','2026-06-18 16:54:51'),(192,17,'Alterou senha no primeiro acesso','10.91.47.24','2026-06-18 16:55:06'),(193,17,'Lancou nota','10.91.47.24','2026-06-18 16:56:08'),(194,17,'Registrou frequencia','10.91.47.24','2026-06-18 16:56:42'),(195,17,'Logout realizado','10.91.47.24','2026-06-18 16:57:46'),(196,4,'Login realizado','10.91.47.24','2026-06-18 16:59:07'),(197,4,'Logout realizado','10.91.47.24','2026-06-18 17:00:35'),(198,4,'Login realizado','10.91.47.24','2026-06-18 17:01:19'),(199,4,'Logout realizado','10.91.47.24','2026-06-18 17:02:28'),(200,4,'Login realizado','10.91.47.24','2026-06-18 17:02:53'),(201,4,'Cadastrou funcionario da coordenacao','10.91.47.24','2026-06-18 17:03:54'),(202,4,'Cadastrou funcionario administrativo','10.91.47.24','2026-06-18 17:05:02'),(203,4,'Cadastrou curso','10.91.47.24','2026-06-18 17:07:16'),(204,4,'Cadastrou aluno','10.91.47.24','2026-06-18 17:08:46'),(205,4,'Cadastrou professor','10.91.47.24','2026-06-18 17:10:18'),(206,4,'Realizou matricula','10.91.47.24','2026-06-18 17:10:42'),(207,4,'Cadastrou pagamento','10.91.47.24','2026-06-18 17:11:53'),(208,4,'Editou pagamento','10.91.47.24','2026-06-18 17:13:01'),(209,4,'Editou pagamento','10.91.47.24','2026-06-18 17:13:16'),(210,4,'Logout realizado','10.91.47.24','2026-06-18 17:16:38'),(211,19,'Login realizado','10.91.47.24','2026-06-18 17:18:31'),(212,19,'Alterou senha no primeiro acesso','10.91.47.24','2026-06-18 17:18:45'),(213,19,'Cadastrou curso','10.91.47.24','2026-06-18 17:21:07'),(214,19,'Cadastrou turma','10.91.47.24','2026-06-18 17:21:58'),(215,19,'Logout realizado','10.91.47.24','2026-06-18 17:24:09'),(216,20,'Login realizado','10.91.47.24','2026-06-18 17:24:54'),(217,20,'Alterou senha no primeiro acesso','10.91.47.24','2026-06-18 17:25:09'),(218,21,'Login realizado','10.91.47.24','2026-06-19 13:59:16'),(219,21,'Logout realizado','10.91.47.24','2026-06-19 13:59:20'),(220,21,'Login realizado','10.91.47.24','2026-06-19 13:59:26'),(221,21,'Logout realizado','10.91.47.24','2026-06-19 13:59:29'),(222,21,'Login realizado','10.91.47.24','2026-06-19 13:59:46'),(223,21,'Alterou senha no primeiro acesso','10.91.47.24','2026-06-19 14:00:06'),(224,21,'Logout realizado','10.91.47.24','2026-06-19 14:00:26'),(225,21,'Login realizado','10.91.47.24','2026-06-19 14:00:37'),(226,6,'Login realizado','10.91.47.24','2026-06-19 14:15:21'),(227,6,'Logout realizado','10.91.47.24','2026-06-19 14:31:09'),(228,6,'Login realizado','10.91.47.24','2026-06-19 14:31:28'),(229,6,'Logout realizado','10.91.47.24','2026-06-19 14:31:32'),(230,6,'Login realizado','10.91.47.24','2026-06-19 14:34:25'),(231,6,'Logout realizado','10.91.47.24','2026-06-19 14:50:10'),(232,6,'Login realizado','10.91.47.24','2026-06-19 14:51:19'),(233,6,'Logout realizado','10.91.47.24','2026-06-19 14:51:25'),(234,4,'Login realizado','10.91.47.24','2026-06-19 14:51:41'),(235,4,'Logout realizado','10.91.47.24','2026-06-19 14:51:50'),(236,4,'Login realizado','10.91.47.24','2026-06-19 14:51:59');
/*!40000 ALTER TABLE `logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `matriculas`
--

DROP TABLE IF EXISTS `matriculas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `matriculas` (
  `id_matricula` int(11) NOT NULL AUTO_INCREMENT,
  `id_aluno` int(11) NOT NULL,
  `id_turma` int(11) NOT NULL,
  `data_matricula` date NOT NULL,
  `status` enum('ativa','cancelada','concluida') DEFAULT 'ativa',
  PRIMARY KEY (`id_matricula`),
  UNIQUE KEY `uq_aluno_turma` (`id_aluno`,`id_turma`),
  KEY `id_turma` (`id_turma`),
  CONSTRAINT `matriculas_ibfk_1` FOREIGN KEY (`id_aluno`) REFERENCES `alunos` (`id_aluno`),
  CONSTRAINT `matriculas_ibfk_2` FOREIGN KEY (`id_turma`) REFERENCES `turmas` (`id_turma`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `matriculas`
--

LOCK TABLES `matriculas` WRITE;
/*!40000 ALTER TABLE `matriculas` DISABLE KEYS */;
INSERT INTO `matriculas` VALUES (1,1,1,'2026-06-12','ativa'),(2,2,1,'2026-06-12','ativa'),(3,3,1,'2026-06-15','ativa'),(4,5,1,'2026-06-15','ativa'),(5,6,3,'2026-06-16','ativa'),(6,6,5,'2026-06-16','ativa'),(7,7,4,'2026-06-17','ativa'),(8,8,2,'2026-06-18','ativa');
/*!40000 ALTER TABLE `matriculas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notas`
--

DROP TABLE IF EXISTS `notas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notas` (
  `id_nota` int(11) NOT NULL AUTO_INCREMENT,
  `id_matricula` int(11) NOT NULL,
  `id_disciplina` int(11) NOT NULL,
  `prova_1` decimal(4,2) DEFAULT NULL,
  `prova_2` decimal(4,2) DEFAULT NULL,
  `trabalho` decimal(4,2) DEFAULT NULL,
  `comportamental` decimal(4,2) DEFAULT NULL,
  `media_uc` decimal(4,2) DEFAULT NULL,
  `status` enum('aprovado','reprovado','em_andamento') DEFAULT 'em_andamento',
  `data_lancamento` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`id_nota`),
  UNIQUE KEY `uq_matricula_disciplina` (`id_matricula`,`id_disciplina`),
  KEY `id_disciplina` (`id_disciplina`),
  CONSTRAINT `notas_ibfk_1` FOREIGN KEY (`id_matricula`) REFERENCES `matriculas` (`id_matricula`) ON DELETE CASCADE,
  CONSTRAINT `notas_ibfk_2` FOREIGN KEY (`id_disciplina`) REFERENCES `disciplinas` (`id_disciplina`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notas`
--

LOCK TABLES `notas` WRITE;
/*!40000 ALTER TABLE `notas` DISABLE KEYS */;
INSERT INTO `notas` VALUES (1,1,1,8.00,7.70,8.50,9.00,8.16,'aprovado','2026-06-12 14:03:54'),(2,1,2,6.80,7.00,10.00,7.60,7.90,'aprovado','2026-06-15 17:07:13'),(3,1,3,8.40,7.70,8.50,9.00,8.28,'aprovado','2026-06-12 14:03:54'),(4,2,1,6.00,5.70,6.50,9.00,6.36,'aprovado','2026-06-12 14:03:54'),(5,2,2,5.60,5.60,10.00,8.00,7.16,'aprovado','2026-06-15 16:42:12'),(6,2,3,6.40,5.70,6.50,9.00,6.48,'aprovado','2026-06-12 14:03:54'),(33,7,58,7.00,6.50,8.00,6.90,7.14,'aprovado','2026-06-18 16:56:08');
/*!40000 ALTER TABLE `notas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagamentos`
--

DROP TABLE IF EXISTS `pagamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagamentos` (
  `id_pagamento` int(11) NOT NULL AUTO_INCREMENT,
  `id_aluno` int(11) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `vencimento` date NOT NULL,
  `status` enum('pendente','pago','atrasado','cancelado') DEFAULT 'pendente',
  PRIMARY KEY (`id_pagamento`),
  KEY `id_aluno` (`id_aluno`),
  CONSTRAINT `pagamentos_ibfk_1` FOREIGN KEY (`id_aluno`) REFERENCES `alunos` (`id_aluno`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagamentos`
--

LOCK TABLES `pagamentos` WRITE;
/*!40000 ALTER TABLE `pagamentos` DISABLE KEYS */;
INSERT INTO `pagamentos` VALUES (1,1,350.00,'2026-06-15','pago'),(2,2,350.00,'2026-06-18','atrasado'),(3,3,400.00,'2026-06-15','pago'),(4,3,1000.00,'2026-06-06','atrasado'),(5,6,350.00,'2026-06-10','atrasado'),(6,1,200.00,'2026-06-16','pago'),(7,6,700.00,'2026-06-20','pendente'),(8,8,350.00,'2026-06-17','pago');
/*!40000 ALTER TABLE `pagamentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professores`
--

DROP TABLE IF EXISTS `professores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `professores` (
  `id_professor` int(11) NOT NULL AUTO_INCREMENT,
  `id_usuario` int(11) NOT NULL,
  `cpf` varchar(14) NOT NULL,
  `especialidade` varchar(120) DEFAULT NULL,
  PRIMARY KEY (`id_professor`),
  UNIQUE KEY `id_usuario` (`id_usuario`),
  UNIQUE KEY `cpf` (`cpf`),
  CONSTRAINT `professores_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professores`
--

LOCK TABLES `professores` WRITE;
/*!40000 ALTER TABLE `professores` DISABLE KEYS */;
INSERT INTO `professores` VALUES (1,7,'111.222.333-44','Desenvolvimento de sistemas'),(2,12,'471.034.872-35','Administração'),(3,15,'235.687.416-53','Estetica'),(4,17,'789.654.123-02','Medicina'),(5,22,'987.456.321-02','Finanças');
/*!40000 ALTER TABLE `professores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turmas`
--

DROP TABLE IF EXISTS `turmas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `turmas` (
  `id_turma` int(11) NOT NULL AUTO_INCREMENT,
  `id_curso` int(11) NOT NULL,
  `id_professor` int(11) NOT NULL,
  `codigo_turma` varchar(50) NOT NULL,
  `turno` enum('manha','tarde','noite') NOT NULL,
  `periodo_letivo` varchar(20) NOT NULL,
  `capacidade_maxima` int(11) DEFAULT 35,
  `status` enum('ativa','encerrada') DEFAULT 'ativa',
  PRIMARY KEY (`id_turma`),
  UNIQUE KEY `codigo_turma` (`codigo_turma`),
  KEY `id_curso` (`id_curso`),
  KEY `id_professor` (`id_professor`),
  CONSTRAINT `turmas_ibfk_1` FOREIGN KEY (`id_curso`) REFERENCES `cursos` (`id_curso`),
  CONSTRAINT `turmas_ibfk_2` FOREIGN KEY (`id_professor`) REFERENCES `professores` (`id_professor`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turmas`
--

LOCK TABLES `turmas` WRITE;
/*!40000 ALTER TABLE `turmas` DISABLE KEYS */;
INSERT INTO `turmas` VALUES (1,1,1,'TI-1A','noite','2026.1',35,'ativa'),(2,2,1,'ADM-1A','tarde','2026',30,'ativa'),(3,4,2,'EST-1A','noite','2026',30,'ativa'),(4,5,4,'TE-1A','manha','2026',40,'ativa'),(5,2,2,'ADM-1B','tarde','2026',30,'ativa'),(6,7,4,'TCG-3B','noite','2026',30,'ativa');
/*!40000 ALTER TABLE `turmas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(150) NOT NULL,
  `email` varchar(150) NOT NULL,
  `senha_hash` varchar(255) NOT NULL,
  `perfil` enum('aluno','professor','coordenacao','administrativo','admin') NOT NULL,
  `status` enum('ativo','inativo') DEFAULT 'ativo',
  `ultimo_login` datetime DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Administrador','admin@escola.com','e10adc3949ba59abbe56e057f20f883e','admin','ativo',NULL,'2026-06-10 17:08:25'),(2,'Professor João','joao@escola.com','e10adc3949ba59abbe56e057f20f883e','professor','ativo',NULL,'2026-06-10 17:08:25'),(3,'Maria Aluna','maria@escola.com','e10adc3949ba59abbe56e057f20f883e','aluno','ativo',NULL,'2026-06-10 17:08:25'),(4,'Admin Flow','admin@flowacademy.com','$2y$10$k1NaR92iequHkkbuY2lvBO0Rqp2F3Y9CimBNE4RisWl1XYbpl0cBa','admin','ativo','2026-06-19 14:51:59','2026-06-12 14:03:54'),(5,'Coordenacao Flow','coordenacao@flowacademy.com','$2y$10$ouNwjuJA/SuchGNEPxtUiuUj6it5qTxUknftl/n5lV2pbAEGoAkoG','coordenacao','ativo','2026-06-18 16:06:54','2026-06-12 14:03:54'),(6,'Financeiro Flow','administrativo@flowacademy.com','$2y$10$dCZizEvMo4d.80zP5sqReOee4rIj9.2xU9r/w2gCqkRfZTH7rIQkW','administrativo','ativo','2026-06-19 14:51:19','2026-06-12 14:03:54'),(7,'Marcos Oliveira','professor@flowacademy.com','$2y$10$4J30WhI.Nf5GoRyV3vpdS.hGbdrTH.9KbpyMCB4q.1Z.nlqIJrobW','professor','ativo','2026-06-18 15:47:30','2026-06-12 14:03:54'),(8,'Ana Martins','aluno@flowacademy.com','$2y$10$shl4vUEd/blIQ7OBRwVeFe1YL3vfBGeb6RyUvMYrFFnhOlbm3ZDXG','aluno','ativo','2026-06-17 16:04:03','2026-06-12 14:03:54'),(9,'Bruno Farias','bruno@flowacademy.com','$2y$10$CM15mym/6d3bXlAomQirxO01HTM/pOnxx1MIi5lHHDjZBCHqalda.','aluno','ativo',NULL,'2026-06-12 14:03:54'),(10,'Ryan Marcos da Silva Costa','ryanmscosta@gmail.com','$2y$10$Ky.VsbJ9RmosCgo8IODtQ.q8fVE0I0ISKiwRP3zQ551jbn2bQkZvu','aluno','ativo','2026-06-15 16:30:47','2026-06-12 14:08:03'),(11,'lucas pereira santos','luscasper@gmail.com','$2y$10$keOA4s9lodHINDDomtJndOtOlpLZixu6f5zRkXSL7HSIXVWlgBeBa','aluno','ativo','2026-06-18 15:46:26','2026-06-15 16:20:26'),(12,'Carlos mendes','carlosmendes123@gmail.com','$2y$10$J3Jbjkjle5op3XAQzPT9DeWYO58ap1B/R4tv3glybl4uWfqm3PBEG','professor','ativo',NULL,'2026-06-15 16:23:01'),(13,'Leonardo Afonço','leo@gmail.com','$2y$10$HGDDC5pWf.SBUBZ7P8/4keVXyS8MeiU8BZlZREie4U2ewPzwK/ZE.','aluno','ativo','2026-06-17 16:30:08','2026-06-15 17:14:55'),(14,'Vinicius Siqueira Caetano','vinicius@gmail.com','$2y$10$5IKMkEECii.8KxHUqiVMYeW0xJ/wDyXhCQ2tdaSRoTnZChBgwebfm','aluno','ativo','2026-06-16 17:07:24','2026-06-16 13:54:41'),(15,'Valeria souza','valeriasouza@gmail.com','$2y$10$KpDXWOvqb4Lf/y8A57tZ4upzrnPnz8pRPlK.vw6XM1gcdAsPc8wCi','professor','ativo','2026-06-17 16:50:10','2026-06-16 13:58:17'),(17,'Josimar Silva','josimar12@gmail.com','$2y$10$pvMF1FS4CKIOllwrJP4AZew3QCHGbWJr6KhNaL8GPAMspM8IJtrca','professor','ativo','2026-06-18 16:55:06','2026-06-16 14:03:20'),(18,'Kauã Nascimento ','kaual@gmail.com','$2y$10$L9BySIFZa4uFbpjEVqRmGOJwsVet2Q0BGsuX35ikb9egmBKJZ106e','aluno','ativo','2026-06-18 16:51:38','2026-06-17 16:41:16'),(19,'Ricardo Souza','ricardo@gmail.com','$2y$10$85igUaAKuVGEMb7hok2efOlydb3rmbso58rVqKGbKYQZMYSuK4IM2','coordenacao','ativo','2026-06-18 17:18:45','2026-06-18 17:03:54'),(20,'Fabricio Lucas','Fabricio@gmail.com','$2y$10$Z5Xk5FjYLVXU/fngoPxcWuD9RnEU7DALTsMBzBuM12CrATFRJQEkS','administrativo','ativo','2026-06-18 17:25:09','2026-06-18 17:05:02'),(21,'Luciene Maria Da Silva','luciene@gmail.com','$2y$10$PKF3liZaQRpMFbXPeYkb/OqnUiH4mMOtSKg9IDpSsP0BedCEMxBhy','aluno','ativo','2026-06-19 14:00:37','2026-06-18 17:08:46'),(22,'Vitoria Ferreira','vitoria@gmail.com','$2y$10$zYCGIQ2/GRtCc77pjhxyPOwAaeObSy80AqU4C/SWotLogb8ozcdI.','professor','ativo',NULL,'2026-06-18 17:10:18');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--

-- Stored procedures for FlowAcademy
--

DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_usuario_insert`$$
CREATE PROCEDURE `sp_usuario_insert`(
  IN p_nome VARCHAR(150),
  IN p_email VARCHAR(150),
  IN p_senha_hash VARCHAR(255),
  IN p_perfil VARCHAR(20),
  IN p_status VARCHAR(20)
)
BEGIN
  INSERT INTO usuarios (nome, email, senha_hash, perfil, status)
  VALUES (p_nome, p_email, p_senha_hash, p_perfil, IFNULL(p_status, 'ativo'));
  SELECT LAST_INSERT_ID() AS id_usuario;
END$$

DROP PROCEDURE IF EXISTS `sp_usuario_update`$$
CREATE PROCEDURE `sp_usuario_update`(
  IN p_id_usuario INT,
  IN p_nome VARCHAR(150),
  IN p_email VARCHAR(150),
  IN p_senha_hash VARCHAR(255),
  IN p_perfil VARCHAR(20),
  IN p_status VARCHAR(20)
)
BEGIN
  UPDATE usuarios
  SET nome = p_nome,
      email = p_email,
      senha_hash = p_senha_hash,
      perfil = p_perfil,
      status = IFNULL(p_status, 'ativo')
  WHERE id_usuario = p_id_usuario;
END$$

DROP PROCEDURE IF EXISTS `sp_usuario_delete`$$
CREATE PROCEDURE `sp_usuario_delete`(IN p_id_usuario INT)
BEGIN
  DELETE FROM usuarios WHERE id_usuario = p_id_usuario;
END$$

DROP PROCEDURE IF EXISTS `sp_usuario_select`$$
CREATE PROCEDURE `sp_usuario_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT id_usuario, nome, email, senha_hash, perfil, status, ultimo_login, created_at
  FROM usuarios
  WHERE nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR email LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR perfil LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY nome;
END$$

DROP PROCEDURE IF EXISTS `sp_usuario_select_id`$$
CREATE PROCEDURE `sp_usuario_select_id`(IN p_id_usuario INT)
BEGIN
  SELECT id_usuario, nome, email, senha_hash, perfil, status, ultimo_login, created_at
  FROM usuarios
  WHERE id_usuario = p_id_usuario;
END$$

DROP PROCEDURE IF EXISTS `sp_usuario_autenticar`$$
CREATE PROCEDURE `sp_usuario_autenticar`(
  IN p_email VARCHAR(150),
  IN p_senha_hash VARCHAR(255)
)
BEGIN
  UPDATE usuarios
  SET ultimo_login = NOW()
  WHERE email = p_email
    AND senha_hash = p_senha_hash
    AND status = 'ativo';

  SELECT id_usuario, nome, email, senha_hash, perfil, status, ultimo_login, created_at
  FROM usuarios
  WHERE email = p_email
    AND senha_hash = p_senha_hash
    AND status = 'ativo';
END$$

DROP PROCEDURE IF EXISTS `sp_aluno_insert`$$
CREATE PROCEDURE `sp_aluno_insert`(
  IN p_id_usuario INT,
  IN p_matricula VARCHAR(30),
  IN p_cpf VARCHAR(14),
  IN p_telefone VARCHAR(20),
  IN p_data_nascimento DATE,
  IN p_endereco VARCHAR(255),
  IN p_status_academico VARCHAR(20)
)
BEGIN
  INSERT INTO alunos (id_usuario, matricula, cpf, telefone, data_nascimento, endereco, status_academico)
  VALUES (p_id_usuario, p_matricula, p_cpf, p_telefone, p_data_nascimento, p_endereco, IFNULL(p_status_academico, 'regular'));
  SELECT LAST_INSERT_ID() AS id_aluno;
END$$

DROP PROCEDURE IF EXISTS `sp_aluno_update`$$
CREATE PROCEDURE `sp_aluno_update`(
  IN p_id_aluno INT,
  IN p_id_usuario INT,
  IN p_matricula VARCHAR(30),
  IN p_cpf VARCHAR(14),
  IN p_telefone VARCHAR(20),
  IN p_data_nascimento DATE,
  IN p_endereco VARCHAR(255),
  IN p_status_academico VARCHAR(20)
)
BEGIN
  UPDATE alunos
  SET id_usuario = p_id_usuario,
      matricula = p_matricula,
      cpf = p_cpf,
      telefone = p_telefone,
      data_nascimento = p_data_nascimento,
      endereco = p_endereco,
      status_academico = IFNULL(p_status_academico, 'regular')
  WHERE id_aluno = p_id_aluno;
END$$

DROP PROCEDURE IF EXISTS `sp_aluno_delete`$$
CREATE PROCEDURE `sp_aluno_delete`(IN p_id_aluno INT)
BEGIN
  DELETE FROM alunos WHERE id_aluno = p_id_aluno;
END$$

DROP PROCEDURE IF EXISTS `sp_aluno_select`$$
CREATE PROCEDURE `sp_aluno_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT a.*, u.nome, u.email
  FROM alunos a
  INNER JOIN usuarios u ON u.id_usuario = a.id_usuario
  WHERE u.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR a.matricula LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR a.cpf LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY u.nome;
END$$

DROP PROCEDURE IF EXISTS `sp_aluno_select_id`$$
CREATE PROCEDURE `sp_aluno_select_id`(IN p_id_aluno INT)
BEGIN
  SELECT id_aluno, id_usuario, matricula, cpf, telefone, data_nascimento, endereco, status_academico
  FROM alunos
  WHERE id_aluno = p_id_aluno;
END$$

DROP PROCEDURE IF EXISTS `sp_professor_insert`$$
CREATE PROCEDURE `sp_professor_insert`(
  IN p_id_usuario INT,
  IN p_cpf VARCHAR(14),
  IN p_especialidade VARCHAR(120)
)
BEGIN
  INSERT INTO professores (id_usuario, cpf, especialidade)
  VALUES (p_id_usuario, p_cpf, p_especialidade);
  SELECT LAST_INSERT_ID() AS id_professor;
END$$

DROP PROCEDURE IF EXISTS `sp_professor_update`$$
CREATE PROCEDURE `sp_professor_update`(
  IN p_id_professor INT,
  IN p_id_usuario INT,
  IN p_cpf VARCHAR(14),
  IN p_especialidade VARCHAR(120)
)
BEGIN
  UPDATE professores
  SET id_usuario = p_id_usuario,
      cpf = p_cpf,
      especialidade = p_especialidade
  WHERE id_professor = p_id_professor;
END$$

DROP PROCEDURE IF EXISTS `sp_professor_delete`$$
CREATE PROCEDURE `sp_professor_delete`(IN p_id_professor INT)
BEGIN
  DELETE FROM professores WHERE id_professor = p_id_professor;
END$$

DROP PROCEDURE IF EXISTS `sp_professor_select`$$
CREATE PROCEDURE `sp_professor_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT p.*, u.nome, u.email
  FROM professores p
  INNER JOIN usuarios u ON u.id_usuario = p.id_usuario
  WHERE u.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR p.cpf LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR p.especialidade LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY u.nome;
END$$

DROP PROCEDURE IF EXISTS `sp_professor_select_id`$$
CREATE PROCEDURE `sp_professor_select_id`(IN p_id_professor INT)
BEGIN
  SELECT id_professor, id_usuario, cpf, especialidade
  FROM professores
  WHERE id_professor = p_id_professor;
END$$

DROP PROCEDURE IF EXISTS `sp_curso_insert`$$
CREATE PROCEDURE `sp_curso_insert`(
  IN p_nome VARCHAR(120),
  IN p_descricao TEXT,
  IN p_carga_horaria INT,
  IN p_status VARCHAR(20)
)
BEGIN
  INSERT INTO cursos (nome, descricao, carga_horaria, status)
  VALUES (p_nome, p_descricao, p_carga_horaria, IFNULL(p_status, 'ativo'));
  SELECT LAST_INSERT_ID() AS id_curso;
END$$

DROP PROCEDURE IF EXISTS `sp_curso_update`$$
CREATE PROCEDURE `sp_curso_update`(
  IN p_id_curso INT,
  IN p_nome VARCHAR(120),
  IN p_descricao TEXT,
  IN p_carga_horaria INT,
  IN p_status VARCHAR(20)
)
BEGIN
  UPDATE cursos
  SET nome = p_nome,
      descricao = p_descricao,
      carga_horaria = p_carga_horaria,
      status = IFNULL(p_status, 'ativo')
  WHERE id_curso = p_id_curso;
END$$

DROP PROCEDURE IF EXISTS `sp_curso_delete`$$
CREATE PROCEDURE `sp_curso_delete`(IN p_id_curso INT)
BEGIN
  DELETE FROM cursos WHERE id_curso = p_id_curso;
END$$

DROP PROCEDURE IF EXISTS `sp_curso_select`$$
CREATE PROCEDURE `sp_curso_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT id_curso, nome, descricao, carga_horaria, status
  FROM cursos
  WHERE nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR status LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY nome;
END$$

DROP PROCEDURE IF EXISTS `sp_curso_select_id`$$
CREATE PROCEDURE `sp_curso_select_id`(IN p_id_curso INT)
BEGIN
  SELECT id_curso, nome, descricao, carga_horaria, status
  FROM cursos
  WHERE id_curso = p_id_curso;
END$$

DROP PROCEDURE IF EXISTS `sp_disciplina_insert`$$
CREATE PROCEDURE `sp_disciplina_insert`(
  IN p_id_curso INT,
  IN p_nome VARCHAR(120),
  IN p_carga_horaria INT
)
BEGIN
  INSERT INTO disciplinas (id_curso, nome, carga_horaria)
  VALUES (p_id_curso, p_nome, p_carga_horaria);
  SELECT LAST_INSERT_ID() AS id_disciplina;
END$$

DROP PROCEDURE IF EXISTS `sp_disciplina_update`$$
CREATE PROCEDURE `sp_disciplina_update`(
  IN p_id_disciplina INT,
  IN p_id_curso INT,
  IN p_nome VARCHAR(120),
  IN p_carga_horaria INT
)
BEGIN
  UPDATE disciplinas
  SET id_curso = p_id_curso,
      nome = p_nome,
      carga_horaria = p_carga_horaria
  WHERE id_disciplina = p_id_disciplina;
END$$

DROP PROCEDURE IF EXISTS `sp_disciplina_delete`$$
CREATE PROCEDURE `sp_disciplina_delete`(IN p_id_disciplina INT)
BEGIN
  DELETE FROM disciplinas WHERE id_disciplina = p_id_disciplina;
END$$

DROP PROCEDURE IF EXISTS `sp_disciplina_select`$$
CREATE PROCEDURE `sp_disciplina_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT d.*, c.nome AS curso
  FROM disciplinas d
  INNER JOIN cursos c ON c.id_curso = d.id_curso
  WHERE d.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR c.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY d.nome;
END$$

DROP PROCEDURE IF EXISTS `sp_disciplina_select_id`$$
CREATE PROCEDURE `sp_disciplina_select_id`(IN p_id_disciplina INT)
BEGIN
  SELECT id_disciplina, id_curso, nome, carga_horaria
  FROM disciplinas
  WHERE id_disciplina = p_id_disciplina;
END$$

DROP PROCEDURE IF EXISTS `sp_turma_insert`$$
CREATE PROCEDURE `sp_turma_insert`(
  IN p_id_curso INT,
  IN p_id_professor INT,
  IN p_codigo_turma VARCHAR(50),
  IN p_turno VARCHAR(20),
  IN p_periodo_letivo VARCHAR(20),
  IN p_capacidade_maxima INT,
  IN p_status VARCHAR(20)
)
BEGIN
  INSERT INTO turmas (id_curso, id_professor, codigo_turma, turno, periodo_letivo, capacidade_maxima, status)
  VALUES (p_id_curso, p_id_professor, p_codigo_turma, p_turno, p_periodo_letivo, IFNULL(p_capacidade_maxima, 35), IFNULL(p_status, 'ativa'));
  SELECT LAST_INSERT_ID() AS id_turma;
END$$

DROP PROCEDURE IF EXISTS `sp_turma_update`$$
CREATE PROCEDURE `sp_turma_update`(
  IN p_id_turma INT,
  IN p_id_curso INT,
  IN p_id_professor INT,
  IN p_codigo_turma VARCHAR(50),
  IN p_turno VARCHAR(20),
  IN p_periodo_letivo VARCHAR(20),
  IN p_capacidade_maxima INT,
  IN p_status VARCHAR(20)
)
BEGIN
  UPDATE turmas
  SET id_curso = p_id_curso,
      id_professor = p_id_professor,
      codigo_turma = p_codigo_turma,
      turno = p_turno,
      periodo_letivo = p_periodo_letivo,
      capacidade_maxima = IFNULL(p_capacidade_maxima, 35),
      status = IFNULL(p_status, 'ativa')
  WHERE id_turma = p_id_turma;
END$$

DROP PROCEDURE IF EXISTS `sp_turma_delete`$$
CREATE PROCEDURE `sp_turma_delete`(IN p_id_turma INT)
BEGIN
  DELETE FROM turmas WHERE id_turma = p_id_turma;
END$$

DROP PROCEDURE IF EXISTS `sp_turma_select`$$
CREATE PROCEDURE `sp_turma_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT t.*, c.nome AS curso, u.nome AS professor
  FROM turmas t
  INNER JOIN cursos c ON c.id_curso = t.id_curso
  INNER JOIN professores p ON p.id_professor = t.id_professor
  INNER JOIN usuarios u ON u.id_usuario = p.id_usuario
  WHERE t.codigo_turma LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR t.periodo_letivo LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR c.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY t.periodo_letivo, t.codigo_turma;
END$$

DROP PROCEDURE IF EXISTS `sp_turma_select_id`$$
CREATE PROCEDURE `sp_turma_select_id`(IN p_id_turma INT)
BEGIN
  SELECT id_turma, id_curso, id_professor, codigo_turma, turno, periodo_letivo, capacidade_maxima, status
  FROM turmas
  WHERE id_turma = p_id_turma;
END$$

DROP PROCEDURE IF EXISTS `sp_matricula_insert`$$
CREATE PROCEDURE `sp_matricula_insert`(
  IN p_id_aluno INT,
  IN p_id_turma INT,
  IN p_data_matricula DATE,
  IN p_status VARCHAR(20)
)
BEGIN
  DECLARE v_capacidade INT DEFAULT 0;
  DECLARE v_matriculados INT DEFAULT 0;

  SELECT capacidade_maxima INTO v_capacidade
  FROM turmas
  WHERE id_turma = p_id_turma;

  SELECT COUNT(*) INTO v_matriculados
  FROM matriculas
  WHERE id_turma = p_id_turma
    AND status = 'ativa';

  IF v_matriculados >= v_capacidade THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Limite de vagas da turma atingido.';
  ELSE
    INSERT INTO matriculas (id_aluno, id_turma, data_matricula, status)
    VALUES (p_id_aluno, p_id_turma, IFNULL(p_data_matricula, CURDATE()), IFNULL(p_status, 'ativa'));
    SELECT LAST_INSERT_ID() AS id_matricula;
  END IF;
END$$

DROP PROCEDURE IF EXISTS `sp_matricula_update`$$
CREATE PROCEDURE `sp_matricula_update`(
  IN p_id_matricula INT,
  IN p_id_aluno INT,
  IN p_id_turma INT,
  IN p_data_matricula DATE,
  IN p_status VARCHAR(20)
)
BEGIN
  UPDATE matriculas
  SET id_aluno = p_id_aluno,
      id_turma = p_id_turma,
      data_matricula = p_data_matricula,
      status = IFNULL(p_status, 'ativa')
  WHERE id_matricula = p_id_matricula;
END$$

DROP PROCEDURE IF EXISTS `sp_matricula_delete`$$
CREATE PROCEDURE `sp_matricula_delete`(IN p_id_matricula INT)
BEGIN
  DELETE FROM matriculas WHERE id_matricula = p_id_matricula;
END$$

DROP PROCEDURE IF EXISTS `sp_matricula_select`$$
CREATE PROCEDURE `sp_matricula_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT m.*, u.nome AS aluno, t.codigo_turma
  FROM matriculas m
  INNER JOIN alunos a ON a.id_aluno = m.id_aluno
  INNER JOIN usuarios u ON u.id_usuario = a.id_usuario
  INNER JOIN turmas t ON t.id_turma = m.id_turma
  WHERE u.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR a.matricula LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR t.codigo_turma LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY m.data_matricula DESC;
END$$

DROP PROCEDURE IF EXISTS `sp_matricula_select_id`$$
CREATE PROCEDURE `sp_matricula_select_id`(IN p_id_matricula INT)
BEGIN
  SELECT id_matricula, id_aluno, id_turma, data_matricula, status
  FROM matriculas
  WHERE id_matricula = p_id_matricula;
END$$

DROP PROCEDURE IF EXISTS `sp_nota_lancar`$$
CREATE PROCEDURE `sp_nota_lancar`(
  IN p_id_matricula INT,
  IN p_id_disciplina INT,
  IN p_prova_1 DECIMAL(4,2),
  IN p_prova_2 DECIMAL(4,2),
  IN p_trabalho DECIMAL(4,2),
  IN p_comportamental DECIMAL(4,2)
)
BEGIN
  DECLARE v_media_uc DECIMAL(4,2);
  DECLARE v_status VARCHAR(20);

  IF p_prova_1 IS NULL OR p_prova_2 IS NULL OR p_trabalho IS NULL OR p_comportamental IS NULL THEN
    SET v_media_uc = NULL;
    SET v_status = 'em_andamento';
  ELSE
    SET v_media_uc = (p_prova_1 * 0.30) + (p_prova_2 * 0.30) + (p_trabalho * 0.30) + (p_comportamental * 0.10);
    SET v_status = IF(v_media_uc >= 6.0, 'aprovado', 'reprovado');
  END IF;

  INSERT INTO notas (id_matricula, id_disciplina, prova_1, prova_2, trabalho, comportamental, media_uc, status, data_lancamento)
  VALUES (p_id_matricula, p_id_disciplina, p_prova_1, p_prova_2, p_trabalho, p_comportamental, v_media_uc, v_status, NOW())
  ON DUPLICATE KEY UPDATE
    prova_1 = p_prova_1,
    prova_2 = p_prova_2,
    trabalho = p_trabalho,
    comportamental = p_comportamental,
    media_uc = v_media_uc,
    status = v_status,
    data_lancamento = NOW();

  IF v_media_uc IS NOT NULL AND v_media_uc < 5.0 THEN
    INSERT INTO alerta_risco (id_matricula, tipo_risco, score, status)
    VALUES (p_id_matricula, 'nota', (10.0 - v_media_uc), 'pendente');
  END IF;

  SELECT id_nota, media_uc, status
  FROM notas
  WHERE id_matricula = p_id_matricula
    AND id_disciplina = p_id_disciplina;
END$$

DROP PROCEDURE IF EXISTS `sp_nota_delete`$$
CREATE PROCEDURE `sp_nota_delete`(IN p_id_nota INT)
BEGIN
  DELETE FROM notas WHERE id_nota = p_id_nota;
END$$

DROP PROCEDURE IF EXISTS `sp_nota_select`$$
CREATE PROCEDURE `sp_nota_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT n.*, d.nome AS disciplina
  FROM notas n
  INNER JOIN disciplinas d ON d.id_disciplina = n.id_disciplina
  WHERE d.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR n.status LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY n.data_lancamento DESC;
END$$

DROP PROCEDURE IF EXISTS `sp_nota_select_id`$$
CREATE PROCEDURE `sp_nota_select_id`(IN p_id_nota INT)
BEGIN
  SELECT id_nota, id_matricula, id_disciplina, prova_1, prova_2, trabalho, comportamental, media_uc, status, data_lancamento
  FROM notas
  WHERE id_nota = p_id_nota;
END$$

DROP PROCEDURE IF EXISTS `sp_frequencia_insert`$$
CREATE PROCEDURE `sp_frequencia_insert`(
  IN p_id_matricula INT,
  IN p_id_disciplina INT,
  IN p_total_aulas INT,
  IN p_presencas INT
)
BEGIN
  INSERT INTO frequencia (id_matricula, id_disciplina, total_aulas, presencas)
  VALUES (p_id_matricula, p_id_disciplina, IFNULL(p_total_aulas, 0), IFNULL(p_presencas, 0))
  ON DUPLICATE KEY UPDATE
    total_aulas = IFNULL(p_total_aulas, 0),
    presencas = IFNULL(p_presencas, 0);

  SELECT id_frequencia, percentual
  FROM frequencia
  WHERE id_matricula = p_id_matricula
    AND id_disciplina = p_id_disciplina;
END$$

DROP PROCEDURE IF EXISTS `sp_frequencia_update`$$
CREATE PROCEDURE `sp_frequencia_update`(
  IN p_id_frequencia INT,
  IN p_id_matricula INT,
  IN p_id_disciplina INT,
  IN p_total_aulas INT,
  IN p_presencas INT
)
BEGIN
  UPDATE frequencia
  SET id_matricula = p_id_matricula,
      id_disciplina = p_id_disciplina,
      total_aulas = IFNULL(p_total_aulas, 0),
      presencas = IFNULL(p_presencas, 0)
  WHERE id_frequencia = p_id_frequencia;
END$$

DROP PROCEDURE IF EXISTS `sp_frequencia_delete`$$
CREATE PROCEDURE `sp_frequencia_delete`(IN p_id_frequencia INT)
BEGIN
  DELETE FROM frequencia WHERE id_frequencia = p_id_frequencia;
END$$

DROP PROCEDURE IF EXISTS `sp_frequencia_select`$$
CREATE PROCEDURE `sp_frequencia_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT f.*, d.nome AS disciplina
  FROM frequencia f
  INNER JOIN disciplinas d ON d.id_disciplina = f.id_disciplina
  WHERE d.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY d.nome;
END$$

DROP PROCEDURE IF EXISTS `sp_frequencia_select_id`$$
CREATE PROCEDURE `sp_frequencia_select_id`(IN p_id_frequencia INT)
BEGIN
  SELECT id_frequencia, id_matricula, id_disciplina, total_aulas, presencas, percentual
  FROM frequencia
  WHERE id_frequencia = p_id_frequencia;
END$$

DROP PROCEDURE IF EXISTS `sp_pagamento_insert`$$
CREATE PROCEDURE `sp_pagamento_insert`(
  IN p_id_aluno INT,
  IN p_valor DECIMAL(10,2),
  IN p_vencimento DATE,
  IN p_status VARCHAR(20)
)
BEGIN
  INSERT INTO pagamentos (id_aluno, valor, vencimento, status)
  VALUES (p_id_aluno, p_valor, p_vencimento, IFNULL(p_status, IF(CURDATE() > p_vencimento, 'atrasado', 'pendente')));
  SELECT LAST_INSERT_ID() AS id_pagamento;
END$$

DROP PROCEDURE IF EXISTS `sp_pagamento_update`$$
CREATE PROCEDURE `sp_pagamento_update`(
  IN p_id_pagamento INT,
  IN p_id_aluno INT,
  IN p_valor DECIMAL(10,2),
  IN p_vencimento DATE,
  IN p_status VARCHAR(20)
)
BEGIN
  UPDATE pagamentos
  SET id_aluno = p_id_aluno,
      valor = p_valor,
      vencimento = p_vencimento,
      status = IFNULL(p_status, IF(CURDATE() > p_vencimento, 'atrasado', 'pendente'))
  WHERE id_pagamento = p_id_pagamento;
END$$

DROP PROCEDURE IF EXISTS `sp_pagamento_delete`$$
CREATE PROCEDURE `sp_pagamento_delete`(IN p_id_pagamento INT)
BEGIN
  DELETE FROM pagamentos WHERE id_pagamento = p_id_pagamento;
END$$

DROP PROCEDURE IF EXISTS `sp_pagamento_select`$$
CREATE PROCEDURE `sp_pagamento_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT p.*, u.nome AS aluno
  FROM pagamentos p
  INNER JOIN alunos a ON a.id_aluno = p.id_aluno
  INNER JOIN usuarios u ON u.id_usuario = a.id_usuario
  WHERE u.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR p.status LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY p.vencimento;
END$$

DROP PROCEDURE IF EXISTS `sp_pagamento_select_id`$$
CREATE PROCEDURE `sp_pagamento_select_id`(IN p_id_pagamento INT)
BEGIN
  SELECT id_pagamento, id_aluno, valor, vencimento, status
  FROM pagamentos
  WHERE id_pagamento = p_id_pagamento;
END$$

DROP PROCEDURE IF EXISTS `sp_alerta_risco_insert`$$
CREATE PROCEDURE `sp_alerta_risco_insert`(
  IN p_id_matricula INT,
  IN p_tipo_risco VARCHAR(20),
  IN p_score DECIMAL(5,2),
  IN p_status VARCHAR(20)
)
BEGIN
  INSERT INTO alerta_risco (id_matricula, tipo_risco, score, status)
  VALUES (p_id_matricula, p_tipo_risco, p_score, IFNULL(p_status, 'pendente'));
  SELECT LAST_INSERT_ID() AS id_alerta;
END$$

DROP PROCEDURE IF EXISTS `sp_alerta_risco_update`$$
CREATE PROCEDURE `sp_alerta_risco_update`(
  IN p_id_alerta INT,
  IN p_id_matricula INT,
  IN p_tipo_risco VARCHAR(20),
  IN p_score DECIMAL(5,2),
  IN p_status VARCHAR(20)
)
BEGIN
  UPDATE alerta_risco
  SET id_matricula = p_id_matricula,
      tipo_risco = p_tipo_risco,
      score = p_score,
      status = IFNULL(p_status, 'pendente')
  WHERE id_alerta = p_id_alerta;
END$$

DROP PROCEDURE IF EXISTS `sp_alerta_risco_delete`$$
CREATE PROCEDURE `sp_alerta_risco_delete`(IN p_id_alerta INT)
BEGIN
  DELETE FROM alerta_risco WHERE id_alerta = p_id_alerta;
END$$

DROP PROCEDURE IF EXISTS `sp_alerta_risco_select`$$
CREATE PROCEDURE `sp_alerta_risco_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT ar.*, u.nome AS aluno
  FROM alerta_risco ar
  INNER JOIN matriculas m ON m.id_matricula = ar.id_matricula
  INNER JOIN alunos a ON a.id_aluno = m.id_aluno
  INNER JOIN usuarios u ON u.id_usuario = a.id_usuario
  WHERE ar.tipo_risco LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR ar.status LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR u.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY ar.id_alerta DESC;
END$$

DROP PROCEDURE IF EXISTS `sp_alerta_risco_select_id`$$
CREATE PROCEDURE `sp_alerta_risco_select_id`(IN p_id_alerta INT)
BEGIN
  SELECT id_alerta, id_matricula, tipo_risco, score, status
  FROM alerta_risco
  WHERE id_alerta = p_id_alerta;
END$$

DROP PROCEDURE IF EXISTS `sp_log_insert`$$
CREATE PROCEDURE `sp_log_insert`(
  IN p_id_usuario INT,
  IN p_acao VARCHAR(255),
  IN p_ip VARCHAR(45)
)
BEGIN
  INSERT INTO logs (id_usuario, acao, ip)
  VALUES (p_id_usuario, p_acao, p_ip);
  SELECT LAST_INSERT_ID() AS id_log;
END$$

DROP PROCEDURE IF EXISTS `sp_log_delete`$$
CREATE PROCEDURE `sp_log_delete`(IN p_id_log INT)
BEGIN
  DELETE FROM logs WHERE id_log = p_id_log;
END$$

DROP PROCEDURE IF EXISTS `sp_log_select`$$
CREATE PROCEDURE `sp_log_select`(IN p_busca VARCHAR(150))
BEGIN
  SELECT l.*, u.nome AS usuario
  FROM logs l
  INNER JOIN usuarios u ON u.id_usuario = l.id_usuario
  WHERE l.acao LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR l.ip LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
     OR u.nome LIKE CONCAT('%', IFNULL(p_busca, ''), '%')
  ORDER BY l.data_evento DESC;
END$$

DROP PROCEDURE IF EXISTS `sp_log_select_id`$$
CREATE PROCEDURE `sp_log_select_id`(IN p_id_log INT)
BEGIN
  SELECT id_log, id_usuario, acao, ip, data_evento
  FROM logs
  WHERE id_log = p_id_log;
END$$

DROP FUNCTION IF EXISTS `fn_verificar_aprovacao_geral`$$
CREATE FUNCTION `fn_verificar_aprovacao_geral`(p_id_matricula INT)
RETURNS VARCHAR(100)
DETERMINISTIC
BEGIN
  DECLARE v_total_ucs INT DEFAULT 0;
  DECLARE v_ucs_aprovadas INT DEFAULT 0;
  DECLARE v_possui_reprovacao INT DEFAULT 0;

  SELECT COUNT(d.id_disciplina) INTO v_total_ucs
  FROM matriculas m
  INNER JOIN turmas t ON t.id_turma = m.id_turma
  INNER JOIN disciplinas d ON d.id_curso = t.id_curso
  WHERE m.id_matricula = p_id_matricula;

  SELECT COUNT(*) INTO v_ucs_aprovadas
  FROM notas
  WHERE id_matricula = p_id_matricula
    AND status = 'aprovado';

  SELECT COUNT(*) INTO v_possui_reprovacao
  FROM notas
  WHERE id_matricula = p_id_matricula
    AND status = 'reprovado';

  IF v_possui_reprovacao > 0 THEN
    RETURN 'Retido no Curso: media inferior a 6.0 detectada em alguma UC.';
  ELSEIF v_ucs_aprovadas = v_total_ucs AND v_total_ucs > 0 THEN
    RETURN 'Aprovado no Curso: media superior a 6.0 em todas as UCs.';
  ELSE
    RETURN 'Cursando: existem UCs pendentes de fechamento.';
  END IF;
END$$

DELIMITER ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-06-19 14:53:04