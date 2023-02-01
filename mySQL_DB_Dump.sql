-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: paintings
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
-- Temporary view structure for view `artistlocationfrompaintings`
--

DROP TABLE IF EXISTS `artistlocationfrompaintings`;
/*!50001 DROP VIEW IF EXISTS `artistlocationfrompaintings`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `artistlocationfrompaintings` AS SELECT 
 1 AS `painting_id`,
 1 AS `artists_artist_id`,
 1 AS `locations_location_id`,
 1 AS `artist_id`,
 1 AS `artist_firstName`,
 1 AS `artist_lastName`,
 1 AS `location_id`,
 1 AS `location_lastLocation`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `artists`
--

DROP TABLE IF EXISTS `artists`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `artists` (
  `artist_id` int NOT NULL AUTO_INCREMENT,
  `artist_firstName` varchar(45) NOT NULL,
  `artist_lastName` varchar(45) NOT NULL,
  `artist_education` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`artist_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `artists`
--

LOCK TABLES `artists` WRITE;
/*!40000 ALTER TABLE `artists` DISABLE KEYS */;
INSERT INTO `artists` VALUES (1,'Eva','Esseen','n/a');
/*!40000 ALTER TABLE `artists` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `locations`
--

DROP TABLE IF EXISTS `locations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `locations` (
  `location_id` int NOT NULL AUTO_INCREMENT,
  `location_lastLocation` varchar(45) NOT NULL,
  `location_movedDate` date DEFAULT NULL,
  `location_previusLocation` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`location_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `locations`
--

LOCK TABLES `locations` WRITE;
/*!40000 ALTER TABLE `locations` DISABLE KEYS */;
INSERT INTO `locations` VALUES (1,'Vänersborg',NULL,NULL);
/*!40000 ALTER TABLE `locations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `motif`
--

DROP TABLE IF EXISTS `motif`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `motif` (
  `motif_id` int NOT NULL,
  `motif_type` varchar(45) NOT NULL,
  PRIMARY KEY (`motif_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motif`
--

LOCK TABLES `motif` WRITE;
/*!40000 ALTER TABLE `motif` DISABLE KEYS */;
INSERT INTO `motif` VALUES (1,'Vatten'),(2,'Stenar'),(3,'Blommor'),(4,'Djur'),(5,'Byggnad'),(6,'Insekter');
/*!40000 ALTER TABLE `motif` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `motiffrompainting`
--

DROP TABLE IF EXISTS `motiffrompainting`;
/*!50001 DROP VIEW IF EXISTS `motiffrompainting`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `motiffrompainting` AS SELECT 
 1 AS `painting_id`,
 1 AS `painting_title`,
 1 AS `motif_type`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `paintings`
--

DROP TABLE IF EXISTS `paintings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paintings` (
  `painting_id` int NOT NULL AUTO_INCREMENT,
  `painting_title` varchar(45) NOT NULL,
  `painting_year` date DEFAULT NULL,
  `painting_dimension` varchar(45) DEFAULT 'Dimension unknown',
  `painting_historical_context` text,
  `painting_image` varchar(120) DEFAULT NULL,
  `artists_artist_id` int NOT NULL,
  `locations_location_id` int NOT NULL,
  PRIMARY KEY (`painting_id`,`artists_artist_id`,`locations_location_id`),
  KEY `fk_paintings_artists1_idx` (`artists_artist_id`),
  KEY `fk_paintings_locations1_idx` (`locations_location_id`),
  CONSTRAINT `fk_paintings_artists` FOREIGN KEY (`artists_artist_id`) REFERENCES `artists` (`artist_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_paintings_locations1` FOREIGN KEY (`locations_location_id`) REFERENCES `locations` (`location_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paintings`
--

LOCK TABLES `paintings` WRITE;
/*!40000 ALTER TABLE `paintings` DISABLE KEYS */;
INSERT INTO `paintings` VALUES (1,'Blomväktare','2021-07-25','Dimension unknown',NULL,'https://drive.google.com/file/d/1xKZDTmjKao7AftfrmoD6LOkVE7o5wdet/view?usp=sharing',1,1),(2,'Blåa sippor','2020-01-01','Dimension unknown',NULL,'https://drive.google.com/file/d/1g72s8yH0pPmEKaoH89xLXIilagcDsLE_/view?usp=sharing',1,1),(14,'Ljungdalen 1','2023-01-29','','','https://drive.google.com/file/d/1ddcRiNRILd3OWseyid0Bs5IKOEA9Mpo7/view?usp=sharing',1,1),(15,'Gemenskap','2023-01-29','','','https://drive.google.com/file/d/1jVLP2DsuLB4sstoT08uuf334nkfG2gb9/view?usp=sharing',1,1),(16,'Fångad','2023-01-29','','','https://drive.google.com/file/d/1QE4MoTsKslSxbCVBTTW0gGMJV3Hl19bY/view?usp=sharing',1,1);
/*!40000 ALTER TABLE `paintings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paintings_has_motif`
--

DROP TABLE IF EXISTS `paintings_has_motif`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paintings_has_motif` (
  `paintings_painting_id` int NOT NULL,
  `motif_motif_id` int NOT NULL,
  `paintings_motif_id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`paintings_motif_id`),
  KEY `fk_paintings_has_motif_motif1_idx` (`motif_motif_id`),
  KEY `fk_paintings_has_motif_paintings1_idx` (`paintings_painting_id`),
  CONSTRAINT `fk_paintings_has_motif_motif1` FOREIGN KEY (`motif_motif_id`) REFERENCES `motif` (`motif_id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_paintings_has_motif_paintings1` FOREIGN KEY (`paintings_painting_id`) REFERENCES `paintings` (`painting_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paintings_has_motif`
--

LOCK TABLES `paintings_has_motif` WRITE;
/*!40000 ALTER TABLE `paintings_has_motif` DISABLE KEYS */;
INSERT INTO `paintings_has_motif` VALUES (1,3,1),(1,6,2),(2,3,3),(16,6,4),(15,1,5),(15,2,6),(14,5,7);
/*!40000 ALTER TABLE `paintings_has_motif` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `artistlocationfrompaintings`
--

/*!50001 DROP VIEW IF EXISTS `artistlocationfrompaintings`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `artistlocationfrompaintings` AS select `paintings`.`painting_id` AS `painting_id`,`paintings`.`artists_artist_id` AS `artists_artist_id`,`paintings`.`locations_location_id` AS `locations_location_id`,`artists`.`artist_id` AS `artist_id`,`artists`.`artist_firstName` AS `artist_firstName`,`artists`.`artist_lastName` AS `artist_lastName`,`locations`.`location_id` AS `location_id`,`locations`.`location_lastLocation` AS `location_lastLocation` from ((`paintings` join `artists` on((`artists`.`artist_id` = `paintings`.`artists_artist_id`))) join `locations` on((`locations`.`location_id` = `paintings`.`locations_location_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `motiffrompainting`
--

/*!50001 DROP VIEW IF EXISTS `motiffrompainting`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `motiffrompainting` AS select `paintings`.`painting_id` AS `painting_id`,`paintings`.`painting_title` AS `painting_title`,`motif`.`motif_type` AS `motif_type` from ((`paintings` join `paintings_has_motif` on((`paintings`.`painting_id` = `paintings_has_motif`.`paintings_painting_id`))) join `motif` on((`motif`.`motif_id` = `paintings_has_motif`.`motif_motif_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-31  9:44:26
