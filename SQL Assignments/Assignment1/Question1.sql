create database Assignment1

use Assignment1


CREATE TABLE Client (
    Client_ID INT PRIMARY KEY,
    Cname VARCHAR(40) NOT NULL,
    Address VARCHAR(30),
    Email VARCHAR(30) UNIQUE,
    Phone FLOAT(10),
    Business VARCHAR(20) NOT NULL
);

insert into Client values(1001,'ACME Utilities','Noida','contact@acmeutil.com',9567880032,'Manufacturing'),
(1002 ,'Trackon Consultants',' Mumbai', 'consult@trackon.com', 8734210090, 'Consultant'),
(1003 ,'MoneySaver Distributors',' Kolkata', 'save@moneysaver.com', 7799886655, 'Reseller'),
(1004 ,'Lawful Corp', 'Chennai', 'justice@lawful.com', 9210342219,'Professional')

select * from Client


CREATE TABLE Departments (
    Deptno INT PRIMARY KEY,
    Dname VARCHAR(15) NOT NULL,
    Loc VARCHAR(20)
);

insert into Departments values(10, 'Design', 'Pune'),
(20, 'Development', 'Pune'),
(30, 'Testing', 'Mumbai'),
(40, 'Document', 'Mumbai')

select * from Departments


CREATE TABLE Employees (
    Empno INT PRIMARY KEY,
    Ename VARCHAR(20) NOT NULL,
    Job VARCHAR(15),
    Salary INT,
    Deptno INT
);

ALTER TABLE Employees
ADD CONSTRAINT salcheck CHECK (Salary>0);

ALTER TABLE Employees
add constraint fkdeptno foreign key(Deptno) references Departments(Deptno)


insert into Employees Values
(7001, 'Sandeep', 'Analyst', 25000, 10),
(7002, 'Rajesh', 'Designer', 30000, 10),
(7003, 'Madhav', 'Developer', 40000, 20),
(7004, 'Manoj', 'Developer', 40000, 20),
(7005, 'Abhay', 'Designer', 35000, 10),
(7006, 'Uma', 'Tester', 30000, 30),
(7007, 'Gita', 'Tech. Writer', 30000, 40),
(7008, 'Priya', 'Tester', 35000, 30),
(7009, 'Nutan', 'Developer', 45000, 20),
(7010, 'Smita', 'Analyst', 20000, 10),
(7011, 'Anand', 'Project Mgr', 65000, 10)

select * from Employees


CREATE TABLE Projects (
    Project_ID INT PRIMARY KEY,
    Descr VARCHAR(30) NOT NULL,
    Budget FLOAT(20),
    Client_ID INT,
    Start_Date DATE,
    Planned_End_Date DATE,
    Actual_End_Date DATE
);

Alter table Projects
add constraint datecheck check(Actual_End_Date > Planned_End_Date)

Alter table Projects
add constraint budgetcheck check(Budget>0)

ALTER TABLE Projects
add constraint fkclientid foreign key(Client_ID) references Client(Client_ID)


INSERT INTO Projects (Project_ID, Descr, Start_Date, Planned_End_Date, Actual_End_Date, Budget, Client_ID) VALUES 
(401, 'Inventory',  '01-Apr-11','01-Oct-11', '31-Oct-11', 150000, 1001),
(402, 'Accounting', '01-Aug-11', '01-Jan-12', NULL, 500000, 1002),
(403, 'Payroll','01-Oct-11','31-Dec-11', NULL, 75000, 1003),
(404, 'Contact Mgmt','01-Nov-11','31-Dec-11', NULL, 50000, 1004);

select * from Projects


CREATE TABLE EmpProjectTasks(
    Project_ID INT,
    Empno INT,
    Start_Date DATE,
    End_Date DATE,
    Task VARCHAR(25) NOT NULL,
    Status VARCHAR(15) NOT NULL,
	PRIMARY KEY (Project_ID, Empno)
);

Alter table EmpProjectTasks
add constraint fkprjid foreign key(Project_ID) references projects(project_id)


Alter table EmpProjectTasks
add constraint fkempno foreign key(Empno) references Employees(Empno)


INSERT INTO EmpProjectTasks(Project_ID, Empno, Start_Date, End_Date, Task, Status) VALUES 
(401, 7001, '01-Apr-11', '20-Apr-11', 'System Analysis', 'Completed'),
(401, 7002, '21-Apr-11', '30-May-11', 'System Design', 'Completed'),
(401, 7003, '01-Jun-11', '15-Jul-11', 'Coding', 'Completed'),
(401, 7004, '18-Jul-11', '01-Sep-11', 'Coding', 'Completed'),
(401, 7006, '03-Sep-11', '15-Sep-11', 'Testing', 'Completed'),
(401, 7009, '18-Sep-11', '05-Oct-11', 'Code Change', 'Completed'),
(401, 7008, '06-Oct-11', '16-Oct-11', 'Testing', 'Completed'),
(401, 7007, '06-Oct-11', '22-Oct-11', 'Documentation', 'Completed'),
(401, 7011, '22-Oct-11', '31-Oct-11', 'Sign off', 'Completed'),
(402, 7010, '01-Aug-11', '20-Aug-11', 'System Analysis', 'Completed'),
(402, 7002, '22-Aug-11', '30-Sep-11', 'System Design', 'Completed'),
(402, 7004, '01-Oct-11', NULL, 'Coding', 'In Progress')

select * from EmpProjectTasks









