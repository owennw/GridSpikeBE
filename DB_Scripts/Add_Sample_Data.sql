INSERT INTO `shopping_app`.`customer` (`id`, `name`, `email_address`) VALUES ('1', 'Nick', 'Owen', 'nowen@scottlogic.com');
INSERT INTO `shopping_app`.`customer` (`id`, `name`, `email_address`) VALUES ('2', 'Paul', 'Williams', 'pwilliams@scottlogic.com');
INSERT INTO `shopping_app`.`customer` (`id`, `name`, `email_address`) VALUES ('3', 'Sam', 'Perridge', 'sperridge@scottlogic.com');

INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('1', 'Banana');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('2', 'Apple');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('3', 'Bacon');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('4', 'Coca Cola');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('5', 'Salmon');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('6', 'Tofu');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('7', 'Coriander');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('8', 'Olive Oil');
INSERT INTO `shopping_app`.`product` (`id`, `name`) VALUES ('9', 'Bread');

INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('1', '1', '2017-05-05 09:15:26');
INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('2', '1', '2017-05-03 20:07:00');
INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('3', '3', '2017-05-08 07:25:46');
INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('4', '1', '2017-03-21 17:15:24');
INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('5', '2', '2016-12-11 15:15:38');
INSERT INTO `shopping_app`.`purchase` (`id`, `customer_id`, `date`) VALUES ('6', '3', '2017-04-1 09:31:02');

INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('1', '1', '5', '0.9');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('1', '4', '12', '8.00');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('1', '6', '1', '2.49');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('1', '7', '1', '0.89');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('1', '8', '1', '4.49');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('2', '3', '12', '3.49');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('2', '9', '1', '1.00');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('3', '5', '1', '6.24');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('3', '2', '4', '0.74');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('4', '9', '1', '0.49');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('5', '7', '1', '0.78');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('5', '1', '4', '0.50');
INSERT INTO `shopping_app`.`purchase_item` (`purchase_id`, `product_id`, `quantity`, `price`) VALUES ('6', '3', '6', '3.04');

