-- MariaDB dump 10.19  Distrib 10.4.22-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: acl
-- ------------------------------------------------------
-- Server version	10.4.22-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20240430200847_Init Migration','8.0.2');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_branches`
--

DROP TABLE IF EXISTS `acl_branches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_branches` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `company_id` bigint(20) unsigned NOT NULL,
  `name` varchar(50) NOT NULL,
  `address` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `status` tinyint(3) unsigned NOT NULL,
  `sequence` bigint(20) unsigned NOT NULL,
  `created_by_id` bigint(20) unsigned NOT NULL,
  `updated_by_id` bigint(20) unsigned NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_branches`
--

LOCK TABLES `acl_branches` WRITE;
/*!40000 ALTER TABLE `acl_branches` DISABLE KEYS */;
INSERT INTO `acl_branches` VALUES (1,2,'Default','Dhaka','TEST',1,0,2,2,'2024-05-01 02:59:58.902135','2024-05-01 02:59:58.902019');
/*!40000 ALTER TABLE `acl_branches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_companies`
--

DROP TABLE IF EXISTS `acl_companies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_companies` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `cname` varchar(100) NOT NULL,
  `cemail` varchar(100) NOT NULL,
  `address1` varchar(100) NOT NULL,
  `address2` varchar(100) NOT NULL,
  `postcode` varchar(10) NOT NULL,
  `phone` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  `fax` varchar(15) NOT NULL,
  `city` varchar(15) NOT NULL,
  `state` varchar(15) NOT NULL,
  `country` varchar(100) NOT NULL,
  `logo` varchar(191) NOT NULL,
  `registration_no` varchar(40) NOT NULL,
  `timezone` int(11) NOT NULL,
  `unique_column_name` tinyint(4) NOT NULL DEFAULT 1,
  `timezone_value` varchar(20) NOT NULL,
  `tax_no` varchar(40) NOT NULL,
  `tax_office` varchar(191) DEFAULT NULL,
  `sector` varchar(191) DEFAULT NULL,
  `average_turnover` double(12,4) NOT NULL,
  `no_of_employees` int(11) NOT NULL,
  `cmmi_level` tinyint(4) NOT NULL,
  `yearly_revenue` double(12,4) NOT NULL,
  `hourly_rate` double(12,4) NOT NULL,
  `daily_rate` double(12,4) NOT NULL,
  `status` tinyint(4) NOT NULL DEFAULT 1,
  `added_by` int(11) NOT NULL DEFAULT 1,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_companies`
--

LOCK TABLES `acl_companies` WRITE;
/*!40000 ALTER TABLE `acl_companies` DISABLE KEYS */;
INSERT INTO `acl_companies` VALUES (1,'Default','Admin','ssadmin@softrobotics.com','A','A2','4100','031','ssadmin@softrobotics.com','Fax','C','s','BD','logo','420',254,1,'TimeZone','tax',NULL,NULL,0.0000,6,0,0.0000,0.0000,0.0000,1,1,'2015-11-03 19:52:01','2019-03-28 07:29:33');
/*!40000 ALTER TABLE `acl_companies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_company_modules`
--

DROP TABLE IF EXISTS `acl_company_modules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_company_modules` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `company_id` bigint(20) unsigned NOT NULL,
  `module_id` bigint(20) unsigned NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_company_modules`
--

LOCK TABLES `acl_company_modules` WRITE;
/*!40000 ALTER TABLE `acl_company_modules` DISABLE KEYS */;
INSERT INTO `acl_company_modules` VALUES (1,1,1001,'2024-04-30 21:00:31','2024-04-30 21:00:31');
/*!40000 ALTER TABLE `acl_company_modules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_countries`
--

DROP TABLE IF EXISTS `acl_countries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_countries` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `company_id` bigint(20) unsigned NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(255) NOT NULL,
  `code` varchar(50) NOT NULL,
  `status` tinyint(3) unsigned NOT NULL,
  `sequence` bigint(20) unsigned NOT NULL,
  `created_by_id` bigint(20) unsigned NOT NULL,
  `updated_by_id` bigint(20) unsigned NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_countries`
--

LOCK TABLES `acl_countries` WRITE;
/*!40000 ALTER TABLE `acl_countries` DISABLE KEYS */;
INSERT INTO `acl_countries` VALUES (1,0,'Bangladesh','This is beautiful country','bn',1,0,2,2,'2024-05-01 03:01:56.388105','2024-05-01 03:01:56.388288');
/*!40000 ALTER TABLE `acl_countries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_modules`
--

DROP TABLE IF EXISTS `acl_modules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_modules` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `icon` varchar(255) NOT NULL,
  `sequence` int(11) NOT NULL,
  `display_name` varchar(100) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1004 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_modules`
--

LOCK TABLES `acl_modules` WRITE;
/*!40000 ALTER TABLE `acl_modules` DISABLE KEYS */;
INSERT INTO `acl_modules` VALUES (1001,'Company','<i class=\"fa fa-list-ul\"></i>',6,'Company','2015-12-09 06:10:46','2019-03-20 15:52:50'),(1002,'Master Data','<i class=\"fa fa-list-ul\"></i>',2,'Master Data','2015-12-09 06:10:46','2019-03-26 16:38:37'),(1003,'Access Control','<img src=\"adminca/assets/img/icons/access-control.svg\" />',1099,'Access Control','2015-12-09 06:10:47','2016-08-06 10:24:34');
/*!40000 ALTER TABLE `acl_modules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_page_routes`
--

DROP TABLE IF EXISTS `acl_page_routes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_page_routes` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `page_id` bigint(20) unsigned DEFAULT NULL,
  `route_name` varchar(100) DEFAULT NULL,
  `route_url` varchar(100) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `acl_page_routes_page_id_index` (`page_id`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8mb4;
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
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_pages` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `module_id` bigint(20) unsigned NOT NULL,
  `sub_module_id` bigint(20) unsigned NOT NULL,
  `name` varchar(100) NOT NULL,
  `method_name` varchar(255) NOT NULL,
  `method_type` int(11) NOT NULL,
  `available_to_company` tinyint(4) NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3085 DEFAULT CHARSET=utf8mb4;
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
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_role_pages` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `role_id` bigint(20) unsigned NOT NULL,
  `page_id` bigint(20) unsigned NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `acl_role_pages_role_id_page_id_unique` (`role_id`,`page_id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_role_pages`
--

LOCK TABLES `acl_role_pages` WRITE;
/*!40000 ALTER TABLE `acl_role_pages` DISABLE KEYS */;
INSERT INTO `acl_role_pages` VALUES (1,1,3001,NULL,NULL),(2,1,3002,NULL,NULL),(3,1,3003,NULL,NULL),(4,1,3004,NULL,NULL),(5,1,3005,NULL,NULL),(6,1,3015,NULL,NULL),(7,1,3016,NULL,NULL),(8,1,3017,NULL,NULL),(9,1,3018,NULL,NULL),(10,1,3019,NULL,NULL),(11,1,3025,NULL,NULL),(12,1,3026,NULL,NULL),(13,1,3027,NULL,NULL),(14,1,3028,NULL,NULL),(15,1,3029,NULL,NULL),(16,1,3035,NULL,NULL),(17,1,3036,NULL,NULL),(18,1,3037,NULL,NULL),(19,1,3038,NULL,NULL),(20,1,3039,NULL,NULL),(21,1,3080,NULL,NULL),(22,1,3081,NULL,NULL),(23,1,3082,NULL,NULL),(24,1,3083,NULL,NULL),(25,1,3084,NULL,NULL);
/*!40000 ALTER TABLE `acl_role_pages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_roles`
--

DROP TABLE IF EXISTS `acl_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_roles` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `title` varchar(100) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `status` tinyint(4) NOT NULL DEFAULT 1,
  `company_id` bigint(20) unsigned NOT NULL,
  `created_by_id` bigint(20) unsigned DEFAULT NULL,
  `updated_by_id` bigint(20) unsigned DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_roles`
--

LOCK TABLES `acl_roles` WRITE;
/*!40000 ALTER TABLE `acl_roles` DISABLE KEYS */;
INSERT INTO `acl_roles` VALUES (1,'super-super-admin','',1,1,NULL,NULL,'2019-03-21 20:38:30','2015-11-09 07:17:00');
/*!40000 ALTER TABLE `acl_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_states`
--

DROP TABLE IF EXISTS `acl_states`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_states` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `company_id` bigint(20) unsigned NOT NULL,
  `country_id` bigint(20) unsigned NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(255) NOT NULL,
  `status` tinyint(3) unsigned NOT NULL,
  `sequence` bigint(20) unsigned NOT NULL,
  `created_by_id` bigint(20) unsigned NOT NULL,
  `updated_by_id` bigint(20) unsigned NOT NULL,
  `created_at` datetime(6) NOT NULL,
  `updated_at` datetime(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_states`
--

LOCK TABLES `acl_states` WRITE;
/*!40000 ALTER TABLE `acl_states` DISABLE KEYS */;
INSERT INTO `acl_states` VALUES (1,1,1,'Florida','Florida is state of USA',1,100,2,2,'2024-05-01 03:02:07.804194','2024-05-01 03:02:07.804427');
/*!40000 ALTER TABLE `acl_states` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_sub_modules`
--

DROP TABLE IF EXISTS `acl_sub_modules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_sub_modules` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `module_id` bigint(20) unsigned NOT NULL,
  `name` varchar(100) NOT NULL,
  `controller_name` varchar(255) NOT NULL,
  `icon` varchar(255) NOT NULL,
  `sequence` int(11) NOT NULL,
  `default_method` varchar(50) NOT NULL,
  `display_name` varchar(100) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2056 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_sub_modules`
--

LOCK TABLES `acl_sub_modules` WRITE;
/*!40000 ALTER TABLE `acl_sub_modules` DISABLE KEYS */;
INSERT INTO `acl_sub_modules` VALUES (2001,1001,'Company Management','CompanyController','<i class=\"fa fa-angle-double-right\"></i>',100,'index','Company Management','2015-12-09 06:10:47','2015-12-09 06:10:47'),(2020,1002,'Module Management','ModuleController','<i class=\"fa fa-angle-double-right\"></i>',100,'index','Module Management','2015-12-09 06:10:48','2015-12-09 06:10:48'),(2021,1002,'Sub Module Management','SubModuleController','<i class=\"fa fa-angle-double-right\"></i>',101,'index','Sub Module Management','2015-12-09 06:10:48','2015-12-09 06:10:48'),(2022,1002,'Page Management','PageController','<i class=\"fa fa-angle-double-right\"></i>',102,'index','Page Management','2015-12-09 06:10:48','2015-12-09 06:10:48'),(2050,1003,'User Management','UserController','<i class=\"fa fa-angle-double-right\"></i>',18,'index','User Management','2015-12-09 06:10:49','2015-12-09 06:10:49'),(2051,1003,'Role Management','RoleController','<i class=\"fa fa-angle-double-right\"></i>',101,'index','Role Management','2015-12-09 06:10:49','2015-12-23 08:35:45'),(2052,1003,'User Group Management','UsergroupController','<i class=\"fa fa-angle-double-right\"></i>',102,'index','User Group Management','2015-12-09 06:10:49','2015-12-09 06:10:49'),(2053,1003,'Usergroup & Role Association','UsergroupRoleController','<i class=\"fa fa-angle-double-right\"></i>',103,'index','Usergroup & Role Association','2015-12-09 06:10:49','2015-12-09 06:10:49'),(2054,1003,'Role & Page Association','RolePageController','<i class=\"fa fa-angle-double-right\"></i>',104,'index','Role & Page Association','2015-12-09 06:10:50','2015-12-09 06:10:50'),(2055,1003,'Company Module Management','CompanyModuleController','<i class=\"fa fa-angle-double-right\"></i>',105,'index','Company Module Management','2015-12-09 06:10:48','2015-12-09 06:10:48');
/*!40000 ALTER TABLE `acl_sub_modules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_user_usergroups`
--

DROP TABLE IF EXISTS `acl_user_usergroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_user_usergroups` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `usergroup_id` bigint(20) unsigned NOT NULL,
  `user_id` bigint(20) unsigned NOT NULL,
  `company_id` bigint(20) unsigned NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_user_usergroups`
--

LOCK TABLES `acl_user_usergroups` WRITE;
/*!40000 ALTER TABLE `acl_user_usergroups` DISABLE KEYS */;
INSERT INTO `acl_user_usergroups` VALUES (1,1,1,1,'2024-01-24 07:23:21','2024-01-24 07:23:23');
/*!40000 ALTER TABLE `acl_user_usergroups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_usergroup_roles`
--

DROP TABLE IF EXISTS `acl_usergroup_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_usergroup_roles` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `usergroup_id` bigint(20) unsigned NOT NULL,
  `role_id` bigint(20) unsigned NOT NULL,
  `company_id` bigint(20) unsigned NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_usergroup_roles`
--

LOCK TABLES `acl_usergroup_roles` WRITE;
/*!40000 ALTER TABLE `acl_usergroup_roles` DISABLE KEYS */;
INSERT INTO `acl_usergroup_roles` VALUES (1,1,1,1,NULL,NULL);
/*!40000 ALTER TABLE `acl_usergroup_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_usergroups`
--

DROP TABLE IF EXISTS `acl_usergroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_usergroups` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `group_name` varchar(100) NOT NULL,
  `category` tinyint(4) NOT NULL,
  `dashboard_url` varchar(255) DEFAULT NULL,
  `status` tinyint(4) NOT NULL DEFAULT 1,
  `company_id` bigint(20) unsigned NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_usergroups`
--

LOCK TABLES `acl_usergroups` WRITE;
/*!40000 ALTER TABLE `acl_usergroups` DISABLE KEYS */;
INSERT INTO `acl_usergroups` VALUES (1,'super-super-admin-group',0,NULL,1,1,'2019-03-22 08:38:12','2023-11-01 19:17:00');
/*!40000 ALTER TABLE `acl_usergroups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_users`
--

DROP TABLE IF EXISTS `acl_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_users` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `first_name` varchar(100) DEFAULT NULL,
  `last_name` varchar(100) DEFAULT NULL,
  `email` varchar(50) NOT NULL,
  `avatar` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `dob` datetime(6) DEFAULT NULL,
  `gender` tinyint(4) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `city` varchar(100) DEFAULT NULL,
  `country` int(10) unsigned NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `is_admin_verified` tinyint(4) NOT NULL,
  `user_type` int(10) unsigned NOT NULL,
  `remember_token` varchar(100) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `activated_at` datetime DEFAULT NULL,
  `language` varchar(2) NOT NULL DEFAULT 'en',
  `username` varchar(20) DEFAULT NULL,
  `img_path` text DEFAULT NULL,
  `status` tinyint(4) NOT NULL DEFAULT 1,
  `company_id` int(10) unsigned NOT NULL,
  `permission_version` int(10) unsigned NOT NULL,
  `otp_channel` tinyint(4) NOT NULL,
  `login_at` datetime DEFAULT NULL,
  `created_by_id` int(10) unsigned NOT NULL,
  `auth_identifier` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acl_users`
--

LOCK TABLES `acl_users` WRITE;
/*!40000 ALTER TABLE `acl_users` DISABLE KEYS */;
INSERT INTO `acl_users` VALUES (1,'admin1','admin1','ssadmin@sipay.com.tr','users/admin/c41353d1c1fcbdbd39f96ea46a3f769136952e79.png','Nop@ss1234','1994-02-22 00:00:00.000000',1,'Dhaka','19',0,'+8801788343704',1,0,'','2018-07-10 16:21:24','2021-08-25 05:46:27',NULL,'en','rajibecbb','storage/users/1/2019-04-18-07-49-28-ba4fe9be59df7b82f8243d2126070d76f5305b3e.png',1,1,1,0,NULL,1,NULL);
/*!40000 ALTER TABLE `acl_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acl_usertype_submodules`
--

DROP TABLE IF EXISTS `acl_usertype_submodules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acl_usertype_submodules` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `user_type_id` tinyint(3) unsigned NOT NULL,
  `sub_module_id` int(10) unsigned NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;
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
-- Table structure for table `failed_jobs`
--

DROP TABLE IF EXISTS `failed_jobs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `failed_jobs` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `uuid` varchar(255) NOT NULL,
  `connection` text NOT NULL,
  `queue` text NOT NULL,
  `payload` longtext NOT NULL,
  `exception` longtext NOT NULL,
  `failed_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  UNIQUE KEY `failed_jobs_uuid_unique` (`uuid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `failed_jobs`
--

LOCK TABLES `failed_jobs` WRITE;
/*!40000 ALTER TABLE `failed_jobs` DISABLE KEYS */;
/*!40000 ALTER TABLE `failed_jobs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `migrations`
--

DROP TABLE IF EXISTS `migrations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `migrations` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `migration` varchar(255) NOT NULL,
  `batch` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `migrations`
--

LOCK TABLES `migrations` WRITE;
/*!40000 ALTER TABLE `migrations` DISABLE KEYS */;
/*!40000 ALTER TABLE `migrations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personal_access_tokens`
--

DROP TABLE IF EXISTS `personal_access_tokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personal_access_tokens` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `tokenable_type` varchar(255) NOT NULL,
  `tokenable_id` bigint(20) unsigned NOT NULL,
  `name` varchar(255) NOT NULL,
  `token` varchar(64) NOT NULL,
  `abilities` text DEFAULT NULL,
  `last_used_at` timestamp NULL DEFAULT NULL,
  `expires_at` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `personal_access_tokens_token_unique` (`token`),
  KEY `personal_access_tokens_tokenable_type_tokenable_id_index` (`tokenable_type`,`tokenable_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personal_access_tokens`
--

LOCK TABLES `personal_access_tokens` WRITE;
/*!40000 ALTER TABLE `personal_access_tokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `personal_access_tokens` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-01  3:03:13
