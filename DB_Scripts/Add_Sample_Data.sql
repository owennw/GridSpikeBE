INSERT INTO `shopping_app`.`customer` (`id`, `first_name`, `last_name`, `email_address`, `city`, `favourite_food_id`) VALUES ('1', 'Nick', 'Owen', 'nowen@scottlogic.com', null, null);
INSERT INTO `shopping_app`.`customer` (`id`, `first_name`, `last_name`, `email_address`, `city`, `favourite_food_id`) VALUES ('2', 'Paul', 'Williams', 'pwilliams@scottlogic.com', null, null);
INSERT INTO `shopping_app`.`customer` (`id`, `first_name`, `last_name`, `email_address`, `city`, `favourite_food_id`) VALUES ('3', 'Sam', 'Perridge', 'sperridge@scottlogic.com', null, null);

INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('1', 'Banana', '0.27');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('2', 'Apple', '0.14');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('3', 'Bacon', '3.49');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('4', 'Coca Cola', '0.80');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('5', 'Salmon', '5.49');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('6', 'Tofu', '4.49');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('7', 'Coriander', '0.79');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('8', 'Olive Oil', '5.99');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('9', 'Bread', '1.29');

INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('1', '1', '2017-05-05 09:15:26');
INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('2', '1', '2017-05-03 20:07:00');
INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('3', '3', '2017-05-08 07:25:46');
INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('4', '1', '2017-03-21 17:15:24');
INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('5', '2', '2016-12-11 15:15:38');
INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('6', '3', '2017-04-1 09:31:02');

INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('1', '1', '1', '5');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('2', '1', '4', '12');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('3', '1', '6', '1');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('4', '1', '7', '1');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('5', '1', '8', '1');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('6', '2', '3', '12');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('7', '2', '9', '1');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('8', '3', '5', '1');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('9', '3', '2', '4');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('10', '4', '9', '1');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('11', '5', '7', '1');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('12', '5', '1', '4');
INSERT INTO `shopping_app`.`purchase_item` (`id`, `purchase_id`, `product_id`, `quantity`) VALUES ('13', '6', '3', '6');

