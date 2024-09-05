LOCK TABLES `acl_branches` WRITE;
/*!40000 ALTER TABLE `acl_branches` DISABLE KEYS */;
INSERT INTO `acl_branches` VALUES (1,2,'Test','Dhaka','Test',1,1,1,1,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(2,0,'Uttara Branch','Uttara sector 11','This is sub branch.',1,1,0,0,'2024-05-20 17:53:44.930363','2024-05-20 17:53:44.930291');
LOCK TABLES `acl_companies` WRITE;
/*!40000 ALTER TABLE `acl_companies` DISABLE KEYS */;
INSERT INTO `acl_companies` VALUES (1,'Default','Admin','ssadmin@softrobotics.com','A','A2','4100','031','ssadmin@softrobotics.com','Fax','C','s','BD','logo','420',254,1,'TimeZone','tax',NULL,NULL,0.0000,6,0,0.0000,0.0000,0.0000,1,1,'2015-11-03 19:52:01','2019-03-28 07:29:33'),(2,'Mahmud','mahmud','mahmud@gmail.com','Sirajgonj','Dhaka bangladesh','1229','+880152455','test@gmail.com','+99845','Dhaka','Dhaka','Bangladesh','logon.png','5444654',6,1,'bd','465456',NULL,NULL,0.0000,0,0,0.0000,0.0000,0.0000,1,1,'2024-05-20 11:25:34','2024-05-20 11:25:34');
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

'2019-03-28 13:29:33.000000'),(35,'Burkina Faso','This is beautiful country','BF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(36,'Burundi','This is beautiful country','BI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(37,'Cambodia','This is beautiful country','KH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(38,'Cameroon','This is beautiful country','CM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(39,'Canada','This is beautiful country','CA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(40,'Cape Verde','This is beautiful country','CV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(41,'Cayman Islands','This is beautiful country','KY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(42,'Central African Republic','This is beautiful country','CF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(43,'Chad','This is beautiful country','TD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(44,'Chile','This is beautiful country','CL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(45,'China','This is beautiful country','CN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(46,'Christmas Island','This is beautiful country','CX',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(47,'Cocos (Keeling) Islands','This is beautiful country','CC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(48,'Colombia','This is beautiful country','CO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(49,'Comoros','This is beautiful country','KM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(50,'Congo','This is beautiful country','CG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(51,'Congo, the Democratic Republic of the','This is beautiful country','CD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(52,'Cook Islands','This is beautiful country','CK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(53,'Costa Rica','This is beautiful country','CR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(54,'Croatia','This is beautiful country','HR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(55,'Cuba','This is beautiful country','CU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(56,'CuraÃ§ao','This is beautiful country','CW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(57,'Cyprus','This is beautiful country','CY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(58,'Czech Republic','This is beautiful country','CZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(59,'CÃ´te d\'Ivoire','This is beautiful country','CI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(60,'Denmark','This is beautiful country','DK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(61,'Djibouti','This is beautiful country','DJ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(62,'Dominica','This is beautiful country','DM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(63,'Dominican Republic','This is beautiful country','DO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(64,'Ecuador','This is beautiful country','EC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(65,'Egypt','This is beautiful country','EG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(66,'El Salvador','This is beautiful country','SV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(67,'Equatorial Guinea','This is beautiful country','GQ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(68,'Eritrea','This is beautiful country','ER',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(69,'Estonia','This is beautiful country','EE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(70,'Ethiopia','This is beautiful country','ET',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(71,'Falkland Islands (Malvinas)','This is beautiful country','FK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(72,'Faroe Islands','This is beautiful country','FO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(73,'Fiji','This is beautiful country','FJ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(74,'Finland','This is beautiful country','FI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(75,'France','This is beautiful country','FR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(76,'French Guiana','This is beautiful country','GF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(77,'French Polynesia','This is beautiful country','PF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(78,'French Southern Territories','This is beautiful country','TF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(79,'Gabon','This is beautiful country','GA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(80,'Gambia','This is beautiful country','GM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(81,'Georgia','This is beautiful country','GE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(82,'Germany','This is beautiful country','DE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(83,'Ghana','This is beautiful country','GH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(84,'Gibraltar','This is beautiful country','GI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(85,'Greece','This is beautiful country','GR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(86,'Greenland','This is beautiful country','GL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(87,'Grenada','This is beautiful country','GD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(88,'Guadeloupe','This is beautiful country','GP',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(89,'Guam','This is beautiful country','GU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(90,'Guatemala','This is beautiful country','GT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(91,'Guernsey','This is beautiful country','GG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(92,'Guinea','This is beautiful country','GN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(93,'Guinea-Bissau','This is beautiful country','GW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(94,'Guyana','This is beautiful country','GY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(95,'Haiti','This is beautiful country','HT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(96,'Heard Island and McDonald Islands','This is beautiful country','HM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(97,'Holy See (Vatican City State)','This is beautiful country','VA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(98,'Honduras','This is beautiful country','HN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(99,'Hong Kong','This is beautiful country','HK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(100,'Hungary','This is beautiful country','HU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(101,'Iceland','This is beautiful country','IS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(102,'India','This is beautiful country','IN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(103,'Indonesia','This is beautiful country','ID',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(104,'Iran, Islamic Republic of','This is beautiful country','IR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(105,'Iraq','This is beautiful country','IQ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(106,'Ireland','This is beautiful country','IE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(107,'Isle of Man','This is beautiful country','IM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(108,'Israel','This is beautiful country','IL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(109,'Italy','This is beautiful country','IT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(110,'Jamaica','This is beautiful country','JM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(111,'Japan','This is beautiful country','JP',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(112,'Jersey','This is beautiful country','JE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(113,'Jordan','This is beautiful country','JO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(114,'Kazakhstan','This is beautiful country','KZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(115,'Kenya','This is beautiful country','KE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(116,'Kiribati','This is beautiful country','KI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(117,'Korea, Democratic People\'s Republic of','This is beautiful country','KP',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(118,'Korea, Republic of','This is beautiful country','KR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(119,'Kuwait','This is beautiful country','KW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(120,'Kyrgyzstan','This is beautiful country','KG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(121,'Lao People\'s Democratic Republic','This is beautiful country','LA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(122,'Latvia','This is beautiful country','LV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(123,'Lebanon','This is beautiful country','LB',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(124,'Lesotho','This is beautiful country','LS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(125,'Liberia','This is beautiful country','LR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(126,'Libya','This is beautiful country','LY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(127,'Liechtenstein','This is beautiful country','LI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(128,'Lithuania','This is beautiful country','LT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(129,'Luxembourg','This is beautiful country','LU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(130,'Macao','This is beautiful country','MO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(131,'Macedonia, the Former Yugoslav Republic of','This is beautiful country','MK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(132,'Madagascar','This is beautiful country','MG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(133,'Malawi','This is beautiful country','MW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(134,'Malaysia','This is beautiful country','MY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(135,'Maldives','This is beautiful country','MV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(136,'Mali','This is beautiful country','ML',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(137,'Malta','This is beautiful country','MT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(138,'Marshall Islands','This is beautiful country','MH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(139,'Martinique','This is beautiful country','MQ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(140,'Mauritania','This is beautiful country','MR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(141,'Mauritius','This is beautiful country','MU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(142,'Mayotte','This is beautiful country','YT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(143,'Mexico','This is beautiful country','MX',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(144,'Micronesia, Federated States of','This is beautiful country','FM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(145,'Moldova, Republic of','This is beautiful country','MD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(146,'Monaco','This is beautiful country','MC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(147,'Mongolia','This is beautiful country','MN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(148,'Montenegro','This is beautiful country','ME',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(149,'Montserrat','This is beautiful country','MS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(150,'Morocco','This is beautiful country','MA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(151,'Mozambique','This is beautiful country','MZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(152,'Myanmar','This is beautiful country','MM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(153,'Namibia','This is beautiful country','NA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(154,'Nauru','This is beautiful country','NR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(155,'Nepal','This is beautiful country','NP',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(156,'Netherlands','This is beautiful country','NL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(157,'New Caledonia','This is beautiful country','NC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(158,'New Zealand','This is beautiful country','NZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(159,'Nicaragua','This is beautiful country','NI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(160,'Niger','This is beautiful country','NE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(161,'Nigeria','This is beautiful country','NG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(162,'Niue','This is beautiful country','NU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(163,'Norfolk Island','This is beautiful country','NF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(164,'Northern Mariana Islands','This is beautiful country','MP',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(165,'Norway','This is beautiful country','NO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(166,'Oman','This is beautiful country','OM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(167,'Pakistan','This is beautiful country','PK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(168,'Palau','This is beautiful country','PW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(169,'Palestine, State of','This is beautiful country','PS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(170,'Panama','This is beautiful country','PA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(171,'Papua New Guinea','This is beautiful country','PG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(172,'Paraguay','This is beautiful country','PY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(173,'Peru','This is beautiful country','PE',1,0,2,2,'2015-11-04 01:52:01.an','This is beautiful country','SS',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(208,'Spain','This is beautiful country','ES',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(209,'Sri Lanka','This is beautiful country','LK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(210,'Sudan','This is beautiful country','SD',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(211,'Suriname','This is beautiful country','SR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(212,'Svalbard and Jan Mayen','This is beautiful country','SJ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(213,'Swaziland','This is beautiful country','SZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(214,'Sweden','This is beautiful country','SE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(215,'Switzerland','This is beautiful country','CH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(216,'Syrian Arab Republic','This is beautiful country','SY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(217,'Taiwan, Province of China','This is beautiful country','TW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(218,'Tajikistan','This is beautiful country','TJ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(219,'Tanzania, United Republic of','This is beautiful country','TZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(220,'Thailand','This is beautiful country','TH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(221,'Timor-Leste','This is beautiful country','TL',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(222,'Togo','This is beautiful country','TG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(223,'Tokelau','This is beautiful country','TK',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(224,'Tonga','This is beautiful country','TO',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(225,'Trinidad and Tobago','This is beautiful country','TT',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(226,'Tunisia','This is beautiful country','TN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(227,'Turkey','This is beautiful country','TR',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(228,'Turkmenistan','This is beautiful country','TM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(229,'Turks and Caicos Islands','This is beautiful country','TC',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(230,'Tuvalu','This is beautiful country','TV',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(231,'Uganda','This is beautiful country','UG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(232,'Ukraine','This is beautiful country','UA',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(233,'United Arab Emirates','This is beautiful country','AE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(234,'United Kingdom','This is beautiful country','GB',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(235,'United States','This is beautiful country','US',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(236,'United States Minor Outlying Islands','This is beautiful country','UM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(237,'Uruguay','This is beautiful country','UY',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(238,'Uzbekistan','This is beautiful country','UZ',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(239,'Vanuatu','This is beautiful country','VU',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(240,'Venezuela, Bolivarian Republic of','This is beautiful country','VE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(241,'Viet Nam','This is beautiful country','VN',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(242,'Virgin Islands, British','This is beautiful country','VG',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(243,'Virgin Islands, U.S.','This is beautiful country','VI',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(244,'Wallis and Futuna','This is beautiful country','WF',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(245,'Western Sahara','This is beautiful country','EH',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(246,'Yemen','This is beautiful country','YE',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(247,'Zambia','This is beautiful country','ZM',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(248,'Zimbabwe','This is beautiful country','ZW',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000'),(249,'Ã…land Islands','This is beautiful country','AX',1,0,2,2,'2015-11-04 01:52:01.000000','2019-03-28 13:29:33.000000');
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
  `normalized_name` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `concurrency_stamp` longtext COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_roles`
--

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

/*!40000 ALTER TABLE `acl_sub_modules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_user_settings`
--

DROP TABLE IF EXISTS `acl_user_settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_user_settings` (
  `id` int unsigned NOT NULL COMMENT 'id of users table',
  `user_id` int unsigned NOT NULL COMMENT 'id of users table',
  `app_id` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `app_secret` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_user_settings`
--

LOCK TABLES `acl_user_settings` WRITE;
/*!40000 ALTER TABLE `acl_user_settings` DISABLE KEYS */;
INSERT INTO `acl_user_settings` VALUES (5,5,'354103','Srbl@123.');
LOCK TABLES `acl_user_usergroups` WRITE;
/*!40000 ALTER TABLE `acl_user_usergroups` DISABLE KEYS */;
INSERT INTO `acl_user_usergroups` VALUES (1,1,1,1,'2024-01-24 07:23:21','2024-01-24 07:23:23'),(2,2,2,0,'2024-05-20 17:25:35','2024-05-20 17:25:35'),(21,0,18,0,'2024-09-05 16:44:19','2024-09-05 16:44:19');
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

/*!40000 ALTER TABLE `acl_usergroups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_users`
--

DROP TABLE IF EXISTS `acl_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acl_users` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `first_name` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `last_name` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `avatar` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `salt` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `gender` tinyint DEFAULT NULL COMMENT '1=Male, 2=Female',
  `address` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `city` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `country` int unsigned NOT NULL DEFAULT '0',
  `phone` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `is_admin_verified` tinyint NOT NULL DEFAULT '0' COMMENT '0=Pending, 1=Approved, 2=Not Approved, 3=Lock User',
  `user_type` int unsigned NOT NULL DEFAULT '0' COMMENT 'USER_TYPE_SS_ADMIN = 0; USER_TYPE_S_ADMIN = 1; USER_TYPE_USER = 2',
  `remember_token` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `refresh_token` varchar(300) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `claims` varchar(3000) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `activated_at` datetime DEFAULT NULL,
  `language` varchar(2) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'en',
  `username` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `img_path` text COLLATE utf8mb4_unicode_ci,
  `status` tinyint NOT NULL DEFAULT '1' COMMENT '0=>Inactive or disable; 1=>enable or active; 2=> disabled or suspected;3= awaiting disable or banned;4=awaiting GSM',
  `company_id` int unsigned NOT NULL DEFAULT '0',
  `permission_version` int unsigned NOT NULL DEFAULT '0',
  `otp_channel` tinyint NOT NULL DEFAULT '0' COMMENT '0 => all channel like sms, email, 1 => only sms, 2=> only email',
  `login_at` datetime DEFAULT NULL COMMENT 'user logged in time',
  `created_by_id` int unsigned NOT NULL DEFAULT '0',
  `auth_identifier` varchar(150) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `normalized_user_name` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `normalized_email` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email_confirmed` tinyint(1) NOT NULL,
  `password_hash` longtext COLLATE utf8mb4_unicode_ci,
  `security_stamp` longtext COLLATE utf8mb4_unicode_ci,
  `concurrency_stamp` longtext COLLATE utf8mb4_unicode_ci,
  `phone_number` longtext COLLATE utf8mb4_unicode_ci,
  `phone_number_confirmed` tinyint(1) DEFAULT '0',
  `two_factor_enabled` tinyint(1) NOT NULL,
  `lockout_end` datetime DEFAULT NULL,
  `lockout_enabled` tinyint(1) DEFAULT '0',
  `access_failed_count` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_users`
--

LOCK TABLES `acl_users` WRITE;
/*!40000 ALTER TABLE `acl_users` DISABLE KEYS */;
INSERT INTO `acl_users` VALUES (18,'string','string','string','string','hJCqCWrg7+FfdMI+Q+DtnFH2erwWnA7mE8NgpvCrPvHzWAi6bI1XhWvCiGtGHhYKBV53sM+G6oM6mjuLj1wlqA==','g7+3NFVkUePiiQaC+At1Cy9qFVGx2rid52G18EidwHhBo//fSOLjuKbeEVPC3XhDCFk4u9Pbi/eyX/Btm1KiZQ==','2024-09-05',0,'string','string',0,'string',0,1,NULL,NULL,NULL,'2024-09-05 16:44:16','2024-09-05 16:44:16',NULL,'bd',NULL,'string',1,0,0,0,NULL,0,NULL,NULL,NULL,0,'hJCqCWrg7+FfdMI+Q+DtnFH2erwWnA7mE8NgpvCrPvHzWAi6bI1XhWvCiGtGHhYKBV53sM+G6oM6mjuLj1wlqA==','g7+3NFVkUePiiQaC+At1Cy9qFVGx2rid52G18EidwHhBo//fSOLjuKbeEVPC3XhDCFk4u9Pbi/eyX/Btm1KiZQ==','g7+3NFVkUePiiQaC+At1Cy9qFVGx2rid52G18EidwHhBo//fSOLjuKbeEVPC3XhDCFk4u9Pbi/eyX/Btm1KiZQ==','string',0,0,NULL,0,0);
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
  `gmt` varchar(5) NOT NULL COMMENT 'GMT offset in hours (e.g., +5, -3)',
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, corridor is setup of source country-currency to destination country-currency, like send GBP Euro to USA USD';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_corridors`
--

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
  `iso_code` varchar(3) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `iso_code_short` varchar(2) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `iso_code_num` varchar(3) COLLATE utf8mb4_general_ci NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `official_state_name` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `status` tinyint unsigned DEFAULT '1' COMMENT '1=active, 0=inactive, 2=soft-deleted',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_countries`
--

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
LOCK TABLES `imt_currency_conversion_rates` WRITE;
/*!40000 ALTER TABLE `imt_currency_conversion_rates` DISABLE KEYS */;
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
  `gmt` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'GMT offset in hours (e.g., +5, -3)',
  `open_at` datetime DEFAULT NULL COMMENT 'Time to start if type is not full',
  `close_at` datetime DEFAULT NULL COMMENT 'Time to end if type is not full',
  `company_id` int unsigned DEFAULT '0',
  `status` tinyint unsigned NOT NULL DEFAULT '1' COMMENT '0=inactive, 1=active, 2=pending, 3=rejected ',
  `created_by_id` int unsigned DEFAULT NULL,
  `updated_by_id` int unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, contrywise holidays';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_holiday_settings`
--

LOCK TABLES `imt_holiday_settings` WRITE;
/*!40000 ALTER TABLE `imt_holiday_settings` DISABLE KEYS */;
INSERT INTO `imt_holiday_settings` VALUES (1,0,'2024-08-28',0,'0','2024-08-28 14:16:22','2024-08-28 14:16:22',0,1,NULL,NULL,NULL,NULL),(2,0,'2024-08-28',0,'0','2024-08-28 14:16:22','2024-08-28 14:16:22',0,1,NULL,NULL,NULL,NULL);
LOCK TABLES `imt_institution_app_settings` WRITE;
/*!40000 ALTER TABLE `imt_institution_app_settings` DISABLE KEYS */;
INSERT INTO `imt_institution_app_settings` VALUES (1,1,'sfsdfdfg','dgdgfdgh','dfgdfg','token',1,'2024-08-30 08:16:41','2024-08-30 08:16:41',NULL,1,1),(2,245,'SomeName','dgdgfdgh','dfgdfg','token',1,'2024-09-03 02:28:10','2024-09-03 02:28:10',NULL,1,1);
LOCK TABLES `imt_institution_funds` WRITE;
/*!40000 ALTER TABLE `imt_institution_funds` DISABLE KEYS */;
LOCK TABLES `imt_institution_mtts` WRITE;
/*!40000 ALTER TABLE `imt_institution_mtts` DISABLE KEYS */;
LOCK TABLES `imt_institutions` WRITE;
/*!40000 ALTER TABLE `imt_institutions` DISABLE KEYS */;
INSERT INTO `imt_institutions` VALUES (32,'SomeName','Url',1,1,0,0,'2024-09-03 16:49:08','2024-09-03 16:49:08');
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
  `gmt` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'GMT offset (e.g., +5, -3)',
  `opens_at` datetime NOT NULL COMMENT 'Opening time',
  `closes_at` datetime NOT NULL COMMENT 'Closing time',
  `working_days` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL COMMENT 'CSV of weekdays (e.g., Monday,Tuesday)',
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
  `transaction_type_id` int unsigned NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Type : Master, transaction setup between providers and us, like POS of a payment system';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `imt_mtts`
--

LOCK TABLES `imt_mtts` WRITE;
/*!40000 ALTER TABLE `imt_mtts` DISABLE KEYS */;
INSERT INTO `imt_mtts` VALUES (3,1,NULL,1,1,1,1.0000,1.0000,1.0000,1.0000,1.0000,1.0000,1,1,1,1,1,'2024-09-02 18:50:05','2024-09-02 18:50:05'),(4,1,NULL,1,1,1,1.0000,1.0000,1.0000,1.0000,1.0000,1.0000,1,1,1,1,1,'2024-09-03 01:53:12','2024-09-03 01:53:12');
LOCK TABLES `imt_payer_payment_speeds` WRITE;
/*!40000 ALTER TABLE `imt_payer_payment_speeds` DISABLE KEYS */;
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
LOCK TABLES `imt_provider_error_details` WRITE;
/*!40000 ALTER TABLE `imt_provider_error_details` DISABLE KEYS */;
INSERT INTO `imt_provider_error_details` VALUES (64,1,1,11,'1007001','External ID already used','2024-08-20 13:53:55','2024-08-20 13:53:55'),(65,1,1,12,'1007001','External ID already used','2024-08-22 12:37:28','2024-08-22 12:37:28');
LOCK TABLES `imt_provider_payers` WRITE;
/*!40000 ALTER TABLE `imt_provider_payers` DISABLE KEYS */;
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
LOCK TABLES `imt_quotation_requests` WRITE;
/*!40000 ALTER TABLE `imt_quotation_requests` DISABLE KEYS */;
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
  `name` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL COMMENT 'Example : EuroZone, Asia Pacific',
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
LOCK TABLES `notification_layouts` WRITE;
/*!40000 ALTER TABLE `notification_layouts` DISABLE KEYS */;
INSERT INTO `notification_layouts` VALUES (1,'Money Transfer','MoneyTransfer','/Views/MoneyTransfer/',0,0,0,NULL,NULL,0);
LOCK TABLES `notification_receiver_groups` WRITE;
/*!40000 ALTER TABLE `notification_receiver_groups` DISABLE KEYS */;
INSERT INTO `notification_receiver_groups` VALUES (1,1,'General','rifat.simoom@gmail.com, rifatsimoomchy@gmail.com,\r\nrifat.simoom@softrobotics.com.bd','rifat.simoom@gmail.com, rifatsimoomchy@gmail.com,\r\nrifat.simoom@softrobotics.com.bd','rifat.simoom@gmail.com, rifatsimoomchy@gmail.com,\r\nrifat.simoom@softrobotics.com.bd',0,0,1,NULL,NULL,0),(2,2,'General','+8801711456455, +8801711456454,\r\n+8801711456453','','',0,0,1,NULL,NULL,0),(3,3,'General','https://webhook.site/eb563dcc-7733-4c79-9998-9c3b4cb89e66','','',0,0,1,NULL,NULL,0);
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

/*!40000 ALTER TABLE `notification_web_outgoings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'acl_dot_net1'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-05 16:45:47
