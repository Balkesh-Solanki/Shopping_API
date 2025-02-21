-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: shoppingappdb
-- ------------------------------------------------------
-- Server version	8.0.41

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
-- Table structure for table `carts`
--

DROP TABLE IF EXISTS `carts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProductId` int DEFAULT NULL,
  `Quantity` int DEFAULT '1',
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `ProductId` (`ProductId`),
  CONSTRAINT `carts_ibfk_1` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carts`
--

LOCK TABLES `carts` WRITE;
/*!40000 ALTER TABLE `carts` DISABLE KEYS */;
INSERT INTO `carts` VALUES (1,1,12,'2025-02-21 17:06:59'),(2,2,10,'2025-02-21 17:14:25'),(3,3,140,'2025-02-21 17:14:34');
/*!40000 ALTER TABLE `carts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Category_02','2025-02-21 17:02:18'),(2,'Category_03','2025-02-21 17:10:02'),(3,'Category_04','2025-02-21 17:10:15');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `ImageUrl` varchar(255) DEFAULT NULL,
  `SubCategoryId` int DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `SubCategoryId` (`SubCategoryId`),
  CONSTRAINT `products_ibfk_1` FOREIGN KEY (`SubCategoryId`) REFERENCES `subcategories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Product_02',500.00,'ButterFly.jpg',1,'2025-02-21 17:06:35'),(2,'Product_03',10000.00,'Lion.jpg',2,'2025-02-21 17:12:30'),(3,'Product_04',4000.00,'Forest.jpg',3,'2025-02-21 17:12:48');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subcategories`
--

DROP TABLE IF EXISTS `subcategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subcategories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `CategoryId` int DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `CategoryId` (`CategoryId`),
  CONSTRAINT `subcategories_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subcategories`
--

LOCK TABLES `subcategories` WRITE;
/*!40000 ALTER TABLE `subcategories` DISABLE KEYS */;
INSERT INTO `subcategories` VALUES (1,'Sub_Category02',1,'2025-02-21 17:04:23'),(2,'SubCategory_03',2,'2025-02-21 17:11:00'),(3,'SubCategory_04',3,'2025-02-21 17:11:05');
/*!40000 ALTER TABLE `subcategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'shoppingappdb'
--

--
-- Dumping routines for database 'shoppingappdb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-02-21 17:30:03
