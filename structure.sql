
DROP TABLE IF EXISTS `contracts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contracts` (
  `contract_id` int NOT NULL AUTO_INCREMENT,
  `contract_name` varchar(45) NOT NULL,
  PRIMARY KEY (`contract_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `products_id` int NOT NULL AUTO_INCREMENT,
  `products_name` varchar(45) NOT NULL,
  `products_price` decimal(10,0) NOT NULL,
  `min_quantity` int NOT NULL,
  `suppliers_id` int DEFAULT NULL,
  PRIMARY KEY (`products_id`),
  KEY `idx_products_id` (`products_id`),
  KEY `fk_suppliers_products_idx` (`suppliers_id`),
  CONSTRAINT `fk_suppliers_products` FOREIGN KEY (`suppliers_id`) REFERENCES `suppliers` (`suppliers_id`)
) ENGINE=InnoDB AUTO_INCREMENT=144 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `project_status`
--

DROP TABLE IF EXISTS `project_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project_status` (
  `project_status_id` int NOT NULL AUTO_INCREMENT,
  `project_status_name` varchar(45) NOT NULL,
  PRIMARY KEY (`project_status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `purchases`
--

DROP TABLE IF EXISTS `purchases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchases` (
  `purchases_id` int NOT NULL AUTO_INCREMENT,
  `suppliers_id` int NOT NULL,
  `products_id` int NOT NULL,
  `purchases_user_id` int NOT NULL,
  `purchases_quantity` int NOT NULL,
  `purchases_date` date NOT NULL,
  `purchases_total_price` int NOT NULL,
  `unit_price` int NOT NULL,
  `status` int DEFAULT NULL,
  PRIMARY KEY (`purchases_id`),
  KEY `user_id_idx` (`purchases_user_id`),
  KEY `fk_purchases_purchases_status_idx` (`status`),
  CONSTRAINT `fk_purchases_purchases_status` FOREIGN KEY (`status`) REFERENCES `purchases_status` (`purchases_status_id`),
  CONSTRAINT `user_id` FOREIGN KEY (`purchases_user_id`) REFERENCES `users` (`users_id`)
) ENGINE=InnoDB AUTO_INCREMENT=89 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `purchases_status`
--

DROP TABLE IF EXISTS `purchases_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchases_status` (
  `purchases_status_id` int NOT NULL AUTO_INCREMENT,
  `purchases_status_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`purchases_status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `role_id` int NOT NULL AUTO_INCREMENT,
  `role_name` varchar(45) NOT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock` (
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  UNIQUE KEY `product_id_UNIQUE` (`product_id`),
  KEY `fk_product_stock_idx` (`product_id`),
  CONSTRAINT `fk_product_stock` FOREIGN KEY (`product_id`) REFERENCES `products` (`products_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliers` (
  `suppliers_id` int NOT NULL AUTO_INCREMENT,
  `contract` int NOT NULL,
  `suppliers_name` varchar(45) NOT NULL,
  `suppliers_phone` varchar(20) NOT NULL,
  `suppliers_address` varchar(45) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date DEFAULT NULL,
  PRIMARY KEY (`suppliers_id`),
  KEY `idx_suppliers_id` (`suppliers_id`),
  KEY `contract_idx` (`contract`),
  CONSTRAINT `contract` FOREIGN KEY (`contract`) REFERENCES `contracts` (`contract_id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `users_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `role_id` int NOT NULL,
  PRIMARY KEY (`users_id`),
  KEY `role_id_idx` (`role_id`),
  KEY `idx_users_id` (`users_id`),
  CONSTRAINT `role_id` FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `write_offs`
--

DROP TABLE IF EXISTS `write_offs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `write_offs` (
  `write_off_id` int NOT NULL AUTO_INCREMENT,
  `products_id` int NOT NULL,
  `quantity` int NOT NULL,
  `reason` varchar(255) DEFAULT NULL,
  `write_off_date` date DEFAULT NULL,
  `user_id` int NOT NULL,
  `write_on_date` date DEFAULT NULL,
  PRIMARY KEY (`write_off_id`),
  KEY `products_id` (`products_id`),
  KEY `write_offs_ibfk_2` (`user_id`),
  CONSTRAINT `write_offs_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `users` (`users_id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-30  2:13:02
