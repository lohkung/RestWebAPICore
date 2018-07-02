CREATE DATABASE payment
GO

USE [payment]
GO

CREATE TABLE creditcard (
    id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    cardnumber varchar(16) NOT NULL
)
GO

INSERT INTO [dbo].[creditcard] 
SELECT '333333333333333' UNION
SELECT '3999999999999999' UNION
SELECT '4999999999999999' UNION
SELECT '5999999999999999' 
GO

CREATE PROCEDURE GetOfCreditCards   
    @CardNumber varchar(16)
AS   

    SELECT id, cardnumber 
    FROM creditcard
    WHERE cardnumber = @CardNumber 
 
GO  