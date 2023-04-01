﻿DROP TABLE IF EXISTS Authors;

CREATE TABLE Authors (
	Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	FirstName NVARCHAR (50) NULL,
	LastName NVARCHAR (50) NULL,
	Bio NVARCHAR (250) NULL,
)

DROP TABLE IF EXISTS Books;
CREATE TABLE Books (
	Id INT PRIMARY KEY IDENTITY (1,1),
	Title NVARCHAR (50) NULL,
	Year INT NULL,
	ISBN NVARCHAR (50) NOT NULL UNIQUE,
	Summary NVARCHAR (250) NULL,
	Image NVARCHAR (50) NULL,
	Price DECIMAL (18,2) NULL,
	AuthorId INT Null
	CONSTRAINT FK_Book_AuthorId FOREIGN KEY (AuthorId) REFERENCES Authors(Id)
);