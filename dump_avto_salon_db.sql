-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: avto_salon_db
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `avto`
--

DROP TABLE IF EXISTS `avto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `avto` (
  `id_avto` int NOT NULL AUTO_INCREMENT,
  `marka_avto` varchar(50) NOT NULL,
  `tip_avto` varchar(20) DEFAULT NULL,
  `strana` varchar(20) NOT NULL,
  `nomer_kuzova` varchar(17) NOT NULL,
  `god_vypuska` year NOT NULL,
  `cvet_kuzova` varchar(20) NOT NULL,
  `data_postupleniya` date NOT NULL,
  `cena_avto` double(10,2) NOT NULL,
  `id_status` int NOT NULL,
  PRIMARY KEY (`id_avto`),
  KEY `fk_avto_status` (`id_status`),
  CONSTRAINT `fk_avto_status` FOREIGN KEY (`id_status`) REFERENCES `status` (`id_status`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avto`
--

LOCK TABLES `avto` WRITE;
/*!40000 ALTER TABLE `avto` DISABLE KEYS */;
INSERT INTO `avto` VALUES (1,'Hino Motors','Грузовик','Япония','G58H99N654S5102R7',2015,'Зеленый','2022-09-15',2900000.00,2),(2,'BMW','Седан','Германия','G5895484DFSQW45R7',2019,'Серый ','2022-09-29',10000000.00,2),(3,'Chery Tiggo','Универсал','Китай','12578GY12R346W170',2018,'Белый','2022-10-10',1700000.00,1),(4,'LADA Granta','Универсал','Россия','5987RE365S98H12O7',2022,'Черный','2022-10-10',675000.00,2),(5,'Ford Focus','Универсал','Германия','98542D8356W21D69S',2020,'Синий','2022-10-15',2000000.50,1),(6,'BMW','Седан','Германия','651XGS6546546D54F',2021,'Красный','2022-10-20',11000000.00,1),(7,'EXEED LX','Кроссовер','Китай','4653S22G323WE2110',2022,'Черный','2022-10-22',4750000.00,1),(8,'Hino Motors','Грузовик','Япония','4884D64S8R6504W29',2017,'Белый','2022-10-10',4100000.00,1),(9,'LADA Kalina','Универсал','Россия','856A432U35R14B6W3',2017,'Коричневый','2022-10-14',450000.00,1),(10,'Kia Mohave I','Внедорожник','Южная Корея','4896A6D4W9F46G646',2022,'Белый','2022-10-25',5000000.00,1);
/*!40000 ALTER TABLE `avto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `avtorizacia`
--

DROP TABLE IF EXISTS `avtorizacia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `avtorizacia` (
  `id_user` int NOT NULL AUTO_INCREMENT,
  `login` varchar(10) NOT NULL,
  `password` varchar(10) NOT NULL,
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avtorizacia`
--

LOCK TABLES `avtorizacia` WRITE;
/*!40000 ALTER TABLE `avtorizacia` DISABLE KEYS */;
INSERT INTO `avtorizacia` VALUES (1,'1111','1111'),(2,'3333','3333');
/*!40000 ALTER TABLE `avtorizacia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menedzher`
--

DROP TABLE IF EXISTS `menedzher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menedzher` (
  `id_menedzher` int NOT NULL AUTO_INCREMENT,
  `fio_menedzher` varchar(30) NOT NULL,
  `telefon` varchar(18) NOT NULL,
  PRIMARY KEY (`id_menedzher`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menedzher`
--

LOCK TABLES `menedzher` WRITE;
/*!40000 ALTER TABLE `menedzher` DISABLE KEYS */;
INSERT INTO `menedzher` VALUES (1,'Воронцов Артём Дмитриевич','+7 (930) 185-70-98'),(2,'Кулакова Мария Александровна','+7 (952) 299-54-76'),(3,'Баранов Марк Всеволодович','+7 (966) 752-44-26'),(4,'Лебедева Амина Ивановна','+7 (916) 912-47-29'),(5,'Авдеев Мирослав Алиевич','+7 (979) 444-38-92'),(6,'Соколов Алексей Михайлович','+7 (643) 136-56-98');
/*!40000 ALTER TABLE `menedzher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pokupatel`
--

DROP TABLE IF EXISTS `pokupatel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pokupatel` (
  `id_pokupatel` int NOT NULL AUTO_INCREMENT,
  `fio_pokupatel` varchar(30) NOT NULL,
  `pasport` varchar(12) NOT NULL,
  `adres` varchar(50) NOT NULL,
  `telefon` varchar(18) NOT NULL,
  PRIMARY KEY (`id_pokupatel`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pokupatel`
--

LOCK TABLES `pokupatel` WRITE;
/*!40000 ALTER TABLE `pokupatel` DISABLE KEYS */;
INSERT INTO `pokupatel` VALUES (1,'Горбунов Андрей Артёмович','33 33 323233','г. Рубцовск, Советская ул., д. 1 кв.173','+7 (643) 896-45-63'),(2,'Кожевников Олег Егорович','58 90 948868','г. Астрахань, Дзержинского ул., д. 8 кв.195','+7 (918) 434-27-26'),(3,'Иванова Мария Борисовна','16 44 021937','г. Сургут, Зеленая ул., д. 3 кв.133','+7 (915) 468-93-78'),(4,'Лебедева Амина Ивановна','61 96 413121','г. Ковров, Партизанская ул., д. 10 кв.92','+7 (987) 645-61-32'),(5,'Завьялова Анна Никитична','97 40 291626','г. Керчь, Вокзальная ул., д. 10 кв.158','+7 (978) 964-14-35'),(6,'Левина Вера Дмитриевна','64 31 931331','г. Каспийск, Чапаева ул., д. 13 кв.43','+7 (931) 464-15-37');
/*!40000 ALTER TABLE `pokupatel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prodazha`
--

DROP TABLE IF EXISTS `prodazha`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prodazha` (
  `id_prodazhi` int NOT NULL AUTO_INCREMENT,
  `data_prodazhi` date NOT NULL,
  `id_avto` int NOT NULL,
  `id_menedzhera` int NOT NULL,
  `id_pokupatelya` int NOT NULL,
  PRIMARY KEY (`id_prodazhi`),
  KEY `fk_prodazha_avto` (`id_avto`),
  KEY `fk_prodazha_menedzher` (`id_menedzhera`),
  KEY `fk_prodazha_pokupatel` (`id_pokupatelya`),
  CONSTRAINT `fk_prodazha_avto` FOREIGN KEY (`id_avto`) REFERENCES `avto` (`id_avto`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_prodazha_menedzher` FOREIGN KEY (`id_menedzhera`) REFERENCES `menedzher` (`id_menedzher`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_prodazha_pokupatel` FOREIGN KEY (`id_pokupatelya`) REFERENCES `pokupatel` (`id_pokupatel`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prodazha`
--

LOCK TABLES `prodazha` WRITE;
/*!40000 ALTER TABLE `prodazha` DISABLE KEYS */;
INSERT INTO `prodazha` VALUES (1,'2022-10-17',4,2,3),(2,'2022-10-26',1,1,1),(3,'2022-10-26',2,5,2);
/*!40000 ALTER TABLE `prodazha` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `id_status` int NOT NULL AUTO_INCREMENT,
  `status` varchar(10) NOT NULL,
  PRIMARY KEY (`id_status`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
INSERT INTO `status` VALUES (1,'В наличии'),(2,'Продано');
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-10-26 22:31:48
