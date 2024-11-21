-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: mobilebilling
-- ------------------------------------------------------
-- Server version	8.0.40

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
-- Temporary view structure for view `viewtransactions`
--

DROP TABLE IF EXISTS `viewtransactions`;
/*!50001 DROP VIEW IF EXISTS `viewtransactions`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `viewtransactions` AS SELECT 
 1 AS `TransactionID`,
 1 AS `SubscriberPhone`,
 1 AS `TransactionType`,
 1 AS `Amount`,
 1 AS `Timestamp`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `viewtariffs`
--

DROP TABLE IF EXISTS `viewtariffs`;
/*!50001 DROP VIEW IF EXISTS `viewtariffs`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `viewtariffs` AS SELECT 
 1 AS `TariffID`,
 1 AS `Name`,
 1 AS `PricePerMinute`,
 1 AS `MonthlyFee`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `viewtransactions`
--

/*!50001 DROP VIEW IF EXISTS `viewtransactions`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = cp866 */;
/*!50001 SET character_set_results     = cp866 */;
/*!50001 SET collation_connection      = cp866_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `viewtransactions` AS select `t`.`TransactionID` AS `TransactionID`,`s`.`PhoneNumber` AS `SubscriberPhone`,`t`.`TransactionType` AS `TransactionType`,`t`.`Amount` AS `Amount`,`t`.`Timestamp` AS `Timestamp` from (`transactions` `t` join `subscribers` `s` on((`t`.`SubscriberID` = `s`.`SubscriberID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `viewtariffs`
--

/*!50001 DROP VIEW IF EXISTS `viewtariffs`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = cp866 */;
/*!50001 SET character_set_results     = cp866 */;
/*!50001 SET collation_connection      = cp866_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `viewtariffs` AS select `tariffs`.`TariffID` AS `TariffID`,`tariffs`.`Name` AS `Name`,`tariffs`.`PricePerMinute` AS `PricePerMinute`,`tariffs`.`MonthlyFee` AS `MonthlyFee` from `tariffs` */;
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

-- Dump completed on 2024-11-22  0:39:37
