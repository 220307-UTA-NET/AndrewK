-- SQL "Families" of the language
-- DQL - Data Query Language    - how we phrase/form query
-- DDL - Data Definition Language   - how we define the database (create a table, define the columns of a table)
-- DML - Data Manipulation Language - how we manipulate the database (add an entry, how we change an entry or table)


-- DDL - CREATE, ALTER, DROP

-- Schemas are a logical 'namespace' in SQL. "dbo" is the default, the one that it assumes if you don't give one
-- Ex: 
CREATE SCHEMA School;
GO
-- SELECT * FROM dbo.Customer

-- VERB NOUN NAME
CREATE TABLE School.Course (    -- Create a table named Course as part of the School schema
    Course_Id NVARCHAR(31) NOT NULL PRIMARY KEY,    -- NOT NULL to enforce that the field must have a value
    Course_Name VARCHAR(255) NOT NULL,
    Teacher_Id INT NULL,                 -- NULL allows this field to be NULL when the entry is added to the table
    StartDate DATE NOT NULL DEFAULT GETDATE(),  -- DEFAULT gives us a value if none was specified
    EndDate DATE NOT NULL,
    CHECK (EndDate > StartDate) -- Ensures/enforces that the condition stated must be met before the entry is added to the table
);

-- DROP TABLE School.Course;

ALTER TABLE School.Course
    DROP CONSTRAINT PK__COURSE__37E005DB6D3CB4DD;
ALTER TABLE School.Course
    DROP COLUMN Course_Id;

-- Constraints
-- By default, any column can contain NULL. We can restrict that with "NOT NULL"
-- Writing "NULL" can make that default explicit

-- PRIMARY KEY
-- Automatically implies that a field must not be null, and that it must be unique

-- UNIQUE
-- Enforces that every entry must have a different value for this column
-- GOOD for candidate key
-- GOOD for representing a 1-1 relationship

-- CHECK
-- CHECK (Condition)
-- Whatever condition is inside the () must result in true for the entry to be considered valid
-- If the condition tests false an entry will be refused

-- DEFAULT
-- Sets a default value for the column when new data is added

CREATE TABLE School.Teacher (
    Teacher_Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) NOT NULL
    CHECK (LEN(Name) > 0)
);

-- DROP TABLE School.Teacher;

-- IDENTITY
-- Creates a unique value that changes with every new entry in a table
-- You can specify a seed and an increment

ALTER TABLE School.Course
    ADD CONSTRAINT FK__COURSE__Teacher_Id FOREIGN KEY (Teacher_Id)
        REFERENCES School.Teacher (Teacher_Id);


-- DML - INSERT, UPDATE, DELETE, TRUNCATE

-- VERB NOUN
INSERT INTO School.Teacher (Name)
VALUES
    ('Trygg'),
    ('Brian'),
    ('Francis'),
    ('Christian');
-- INSERT adds data to a table

SELECT * FROM School.Teacher;


DELETE FROM School.Teacher;
-- DELETE removes entries from a table

UPDATE School.Teacher
SET Name = 'Andrew'
WHERE Teacher_Id = 3;
-- UPDATE updates the values of an entry that are already part of a table


CREATE TABLE School.Student (
    Student_Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) NOT NULL
    CHECK(LEN(Name) > 0)
);

-- DROP TABLE School.Student;

CREATE TABLE School.CourseStudent(
    Course_ID NVARCHAR (31) NOT NULL
        FOREIGN KEY REFERENCES School.Course (Course_ID) ON DELETE CASCADE ON UPDATE CASCADE,
    Student_ID INT NOT NULL
        FOREIGN KEY REFERENCES School.Student (Student_ID) ON DELETE CASCADE ON UPDATE CASCADE
    PRIMARY KEY (Course_ID, Student_ID)
);

-- DROP TABLE School.CourseStudent;

INSERT INTO School.Student (Name)
VALUES
    ('Cam'),
    ('Kevin'),
    ('Kelly');

INSERT INTO School.Course (Course_Id, Course_Name, Teacher_Id, EndDate)
VALUES
    ('CS-101', 'Intro to C#', 3, '2022-06-06');

INSERT INTO School.CourseStudent (Course_Id, Student_Id) 
VALUES 
    ('CS-101', (SELECT Student_Id FROM School.Student WHERE Name = 'Kelly')),
    ('CS-101', (SELECT Student_Id FROM School.Student WHERE Name = 'Kevin'));

SELECT * FROM School.CourseStudent;
SELECT * FROM School.Student;
SELECT * FROM School.Course;

DELETE FROM School.Course;
DELETE FROM School.Student WHERE Name = 'Kevin';


-- CASCADE
-- A cascade is a sequence of actions that are triggered by one event, and carry out
-- a series of predetermined commands.