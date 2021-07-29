CREATE DATABASE IF NOT EXISTS `samson_school_suppliers_db`;

USE `samson_school_suppliers_db`;

CREATE TABLE `staff` ( `staffID` VARCHAR(10) NOT NULL , 
`staffName` VARCHAR(255) NOT NULL , 
`staffSurname` VARCHAR(255) NOT NULL , 
`staffDOB` DATE NOT NULL , 
`staffEmail` VARCHAR(255) NOT NULL , 
`staffPhone` VARCHAR(10) NOT NULL , 
`staffType` VARCHAR(255) NOT NULL , 
`staffAccessStatus` VARCHAR(255) NOT NULL ,
PRIMARY KEY (`staffID`)) ENGINE = InnoDB; 

CREATE TABLE `client` (`clientID` VARCHAR(10) NOT NULL,
 `clientName` VARCHAR(255) NOT NULL,
 `clientSurname` VARCHAR(255) NOT NULL, 
 `clientPhone` VARCHAR(10) NOT NULL, 
 `clientEmail` VARCHAR(255) NOT NULL, 
 `clientAddress` VARCHAR(255) NOT NULL, 
 PRIMARY KEY (`clientID`)) ENGINE = InnoDB;
 
 CREATE TABLE `order` ( `orderID` VARCHAR(10) NOT NULL , 
`orderDate` DATE NOT NULL , 
`orderStatus` VARCHAR(255) NOT NULL , 
`orderTotal` INT NOT NULL , 
`clientID` VARCHAR(10) NOT NULL,
PRIMARY KEY (`orderID`),
FOREIGN KEY (`clientID`) REFERENCES `client`(`clientID`)) ENGINE = InnoDB; 

CREATE TABLE `product` ( `productID` VARCHAR(10) NOT NULL , 
`productName` VARCHAR(255) NOT NULL , 
`productDescription` VARCHAR(255) NOT NULL , 
`productPrice` VARCHAR(255) NOT NULL , 
`prodcutQuantity` VARCHAR(255) NOT NULL , 
`productImage` VARCHAR(255) NOT NULL , 
PRIMARY KEY (`productID`)) ENGINE = InnoDB; 

CREATE TABLE `order_item` ( `itemID` VARCHAR(10) NOT NULL , 
`itemQuantity` INT NOT NULL , 
`orderID` VARCHAR(10) NOT NULL , 
`productID` VARCHAR(10) NOT NULL , 
PRIMARY KEY (`itemID`),
FOREIGN KEY (`orderID`) REFERENCES `order`(`orderID`),
FOREIGN KEY (`productID`) REFERENCES `product`(`productID`)) ENGINE = InnoDB; 