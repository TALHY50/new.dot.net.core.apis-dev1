-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: xxx
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `acl_branches`
--

DROP TABLE IF EXISTS `acl_branches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_branches` (
  `id` int NOT NULL AUTO_INCREMENT,
  `company_id` int NOT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `status` tinyint NOT NULL,
  `sequence` int NOT NULL,
  `created_by_id` int NOT NULL,
  `updated_by_id` int NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_branches`
--

LOCK TABLES `acl_branches` WRITE;
/*!40000 ALTER TABLE `acl_branches` DISABLE KEYS */;
INSERT INTO `acl_branches` VALUES (1,2,'Test','Dhaka','Test',1,1,1,1,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(2,0,'Uttara Branch','Uttara sector 11','This is sub branch.',1,1,0,0,'2024-05-20 17:53:44.930363','2024-05-20 17:53:44.930291');
/*!40000 ALTER TABLE `acl_branches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_companies`
--

DROP TABLE IF EXISTS `acl_companies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_companies` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `cname` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `cemail` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `address1` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `address2` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `postcode` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `fax` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `city` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `state` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `country` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `logo` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `registration_no` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `timezone` int NOT NULL,
  `unique_column_name` tinyint NOT NULL DEFAULT '1',
  `timezone_value` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `tax_no` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `tax_office` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `sector` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `average_turnover` double(16,4) NOT NULL,
  `no_of_employees` int NOT NULL,
  `cmmi_level` tinyint NOT NULL,
  `yearly_revenue` double(16,4) NOT NULL,
  `hourly_rate` double(12,4) NOT NULL,
  `daily_rate` double(12,4) NOT NULL,
  `status` tinyint NOT NULL DEFAULT '1',
  `added_by` int NOT NULL DEFAULT '1',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_companies`
--

LOCK TABLES `acl_companies` WRITE;
/*!40000 ALTER TABLE `acl_companies` DISABLE KEYS */;
INSERT INTO `acl_companies` VALUES (1,'Default','Admin','ssadmin@softrobotics.com','A','A2','4100','031','ssadmin@softrobotics.com','Fax','C','s','BD','logo','420',254,1,'TimeZone','tax',NULL,NULL,0.0000,6,0,0.0000,0.0000,0.0000,1,1,'2015-11-03 19:52:01','2019-03-28 07:29:33'),(2,'Mahmud','mahmud','mahmud@gmail.com','Sirajgonj','Dhaka bangladesh','1229','+880152455','test@gmail.com','+99845','Dhaka','Dhaka','Bangladesh','logon.png','5444654',6,1,'bd','465456',NULL,NULL,0.0000,0,0,0.0000,0.0000,0.0000,1,1,'2024-05-20 11:25:34','2024-05-20 11:25:34');
/*!40000 ALTER TABLE `acl_companies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_company_modules`
--

DROP TABLE IF EXISTS `acl_company_modules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_company_modules` (
  `id` int NOT NULL AUTO_INCREMENT,
  `company_id` int NOT NULL,
  `module_id` int NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_company_modules`
--

LOCK TABLES `acl_company_modules` WRITE;
/*!40000 ALTER TABLE `acl_company_modules` DISABLE KEYS */;
INSERT INTO `acl_company_modules` VALUES (1,1,1001,'2015-11-04 01:52:01','2019-03-28 13:29:33'),(2,1,1002,'2024-05-20 17:55:10','2024-05-20 17:55:10');
/*!40000 ALTER TABLE `acl_company_modules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_countries`
--

DROP TABLE IF EXISTS `acl_countries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_countries` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `status` tinyint NOT NULL,
  `sequence` int NOT NULL,
  `created_by_id` int NOT NULL,
  `updated_by_id` int NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=250 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_countries`
--

LOCK TABLES `acl_countries` WRITE;
/*!40000 ALTER TABLE `acl_countries` DISABLE KEYS */;
INSERT INTO `acl_countries` VALUES (1,'Afghanistan','This is beautiful country','AF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(2,'Albania','This is beautiful country','AL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(3,'Algeria','This is beautiful country','DZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(4,'American Samoa','This is beautiful country','AS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(5,'Andorra','This is beautiful country','AD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(6,'Angola','This is beautiful country','AO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(7,'Anguilla','This is beautiful country','AI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(8,'Antarctica','This is beautiful country','AQ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(9,'Antigua and Barbuda','This is beautiful country','AG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(10,'Argentina','This is beautiful country','AR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(11,'Armenia','This is beautiful country','AM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(12,'Aruba','This is beautiful country','AW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(13,'Australia','This is beautiful country','AU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(14,'Austria','This is beautiful country','AT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(15,'Azerbaijan','This is beautiful country','AZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(16,'Bahamas','This is beautiful country','BS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(17,'Bahrain','This is beautiful country','BH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(18,'Bangladesh','This is beautiful country','BD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(19,'Barbados','This is beautiful country','BB',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(20,'Belarus','This is beautiful country','BY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(21,'Belgium','This is beautiful country','BE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(22,'Belize','This is beautiful country','BZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(23,'Benin','This is beautiful country','BJ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(24,'Bermuda','This is beautiful country','BM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(25,'Bhutan','This is beautiful country','BT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(26,'Bolivia, Plurinational State of','This is beautiful country','BO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(27,'Bonaire, Sint Eustatius and Saba','This is beautiful country','BQ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(28,'Bosnia and Herzegovina','This is beautiful country','BA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(29,'Botswana','This is beautiful country','BW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(30,'Bouvet Island','This is beautiful country','BV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(31,'Brazil','This is beautiful country','BR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(32,'British Indian Ocean Territory','This is beautiful country','IO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(33,'Brunei Darussalam','This is beautiful country','BN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(34,'Bulgaria','This is beautiful country','BG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(35,'Burkina Faso','This is beautiful country','BF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(36,'Burundi','This is beautiful country','BI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(37,'Cambodia','This is beautiful country','KH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(38,'Cameroon','This is beautiful country','CM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(39,'Canada','This is beautiful country','CA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(40,'Cape Verde','This is beautiful country','CV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(41,'Cayman Islands','This is beautiful country','KY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(42,'Central African Republic','This is beautiful country','CF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(43,'Chad','This is beautiful country','TD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(44,'Chile','This is beautiful country','CL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(45,'China','This is beautiful country','CN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(46,'Christmas Island','This is beautiful country','CX',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(47,'Cocos (Keeling) Islands','This is beautiful country','CC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(48,'Colombia','This is beautiful country','CO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(49,'Comoros','This is beautiful country','KM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(50,'Congo','This is beautiful country','CG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(51,'Congo, the Democratic Republic of the','This is beautiful country','CD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(52,'Cook Islands','This is beautiful country','CK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(53,'Costa Rica','This is beautiful country','CR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(54,'Croatia','This is beautiful country','HR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(55,'Cuba','This is beautiful country','CU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(56,'CuraÃ§ao','This is beautiful country','CW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(57,'Cyprus','This is beautiful country','CY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(58,'Czech Republic','This is beautiful country','CZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(59,'CÃ´te d\'Ivoire','This is beautiful country','CI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(60,'Denmark','This is beautiful country','DK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(61,'Djibouti','This is beautiful country','DJ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(62,'Dominica','This is beautiful country','DM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(63,'Dominican Republic','This is beautiful country','DO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(64,'Ecuador','This is beautiful country','EC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(65,'Egypt','This is beautiful country','EG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(66,'El Salvador','This is beautiful country','SV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(67,'Equatorial Guinea','This is beautiful country','GQ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(68,'Eritrea','This is beautiful country','ER',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(69,'Estonia','This is beautiful country','EE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(70,'Ethiopia','This is beautiful country','ET',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(71,'Falkland Islands (Malvinas)','This is beautiful country','FK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(72,'Faroe Islands','This is beautiful country','FO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(73,'Fiji','This is beautiful country','FJ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(74,'Finland','This is beautiful country','FI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(75,'France','This is beautiful country','FR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(76,'French Guiana','This is beautiful country','GF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(77,'French Polynesia','This is beautiful country','PF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(78,'French Southern Territories','This is beautiful country','TF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(79,'Gabon','This is beautiful country','GA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(80,'Gambia','This is beautiful country','GM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(81,'Georgia','This is beautiful country','GE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(82,'Germany','This is beautiful country','DE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(83,'Ghana','This is beautiful country','GH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(84,'Gibraltar','This is beautiful country','GI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(85,'Greece','This is beautiful country','GR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(86,'Greenland','This is beautiful country','GL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(87,'Grenada','This is beautiful country','GD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(88,'Guadeloupe','This is beautiful country','GP',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(89,'Guam','This is beautiful country','GU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(90,'Guatemala','This is beautiful country','GT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(91,'Guernsey','This is beautiful country','GG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(92,'Guinea','This is beautiful country','GN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(93,'Guinea-Bissau','This is beautiful country','GW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(94,'Guyana','This is beautiful country','GY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(95,'Haiti','This is beautiful country','HT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(96,'Heard Island and McDonald Islands','This is beautiful country','HM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(97,'Holy See (Vatican City State)','This is beautiful country','VA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(98,'Honduras','This is beautiful country','HN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(99,'Hong Kong','This is beautiful country','HK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(100,'Hungary','This is beautiful country','HU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(101,'Iceland','This is beautiful country','IS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(102,'India','This is beautiful country','IN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(103,'Indonesia','This is beautiful country','ID',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(104,'Iran, Islamic Republic of','This is beautiful country','IR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(105,'Iraq','This is beautiful country','IQ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(106,'Ireland','This is beautiful country','IE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(107,'Isle of Man','This is beautiful country','IM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(108,'Israel','This is beautiful country','IL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(109,'Italy','This is beautiful country','IT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(110,'Jamaica','This is beautiful country','JM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(111,'Japan','This is beautiful country','JP',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(112,'Jersey','This is beautiful country','JE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(113,'Jordan','This is beautiful country','JO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(114,'Kazakhstan','This is beautiful country','KZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(115,'Kenya','This is beautiful country','KE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(116,'Kiribati','This is beautiful country','KI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(117,'Korea, Democratic People\'s Republic of','This is beautiful country','KP',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(118,'Korea, Republic of','This is beautiful country','KR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(119,'Kuwait','This is beautiful country','KW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(120,'Kyrgyzstan','This is beautiful country','KG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(121,'Lao People\'s Democratic Republic','This is beautiful country','LA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(122,'Latvia','This is beautiful country','LV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(123,'Lebanon','This is beautiful country','LB',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(124,'Lesotho','This is beautiful country','LS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(125,'Liberia','This is beautiful country','LR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(126,'Libya','This is beautiful country','LY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(127,'Liechtenstein','This is beautiful country','LI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(128,'Lithuania','This is beautiful country','LT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(129,'Luxembourg','This is beautiful country','LU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(130,'Macao','This is beautiful country','MO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(131,'Macedonia, the Former Yugoslav Republic of','This is beautiful country','MK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(132,'Madagascar','This is beautiful country','MG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(133,'Malawi','This is beautiful country','MW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(134,'Malaysia','This is beautiful country','MY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(135,'Maldives','This is beautiful country','MV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(136,'Mali','This is beautiful country','ML',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(137,'Malta','This is beautiful country','MT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(138,'Marshall Islands','This is beautiful country','MH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(139,'Martinique','This is beautiful country','MQ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(140,'Mauritania','This is beautiful country','MR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(141,'Mauritius','This is beautiful country','MU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(142,'Mayotte','This is beautiful country','YT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(143,'Mexico','This is beautiful country','MX',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(144,'Micronesia, Federated States of','This is beautiful country','FM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(145,'Moldova, Republic of','This is beautiful country','MD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(146,'Monaco','This is beautiful country','MC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(147,'Mongolia','This is beautiful country','MN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(148,'Montenegro','This is beautiful country','ME',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(149,'Montserrat','This is beautiful country','MS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(150,'Morocco','This is beautiful country','MA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(151,'Mozambique','This is beautiful country','MZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(152,'Myanmar','This is beautiful country','MM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(153,'Namibia','This is beautiful country','NA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(154,'Nauru','This is beautiful country','NR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(155,'Nepal','This is beautiful country','NP',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(156,'Netherlands','This is beautiful country','NL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(157,'New Caledonia','This is beautiful country','NC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(158,'New Zealand','This is beautiful country','NZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(159,'Nicaragua','This is beautiful country','NI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(160,'Niger','This is beautiful country','NE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(161,'Nigeria','This is beautiful country','NG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(162,'Niue','This is beautiful country','NU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(163,'Norfolk Island','This is beautiful country','NF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(164,'Northern Mariana Islands','This is beautiful country','MP',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(165,'Norway','This is beautiful country','NO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(166,'Oman','This is beautiful country','OM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(167,'Pakistan','This is beautiful country','PK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(168,'Palau','This is beautiful country','PW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(169,'Palestine, State of','This is beautiful country','PS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(170,'Panama','This is beautiful country','PA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(171,'Papua New Guinea','This is beautiful country','PG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(172,'Paraguay','This is beautiful country','PY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(173,'Peru','This is beautiful country','PE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(174,'Philippines','This is beautiful country','PH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(175,'Pitcairn','This is beautiful country','PN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(176,'Poland','This is beautiful country','PL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(177,'Portugal','This is beautiful country','PT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(178,'Puerto Rico','This is beautiful country','PR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(179,'Qatar','This is beautiful country','QA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(180,'Romania','This is beautiful country','RO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(181,'Russian Federation','This is beautiful country','RU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(182,'Rwanda','This is beautiful country','RW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(183,'RÃ©union','This is beautiful country','RE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(184,'Saint BarthÃ©lemy','This is beautiful country','BL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(185,'Saint Helena, Ascension and Tristan da Cunha','This is beautiful country','SH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(186,'Saint Kitts and Nevis','This is beautiful country','KN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(187,'Saint Lucia','This is beautiful country','LC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(188,'Saint Martin (French part)','This is beautiful country','MF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(189,'Saint Pierre and Miquelon','This is beautiful country','PM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(190,'Saint Vincent and the Grenadines','This is beautiful country','VC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(191,'Samoa','This is beautiful country','WS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(192,'San Marino','This is beautiful country','SM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(193,'Sao Tome and Principe','This is beautiful country','ST',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(194,'Saudi Arabia','This is beautiful country','SA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(195,'Senegal','This is beautiful country','SN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(196,'Serbia','This is beautiful country','RS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(197,'Seychelles','This is beautiful country','SC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(198,'Sierra Leone','This is beautiful country','SL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(199,'Singapore','This is beautiful country','SG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(200,'Sint Maarten (Dutch part)','This is beautiful country','SX',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(201,'Slovakia','This is beautiful country','SK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(202,'Slovenia','This is beautiful country','SI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(203,'Solomon Islands','This is beautiful country','SB',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(204,'Somalia','This is beautiful country','SO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(205,'South Africa','This is beautiful country','ZA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(206,'South Georgia and the South Sandwich Islands','This is beautiful country','GS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(207,'South Sudan','This is beautiful country','SS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(208,'Spain','This is beautiful country','ES',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(209,'Sri Lanka','This is beautiful country','LK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(210,'Sudan','This is beautiful country','SD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(211,'Suriname','This is beautiful country','SR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(212,'Svalbard and Jan Mayen','This is beautiful country','SJ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(213,'Swaziland','This is beautiful country','SZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(214,'Sweden','This is beautiful country','SE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(215,'Switzerland','This is beautiful country','CH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(216,'Syrian Arab Republic','This is beautiful country','SY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(217,'Taiwan, Province of China','This is beautiful country','TW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(218,'Tajikistan','This is beautiful country','TJ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(219,'Tanzania, United Republic of','This is beautiful country','TZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(220,'Thailand','This is beautiful country','TH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(221,'Timor-Leste','This is beautiful country','TL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(222,'Togo','This is beautiful country','TG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(223,'Tokelau','This is beautiful country','TK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(224,'Tonga','This is beautiful country','TO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(225,'Trinidad and Tobago','This is beautiful country','TT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(226,'Tunisia','This is beautiful country','TN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(227,'Turkey','This is beautiful country','TR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(228,'Turkmenistan','This is beautiful country','TM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(229,'Turks and Caicos Islands','This is beautiful country','TC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(230,'Tuvalu','This is beautiful country','TV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(231,'Uganda','This is beautiful country','UG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(232,'Ukraine','This is beautiful country','UA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(233,'United Arab Emirates','This is beautiful country','AE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(234,'United Kingdom','This is beautiful country','GB',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(235,'United States','This is beautiful country','US',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(236,'United States Minor Outlying Islands','This is beautiful country','UM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(237,'Uruguay','This is beautiful country','UY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(238,'Uzbekistan','This is beautiful country','UZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(239,'Vanuatu','This is beautiful country','VU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(240,'Venezuela, Bolivarian Republic of','This is beautiful country','VE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(241,'Viet Nam','This is beautiful country','VN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(242,'Virgin Islands, British','This is beautiful country','VG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(243,'Virgin Islands, U.S.','This is beautiful country','VI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(244,'Wallis and Futuna','This is beautiful country','WF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(245,'Western Sahara','This is beautiful country','EH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(246,'Yemen','This is beautiful country','YE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(247,'Zambia','This is beautiful country','ZM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(248,'Zimbabwe','This is beautiful country','ZW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(249,'Ã…land Islands','This is beautiful country','AX',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000');
/*!40000 ALTER TABLE `acl_countries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_modules`
--

DROP TABLE IF EXISTS `acl_modules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_modules` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `icon` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `sequence` int NOT NULL,
  `display_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1011 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_modules`
--

LOCK TABLES `acl_modules` WRITE;
/*!40000 ALTER TABLE `acl_modules` DISABLE KEYS */;
INSERT INTO `acl_modules` VALUES (1001,'Company','<i class=\"fa fa-list-ul\"></i>',6,'Company','2015-12-09 12:10:46','2019-03-20 21:52:50'),(1002,'Master Data','<i class=\"fa fa-list-ul\"></i>',2,'Master Data','2015-12-09 12:10:46','2019-03-26 22:38:37'),(1003,'Access Control','<img src=\"adminca/assets/img/icons/access-control.svg\" />',1099,'Access Control','2015-12-09 12:10:47','2024-05-20 17:13:38'),(1004,'Hrm Module','<i class=\'fa fa-list-ul\'></i>',1,'Hrm Module','2024-05-16 19:59:59','2024-05-17 14:37:17');
/*!40000 ALTER TABLE `acl_modules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_page_routes`
--

DROP TABLE IF EXISTS `acl_page_routes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_page_routes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `page_id` int DEFAULT NULL,
  `route_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `route_url` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `acl_page_routes_page_id_index` (`page_id`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_page_routes`
--

LOCK TABLES `acl_page_routes` WRITE;
/*!40000 ALTER TABLE `acl_page_routes` DISABLE KEYS */;
INSERT INTO `acl_page_routes` VALUES (1,3001,'acl.company.list','companies',NULL,NULL),(2,3002,'acl.company.add','companies/add',NULL,NULL),(3,3003,'acl.company.edit','companies/edit/{id}',NULL,NULL),(4,3004,'acl.company.destroy','companies/delete/{id}',NULL,NULL),(5,3005,'acl.company.show','companies/view/{id}',NULL,NULL),(6,3015,'acl.module.list','modules',NULL,NULL),(7,3016,'acl.module.add','modules/add',NULL,NULL),(8,3017,'acl.module.edit','modules/edit/{id}',NULL,NULL),(9,3018,'acl.module.destroy','modules/delete/{id}',NULL,NULL),(10,3019,'acl.module.view','modules/view/{id}',NULL,NULL),(11,3080,'acl.company_module.list','company/modules',NULL,NULL),(12,3081,'acl.company_module.add','company/modules/add',NULL,NULL),(13,3082,'acl.company_module.edit','company/modules/edit/{id}',NULL,NULL),(14,3083,'acl.company_module.destroy','company/modules/delete/{id}',NULL,NULL),(15,3084,'acl.company_module.view','company/modules/view/{id}',NULL,NULL),(16,3025,'acl.submodule.list','submodules',NULL,NULL),(17,3026,'acl.submodule.add','submodules/add',NULL,NULL),(18,3027,'acl.submodule.edit','submodules/edit/{id}',NULL,NULL),(19,3028,'acl.submodule.destroy','submodules/delete/{id}',NULL,NULL),(20,3029,'acl.submodule.view','submodules/view/{id}',NULL,NULL),(21,3035,'acl.page.list','pages',NULL,NULL),(22,3036,'acl.page.add','pages/add',NULL,NULL),(23,3037,'acl.page.edit','pages/edit/{id}',NULL,NULL),(24,3038,'acl.page.destroy','pages/delete/{id}',NULL,NULL),(25,3039,'acl.page.view','pages/view/{id}',NULL,NULL),(26,3045,'acl.user.list','users',NULL,NULL),(27,3046,'acl.user.add','users/add',NULL,NULL),(28,3047,'acl.user.edit','users/edit/{id}',NULL,NULL),(29,3048,'acl.user.destroy','users/delete/{id}',NULL,NULL),(30,3049,'acl.user.view','users/view/{id}',NULL,NULL),(31,3055,'acl.role.list','roles',NULL,NULL),(32,3056,'acl.role.add','roles/add',NULL,NULL),(33,3057,'acl.role.edit','roles/edit/{id}',NULL,NULL),(34,3058,'acl.role.destroy','roles/delete/{id}',NULL,NULL),(35,3059,'acl.role.view','roles/view/{id}',NULL,NULL),(36,3065,'acl.usergroups.list','usergroups',NULL,NULL),(37,3066,'acl.usergroups.add','usergroups/add',NULL,NULL),(38,3067,'acl.usergroups.edit','usergroups/edit/{id}',NULL,NULL),(39,3068,'acl.usergroups.destroy','usergroups/delete/{id}',NULL,NULL),(40,3069,'acl.usergroups.view','usergroups/view/{id}',NULL,NULL),(41,3075,'acl.usergroups.role.association','usergroups/roles/{user_group_id}',NULL,NULL),(42,3076,'acl.usergroups.role.association.update','usergroups/roles/update',NULL,NULL),(43,3078,'acl.role&page.association','permissions/associations/{role_id}',NULL,NULL),(44,3079,'acl.role&page.association.update','permissions/associations/update',NULL,NULL),(45,3036,'acl.page.route.add','pages/routes/add',NULL,NULL),(46,3037,'acl.page.route.edit','pages/routes/edit/{id}',NULL,NULL),(47,3038,'acl.page.route.destroy','pages/routes/delete/{id}',NULL,NULL);
/*!40000 ALTER TABLE `acl_page_routes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_pages`
--

DROP TABLE IF EXISTS `acl_pages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_pages` (
  `id` int NOT NULL AUTO_INCREMENT,
  `module_id` int NOT NULL,
  `sub_module_id` int NOT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `method_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `method_type` int NOT NULL,
  `available_to_company` tinyint NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3085 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_pages`
--

LOCK TABLES `acl_pages` WRITE;
/*!40000 ALTER TABLE `acl_pages` DISABLE KEYS */;
INSERT INTO `acl_pages` VALUES (3001,1001,2001,'Company List','index',0,0,'2015-12-09 12:10:51','2015-12-09 12:10:51'),(3002,1001,2001,'Add New Company','create',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52'),(3003,1001,2001,'Modify Company','edit',2,0,'2015-12-09 12:10:52','2019-03-27 15:03:28'),(3004,1001,2001,'Delete Company','destroy',2,0,'2015-12-09 12:10:52','2019-03-26 22:42:31'),(3005,1001,2001,'View Company','show',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52'),(3015,1002,2020,'Module List','index',0,0,'2015-12-09 12:10:53','2015-12-09 12:10:53'),(3016,1002,2020,'Add New Module','create',0,0,'2015-12-09 12:10:53','2015-12-09 12:10:53'),(3017,1002,2020,'Modify Module','edit',0,0,'2015-12-09 12:10:53','2015-12-09 12:10:53'),(3018,1002,2020,'Delete Module','destroy',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),(3019,1002,2020,'View Module','view',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),(3025,1002,2021,'Submodule List','index',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),(3026,1002,2021,'Add New Submodule','create',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),(3027,1002,2021,'Modify Submodule','edit',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),(3028,1002,2021,'Delete Submodule','destroy',0,0,'2015-12-09 12:10:55','2015-12-09 12:10:55'),(3029,1002,2021,'View Submodule','view',0,0,'2015-12-09 12:10:55','2015-12-09 12:10:55'),(3035,1002,2022,'Page List','index',0,0,'2015-12-09 12:10:55','2015-12-09 12:10:55'),(3036,1002,2022,'Add New Page','create',0,0,'2015-12-09 12:10:55','2016-01-21 10:44:25'),(3037,1002,2022,'Modify Page','edit',0,0,'2015-12-09 12:10:56','2015-12-09 12:10:56'),(3038,1002,2022,'Delete Page','destroy',0,0,'2015-12-09 12:10:56','2015-12-09 12:10:56'),(3039,1002,2022,'View Page','view',0,0,'2015-12-09 12:10:56','2015-12-09 12:10:56'),(3045,1003,2050,'User List','index',0,1,'2015-12-09 12:10:56','2015-12-09 12:10:56'),(3046,1003,2050,'User Add','create',0,1,'2015-12-09 12:10:57','2015-12-09 12:10:57'),(3047,1003,2050,'User Edit','edit',0,1,'2015-12-09 12:10:57','2015-12-09 12:10:57'),(3048,1003,2050,'User Delete','destroy',0,1,'2015-12-09 12:10:57','2015-12-09 12:10:57'),(3049,1003,2050,'User View','view',0,0,'2015-11-22 23:13:47','2015-11-22 23:13:47'),(3055,1003,2051,'Role List','index',0,1,'2015-12-09 12:12:02','2015-12-09 12:12:02'),(3056,1003,2051,'Role Add','create',0,1,'2015-12-09 12:12:02','2015-12-09 12:12:02'),(3057,1003,2051,'Role Edit','edit',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),(3058,1003,2051,'Role Delete','destroy',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),(3059,1003,2051,'Role View','view',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),(3065,1003,2052,'UserGroup List','index',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),(3066,1003,2052,'UserGroup Add','create',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),(3067,1003,2052,'UserGroup Edit','edit',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),(3068,1003,2052,'UserGroup Delete','destroy',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),(3069,1003,2052,'UserGroup View','view',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),(3075,1003,2053,'Usergroup Role Association','index',0,1,'2015-12-09 12:12:05','2015-12-09 12:12:05'),(3076,1003,2053,'Usergroup & Role Association Update','edit',0,1,'2021-12-09 15:10:51','2021-12-09 15:10:51'),(3078,1003,2054,'Role & Page Association','index',0,1,'2015-12-09 12:12:05','2015-12-09 12:12:05'),(3079,1003,2054,'Role & Page Association Update','edit',0,1,'2021-12-09 15:10:51','2021-12-09 15:10:51'),(3080,1003,2055,'Company Module List','index',0,0,'2015-12-09 12:10:51','2015-12-09 12:10:51'),(3081,1003,2055,'Add New Company Module','create',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52'),(3082,1003,2055,'Modify Company Module','edit',2,0,'2015-12-09 12:10:52','2019-03-27 15:03:28'),(3083,1003,2055,'Delete Company Module','destroy',2,0,'2015-12-09 12:10:52','2019-03-26 22:42:31'),(3084,1003,2055,'View Company Module','show',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52');
/*!40000 ALTER TABLE `acl_pages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_role_pages`
--

DROP TABLE IF EXISTS `acl_role_pages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_role_pages` (
  `id` int NOT NULL AUTO_INCREMENT,
  `role_id` int NOT NULL,
  `page_id` int NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `acl_role_pages_role_id_page_id_unique` (`role_id`,`page_id`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_role_pages`
--

LOCK TABLES `acl_role_pages` WRITE;
/*!40000 ALTER TABLE `acl_role_pages` DISABLE KEYS */;
INSERT INTO `acl_role_pages` VALUES (1,1,3001,NULL,NULL),(2,1,3002,NULL,NULL),(3,1,3003,NULL,NULL),(4,1,3004,NULL,NULL),(5,1,3005,NULL,NULL),(6,1,3015,NULL,NULL),(7,1,3016,NULL,NULL),(8,1,3017,NULL,NULL),(9,1,3018,NULL,NULL),(10,1,3019,NULL,NULL),(11,1,3025,NULL,NULL),(12,1,3026,NULL,NULL),(13,1,3027,NULL,NULL),(14,1,3028,NULL,NULL),(15,1,3029,NULL,NULL),(16,1,3035,NULL,NULL),(17,1,3036,NULL,NULL),(18,1,3037,NULL,NULL),(19,1,3038,NULL,NULL),(20,1,3039,NULL,NULL),(21,1,3080,NULL,NULL),(22,1,3081,NULL,NULL),(23,1,3082,NULL,NULL),(24,1,3083,NULL,NULL),(25,1,3084,NULL,NULL),(26,2,3045,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(27,2,3046,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(28,2,3047,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(29,2,3048,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(30,2,3049,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(31,2,3055,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(32,2,3056,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(33,2,3057,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(34,2,3058,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(35,2,3059,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(36,2,3065,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(37,2,3066,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(38,2,3067,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(39,2,3068,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(40,2,3069,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(41,2,3075,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(42,2,3076,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(43,2,3078,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(44,2,3079,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(45,2,3080,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(46,2,3081,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(47,2,3082,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(48,2,3083,'2024-05-20 11:25:35','2024-05-20 11:25:35'),(49,2,3084,'2024-05-20 11:25:35','2024-05-20 11:25:35');
/*!40000 ALTER TABLE `acl_role_pages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_roles`
--

DROP TABLE IF EXISTS `acl_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `status` tinyint NOT NULL DEFAULT '1',
  `company_id` int NOT NULL,
  `created_by_id` int DEFAULT NULL,
  `updated_by_id` int DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_roles`
--

LOCK TABLES `acl_roles` WRITE;
/*!40000 ALTER TABLE `acl_roles` DISABLE KEYS */;
INSERT INTO `acl_roles` VALUES (1,'super-super-admin','',1,1,NULL,NULL,'2019-03-21 20:38:30','2015-11-09 07:17:00'),(2,'ADMIN_ROLE','Mahmud',1,2,0,0,'2024-05-20 17:25:35','2024-05-20 17:25:35');
/*!40000 ALTER TABLE `acl_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_states`
--

DROP TABLE IF EXISTS `acl_states`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_states` (
  `id` int NOT NULL AUTO_INCREMENT,
  `country_id` int NOT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `status` tinyint NOT NULL,
  `sequence` int NOT NULL,
  `created_by_id` int NOT NULL,
  `updated_by_id` int NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_states`
--

LOCK TABLES `acl_states` WRITE;
/*!40000 ALTER TABLE `acl_states` DISABLE KEYS */;
INSERT INTO `acl_states` VALUES (1,1,'Dhaka','Dhaka city of BD',1,100,1,1,'2019-03-22 08:38:12.000000','2023-11-01 19:17:00.000000'),(2,235,'Florida','Florida is state of USA',1,100,0,0,'2024-05-17 16:09:23.226668','2024-05-17 17:03:45.156519');
/*!40000 ALTER TABLE `acl_states` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_sub_modules`
--

DROP TABLE IF EXISTS `acl_sub_modules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_sub_modules` (
  `id` int NOT NULL AUTO_INCREMENT,
  `module_id` int NOT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `controller_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `icon` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `sequence` int NOT NULL,
  `default_method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `display_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2058 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_sub_modules`
--

LOCK TABLES `acl_sub_modules` WRITE;
/*!40000 ALTER TABLE `acl_sub_modules` DISABLE KEYS */;
INSERT INTO `acl_sub_modules` VALUES (2001,1001,'Company Management','CompanyController','<i class=\"fa fa-angle-double-right\"></i>',100,'index','Company Management','2015-12-09 12:10:47','2015-12-09 12:10:47'),(2020,1002,'Module Management','ModuleController','<i class=\"fa fa-angle-double-right\"></i>',100,'index','Module Management','2015-12-09 12:10:48','2015-12-09 12:10:48'),(2021,1002,'Sub Module Management','SubModuleController','<i class=\"fa fa-angle-double-right\"></i>',101,'index','Sub Module Management','2015-12-09 12:10:48','2015-12-09 12:10:48'),(2022,1002,'Page Management','PageController','<i class=\"fa fa-angle-double-right\"></i>',102,'index','Page Management','2015-12-09 12:10:48','2015-12-09 12:10:48'),(2050,1003,'User Management','UserController','<i class=\"fa fa-angle-double-right\"></i>',18,'index','User Management','2015-12-09 12:10:49','2015-12-09 12:10:49'),(2051,1003,'Role Management','RoleController','<i class=\"fa fa-angle-double-right\"></i>',101,'index','Role Management','2015-12-09 12:10:49','2015-12-23 14:35:45'),(2052,1003,'User Group Management','UsergroupController','<i class=\"fa fa-angle-double-right\"></i>',102,'index','User Group Management','2015-12-09 12:10:49','2015-12-09 12:10:49'),(2053,1003,'Usergroup & Role Association','UsergroupRoleController','<i class=\"fa fa-angle-double-right\"></i>',103,'index','Usergroup & Role Association','2015-12-09 12:10:49','2015-12-09 12:10:49'),(2054,1003,'Role & Page Association','RolePageController','<i class=\"fa fa-angle-double-right\"></i>',104,'index','Role & Page Association','2015-12-09 12:10:50','2015-12-09 12:10:50'),(2055,1003,'Company Module Management','CompanyModuleController','<i class=\"fa fa-angle-double-right\"></i>',105,'index','Company Module Management','2015-12-09 12:10:48','2015-12-09 12:10:48'),(2056,1004,'Company','AclCompanyController','<i class=\'fa fa-angle-double-right\'></i>',100,'index','Company Management','2024-05-17 17:59:08','2024-05-17 17:59:08');
/*!40000 ALTER TABLE `acl_sub_modules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_user_usergroups`
--

DROP TABLE IF EXISTS `acl_user_usergroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_user_usergroups` (
  `id` int NOT NULL AUTO_INCREMENT,
  `usergroup_id` int NOT NULL,
  `user_id` int NOT NULL,
  `company_id` int NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_user_usergroups`
--

LOCK TABLES `acl_user_usergroups` WRITE;
/*!40000 ALTER TABLE `acl_user_usergroups` DISABLE KEYS */;
INSERT INTO `acl_user_usergroups` VALUES (1,1,1,1,'2024-01-24 07:23:21','2024-01-24 07:23:23'),(2,2,2,0,'2024-05-20 17:25:35','2024-05-20 17:25:35');
/*!40000 ALTER TABLE `acl_user_usergroups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_usergroup_roles`
--

DROP TABLE IF EXISTS `acl_usergroup_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_usergroup_roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `usergroup_id` int NOT NULL,
  `role_id` int NOT NULL,
  `company_id` int NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_usergroup_roles`
--

LOCK TABLES `acl_usergroup_roles` WRITE;
/*!40000 ALTER TABLE `acl_usergroup_roles` DISABLE KEYS */;
INSERT INTO `acl_usergroup_roles` VALUES (1,1,1,1,NULL,NULL),(2,2,2,2,'2024-05-20 11:25:35','2024-05-20 11:25:35');
/*!40000 ALTER TABLE `acl_usergroup_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_usergroups`
--

DROP TABLE IF EXISTS `acl_usergroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_usergroups` (
  `id` int NOT NULL AUTO_INCREMENT,
  `group_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `category` tinyint NOT NULL,
  `dashboard_url` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `status` tinyint NOT NULL DEFAULT '1',
  `company_id` int NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_usergroups`
--

LOCK TABLES `acl_usergroups` WRITE;
/*!40000 ALTER TABLE `acl_usergroups` DISABLE KEYS */;
INSERT INTO `acl_usergroups` VALUES (1,'super-super-admin-group',0,NULL,1,1,'2019-03-22 08:38:12','2023-11-01 19:17:00'),(2,'ADMIN_USERGROUP',0,NULL,1,0,'2024-05-20 17:25:34','2024-05-20 17:25:34');
/*!40000 ALTER TABLE `acl_usergroups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_users`
--

DROP TABLE IF EXISTS `acl_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `last_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `avatar` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `dob` datetime(6) DEFAULT NULL,
  `gender` tinyint DEFAULT NULL,
  `address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `city` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `country` int NOT NULL,
  `phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `is_admin_verified` tinyint(1) NOT NULL,
  `user_type` tinyint NOT NULL,
  `remember_token` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `refresh_token` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `salt` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `activated_at` datetime DEFAULT NULL,
  `language` varchar(8) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'en-US',
  `username` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `img_path` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `claims` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `status` tinyint NOT NULL DEFAULT '1',
  `company_id` int NOT NULL,
  `permission_version` int NOT NULL,
  `otp_channel` tinyint NOT NULL,
  `login_at` datetime DEFAULT NULL,
  `created_by_id` int NOT NULL,
  `auth_identifier` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_users`
--

LOCK TABLES `acl_users` WRITE;
/*!40000 ALTER TABLE `acl_users` DISABLE KEYS */;
INSERT INTO `acl_users` VALUES (1,'admin1','admin1','ssadmin@sipay.com.tr','users/admin/c41353d1c1fcbdbd39f96ea46a3f769136952e79.png','QCy4DY93n7XSPqOJAjrq9hmwoIuaq9zqbDUBXmXPs+DgWlbGHBxWVQTlQVdmmUYUk0D21muGuNGQr32ro0zFdA==','1994-02-22 00:00:00.000000',1,'Dhaka','19',0,'+8801788343704',1,0,'','{\"Value\":\"PWBPj6eNaFtmbhwz6wjWnVpOfpeYnZIdZQNnnj2Kdu3vURKdhOzWFMb0t8wCbiOukiEEsish4LowcyD/TsT0sg==\",\"Active\":true,\"ExpirationDate\":\"2024-08-23T09:31:00.5975438Z\"}','pNr7R0FzsicCDrMlIwXYVI6zM4rZByVgNCkWRwM4y57Sw+cdKUbTrRZLbV8nccwNlN+DokHXlkxKGvw+7ISPPw==','2018-07-10 16:21:24','2021-08-25 05:46:27',NULL,'en-US','rajibecbb','storage/users/1/2019-04-18-07-49-28-ba4fe9be59df7b82f8243d2126070d76f5305b3e.png','[]',1,1,2,0,NULL,1,NULL),(2,'Mahmud','Mahmud','test@gmail.com',NULL,'DmCAhbrFo0aaQvJ6IAgP1XfskHLmBzGeHJ2Brs2cYuLcaes0wo3YEtbYYTvThtSF58ILubqMIZei5H/sW9IDkw==',NULL,NULL,NULL,NULL,0,NULL,0,1,NULL,'{\"Value\":\"Aef5f6z1VacASqBav1wnvfTCAWSjQNPsV41nnZIXsvKP0OMlFKiRogqPPNRYi18BtKNRvSe34mdZKSuB0ynIvA==\",\"Active\":true,\"ExpirationDate\":\"2024-05-20T14:09:56.3959656Z\"}','afpAOoSCCbkD5gg3cA7asIT3Zcno4w+To7ZKct9KyN2xmAXcultqy5vJltIQiud0qocCQ44M4sB9UgnYiAt+Nw==','2024-05-20 17:25:35','2024-05-20 17:25:35',NULL,'en-US','test@gmail.com',NULL,'[]',1,0,0,0,NULL,0,NULL);
/*!40000 ALTER TABLE `acl_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_usertype_submodules`
--

DROP TABLE IF EXISTS `acl_usertype_submodules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_usertype_submodules` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_type_id` int unsigned NOT NULL,
  `sub_module_id` int NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_usertype_submodules`
--

LOCK TABLES `acl_usertype_submodules` WRITE;
/*!40000 ALTER TABLE `acl_usertype_submodules` DISABLE KEYS */;
INSERT INTO `acl_usertype_submodules` VALUES (1,0,2001,NULL,NULL),(2,0,2020,NULL,NULL),(3,0,2021,NULL,NULL),(4,0,2022,NULL,NULL),(5,1,2050,NULL,NULL),(6,1,2051,NULL,NULL),(7,1,2052,NULL,NULL),(8,1,2053,NULL,NULL),(9,1,2054,NULL,NULL);
/*!40000 ALTER TABLE `acl_usertype_submodules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_banks`
--

DROP TABLE IF EXISTS `imt_banks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_banks` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `display_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `url` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `logo` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '1=active, 0=inactive, 2=soft deleted',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_banks`
--

LOCK TABLES `imt_banks` WRITE;
/*!40000 ALTER TABLE `imt_banks` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_banks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_business_hours_and_weekends`
--

DROP TABLE IF EXISTS `imt_business_hours_and_weekends`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_business_hours_and_weekends` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `hour_type` tinyint unsigned DEFAULT '0' COMMENT '0 = regular, 1 = special',
  `country_id` int unsigned DEFAULT NULL,
  `day` varchar(10) NOT NULL COMMENT 'Friday, Saturday, Sunday, Monday, etc',
  `is_weekend` tinyint NOT NULL DEFAULT '0' COMMENT '0=not weekend, 1=weekend',
  `gmt` tinyint NOT NULL COMMENT 'GMT offset in hours (e.g., +5, -3)',
  `open_at` datetime NOT NULL,
  `close_at` datetime NOT NULL,
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Type : Master, regular office hours and weekends';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_business_hours_and_weekends`
--

LOCK TABLES `imt_business_hours_and_weekends` WRITE;
/*!40000 ALTER TABLE `imt_business_hours_and_weekends` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_business_hours_and_weekends` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_cities`
--

DROP TABLE IF EXISTS `imt_cities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_cities` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `country_id` int unsigned DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '1' COMMENT '1=active, 0=inactive, 2=soft-deleted',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_cities`
--

LOCK TABLES `imt_cities` WRITE;
/*!40000 ALTER TABLE `imt_cities` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_cities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_corridors`
--

DROP TABLE IF EXISTS `imt_corridors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_corridors` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `source_country_id` int unsigned DEFAULT NULL,
  `destination_country_id` int unsigned DEFAULT NULL,
  `source_currency_id` int unsigned DEFAULT NULL,
  `destination_currency_id` int unsigned DEFAULT NULL,
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, corridor is setup of source country-currency to destination country-currency, like send GBP Euro to USA USD';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_corridors`
--

LOCK TABLES `imt_corridors` WRITE;
/*!40000 ALTER TABLE `imt_corridors` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_corridors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_countries`
--

DROP TABLE IF EXISTS `imt_countries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_countries` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `iso_code` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '1' COMMENT '1=active, 0=inactive, 2=soft-deleted',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_countries`
--

LOCK TABLES `imt_countries` WRITE;
/*!40000 ALTER TABLE `imt_countries` DISABLE KEYS */;
INSERT INTO `imt_countries` VALUES (1,'TUR','TUR','Turkish',NULL,NULL,1,NULL,NULL);
/*!40000 ALTER TABLE `imt_countries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_currencies`
--

DROP TABLE IF EXISTS `imt_currencies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_currencies` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `iso_code` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `symbol` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '1' COMMENT '1=active, 0=inactive,2=soft-delete ',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_currencies`
--

LOCK TABLES `imt_currencies` WRITE;
/*!40000 ALTER TABLE `imt_currencies` DISABLE KEYS */;
INSERT INTO `imt_currencies` VALUES (1,'USD','USD','Doller','$',NULL,NULL,1,NULL,NULL),(2,'EUR','EUR','Euro','&',NULL,NULL,1,NULL,NULL);
/*!40000 ALTER TABLE `imt_currencies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_currency_conversion_rates`
--

DROP TABLE IF EXISTS `imt_currency_conversion_rates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_currency_conversion_rates` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `corridor_id` int unsigned NOT NULL,
  `exchange_rate` decimal(16,4) NOT NULL COMMENT 'Exchange rate between currencies',
  `fx_spread` decimal(16,4) NOT NULL COMMENT 'Foreign exchange spread',
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, conversion rates based on a corridor';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_currency_conversion_rates`
--

LOCK TABLES `imt_currency_conversion_rates` WRITE;
/*!40000 ALTER TABLE `imt_currency_conversion_rates` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_currency_conversion_rates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_customer_banks`
--

DROP TABLE IF EXISTS `imt_customer_banks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_customer_banks` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `customer_id` int unsigned DEFAULT NULL,
  `country_id` int unsigned DEFAULT NULL,
  `city_id` int unsigned DEFAULT NULL,
  `bank_id` int unsigned DEFAULT NULL,
  `account_title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `account_no` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `branch_iban` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '1' COMMENT '1=active, 0=inactive, 2= soft-deleted',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_customer_banks`
--

LOCK TABLES `imt_customer_banks` WRITE;
/*!40000 ALTER TABLE `imt_customer_banks` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_customer_banks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_customers`
--

DROP TABLE IF EXISTS `imt_customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_customers` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `first_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `last_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `name` varchar(70) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `phone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tckn` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `type` tinyint DEFAULT NULL,
  `category` tinyint DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '1' COMMENT '0=inactive, 1= active, 2= pending, 3= blocked, 4=banned, 5=expired, 6=rejected, 7 = approved but not active yet',
  `dob` date DEFAULT NULL,
  `address1` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `address2` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `password` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `customer_number` int DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_customers`
--

LOCK TABLES `imt_customers` WRITE;
/*!40000 ALTER TABLE `imt_customers` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_holiday_settings`
--

DROP TABLE IF EXISTS `imt_holiday_settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_holiday_settings` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `country_id` int unsigned DEFAULT NULL,
  `date` date NOT NULL,
  `type` tinyint unsigned NOT NULL COMMENT '0 = full, 1 = half, 2 = quarter, 3 = special',
  `gmt` tinyint NOT NULL COMMENT 'GMT offset in hours (e.g., +5, -3)',
  `open_at` datetime DEFAULT NULL COMMENT 'Time to start if type is not full',
  `close_at` datetime DEFAULT NULL COMMENT 'Time to end if type is not full',
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, contrywise holidays';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_holiday_settings`
--

LOCK TABLES `imt_holiday_settings` WRITE;
/*!40000 ALTER TABLE `imt_holiday_settings` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_holiday_settings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_institution_funds`
--

DROP TABLE IF EXISTS `imt_institution_funds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_institution_funds` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `institution_id` int unsigned NOT NULL,
  `provider_id` int unsigned NOT NULL,
  `fund_country_id` int unsigned NOT NULL,
  `fund_currency_id` int unsigned NOT NULL,
  `account_number` varchar(255) CHARACTER SET latin1 NOT NULL COMMENT 'Account number for the wallet',
  `starting_amount` decimal(16,4) NOT NULL COMMENT 'Starting amount in the wallet',
  `current_amount` decimal(16,4) NOT NULL COMMENT 'Current amount in the wallet',
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, fund deposited for an institution like Sipay in a provider account (Thunes)';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_institution_funds`
--

LOCK TABLES `imt_institution_funds` WRITE;
/*!40000 ALTER TABLE `imt_institution_funds` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_institution_funds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_institution_mtts`
--

DROP TABLE IF EXISTS `imt_institution_mtts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_institution_mtts` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `institution_id` int unsigned NOT NULL,
  `mtt_id` int unsigned NOT NULL,
  `commission_type` tinyint unsigned NOT NULL COMMENT '1 = Regular, 2 = Some-other-type',
  `commission_currency_id` int unsigned DEFAULT NULL,
  `commission_percentage` decimal(16,4) NOT NULL,
  `commission_fixed` decimal(16,4) NOT NULL,
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, mtt(s) assigned to an institution';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_institution_mtts`
--

LOCK TABLES `imt_institution_mtts` WRITE;
/*!40000 ALTER TABLE `imt_institution_mtts` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_institution_mtts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_institutions`
--

DROP TABLE IF EXISTS `imt_institutions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_institutions` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL COMMENT 'Name of the institution',
  `url` varchar(255) DEFAULT NULL COMMENT 'Url of the official site',
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '2' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Type : Master, we onboard an institution, and perform transactions under it, like the merchants of a payment system';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_institutions`
--

LOCK TABLES `imt_institutions` WRITE;
/*!40000 ALTER TABLE `imt_institutions` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_institutions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_money_transfers`
--

DROP TABLE IF EXISTS `imt_money_transfers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_money_transfers` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `payment_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `transaction_state_id` int unsigned DEFAULT NULL,
  `reason_id` int unsigned DEFAULT NULL,
  `payment_method_id` int unsigned DEFAULT NULL,
  `transfer_type` tinyint DEFAULT '1' COMMENT '1=regular, 2 = instant, 3 = same day',
  `reason_code` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `type` tinyint DEFAULT '2' COMMENT '1 = b2b, 2 = c2c, 3=c2b, 4=b2c ',
  `sender_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `receiver_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `sender_currency_id` int unsigned DEFAULT NULL,
  `receiver_currency_id` int unsigned DEFAULT NULL,
  `exchange_rate` decimal(12,4) DEFAULT NULL,
  `send_amount` decimal(12,4) DEFAULT NULL,
  `receive_amount` decimal(12,4) DEFAULT NULL,
  `exchanged_amount` decimal(12,4) DEFAULT NULL,
  `fee` decimal(12,4) DEFAULT NULL,
  `vat` decimal(12,4) DEFAULT NULL,
  `commission_paid_by` tinyint DEFAULT '1' COMMENT '1=paid by sender, 2=paid by receiver',
  `sender_customer_id` int unsigned DEFAULT NULL,
  `receiver_customer_id` int unsigned DEFAULT NULL,
  `source` tinyint DEFAULT '1' COMMENT '1=from api, 2= from admin',
  `order_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `remote_order_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `invoice_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_money_transfers`
--

LOCK TABLES `imt_money_transfers` WRITE;
/*!40000 ALTER TABLE `imt_money_transfers` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_money_transfers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_mtt_payment_speeds`
--

DROP TABLE IF EXISTS `imt_mtt_payment_speeds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_mtt_payment_speeds` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `mtt_id` int unsigned NOT NULL,
  `processing_time` int unsigned NOT NULL COMMENT 'Processing time in minutes',
  `gmt` tinyint NOT NULL COMMENT 'GMT offset (e.g., +5, -3)',
  `opens_at` datetime NOT NULL COMMENT 'Opening time',
  `closes_at` datetime NOT NULL COMMENT 'Closing time',
  `working_days` varchar(255) CHARACTER SET latin1 NOT NULL COMMENT 'CSV of weekdays (e.g., Monday,Tuesday)',
  `is_processing_during_banking_holiday` tinyint(1) NOT NULL DEFAULT '0' COMMENT '0 = No, 1 = Yes',
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, time to complete a transaction.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_mtt_payment_speeds`
--

LOCK TABLES `imt_mtt_payment_speeds` WRITE;
/*!40000 ALTER TABLE `imt_mtt_payment_speeds` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_mtt_payment_speeds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_mtts`
--

DROP TABLE IF EXISTS `imt_mtts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_mtts` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `corridor_id` int unsigned DEFAULT NULL,
  `currency_id` int unsigned DEFAULT NULL,
  `payer_id` int unsigned NOT NULL,
  `service_method_id` int unsigned DEFAULT NULL,
  `transaction_type_id` varchar(255) CHARACTER SET latin1 NOT NULL,
  `cot_percentage` decimal(16,4) NOT NULL,
  `cot_fixed` decimal(16,4) NOT NULL,
  `fx_spread` decimal(16,4) NOT NULL,
  `mark_up_percentage` decimal(16,4) NOT NULL,
  `mark_up_fixed` decimal(16,4) NOT NULL,
  `increment` decimal(16,4) NOT NULL COMMENT 'Increment value, definition may vary',
  `money_precision` tinyint unsigned NOT NULL,
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, transaction setup between providers and us, like POS of a payment system';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_mtts`
--

LOCK TABLES `imt_mtts` WRITE;
/*!40000 ALTER TABLE `imt_mtts` DISABLE KEYS */;
INSERT INTO `imt_mtts` VALUES (2,0,0,0,0,'Awesome udated',0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,0,0,0,1,1,'2024-08-23 18:58:56','2024-08-27 14:06:25');
/*!40000 ALTER TABLE `imt_mtts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_payer_payment_speeds`
--

DROP TABLE IF EXISTS `imt_payer_payment_speeds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_payer_payment_speeds` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `payer_id` int unsigned NOT NULL,
  `processing_time` int unsigned NOT NULL COMMENT 'Processing time in minutes',
  `gmt` tinyint NOT NULL COMMENT 'GMT offset in hours (e.g., +5, -3)',
  `open_at` datetime NOT NULL COMMENT 'Opening time',
  `close_at` datetime NOT NULL COMMENT 'Closing time',
  `working_days` varchar(255) CHARACTER SET latin1 NOT NULL COMMENT 'CSV of weekdays (e.g., Monday,Tuesday)',
  `is_processing_during_banking_holiday` tinyint(1) NOT NULL DEFAULT '0' COMMENT '0 = No, 1 = Yes',
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, for every transaction it takes time to process the transactions, this is the setup in payers'' context';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_payer_payment_speeds`
--

LOCK TABLES `imt_payer_payment_speeds` WRITE;
/*!40000 ALTER TABLE `imt_payer_payment_speeds` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_payer_payment_speeds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_payers`
--

DROP TABLE IF EXISTS `imt_payers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_payers` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET latin1 NOT NULL,
  `provider_id` int unsigned DEFAULT NULL,
  `corridor_id` int unsigned DEFAULT NULL,
  `internal_payer_id` varchar(50) CHARACTER SET latin1 NOT NULL,
  `fund_currency_id` int unsigned DEFAULT NULL,
  `increment` decimal(16,4) NOT NULL,
  `money_precision` tinyint unsigned NOT NULL,
  `service_method_id` int unsigned DEFAULT NULL,
  `transaction_type_ids` varchar(255) CHARACTER SET latin1 NOT NULL COMMENT 'CSV of transaction_type_id values',
  `source_amount_max` decimal(16,4) NOT NULL,
  `source_amount_min` decimal(16,4) NOT NULL,
  `destination_amount_max` decimal(16,4) NOT NULL,
  `destination_amount_min` decimal(16,4) NOT NULL,
  `cot_currency_id` int unsigned DEFAULT NULL,
  `cot_percentage` decimal(16,4) NOT NULL,
  `cot_fixed` decimal(16,4) NOT NULL,
  `fx_spread` decimal(16,4) NOT NULL,
  `payment_speed` text CHARACTER SET latin1 NOT NULL,
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, payers are the corridor setups under a provider like Thunes, a payer is acting like a bank terminal, most of the data are operational, will be set as MTT''s values, here to crosscheck';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_payers`
--

LOCK TABLES `imt_payers` WRITE;
/*!40000 ALTER TABLE `imt_payers` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_payers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_payment_methods`
--

DROP TABLE IF EXISTS `imt_payment_methods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_payment_methods` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `method_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `description` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '1' COMMENT '1= active, 0=inactive, 2=soft-deleted',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_payment_methods`
--

LOCK TABLES `imt_payment_methods` WRITE;
/*!40000 ALTER TABLE `imt_payment_methods` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_payment_methods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_provider_commissions`
--

DROP TABLE IF EXISTS `imt_provider_commissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_provider_commissions` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `provider_id` int unsigned DEFAULT NULL,
  `from_currency_id` int unsigned DEFAULT NULL,
  `to_currency_id` int unsigned DEFAULT NULL,
  `sender_commission_percentage` decimal(12,4) DEFAULT NULL,
  `sender_commission_fixed` decimal(12,4) DEFAULT NULL,
  `receiver_commission_percentage` decimal(12,4) DEFAULT NULL,
  `receiver_commission_fixed` decimal(12,4) DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '1' COMMENT '1=active, 0=inactive, 2=soft-deleted',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_provider_commissions`
--

LOCK TABLES `imt_provider_commissions` WRITE;
/*!40000 ALTER TABLE `imt_provider_commissions` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_provider_commissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_provider_error_details`
--

DROP TABLE IF EXISTS `imt_provider_error_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_provider_error_details` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `imt_provider_id` int unsigned NOT NULL,
  `type` tinyint NOT NULL,
  `reference_id` int unsigned NOT NULL,
  `error_code` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `error_message` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_provider_error_details`
--

LOCK TABLES `imt_provider_error_details` WRITE;
/*!40000 ALTER TABLE `imt_provider_error_details` DISABLE KEYS */;
INSERT INTO `imt_provider_error_details` VALUES (64,1,1,11,'1007001','External ID already used','2024-08-20 13:53:55','2024-08-20 13:53:55'),(65,1,1,12,'1007001','External ID already used','2024-08-22 12:37:28','2024-08-22 12:37:28');
/*!40000 ALTER TABLE `imt_provider_error_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_provider_payers`
--

DROP TABLE IF EXISTS `imt_provider_payers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_provider_payers` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `imt_provider_id` int unsigned NOT NULL,
  `imt_country_id` int unsigned NOT NULL,
  `imt_currency_id` int unsigned NOT NULL,
  `imt_provider_service_id` int unsigned DEFAULT NULL,
  `remote_payer_id` int unsigned DEFAULT NULL,
  `precision` tinyint DEFAULT NULL,
  `increment` decimal(12,4) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_provider_payers`
--

LOCK TABLES `imt_provider_payers` WRITE;
/*!40000 ALTER TABLE `imt_provider_payers` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_provider_payers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_provider_services`
--

DROP TABLE IF EXISTS `imt_provider_services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_provider_services` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `imt_provider_id` int unsigned NOT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_provider_services`
--

LOCK TABLES `imt_provider_services` WRITE;
/*!40000 ALTER TABLE `imt_provider_services` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_provider_services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_providers`
--

DROP TABLE IF EXISTS `imt_providers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_providers` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `base_url` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `api_key` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `api_secret` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '1' COMMENT '1= active, 0 =inactive, 2 =soft-deleted',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_providers`
--

LOCK TABLES `imt_providers` WRITE;
/*!40000 ALTER TABLE `imt_providers` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_providers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_quotation_info`
--

DROP TABLE IF EXISTS `imt_quotation_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_quotation_info` (
  `id` int unsigned NOT NULL,
  `request_amount` decimal(16,4) DEFAULT NULL,
  `currency_id` int unsigned DEFAULT NULL,
  `commission` decimal(16,4) DEFAULT NULL,
  `commision_fixed` decimal(16,4) DEFAULT NULL,
  `commission_percentage` decimal(16,4) DEFAULT NULL,
  `cot` decimal(16,4) DEFAULT NULL,
  `cot_percentage` decimal(16,4) DEFAULT NULL,
  `cot_fixed` decimal(16,4) DEFAULT NULL,
  `mark_up` decimal(16,4) DEFAULT NULL,
  `mark_up_percentage` decimal(16,4) DEFAULT NULL,
  `mark_up_fixed` decimal(16,4) DEFAULT NULL,
  `tax` decimal(16,4) DEFAULT NULL,
  `tax_percentage` decimal(16,4) DEFAULT NULL,
  `tax_fixed` decimal(16,4) DEFAULT NULL,
  `sent_amount` decimal(16,4) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_quotation_info`
--

LOCK TABLES `imt_quotation_info` WRITE;
/*!40000 ALTER TABLE `imt_quotation_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_quotation_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_quotation_requests`
--

DROP TABLE IF EXISTS `imt_quotation_requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_quotation_requests` (
  `id` int unsigned NOT NULL,
  `request` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_quotation_requests`
--

LOCK TABLES `imt_quotation_requests` WRITE;
/*!40000 ALTER TABLE `imt_quotation_requests` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_quotation_requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_quotations`
--

DROP TABLE IF EXISTS `imt_quotations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_quotations` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `institution_id` int unsigned DEFAULT NULL,
  `invoice_id` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `order_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `mtt_id` int unsigned NOT NULL,
  `mode` int NOT NULL COMMENT 'SOURCE_AMOUNT,DESTINATION_AMOUNT',
  `source_amount` decimal(16,4) DEFAULT NULL,
  `destination_amount` decimal(16,4) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_quotations`
--

LOCK TABLES `imt_quotations` WRITE;
/*!40000 ALTER TABLE `imt_quotations` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_quotations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_reasons`
--

DROP TABLE IF EXISTS `imt_reasons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_reasons` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `title` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `description` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '0' COMMENT '0 = inactive, 1=active, 2=soft=deleted',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_reasons`
--

LOCK TABLES `imt_reasons` WRITE;
/*!40000 ALTER TABLE `imt_reasons` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_reasons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_regions`
--

DROP TABLE IF EXISTS `imt_regions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_regions` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET latin1 DEFAULT NULL COMMENT 'Example : EuroZone, Asia Pacific',
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master; Regions like Asia Pacific, SARC. Every country belongs to a region';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_regions`
--

LOCK TABLES `imt_regions` WRITE;
/*!40000 ALTER TABLE `imt_regions` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_regions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_service_methods`
--

DROP TABLE IF EXISTS `imt_service_methods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_service_methods` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `method` tinyint unsigned NOT NULL COMMENT '1 = Bank Account, 2 = Wallet, 3 = Cash Pickup, 4 = Card',
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, delivery methods of transactions';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_service_methods`
--

LOCK TABLES `imt_service_methods` WRITE;
/*!40000 ALTER TABLE `imt_service_methods` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_service_methods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_tax_rates`
--

DROP TABLE IF EXISTS `imt_tax_rates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_tax_rates` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `tax_type` tinyint unsigned NOT NULL COMMENT '1 = Regular, 2 = Corridor tax, 3 = Country tax',
  `corridor_id` int unsigned DEFAULT NULL,
  `country_id` int unsigned DEFAULT NULL,
  `tax_currency_id` int unsigned DEFAULT NULL,
  `tax_percentage` decimal(16,4) NOT NULL,
  `tax_fixed` decimal(16,4) NOT NULL,
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, government tax rates based on countries for each transaction';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_tax_rates`
--

LOCK TABLES `imt_tax_rates` WRITE;
/*!40000 ALTER TABLE `imt_tax_rates` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_tax_rates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_transaction_limits`
--

DROP TABLE IF EXISTS `imt_transaction_limits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_transaction_limits` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `transaction_type` tinyint DEFAULT NULL,
  `user_category` tinyint DEFAULT NULL,
  `daily_total_number` int DEFAULT NULL,
  `daily_total_amount` decimal(16,4) DEFAULT NULL,
  `monthly_total_number` int DEFAULT NULL,
  `monthly_total_amount` decimal(16,4) DEFAULT NULL,
  `currency_id` int unsigned DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_transaction_limits`
--

LOCK TABLES `imt_transaction_limits` WRITE;
/*!40000 ALTER TABLE `imt_transaction_limits` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_transaction_limits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_transaction_states`
--

DROP TABLE IF EXISTS `imt_transaction_states`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_transaction_states` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `status` tinyint unsigned DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_transaction_states`
--

LOCK TABLES `imt_transaction_states` WRITE;
/*!40000 ALTER TABLE `imt_transaction_states` DISABLE KEYS */;
INSERT INTO `imt_transaction_states` VALUES (1,'Pending',1,NULL,NULL,NULL,NULL),(2,'Success',2,NULL,NULL,NULL,NULL),(3,'Fail',3,NULL,NULL,NULL,NULL),(4,'Cancel',4,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `imt_transaction_states` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_transaction_types`
--

DROP TABLE IF EXISTS `imt_transaction_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_transaction_types` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `status` tinyint unsigned DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_transaction_types`
--

LOCK TABLES `imt_transaction_types` WRITE;
/*!40000 ALTER TABLE `imt_transaction_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_transaction_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `imt_transactions`
--

DROP TABLE IF EXISTS `imt_transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imt_transactions` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `payment_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `customer_id` int unsigned DEFAULT NULL,
  `transaction_state_id` int unsigned DEFAULT NULL,
  `transaction_id` int unsigned DEFAULT NULL,
  `transaction_type` tinyint DEFAULT '0' COMMENT '1= send money, 2=receive money ',
  `transaction_reference_id` int unsigned NOT NULL DEFAULT '0' COMMENT 'For refund, it would be corresponding sale id',
  `money_flow` tinyint DEFAULT '0' COMMENT '1= incoming and 2 = outgoing',
  `amount` decimal(12,4) DEFAULT NULL,
  `fee` decimal(12,4) DEFAULT NULL,
  `gross` decimal(12,4) DEFAULT NULL,
  `currency_id` int unsigned DEFAULT NULL,
  `current_balance` decimal(16,4) DEFAULT NULL,
  `previous_balance` decimal(16,4) DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '1' COMMENT '0=pending, 1=approved, 2=reject',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_transactions`
--

LOCK TABLES `imt_transactions` WRITE;
/*!40000 ALTER TABLE `imt_transactions` DISABLE KEYS */;
/*!40000 ALTER TABLE `imt_transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_app_event_data`
--

DROP TABLE IF EXISTS `notification_app_event_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_app_event_data` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `notification_event_id` int NOT NULL DEFAULT '0',
  `reference_unique_id` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Application Log Id',
  `data` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci COMMENT 'Event payload',
  `attachment_info` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Attachment info for template',
  `receivers` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci COMMENT 'Extra/Custom receivers',
  `url` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Dynamic Url',
  `path` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Remote FTP path',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_app_event_data`
--

LOCK TABLES `notification_app_event_data` WRITE;
/*!40000 ALTER TABLE `notification_app_event_data` DISABLE KEYS */;
/*!40000 ALTER TABLE `notification_app_event_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_credentials`
--

DROP TABLE IF EXISTS `notification_credentials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_credentials` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` tinyint NOT NULL COMMENT '1=mail, 2= sms, 3 = web',
  `title` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Name of the credentials. e.g: Codex, Verimo etc.',
  `host` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'host ip or url should be set here',
  `port` int DEFAULT NULL COMMENT 'port of the host or url',
  `username` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0' COMMENT 'username/api_key/app_key may be set here',
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0' COMMENT 'password/secret_key may be placed here',
  `api_key` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `encryption_type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'email encryption type e.g tls, ssl, starttls etc',
  `transport_driver` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'SMTP, Mailgun, etc.',
  `from_address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'email/phone/url may be placed here',
  `from_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Title of from adress.',
  `created_by_id` int NOT NULL DEFAULT '0',
  `updated_by_id` int NOT NULL DEFAULT '0',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `company_id` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_credentials`
--

LOCK TABLES `notification_credentials` WRITE;
/*!40000 ALTER TABLE `notification_credentials` DISABLE KEYS */;
INSERT INTO `notification_credentials` VALUES (1,1,'Mailtrap','sandbox.smtp.mailtrap.io',587,'92e0ae7a791f20','17d5b1ee026744','0','tls','SMTP','rifat.simoom@gmail.com','Rifat Simoom',0,0,NULL,NULL,0),(2,2,'Ozeki',' http://127.0.0.1',9501,'admin','abc123','0','tls','SMTP','Softrobotics','Softrobotics',0,0,NULL,NULL,0),(3,3,'Webhook','127.0.0.1',2525,'abc','xyz','null','null','','null','null',0,0,NULL,NULL,0);
/*!40000 ALTER TABLE `notification_credentials` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_email_events`
--

DROP TABLE IF EXISTS `notification_email_events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_email_events` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `notification_event_id` int NOT NULL,
  `notification_credential_id` int NOT NULL DEFAULT '0',
  `notification_receiver_group_id` int NOT NULL DEFAULT '0',
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Deposit Approve, Deposit Reject etc',
  `is_allow_from_app` tinyint(1) NOT NULL DEFAULT '1' COMMENT '1= allows manual receivers, 0= does not allow manual receivers',
  `is_allow_cc` tinyint(1) NOT NULL DEFAULT '1' COMMENT 'notification_receivers_groups cc can be on/off from here',
  `is_allow_bcc` tinyint(1) NOT NULL DEFAULT '1' COMMENT 'notification_receivers_groups bcc can be on/off from here',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_email_events`
--

LOCK TABLES `notification_email_events` WRITE;
/*!40000 ALTER TABLE `notification_email_events` DISABLE KEYS */;
/*!40000 ALTER TABLE `notification_email_events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_email_outgoings`
--

DROP TABLE IF EXISTS `notification_email_outgoings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_email_outgoings` (
  `id` int NOT NULL AUTO_INCREMENT,
  `notification_credential_id` int NOT NULL DEFAULT '0',
  `subject` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0' COMMENT 'Subject of the email',
  `content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'full email body content with html',
  `to` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'email must be seperated by comma(,)',
  `cc` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'email must be seperated by comma(,)',
  `bcc` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'email must be seperated by comma(,)',
  `is_attachment` tinyint(1) NOT NULL DEFAULT '0' COMMENT '0=no attachedment, 1=has attachedment',
  `attachment_details` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Attachedment file path must be kept by comma(,) separator',
  `status` tinyint NOT NULL DEFAULT '0' COMMENT '0=pending, 1= completed, 2= failed ',
  `attempt` int NOT NULL DEFAULT '0',
  `sent_at` datetime DEFAULT NULL,
  `notification_event_id` int NOT NULL,
  `notification_event_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `company_id` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_email_outgoings`
--

LOCK TABLES `notification_email_outgoings` WRITE;
/*!40000 ALTER TABLE `notification_email_outgoings` DISABLE KEYS */;
/*!40000 ALTER TABLE `notification_email_outgoings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_event_templates`
--

DROP TABLE IF EXISTS `notification_event_templates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_event_templates` (
  `id` int NOT NULL AUTO_INCREMENT,
  `notification_event_id` int NOT NULL,
  `subject` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '' COMMENT 'Email subject or Web Title',
  `content` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `path` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `type` tinyint NOT NULL DEFAULT '1' COMMENT '1=email, 2=sms, 3=web',
  `variables` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci COMMENT 'Must be set as comma(,) separator {{$var1}},{{$var2}}',
  `created_by_id` int NOT NULL DEFAULT '1',
  `updated_by_id` int NOT NULL DEFAULT '1',
  `status` tinyint NOT NULL DEFAULT '0' COMMENT '0= Not Processed, 1=Processed',
  `language` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'eng' COMMENT '3 digit iso code',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `company_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `company_id_idx` (`company_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_event_templates`
--

LOCK TABLES `notification_event_templates` WRITE;
/*!40000 ALTER TABLE `notification_event_templates` DISABLE KEYS */;
/*!40000 ALTER TABLE `notification_event_templates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_events`
--

DROP TABLE IF EXISTS `notification_events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_events` (
  `id` int NOT NULL AUTO_INCREMENT,
  `category` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `is_email` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'true=notification is enabled for email',
  `is_sms` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'true=notification is enabled for sms',
  `is_web` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'true=notification is enabled for webhook',
  `is_allow_from_app` tinyint(1) NOT NULL DEFAULT '1' COMMENT '1= allows manual receivers, 0= does not allow manual receivers',
  `created_by_id` int NOT NULL DEFAULT '0' COMMENT 'The person who created the event',
  `updated_by_id` int NOT NULL DEFAULT '0' COMMENT 'The person who updated the event last time',
  `status` tinyint NOT NULL DEFAULT '0' COMMENT '0= Not Processed, 1=Processed',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_events`
--

LOCK TABLES `notification_events` WRITE;
/*!40000 ALTER TABLE `notification_events` DISABLE KEYS */;
/*!40000 ALTER TABLE `notification_events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_layouts`
--

DROP TABLE IF EXISTS `notification_layouts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_layouts` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `content` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'content must contain a variable name {{$template}} . one and only once',
  `file_path` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `is_default` tinyint(1) NOT NULL DEFAULT '0',
  `created_by_id` int NOT NULL DEFAULT '0' COMMENT 'The person who created the layout',
  `updated_by_id` int NOT NULL DEFAULT '0' COMMENT 'The person who updated the layout',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `company_id` bigint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `notification_email_layouts_company_id_index` (`company_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_layouts`
--

LOCK TABLES `notification_layouts` WRITE;
/*!40000 ALTER TABLE `notification_layouts` DISABLE KEYS */;
INSERT INTO `notification_layouts` VALUES (1,'Money Transfer','MoneyTransfer','/Views/MoneyTransfer/',0,0,0,NULL,NULL,0);
/*!40000 ALTER TABLE `notification_layouts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_receiver_groups`
--

DROP TABLE IF EXISTS `notification_receiver_groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_receiver_groups` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` tinyint NOT NULL COMMENT '1=mail,\r\n2=sms,\r\n3=web',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '0',
  `to` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci COMMENT 'must be separated by comma(,)',
  `cc_emails` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci COMMENT 'must be separated by comma(,)',
  `bcc_emails` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci COMMENT 'must be separated by comma(,)',
  `created_by_id` int NOT NULL DEFAULT '0',
  `updated_by_id` int NOT NULL DEFAULT '0',
  `status` tinyint NOT NULL DEFAULT '1' COMMENT '1= active, 0= inactive',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `company_id` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_receiver_groups`
--

LOCK TABLES `notification_receiver_groups` WRITE;
/*!40000 ALTER TABLE `notification_receiver_groups` DISABLE KEYS */;
INSERT INTO `notification_receiver_groups` VALUES (1,1,'General','rifat.simoom@gmail.com, rifatsimoomchy@gmail.com,\r\nrifat.simoom@softrobotics.com.bd','rifat.simoom@gmail.com, rifatsimoomchy@gmail.com,\r\nrifat.simoom@softrobotics.com.bd','rifat.simoom@gmail.com, rifatsimoomchy@gmail.com,\r\nrifat.simoom@softrobotics.com.bd',0,0,1,NULL,NULL,0),(2,2,'General','+8801711456455, +8801711456454,\r\n+8801711456453','','',0,0,1,NULL,NULL,0),(3,3,'General','https://webhook.site/eb563dcc-7733-4c79-9998-9c3b4cb89e66','','',0,0,1,NULL,NULL,0);
/*!40000 ALTER TABLE `notification_receiver_groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_sms_events`
--

DROP TABLE IF EXISTS `notification_sms_events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_sms_events` (
  `id` int NOT NULL AUTO_INCREMENT,
  `notification_event_id` int NOT NULL,
  `notification_credential_id` int NOT NULL DEFAULT '0',
  `notification_receiver_group_id` int NOT NULL DEFAULT '0',
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Deposit Approve, Deposit Reject etc',
  `is_allow_from_app` tinyint(1) NOT NULL DEFAULT '1' COMMENT '1= allows manual receivers, 0= does not allow manual receivers',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_sms_events`
--

LOCK TABLES `notification_sms_events` WRITE;
/*!40000 ALTER TABLE `notification_sms_events` DISABLE KEYS */;
/*!40000 ALTER TABLE `notification_sms_events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_sms_outgoings`
--

DROP TABLE IF EXISTS `notification_sms_outgoings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_sms_outgoings` (
  `id` int NOT NULL AUTO_INCREMENT,
  `notification_credential_id` int NOT NULL DEFAULT '0',
  `content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'full sms content ',
  `to` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'phone number must be set as comma(,) separator',
  `status` tinyint NOT NULL DEFAULT '0' COMMENT '0=pending, 1= completed, 2= failed ',
  `attempt` int NOT NULL DEFAULT '0',
  `sent_at` datetime DEFAULT NULL COMMENT 'The moment when sms sent successfully',
  `notification_event_id` int NOT NULL,
  `notification_event_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `company_id` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_sms_outgoings`
--

LOCK TABLES `notification_sms_outgoings` WRITE;
/*!40000 ALTER TABLE `notification_sms_outgoings` DISABLE KEYS */;
INSERT INTO `notification_sms_outgoings` VALUES (1,2,'\nWe\'re excited to have you get started. Click https://www.randomfactgenerator.com for fun of facts!\n    ','+8801711456455, +8801711456454,\r\n+8801711456453,+8801717026889,+8801711468350,+8801819956740',1,0,NULL,1,'General','2024-07-16 14:31:18','2024-07-16 14:31:18',0);
/*!40000 ALTER TABLE `notification_sms_outgoings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_variables`
--

DROP TABLE IF EXISTS `notification_variables`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_variables` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `variable_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '' COMMENT 'variable must be placed with comma separator',
  `created_by_id` int NOT NULL DEFAULT '0' COMMENT 'User Id of the person who created the event',
  `updated_by_id` int NOT NULL DEFAULT '0' COMMENT 'User Id of the person who updated the event for the last time',
  `status` tinyint NOT NULL DEFAULT '1' COMMENT '1=active, 0=inactive',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `variable_name` (`variable_name`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_variables`
--

LOCK TABLES `notification_variables` WRITE;
/*!40000 ALTER TABLE `notification_variables` DISABLE KEYS */;
INSERT INTO `notification_variables` VALUES (1,'var1,var2,var3',0,0,1,NULL,NULL);
/*!40000 ALTER TABLE `notification_variables` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_web_events`
--

DROP TABLE IF EXISTS `notification_web_events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_web_events` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `notification_event_id` int NOT NULL,
  `notification_credential_id` int NOT NULL,
  `notification_receiver_group_id` int NOT NULL DEFAULT '0',
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Deposit Approve, Deposit Reject etc',
  `is_allow_from_app` tinyint(1) NOT NULL DEFAULT '1' COMMENT '1= allows manual receivers, 0= does not allow manual receivers',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_web_events`
--

LOCK TABLES `notification_web_events` WRITE;
/*!40000 ALTER TABLE `notification_web_events` DISABLE KEYS */;
/*!40000 ALTER TABLE `notification_web_events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification_web_outgoings`
--

DROP TABLE IF EXISTS `notification_web_outgoings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification_web_outgoings` (
  `id` int NOT NULL AUTO_INCREMENT,
  `notification_credential_id` int NOT NULL DEFAULT '0',
  `subject` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Title of the web notification',
  `content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci COMMENT 'payload of web notification',
  `host` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'url of the web notification host',
  `status` tinyint NOT NULL DEFAULT '0' COMMENT '0=pending, 1= completed, 2= failed ',
  `attempt` int NOT NULL DEFAULT '0',
  `sent_at` datetime DEFAULT NULL COMMENT 'The moment when we notification sent succesfully',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `company_id` int NOT NULL DEFAULT '0',
  `notification_event_id` int NOT NULL,
  `notification_event_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification_web_outgoings`
--

LOCK TABLES `notification_web_outgoings` WRITE;
/*!40000 ALTER TABLE `notification_web_outgoings` DISABLE KEYS */;
/*!40000 ALTER TABLE `notification_web_outgoings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'xxx'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-08-28 16:19:35
