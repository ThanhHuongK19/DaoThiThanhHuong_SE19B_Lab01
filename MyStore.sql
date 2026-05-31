-- Create the Database (Optional, uncomment if needed)
-- DROP DATABASE IF EXISTS MyStore;
CREATE DATABASE MyStore;
GO
USE MyStore;
GO

delete from AccountMember;

-- 1. Create AccountMember Table
CREATE TABLE AccountMember (
    MemberID nvarchar(20) NOT NULL,
    MemberPassword nvarchar(80) NOT NULL,
    FullName nvarchar(80) NOT NULL,
    EmailAddress nvarchar(100) NOT NULL,
    MemberRole int NOT NULL,
    CONSTRAINT PK_AccountMember PRIMARY KEY (MemberID)
);
GO

-- 2. Create Categories Table
CREATE TABLE Categories (
    CategoryID int NOT NULL,
    CategoryName nvarchar(15) NOT NULL,
    CONSTRAINT PK_Categories PRIMARY KEY (CategoryID)
);
GO

-- 3. Create Products Table
CREATE TABLE Products (
    ProductID int NOT NULL,
    ProductName nvarchar(40) NOT NULL,
    CategoryID int NOT NULL,
    UnitsInStock smallint NULL,      -- 'Allow Nulls' is checked in the image
    UnitPrice money NULL,            -- 'Allow Nulls' is checked in the image
    CONSTRAINT PK_Products PRIMARY KEY (ProductID),
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryID) 
        REFERENCES Categories (CategoryID)
);
GO

-- ===================================================
-- 1. CHÈN DỮ LIỆU MẪU CHO BẢNG AccountMember
-- ===================================================
INSERT INTO AccountMember (MemberID, MemberPassword, FullName, EmailAddress, MemberRole)
VALUES 
('admin01', '123', N'Nguyễn Văn Admin', 'admin@mystore.com', 1),
('member01', '456', N'Trần Thị Khách', 'khachhang1@gmail.com', 2),
('member02', '789', N'Lê Hoàng Nam', 'namlh@gmail.com', 2);
GO

-- ===================================================
-- 2. CHÈN DỮ LIỆU MẪU CHO BẢNG Categories
-- ===================================================
INSERT INTO Categories (CategoryID, CategoryName)
VALUES 
(1, N'Điện thoại'),
(2, N'Laptop'),
(3, N'Phụ kiện');
GO

-- ===================================================
-- 3. CHÈN DỮ LIỆU MẪU CHO BẢNG Products
-- ===================================================
INSERT INTO Products (ProductID, ProductName, CategoryID, UnitsInStock, UnitPrice)
VALUES 
(101, N'iPhone 15 Pro Max', 1, 50, 34990000),  -- Thuộc danh mục Điện thoại (CategoryID = 1)
(102, N'MacBook Air M3', 2, 25, 27990000),      -- Thuộc danh mục Laptop (CategoryID = 2)
(103, N'Sạc dự phòng 20000mAh', 3, 120, 450000), -- Thuộc danh mục Phụ kiện (CategoryID = 3)
(104, N'Sản phẩm thử nghiệm', 1, NULL, NULL);   -- UnitsInStock và UnitPrice có thể để NULL như thiết kế
GO

select * from AccountMember;
select * from Categories;
select * from Products;
