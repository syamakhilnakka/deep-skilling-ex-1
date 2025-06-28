
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Departments;


CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);


CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);


INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');


INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');


DELIMITER $$

CREATE PROCEDURE sp_GetEmployeesByDepartment(IN deptID INT)
BEGIN
    SELECT * FROM Employees
    WHERE DepartmentID = deptID;
END$$


CREATE PROCEDURE sp_InsertEmployee (
    IN FirstName VARCHAR(50),
    IN LastName VARCHAR(50),
    IN DepartmentID INT,
    IN Salary DECIMAL(10,2),
    IN JoinDate DATE
)
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (FirstName, LastName, DepartmentID, Salary, JoinDate);
END$$

DELIMITER ;


CALL sp_InsertEmployee('Akhil', 'Syam', 2, 6200.00, '2025-06-28');


CALL sp_GetEmployeesByDepartment(4);

-- Show all employees after insertion
SELECT * FROM Employees;
