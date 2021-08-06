CREATE TABLE `order` ( `orderID` VARCHAR(10) NOT NULL , 
`orderDate` VARCHAR(255) NOT NULL , 
`orderStatus` VARCHAR(255) NOT NULL , 
`orderTotal` INT NOT NULL , 
`clientID` VARCHAR(10) NOT NULL,
PRIMARY KEY (`orderID`),
FOREIGN KEY (`clientID`) REFERENCES `client`(`clientID`)) ENGINE = InnoDB; 