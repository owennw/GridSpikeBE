CREATE DATABASE shopping_app;

CREATE TABLE `shopping_app`.`product` (
    `id` INT NOT NULL,
    `name` VARCHAR(45) NOT NULL,
    PRIMARY KEY (`id`)
);
  
CREATE TABLE `shopping_app`.`customer` (
    `id` INT NOT NULL,
    `first_name` VARCHAR(45) NOT NULL,
    `last_name` VARCHAR(45) NOT NULL,
    `email_address` VARCHAR(45) NOT NULL,
    PRIMARY KEY (`id`)
);
  
CREATE TABLE `shopping_app`.`purchase` (
    `id` INT NOT NULL,
    `customer_id` INT NOT NULL,
    `date` DATETIME NOT NULL,
    PRIMARY KEY (`id`),
    INDEX `customer_id_idx` (`customer_id` ASC),
    CONSTRAINT `fk_customer` FOREIGN KEY (`customer_id`)
        REFERENCES `shopping_app`.`customer` (`id`)
        ON DELETE NO ACTION ON UPDATE NO ACTION
);
    
CREATE TABLE `shopping_app`.`purchase_item` (
    `purchase_id` INT NOT NULL,
    `product_id` INT NOT NULL,
    `quantity` INT NOT NULL,
    `price` DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (`purchase_id, product_id`),
    INDEX `fk_product_idx` (`product_id` ASC),
    CONSTRAINT `fk_purchase` FOREIGN KEY (`purchase_id`)
        REFERENCES `shopping_app`.`purchase` (`id`)
        ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_product` FOREIGN KEY (`product_id`)
        REFERENCES `shopping_app`.`product` (`id`)
        ON DELETE NO ACTION ON UPDATE NO ACTION
);