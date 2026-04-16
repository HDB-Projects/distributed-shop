-- Create Database
CREATE DATABASE OrderDb;
GO

USE OrderDb;
GO

-- CustomerOrder Table
CREATE TABLE CustomerOrder (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    CreatedAt DATETIME2 NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL
);

-- OrderItem Table
CREATE TABLE OrderItem (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    CustomerOrderId UNIQUEIDENTIFIER NOT NULL,
    ProductId UNIQUEIDENTIFIER NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,

    CONSTRAINT FK_OrderItem_CustomerOrder
        FOREIGN KEY (CustomerOrderId)
        REFERENCES CustomerOrder(Id)
        ON DELETE NO ACTION
);