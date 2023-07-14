--CREATE DATABASE StoreManager

USE StoreManager

-- Supplier Table
CREATE TABLE Suppliers (
  SupplierID INT PRIMARY KEY,
  [Name] NVARCHAR(255),
  [Address] NVARCHAR(MAX),
  Phone NVARCHAR(20),
  Email NVARCHAR(255)
);

--Category Table
CREATE TABLE Categories (
  CategoryID INT PRIMARY KEY,
  [Name] NVARCHAR(255),
  Description NVARCHAR(MAX)
);

CREATE TABLE Products (
  ProductID INT PRIMARY KEY,
  SupplierID INT,
  [Name] NVARCHAR(255),
  [Description] NVARCHAR(MAX),
  Price DECIMAL(18, 2),
  Quantity INT,
  CategoryID INT
  FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
  FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- Order Table
CREATE TABLE Orders (
  OrderID INT PRIMARY KEY,
  CustomerName NVARCHAR(255),
  CustomerPhone NVARCHAR(20),
  OrderDate DATE,
  TotalAmount DECIMAL(18, 2)
);

-- Order Detail Table
CREATE TABLE OrderDetails (
  OrderDetailID INT PRIMARY KEY,
  OrderID INT,
  ProductID INT,
  Quantity INT,
  TotalPrice DECIMAL(18, 2),
  FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
  FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

--Role Table
CREATE TABLE Roles (
  RoleID INT PRIMARY KEY,
  [Name] NVARCHAR(50)
);

--Staff Table
CREATE TABLE Staff (
  StaffID INT PRIMARY KEY,
  FirstName NVARCHAR(50),
  LastName NVARCHAR(50),
  Gender NVARCHAR(10),
  [Address] NVARCHAR(MAX),
  Phone NVARCHAR(20),
  Email NVARCHAR(255),
  RoleID INT,
  FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- Employees Table
CREATE TABLE Employees (
  EmployeeID INT PRIMARY KEY,
  FirstName NVARCHAR(50),
  LastName NVARCHAR(50),
  Gender NVARCHAR(10),
  [Address] NVARCHAR(MAX),
  Phone NVARCHAR(20),
  Email NVARCHAR(255),
  RoleID INT,
  FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- Invoices Table
CREATE TABLE Invoices (
  InvoiceID INT PRIMARY KEY,
  OrderID INT,
  EmployeeID INT,
  InvoiceDate DATE,
  TotalAmount DECIMAL(18, 2),
  FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
  FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);