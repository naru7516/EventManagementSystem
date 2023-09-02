-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: eventmanagementsystemdb
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `address` (
  `id` int NOT NULL AUTO_INCREMENT,
  `house_number` varchar(45) NOT NULL,
  `area` varchar(45) NOT NULL,
  `city` varchar(45) NOT NULL,
  `pincode` varchar(6) NOT NULL,
  `state` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (1,'13','Narkhede Wada','jalgaon','425102','Maharashtra'),(2,'54','Samta nagar','Dhule','48764','Maharashtra'),(3,'23','Ramanand Colony','jalgaon','45743','Bihar'),(4,'79','villeparle','sangli','12234','UttarPradesh'),(5,'34','AhilyaNagar','Shrigonda','484523','Chennai'),(6,'99','Ram Nagar','Nasik','424002','Maharashtra'),(7,'91','Ideal Colony','Pune','411021','Maharastra'),(8,'87','Anand Nagar','Nagpur','431031','Maharastra'),(9,'83','Jayanti Colony','Indore','422065','MadhyaPradesh'),(10,'79','Kanti Nagar','Surat','543009','Gujarat'),(11,'344','GOkhle NAgar','Baramati','65445','Bihar'),(12,'66','Buttiburi','Wardha','45354','UP'),(13,'54','Ramwadi','jodhpur','345443','Bihar'),(15,'44','dfldk','lcxkcl','ldkl','cklx'),(16,'23','kgg','eeerr','765','mh'),(17,'00','fdsf','strdsfsing','98976','sdfs'),(18,'00','fdsf','strdsfsing','98976','sdfs'),(19,'433','KJHGF','UGCX','3456','DGFD'),(20,'33','uuuu','yyyy','4454','xxx'),(24,'Narkhede wada,ram mandir road,bhadli,bk','Kothrood','Jalgaon District','425102','Maharashtra'),(25,'string','string','string','string','string'),(26,'00','fdsf','strdsfsing','98976','sdfs'),(27,'3','frff','cccc','cxc2','sxsx'),(28,'string','string','string','df,dlf','string'),(29,'string','string','string','df,dlf','string'),(30,'string','string','string','df,dlf','string'),(31,'123','DJKLDS','ADFLMKD','45546','DFLKNSFNDD'),(32,'406','goikhle sanchit','kolhapur','3545','bihar'),(34,'41','vanaz','pune','34983','bihar'),(35,'23','askrwadi','pune','8788','maharashtra'),(36,'11','vanaz','pune','34983','bihar'),(38,'901','chowkk','Pune','4928','Maharashtra'),(39,'101','zopadpattii','Pune','412207','Maharashtra'),(40,'122','kothrud','pune','411038','Maharashtra'),(41,'901','chowkk','Pune','4928','Maharashtra'),(42,'901','chowkk','Pune','4928','Maharashtra'),(43,'44','kothrud','pune','411038','maharashtra'),(44,'44','kothrud','pune','411038','maharashtra'),(45,'66','kothrud','pune','411038','maharashtra'),(46,'76','ramnagar','pune','546372','maha'),(47,'191','kithidie','delhi','3929','asam'),(48,'445','ShukrwarPeth','Pune','412207','maharashtra'),(49,'43','RajendraNagar','Guwahati','424001','Sikkim'),(50,'5','kothorrd','jalgaon','412207','Pune'),(51,'','','','',''),(52,'401','Gokhle Nagar','Pune','412207','Maharashtra');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `buisness_services`
--

DROP TABLE IF EXISTS `buisness_services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `buisness_services` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(100) NOT NULL,
  `price` double NOT NULL,
  `business_id` int DEFAULT NULL,
  `services_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `serviceprovidersid_idx` (`business_id`),
  KEY `servicesid_idx` (`services_id`),
  CONSTRAINT `buisness_id` FOREIGN KEY (`business_id`) REFERENCES `businesses` (`id`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `services_id` FOREIGN KEY (`services_id`) REFERENCES `services` (`id`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buisness_services`
--

LOCK TABLES `buisness_services` WRITE;
/*!40000 ALTER TABLE `buisness_services` DISABLE KEYS */;
INSERT INTO `buisness_services` VALUES (1,'Buffetsaurabhc','Best in market',120,1,1),(2,'ServingFoodSMC','proper higine,humble staff',200,1,2),(3,'SomanathDecorators','design and ballons ,pataka use in our events ',680,4,3),(4,'JayaLights','Lighting as per requirement',2500,5,4),(5,'SwamiLawns','Clean and proper maintain Lawns',1800,6,5),(6,'Sudha Hall','Halls with proper ambience',7002,7,6),(7,'Ganga hall','Ac with Ambieance',5001,2,6);
/*!40000 ALTER TABLE `buisness_services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `businesses`
--

DROP TABLE IF EXISTS `businesses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `businesses` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `contact_number` varchar(10) NOT NULL,
  `registration_number` varchar(45) NOT NULL,
  `working_status` tinyint NOT NULL DEFAULT '1',
  `login_id` int DEFAULT NULL,
  `address_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  UNIQUE KEY `contactnumber_UNIQUE` (`contact_number`),
  UNIQUE KEY `registration_number_UNIQUE` (`registration_number`),
  KEY `business_address_id_idx` (`address_id`),
  KEY `business_login_id_idx` (`login_id`),
  CONSTRAINT `business_address_id` FOREIGN KEY (`address_id`) REFERENCES `address` (`id`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `business_login_id` FOREIGN KEY (`login_id`) REFERENCES `login` (`id`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `businesses`
--

LOCK TABLES `businesses` WRITE;
/*!40000 ALTER TABLE `businesses` DISABLE KEYS */;
INSERT INTO `businesses` VALUES (1,'Saurabh c','src@gmail.com','5463678','458493548',1,2,3),(2,'Suraj Patil','sp@gmail.com','48955497','3434578293',1,4,4),(3,'Akshay Anandkar','aa@gmail.com','9876543210','654123987',1,5,5),(4,'Shailesh Soman','sa@gmail.com','8976541230','456879123',1,6,6),(5,'Jaya Jadhav','jy@gmail.com','4321567890','678943667',1,7,7),(6,'Anna kswami','ak@gmail.com','7689012345','789123457',1,8,8),(7,'Sudhaji Sudame','ss@gmail.com','7891237659','678912345',1,9,9),(12,'Anup Patil','anup@gmail.comm','98125888','1101921',1,59,38),(13,'Rushikesh Mohite','rushi11@gmail.com','88474493','3983033',1,60,39),(15,'Anup Patil','anups@gmail.comm','981258882','11019211',1,NULL,42),(16,'Khemesh m Shinde','khemeshmshinde2@gmail.com','5564495458','139822344804',1,NULL,48),(17,'virat','viratk@gmail.com','8912763450','159632478',1,NULL,49);
/*!40000 ALTER TABLE `businesses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(45) NOT NULL,
  `category_description` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Catering','making and serving food'),(2,'Decoration','enhancing ambience of stage or event.'),(3,'Venue','hill stations,halls,auditoriums ,lawn,etc.');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `email` varchar(45) NOT NULL,
  `contact_number` varchar(10) NOT NULL,
  `address_id` int DEFAULT NULL,
  `login_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  UNIQUE KEY `contactnumber_UNIQUE` (`contact_number`),
  KEY `loginid_idx` (`login_id`,`address_id`),
  KEY `client_address_id_idx` (`address_id`),
  CONSTRAINT `client_address_id` FOREIGN KEY (`address_id`) REFERENCES `address` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,'Ajay','ajay@gmail.com','796457967',1,1),(2,'khemesh','khemeshms@gmail.com','3473989',2,3),(3,'Nikhil','niks@gmail.com','6547676509',10,10),(5,'ASDFG','ASDF','456',19,25),(6,'cccc','ddd','6666',20,26),(10,'Ajay Tushar Narkhede',';','f',24,33),(11,'string','string','string',25,41),(12,'ss','sdf','99009',26,42),(13,'','','',27,43),(16,'strx.c,ing','ajay','abcdefghi',30,49),(17,'dsfjlfk','bxyz@gmaIL.COM','0012GMP2',31,50),(18,'Yohanjingre','yohan@gmail.com','0012b1l',32,51),(19,'Dipakk','dipss12@gmail.com','110010',35,55),(20,'jagan Singh','jagan@123','9897867756',44,67),(21,'jagan','jaganss@gmail.com','734637382',45,68),(22,'khemesh','khems@gmail.com','5463728197',46,70),(23,'Bhushan Upasani','bhu12@gmail.com','568568964',47,71),(24,'SAurabhhhh Patil','src@gmail.com','989811000',50,76),(25,'Hitesh Patil','hits@gmail.com','7767945845',52,82);
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `feedback`
--

DROP TABLE IF EXISTS `feedback`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `feedback` (
  `id` int NOT NULL AUTO_INCREMENT,
  `client_id` int DEFAULT NULL,
  `business_service_id` int DEFAULT NULL,
  `feedback_status_id` int DEFAULT NULL,
  `comment` varchar(100) DEFAULT NULL,
  `business_reply` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `clientid_idx` (`client_id`),
  KEY `fsp-sid_idx` (`business_service_id`),
  KEY `feedbackstatusid_idx` (`feedback_status_id`),
  CONSTRAINT `feedback_buisness_service_id` FOREIGN KEY (`business_service_id`) REFERENCES `buisness_services` (`id`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `feedback_client_id` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `feedback_status_id` FOREIGN KEY (`feedback_status_id`) REFERENCES `feedback_status` (`id`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feedback`
--

LOCK TABLES `feedback` WRITE;
/*!40000 ALTER TABLE `feedback` DISABLE KEYS */;
INSERT INTO `feedback` VALUES (1,1,1,3,'bad behaviour','we will improve sir'),(2,2,5,2,'lights are ok ','next we will improve our look and feel sir'),(3,3,6,1,'awesome','thanks');
/*!40000 ALTER TABLE `feedback` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `feedback_status`
--

DROP TABLE IF EXISTS `feedback_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `feedback_status` (
  `id` int NOT NULL AUTO_INCREMENT,
  `feedback_status` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feedback_status`
--

LOCK TABLES `feedback_status` WRITE;
/*!40000 ALTER TABLE `feedback_status` DISABLE KEYS */;
INSERT INTO `feedback_status` VALUES (1,'good'),(2,'average'),(3,'bad');
/*!40000 ALTER TABLE `feedback_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(15) NOT NULL,
  `user_type_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `logincol_UNIQUE` (`username`),
  KEY `roleid_idx` (`user_type_id`),
  CONSTRAINT `user_type_id` FOREIGN KEY (`user_type_id`) REFERENCES `user_type` (`id`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=84 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES (1,'naru','naru123',1),(2,'saurabh','src',2),(3,'khemo','paul',1),(4,'suraj','suraj@123',2),(5,'Akshay','akshay123',2),(6,'Shailesh','shailesh@123',2),(7,'Jaya','jaya@123',2),(8,'Anna','anna@123',2),(9,'Sudhaji','sudhaji@123',2),(10,'Nikhil','nikhil@123',1),(14,'swara','swara123',1),(15,'dip','dip123',1),(51,'yohan123','yohanjin',1),(54,'ahitesh','ahitesh',2),(55,'dipsss','dips',1),(56,'bbfgfht','ahitesh',2),(58,'jamun','jamwant',2),(59,'anupp','anup123',2),(60,'rushi12','rushii123',2),(83,'Naru12','Naru@7516',3);
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_details`
--

DROP TABLE IF EXISTS `order_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_details` (
  `id` int NOT NULL AUTO_INCREMENT,
  `order_id` int DEFAULT NULL,
  `buisness_service_id` int DEFAULT NULL,
  `price` double NOT NULL,
  PRIMARY KEY (`id`),
  KEY `orderid_idx` (`order_id`),
  KEY `sp-sid_idx` (`buisness_service_id`),
  CONSTRAINT `business_service_id` FOREIGN KEY (`buisness_service_id`) REFERENCES `buisness_services` (`id`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `order_id` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_details`
--

LOCK TABLES `order_details` WRITE;
/*!40000 ALTER TABLE `order_details` DISABLE KEYS */;
INSERT INTO `order_details` VALUES (1,1,1,1800),(2,2,4,1900),(3,3,6,1920);
/*!40000 ALTER TABLE `order_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `id` int NOT NULL AUTO_INCREMENT,
  `client_id` int DEFAULT NULL,
  `booking_date` date NOT NULL,
  `payment_status` tinyint NOT NULL,
  `payment_mode` varchar(45) NOT NULL,
  `order_date` date NOT NULL,
  `total_price` double NOT NULL,
  `transaction_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `clientid_idx` (`client_id`),
  CONSTRAINT `client_id` FOREIGN KEY (`client_id`) REFERENCES `clients` (`id`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,1,'2023-04-08',1,'online','2023-03-29',6700,1001),(2,2,'2023-05-06',1,'cash','2023-04-02',7800,1002),(3,3,'2023-06-07',1,'cash','2023-04-14',6100,1003);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `services`
--

DROP TABLE IF EXISTS `services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `services` (
  `id` int NOT NULL AUTO_INCREMENT,
  `service_name` varchar(45) NOT NULL,
  `service_description` varchar(200) NOT NULL,
  `categories_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `categories_id_idx` (`categories_id`),
  CONSTRAINT `categories_id` FOREIGN KEY (`categories_id`) REFERENCES `categories` (`id`) ON DELETE SET NULL ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
INSERT INTO `services` VALUES (1,'buffet','best food and since 1999. we provides higenic food',1),(2,'serving food','serving best food for breakfast, lunch and dinner',1),(3,'with ballon','our event is decoration will be using ballon',2),(4,'theme_lights','event will be decoration in dark, light mode',2),(5,'Lawns','green and ambience view for any party or any type of gathering',3),(6,'AC Halls','its auditorium and use for meeting and presentation',3),(7,'hill station','lake view and valley view',3);
/*!40000 ALTER TABLE `services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_type`
--

DROP TABLE IF EXISTS `user_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_type` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_type` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `rolename_UNIQUE` (`user_type`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_type`
--

LOCK TABLES `user_type` WRITE;
/*!40000 ALTER TABLE `user_type` DISABLE KEYS */;
INSERT INTO `user_type` VALUES (3,'Admin'),(2,'buisness'),(1,'client');
/*!40000 ALTER TABLE `user_type` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-09-01 19:14:15
