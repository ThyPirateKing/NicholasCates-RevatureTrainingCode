-- DDL and DML Demo --

--CREATE database DemoDB;

/*
Demo -- table Employees
Test -- table Employees
*/

--use DemoDB;

-- SCHEMA is similar to a namespace

--CREATE SCHEMA test;

/*
CREATE table DemoTable(
    demo_id INT IDENTITY(1,1) PRIMARY KEY,
    demo_name VARCHAR(255) NOT NULL,
    demo_date TIMESTAMP
)

CREATE table test.DemoTable(
    demo_id INT IDENTITY(1,1) PRIMARY_KEY,
    demo_name VARCHAR(255) NOT NULL,
    demo_date TIMESTAMP
)
*/

-- Add a new column
ALTER table DemoTable
ADD demo_description VARCHAR (255) NOT NULL;

--Alter column name
--EXEC sp_rename 'dbo.DemoTable.demo_description', 'new_column_name';

-- Data Manipulation Languages
    -- Insert Values
    INSERT INTO DemoTable (demo_name, new_column_name) VALUES ('my Value', 'testing');

    INSERT INTO DemoTable (demo_name, new_column_name) VALUES ('Second Value', 'SQL is the best');

    SELECT * from DemoTable;

    -- Update
    UPDATE DemoTable
    SET new_column_name = 'My new value!!!'
    WHERE demo_id = 1;
    
    -- Delete
    DELETE FROM DemoTable
    WHERE demo_id = 2;

    -- Truncate
    TRUNCATE TABLE DemoTable;

    -- DELETE / DROP TABLE
    DROP TABLE DemoTable;


