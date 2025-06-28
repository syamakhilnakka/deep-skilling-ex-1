
DROP TABLE IF EXISTS Products;


CREATE TABLE Products (
    ProductID INT PRIMARY KEY AUTO_INCREMENT,
    ProductName VARCHAR(100),
    Category VARCHAR(100),
    Price DECIMAL(10, 2)
);

INSERT INTO Products (ProductName, Category, Price) VALUES
('Laptop A', 'Electronics', 80000),
('Laptop B', 'Electronics', 75000),
('Phone X',  'Electronics', 75000),
('Phone Y',  'Electronics', 72000),
('Shirt A',  'Clothing',    2000),
('Shirt B',  'Clothing',    2000),
('Jeans',    'Clothing',    1800),
('Camera',   'Electronics', 70000),
('T-Shirt',  'Clothing',    1700),
('Tablet',   'Electronics', 68000);


SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,


        ROW_NUMBER() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RowNum,

        RANK() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RankNum,


        DENSE_RANK() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS DenseRankNum

    FROM Products
) RankedProducts


WHERE RowNum <= 3;
