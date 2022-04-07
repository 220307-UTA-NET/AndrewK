-- On the Chinook DB, practice writing queries with the following exercises

-- List all customers (full name, customer id, and country) who are not in the USA
SELECT FirstName + ' ' + LastName AS FullName, CustomerId, Country
FROM Customer
WHERE NOT Country = 'USA';

-- List all customers from Brazil
SELECT *
FROM Customer
WHERE Country = 'Brazil';

-- List all sales agents
SELECT *
FROM Employee
WHERE Title = 'Sales Support Agent';

-- Retrieve a list of all countries in billing addresses on invoices
SELECT DISTINCT BillingCountry
FROM Invoice;

-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
    -- (challenge: find the invoice count sales total for every year using one query)
SELECT YEAR(InvoiceDate) AS Year, COUNT(*) AS Total_Count, SUM(Total) AS Sum_Total
FROM Invoice
GROUP BY YEAR(InvoiceDate);

-- how many line items were there for invoice #37
SELECT *
FROM Invoice
WHERE InvoiceId = 37;

-- how many invoices per country?
SELECT BillingCountry, COUNT(*) AS Invoice_Count
FROM Invoice
GROUP BY BillingCountry;

-- Retrieve the total sales per country, ordered by the highest total sales first.
SELECT BillingCountry, SUM(Total) AS Sum_Total
FROM Invoice
GROUP BY BillingCountry
ORDER BY 2 DESC;

-- JOINS CHALLENGES
-- Show all invoices of customers from brazil (mailing address not billing)
SELECT *
FROM Invoice AS i
JOIN Customer AS c ON c.CustomerId = i.CustomerId
WHERE Country = 'Brazil';

-- Show all invoices together with the name of the sales agent for each one
SELECT i.*, e.FirstName + ' ' +  e.LastName AS [Agent]
FROM Invoice AS i
JOIN Customer AS c ON i.CustomerId = c.CustomerId
JOIN Employee AS e ON c.SupportRepId = e.EmployeeId;

-- Show all playlists ordered by the total number of tracks they have
SELECT p.Name AS Playlist, COUNT(*) AS Track_Count
FROM Playlist AS p
JOIN PlaylistTrack AS pt ON p.PlaylistId = pt.PlaylistId
JOIN Track AS t ON pt.TrackId = t.TrackId
GROUP BY p.Name
ORDER BY 2;

-- Which sales agent made the most sales in 2009?
SELECT e.FirstName, e.LastName, SUM(i.Total) AS Sum_Total
FROM Employee e
JOIN Customer c ON e.EmployeeId = c.SupportRepId
JOIN Invoice i ON c.CustomerId = i.CustomerId
GROUP BY e.LastName, e.FirstName
ORDER BY Sum_Total DESC;

-- How many customers are assigned to each sales agent?
SELECT e.FirstName, e.LastName, COUNT(c.SupportRepId) AS Customer_Count
FROM Employee e
JOIN Customer c ON e.EmployeeId = c.SupportRepId
JOIN Invoice i ON c.CustomerId = i.CustomerId
GROUP BY e.LastName, e.FirstName;

-- Which track was purchased the most in 2010?
SELECT t.Name, SUM(i.Total) AS Sum_Total
FROM Track AS t
JOIN InvoiceLine AS il ON t.TrackId = il.TrackId
JOIN Invoice AS i ON il.InvoiceId = i.InvoiceId
WHERE YEAR(i.InvoiceDate) = 2010
GROUP BY t.Name
ORDER BY Sum_Total DESC;

-- Show the top three best selling artists.
SELECT TOP(3) ar.Name, SUM(i.Total) AS Sum_Total
FROM Artist AS ar
JOIN Album AS al ON ar.ArtistId = al.ArtistId
JOIN Track AS t ON al.AlbumId = t.AlbumId
JOIN InvoiceLine AS il ON t.TrackId = il.TrackId
JOIN Invoice AS i ON il.InvoiceId = i.InvoiceId
GROUP BY ar.Name
ORDER BY Sum_Total DESC;

-- Which customers have the same initials as at least one other customer?
-- ???


-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?
SELECT Artist.Name
FROM Artist 
WHERE ArtistId NOT IN (SELECT ArtistId FROM Album)

-- 2. which artists did not record any tracks of the Latin genre?
SELECT COUNT(DISTINCT Artist.Name)
FROM Track
JOIN Album on Track.AlbumId = Album.AlbumId
JOIN Artist on Album.ArtistId = Artist.ArtistId
JOIN Genre on Track.GenreId = Genre.GenreId
WHERE Genre.Name != 'Latin';

-- 3. which video track has the longest length? (use media type table)
SELECT * FROM MediaType
JOIN Track ON Track.MediaTypeId = MediaType.MediaTypeId
WHERE Track.Milliseconds = (SELECT MAX(Track.Milliseconds) FROM Track);

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)
SELECT * FROM Customer
WHERE Customer.City = (SELECT Employee.City FROM Employee 
    WHERE Employee.ReportsTo IS NULL);

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?

/*
SELECT SUM(Total) FROM Invoice
WHERE CustomerId IN (SELECT CustomerId FROM Customer
    WHERE Country = 'Germany'
);
*/

SELECT * FROM Track
SELECT * FROM Customer

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.
SELECT FirstName, LastName, Country FROM Customer
WHERE SupportRepId IN (SELECT EmployeeId FROM Employee
    WHERE (YEAR(HireDate) - YEAR(BirthDate)) < 35
);

-- DML exercises

-- 1. insert two new records into the employee table.

-- 2. insert two new records into the tracks table.

-- 3. update customer Aaron Mitchell's name to Robert Walter

-- 4. delete one of the employees you inserted.

-- 5. delete customer Robert Walter.