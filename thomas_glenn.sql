-- MySQL dump 10.13  Distrib 8.0.15, for macos10.14 (x86_64)
--
-- Host: localhost    Database: thomas_glenn
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20200814172156_Initial','2.2.6-servicing-10079'),('20200814190025_Secondary','2.2.6-servicing-10079'),('20200814221121_Tertiary','2.2.6-servicing-10079'),('20200814234421_Quaternery','2.2.6-servicing-10079'),('20200815025807_Quintile','2.2.6-servicing-10079');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `AspNetRoleClaims`
--

LOCK TABLES `AspNetRoleClaims` WRITE;
/*!40000 ALTER TABLE `AspNetRoleClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetRoleClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `AspNetRoles`
--

LOCK TABLES `AspNetRoles` WRITE;
/*!40000 ALTER TABLE `AspNetRoles` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `AspNetUserClaims`
--

LOCK TABLES `AspNetUserClaims` WRITE;
/*!40000 ALTER TABLE `AspNetUserClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `AspNetUserLogins`
--

LOCK TABLES `AspNetUserLogins` WRITE;
/*!40000 ALTER TABLE `AspNetUserLogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserLogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `AspNetUserRoles`
--

LOCK TABLES `AspNetUserRoles` WRITE;
/*!40000 ALTER TABLE `AspNetUserRoles` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `AspNetUsers`
--

LOCK TABLES `AspNetUsers` WRITE;
/*!40000 ALTER TABLE `AspNetUsers` DISABLE KEYS */;
INSERT INTO `AspNetUsers` VALUES ('d21af495-ce9c-4a0b-bce0-e81f8ad95c69','bc@bc.com','BC@BC.COM',NULL,NULL,_binary '\0','AQAAAAEAACcQAAAAEAE1OIP2uNm6uwu/6ZqwqLHKeRbtpc8hT28fUEhAaMock0K8wNlxbunmVca4+MEPjQ==','YUXMCHA3A4FG4DI7635HNKW3S7R44ZLX','adc39fc9-7bde-4a61-acc4-3df5f1b07cf2',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE `AspNetUsers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `AspNetUserTokens`
--

LOCK TABLES `AspNetUserTokens` WRITE;
/*!40000 ALTER TABLE `AspNetUserTokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserTokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Flavors`
--

LOCK TABLES `Flavors` WRITE;
/*!40000 ALTER TABLE `Flavors` DISABLE KEYS */;
INSERT INTO `Flavors` VALUES (1,'Chocolate','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(2,'Peach','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(3,'Strawberry','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(4,'Roquefort','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(5,'Vanilla','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(6,'Raspberry','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(7,'Caramel','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(8,'Lemongrass','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(9,'Lavender','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(10,'Pineapple','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(11,'Cinnamon Nutmeg','d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(12,'Mocha Almond','d21af495-ce9c-4a0b-bce0-e81f8ad95c69');
/*!40000 ALTER TABLE `Flavors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `TreatFlavors`
--

LOCK TABLES `TreatFlavors` WRITE;
/*!40000 ALTER TABLE `TreatFlavors` DISABLE KEYS */;
INSERT INTO `TreatFlavors` VALUES (1,1,1),(2,2,3),(3,3,1);
/*!40000 ALTER TABLE `TreatFlavors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Treats`
--

LOCK TABLES `Treats` WRITE;
/*!40000 ALTER TABLE `Treats` DISABLE KEYS */;
INSERT INTO `Treats` VALUES (1,'Lollipops',0,'d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(2,'Wine Gums',25,'d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(3,'Ice Cream Beards',100,'d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(4,'Fudge Bars',85,'d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(5,'Popsicles',35,'d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(6,'Pies',46,'d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(7,'Cakes',29,'d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(8,'Cookies',300,'d21af495-ce9c-4a0b-bce0-e81f8ad95c69'),(9,'macarons',400,'d21af495-ce9c-4a0b-bce0-e81f8ad95c69');
/*!40000 ALTER TABLE `Treats` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-08-14 21:03:39
