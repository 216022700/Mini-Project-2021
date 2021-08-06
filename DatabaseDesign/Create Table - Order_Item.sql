CREATE TABLE `order_item` ( `itemID` VARCHAR(10) NOT NULL , 
`itemQuantity` INT NOT NULL , 
`orderID` VARCHAR(10) NOT NULL , 
`productID` VARCHAR(10) NOT NULL , 
PRIMARY KEY (`itemID`),
FOREIGN KEY (`orderID`) REFERENCES `order`(`orderID`),
FOREIGN KEY (`productID`) REFERENCES `product`(`productID`)) ENGINE = InnoDB; 