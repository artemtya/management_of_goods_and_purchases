
CREATE TABLE `contracts` (
  `contract_id` int NOT NULL AUTO_INCREMENT,
  `contract_name` varchar(45) NOT NULL,
  PRIMARY KEY (`contract_id`)
) 
CREATE TABLE `products` (
  `products_id` int NOT NULL AUTO_INCREMENT,
  `products_name` varchar(45) NOT NULL,
  `products_price` decimal(10,0) NOT NULL,
  `min_quantity` int NOT NULL,
  `suppliers_id` int NOT NULL,
  PRIMARY KEY (`products_id`),
  KEY `idx_products_id` (`products_id`),
  KEY `fk_suppliers_products_idx` (`suppliers_id`),
  CONSTRAINT `fk_suppliers_products` FOREIGN KEY (`suppliers_id`) REFERENCES `suppliers` (`suppliers_id`)
) 
CREATE TABLE `purchases` (
  `purchases_id` int NOT NULL AUTO_INCREMENT,
  `suppliers_id` int NOT NULL,
  `products_id` int NOT NULL,
  `purchases_user_id` int NOT NULL,
  `purchases_quantity` int NOT NULL,
  `purchases_date` date NOT NULL,
  `purchases_total_price` decimal(10,0) NOT NULL,
  `unit_price` decimal(10,0) NOT NULL,
  `status` int NOT NULL,
  PRIMARY KEY (`purchases_id`),
  KEY `user_id_idx` (`purchases_user_id`),
  KEY `fk_purchases_purchases_status_idx` (`status`),
  KEY `fk_purchases_sp_idx` (`suppliers_id`),
  KEY `fk_purchases_prod_idx` (`products_id`),
  CONSTRAINT `fk_purchases_product` FOREIGN KEY (`products_id`) REFERENCES `products` (`products_id`),
  CONSTRAINT `fk_purchases_purchases_status` FOREIGN KEY (`status`) REFERENCES `purchases_status` (`purchases_status_id`),
  CONSTRAINT `fk_purchases_suppliers` FOREIGN KEY (`suppliers_id`) REFERENCES `suppliers` (`suppliers_id`),
  CONSTRAINT `user_id` FOREIGN KEY (`purchases_user_id`) REFERENCES `users` (`users_id`)
) 
  `purchases_status_id` int NOT NULL AUTO_INCREMENT,
  `purchases_status_name` varchar(45) NOT NULL,
  PRIMARY KEY (`purchases_status_id`)
) 
CREATE TABLE `role` (
  `role_id` int NOT NULL AUTO_INCREMENT,
  `role_name` varchar(45) NOT NULL,
  PRIMARY KEY (`role_id`)
) 
CREATE TABLE `stock` (
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  UNIQUE KEY `product_id_UNIQUE` (`product_id`),
  KEY `fk_product_stock_idx` (`product_id`),
  CONSTRAINT `fk_product_stock` FOREIGN KEY (`product_id`) REFERENCES `products` (`products_id`)
) 
CREATE TABLE `suppliers` (
  `suppliers_id` int NOT NULL AUTO_INCREMENT,
  `contract` int NOT NULL,
  `suppliers_name` varchar(45) NOT NULL,
  `suppliers_phone` varchar(20) NOT NULL,
  `suppliers_address` varchar(45) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  PRIMARY KEY (`suppliers_id`),
  KEY `idx_suppliers_id` (`suppliers_id`),
  KEY `contract_idx` (`contract`),
  CONSTRAINT `contract` FOREIGN KEY (`contract`) REFERENCES `contracts` (`contract_id`)
) 
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
) 
CREATE TABLE `write_offs` (
  `write_off_id` int NOT NULL AUTO_INCREMENT,
  `products_id` int NOT NULL,
  `quantity` int NOT NULL,
  `reason` varchar(255) DEFAULT NULL,
  `write_off_date` date DEFAULT NULL,
  `user_id` int NOT NULL,
  `write_on_date` date DEFAULT NULL,
  PRIMARY KEY (`write_off_id`),
  KEY `write_offs_ibfk_2` (`user_id`),
  KEY `fk_write_offs_products` (`products_id`),
  CONSTRAINT `fk_write_offs_products` FOREIGN KEY (`products_id`) REFERENCES `products` (`products_id`),
  CONSTRAINT `write_offs_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `users` (`users_id`)
) 
