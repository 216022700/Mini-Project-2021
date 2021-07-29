CREATE TABLE `staff` ( `staffID` VARCHAR(10) PRIMARY KEY NOT NULL , 
`staffName` VARCHAR(255) NOT NULL , 
`staffSurname` VARCHAR(255) NOT NULL , 
`staffDOB` DATE(255) NOT NULL , 
`staffEmail` VARCHAR(255) NOT NULL , 
`staffPhone` VARCHAR(10) NOT NULL , 
`staffType` VARCHAR(255) NOT NULL , 
`staffAccessStatus` VARCHAR(255) NOT NULL ) ENGINE = InnoDB; 