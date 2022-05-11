CREATE SCHEMA Store;
GO

DROP SCHEMA IF EXISTS Store;

CREATE TABLE Store.Inventory (
    ItemId INT NOT NULL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL
        CHECK(LEN(Name) > 0),
    Quantity INT NOT NULL,
    Price NUMERIC(10,2) NOT NULL
);

DROP TABLE Store.Inventory;

CREATE TABLE Store.Customer (
    CustomerId INT NOT NULL PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(40) NOT NULL,
    LastName NVARCHAR(40) NOT NULL,
    Address NVARCHAR(70),
    City NVARCHAR(40),
    State NVARCHAR(40),
    Country NVARCHAR(40),
    PostalCode NVARCHAR(40),
    Phone NVARCHAR(24)
);

DROP TABLE Store.Customer;

CREATE TABLE Store.Location (
    StoreId INT NOT NULL PRIMARY KEY,
    Address NVARCHAR(70) NOT NULL,
    City NVARCHAR(40) NOT NULL,
    State NVARCHAR(40) NOT NULL,
    Country NVARCHAR(40) NOT NULL,
    PostalCode NVARCHAR(40) NOT NULL,
    Phone NVARCHAR(24),
);

DROP TABLE Store.Location;

CREATE TABLE Store.Invoice (
    InvoiceId INT NOT NULL PRIMARY KEY IDENTITY,
    CustomerId INT NOT NULL 
        FOREIGN KEY REFERENCES Store.Customer (CustomerId) ON DELETE CASCADE ON UPDATE CASCADE,
    StoreId INT NOT NULL 
        FOREIGN KEY REFERENCES Store.Location (StoreId) ON DELETE CASCADE ON UPDATE CASCADE,
    InvoiceDate DATETIME NOT NULL,
    Total NUMERIC(10,2) NOT NULL
);

DROP TABLE Store.Invoice;

ALTER TABLE Store.Invoice
DROP CONSTRAINT FK__Invoice__Custome__7755B73D;

ALTER TABLE Store.Invoice
ADD CONSTRAINT FK__Invoice__Custome__7755B73D
    FOREIGN KEY (CustomerId) REFERENCES Store.Customer (CustomerId) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE Store.Invoice
DROP CONSTRAINT FK__Invoice__StoreId__7849DB76;

ALTER TABLE Store.Invoice
ADD CONSTRAINT FK__Invoice__StoreId__7849DB76
    FOREIGN KEY (StoreId) REFERENCES Store.Location (StoreId) ON DELETE CASCADE ON UPDATE CASCADE;

-- CREATE TABLE Store.InvoiceLine (
--     InvoiceLineId INT NOT NULL PRIMARY KEY,
--     InvoiceId INT NOT NULL 
--         FOREIGN KEY REFERENCES Store.Customer (CustomerId),
--     ItemId INT NOT NULL 
--         FOREIGN KEY REFERENCES Store.Inventory (ItemId),
--     UnitPrice NUMERIC(10,2) NOT NULL,
--     Quantity INT NOT NULL
-- );

-- DROP TABLE Store.InvoiceLine;

INSERT INTO Store.Inventory (ItemId, Name, Quantity, Price)
VALUES
    (1, 'Item1', 99, 1.00),
    (2, 'Item2', 999, 2.00),
    (3, 'Item3', 100, 300.00),
    (4, 'Item4', 100, 100.00),
    (5, 'Item5', 500, 25.00),
    (6, 'Item6', 100, 55.55),
    (7, 'Item7', 100, 11.00),
    (8, 'Item8', 100, 130.00),
    (9, 'Item9', 100, 254.00),
    (10, 'Item10', 100, 12.25);

INSERT INTO Store.Customer (FirstName, LastName)
VALUES
    ('CustomerFirst1', 'CustomerLast1'),
    ('CustomerFirst2', 'CustomerLast2'),
    ('CustomerFirst3', 'CustomerLast3'),
    ('CustomerFirst4', 'CustomerLast4'),
    ('CustomerFirst5', 'CustomerLast5'),
    ('CustomerFirst6', 'CustomerLast6'),
    ('CustomerFirst7', 'CustomerLast7');

UPDATE Store.Customer
SET Address = '111 Home1', City = 'HomeCity1', State = 'HomeSate1', Country = 'HomeCountry1', PostalCode = '12345', Phone = '0987654321'
WHERE CustomerId = 1;

UPDATE Store.Customer
SET Address = '222 Home2', City = 'HomeCity2', State = 'HomeSate2', Country = 'HomeCountry2', PostalCode = '23456', Phone = '9876543210'
WHERE CustomerId = 2;

INSERT INTO Store.Location (StoreId, Address, City, State, Country, PostalCode, Phone)
VALUES
    (1, '1234 Address1', 'City1', 'State1', 'Country1', '11111', '1234567890'),
    (2, '2345 Address2', 'City2', 'State2', 'Country2', '22222', '2345678901'),
    (3, '3456 Address3', 'City3', 'State3', 'Country3', '33333', '3456789012');

DELETE FROM Store.Customer WHERE FirstName = 'andrew';

INSERT INTO Store.Invoice (CustomerId, StoreId, InvoiceDate, Total)
VALUES
    (1, 1, GETDATE(), 1.00);

INSERT INTO Store.Invoice (CustomerId, StoreId, InvoiceDate, Total)
VALUES
    (2, 3, GETDATE(), 100.00),
    (2, 3, GETDATE(), 2.00);    

INSERT INTO Store.Invoice (CustomerId, StoreId, InvoiceDate, Total)
VALUES
    (6, 1, GETDATE(), 101.00),
    (7, 3, GETDATE(), 22.00);    

UPDATE Store.Inventory
SET Price = 300.99
WHERE ItemId = 3;    

UPDATE Store.Inventory
SET Quantity = Quantity - 1
WHERE ItemId = 1;

SELECT TOP 1 *
FROM Store.Invoice
ORDER BY InvoiceId DESC;

-- Selecting non-existent customer
SELECT * FROM Store.Customer
WHERE FirstName = 'hello';

SELECT *
FROM Store.Invoice
WHERE CustomerId = 13;

SELECT *
FROM Store.Customer;

DELETE FROM Store.Customer
WHERE FirstName = '';

INSERT INTO Store.Customer (FirstName, LastName)
VALUES ('bb', 'cc');

DELETE FROM Store.Customer
WHERE FirstName = 'bb' AND LastName = 'cc';

SELECT * FROM Store.Customer;
SELECT * FROM Store.Inventory;
SELECT * FROM Store.Invoice;