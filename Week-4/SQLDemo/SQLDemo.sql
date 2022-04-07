-- This is SQL
-- for comments

-- When nothing is highlighter, and we run/execute everything in the current query is run
-- you can select only a specific command, and only run that one

SELECT *
FROM Customer;
-- When you make a query to a DB, any result will take the form of a table

SELECT 'Hello World';

SELECT 2 + 2;

SELECT SYSUTCDATETIME();

-- USUALLY nothing in SQL is case sensitive
select 2 + 2;

-- Seimcolons are not a required end-line character. They are an end of operation/and of thought, and are not generally required.
SELECT 2 + 2

-- SELECT (Columns) FROM (Table)
SELECT FirstName, LastName, Address 
FROM Customer;

SELECT FirstName + ' ' + LastName, Address
FROM Customer;

-- Column Alias
-- Great for concatenating multiple columns together
SELECT FirstName + ' ' + LastName AS FullName, Address
FROM Customer;

-- Filtering with WHERE
SELECT *    -- Get this column
FROM Customer   -- From this table
WHERE LEN(FirstName) > 5;   -- For entires that meet this condition

SELECT *
FROM Customer
WHERE Country = 'Brazil';

SELECT *
FROM Customer
WHERE Country = 'Brazil' AND City = 'São Paulo';

SELECT *
FROM Customer
WHERE CustomerId = 10;

-- Aggregate functions
SELECT COUNT(*)
FROM Customer;

SELECT SUM(Total)
FROM Invoice;

-- Other aggregate functions include MIN, MAX, AVG, etc.

SELECT CustomerId, SUM(Total)
FROM Invoice
GROUP BY CustomerId;    -- GROUP BY gives us a way to group the results of an aggregate function by entries

SELECT CustomerId, SUM(Total) AS Sum_Total
FROM Invoice
GROUP BY CustomerId
HAVING SUM(TOTAL) > 40
ORDER BY SUM(Total) DESC, CustomerId;

-- JOIN
-- Accessing more than one table to return the desired data

-- INNER JOIN
-- LEFT (OUTER) JOIN
-- RIGHT (OUTER) JOIN
-- FULL (OUTER) JOIN
-- CROSS JOIN

SELECT Album.Title AS [Album Title], Artist.Name AS [Artist Name]
FROM Album
INNER JOIN Artist ON Album.ArtistId = Artist.ArtistId;

SELECT al.Title, ar.Name
FROM Album AS al
INNER JOIN Artist AS ar ON al.ArtistId = ar.ArtistId;

-- All rock songs, showing the name in the format: "Artist Name = Song Name"
SELECT ar.Name + ' - ' + t.Name AS [Artist - Song]
FROM Track AS t
INNER JOIN Genre AS g ON g.GenreId = t.GenreId
JOIN ALBUM AS al ON t.AlbumId = al.AlbumId
JOIN Artist AS ar ON al.ArtistId = ar.ArtistId
WHERE g.Name = 'Rock';

-- Set operations
-- Set operations let us run multiple queries as a single query

-- All first names of employees and customers
SELECT FirstName 
FROM Employee
UNION ALL
SELECT FirstName
FROM Customer;
-- UNION returns all entries that are found on either query, wihout duplicates.
-- UNION ALL, with duplicates (a little faster, but could have more data).

-- Names that are both a customer and an employee
SELECT FirstName 
FROM Employee
INTERSECT
SELECT FirstName
FROM Customer;
-- INTERSECT returns all entries that are in both queries (without duplicates).

-- Names that are employees but not customers
SELECT FirstName 
FROM Employee
EXCEPT
SELECT FirstName
FROM Customer;
-- EXCEPT returns entries that match the first query, and are not matched in the second query.
-- ORDER MATTERS for EXCEPT!

-- To use a set operator, the queries must return the same type and number of columns.

-- Sub-Query
-- It is sometimes easier to express a complex idea as two queries that work sequentially

-- The artist who maed the album with the longest title
SELECT *
FROM Artist ar
WHERE ArtistId = (
    SELECT ArtistId
    FROM Album
    WHERE LEN(Title) >= ALL (
        SELECT LEN(Title)
        FROM Album)
);

-- Returns all tracks that were never purchased
SELECT * 
FROM Track 
WHERE TrackId NOT IN (SELECT TrackId FROM InvoiceLine);
-- Queries operate from the most-nested to the least-nested query
-- Operators for Subqueries:
-- IN, NOT IN, EXISTS, ANY, ALL
