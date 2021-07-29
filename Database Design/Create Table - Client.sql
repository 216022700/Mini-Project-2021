CREATE TABLE `client` (`clientID` VARCHAR(10) NOT NULL,
 `clientName` VARCHAR(255) NOT NULL,
 `clientSurname` VARCHAR(255) NOT NULL, 
 `clientPhone` VARCHAR(10) NOT NULL, 
 `clientEmail` VARCHAR(255) NOT NULL, 
 `clientAddress` VARCHAR(255) NOT NULL, 
 PRIMARY KEY (`clientID`)) ENGINE = InnoDB;