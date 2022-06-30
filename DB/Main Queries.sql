--Department Queries

CREATE TABLE dbo.Department(
DepartmentId INT IDENTITY(1,1),
DepartmentName NVARCHAR(500));

INSERT INTO dbo.Department VALUES ('IT');
INSERT INTO dbo.Department VALUES ('HR');
INSERT INTO dbo.Department VALUES ('SYS');

SELECT * FROM dbo.Department;

--Employee Quries

CREATE TABLE dbo.Employee(
EmployeeId INT IDENTITY(1,1),
FirstName NVARCHAR(500),
LastName NVARCHAR(500),
Email NVARCHAR(100),
DateOfBirth DATETIME,
Salary DECIMAL,
Department NVARCHAR(500));

INSERT INTO dbo.Employee VALUES ('Nisais','Nimalasingam','n.nisais@gmail.com','1995-08-19','100000','IT');

SELECT * FROM dbo.Employee;
