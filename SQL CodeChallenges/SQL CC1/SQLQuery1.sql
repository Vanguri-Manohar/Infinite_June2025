create database CodeChallenge

use CodeChallenge
/*
Create a book table with id as primary key and provide the appropriate data type to other attributes .isbn no should be unique for each book

Write a query to fetch the details of the books written by author whose name ends with er.
*/

create table books(id int primary key,
title varchar(30),author varchar(30),
isbn BIGINT unique,
published_date DATETIME)

insert into books values(1,'My First SQL book','Mary Parker',981483029127,'2012-02-22 12:08:17'),
(2,'My Second SQL book','John Mayer',857300923713,'1972-07-03 09:22:45'),
(3,'My Third SQL book','Cary Flint',523120967912,'2015-10-18 14:05:44')

select * from books

select * from  books WHERE author LIKE '%er'

--Display the Title ,Author and ReviewerName for all the books from the above table

create table reviews(id int primary key,
book_id int,reviewer_name varchar(30),content varchar(30),rating int,
published_date DateTime)

alter table reviews
add constraint fkbookid foreign key(book_id) references books(id)

insert into reviews values(1,1,'John Smith','My first review',4,'2017-12-10 05:50:11.1'),
(2,2,'John Smith','My second review',5,'2017-10-13 15:05:12.6'),
(3,2,'Alice Walker','Another review',1,'2017-10-22 23:47:10')

select * from reviews

select title,author,reviewer_name from books,reviews


select b.title, b.author, r.reviewer_name
from books b
JOIN reviews r ON b.id = r.book_id;

--Display the reviewer name who reviewed more than one book.


select reviewer_name
from reviews
group by reviewer_name
Having COUNT( distinct book_id) > 1;


create table customers(id int  primary key,Name varchar(20),Age int,
address varchar(30),Salary float)


insert into customers values(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',4500.00),
(7,'Muffy',24,'Indore',10000.00)

select * from customers

--Display the Name for the customer from above customer table who live in same address which has character o anywhere in addres

select Name,address from customers where address like '%o%'

create table orders(OID int primary key,Date DATETIME,
customer_id int,amount bigint)

insert into orders values(102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),
(103,'2008-05-20 00:00:00',4,2060)

alter table orders
add constraint fkcusid foreign key(customer_id) references customers(id)

--Write a query to display the Date,Total no of customer placed order on same Date


select date, COUNT(customer_id) 'No of Customers'
from orders
GROUP BY date;

create table customers1(id int  primary key,Name varchar(20),Age int,
address varchar(30),Salary float)

insert into customers1 values(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',null),
(7,'Muffy',24,'Indore',null)

--Display the Names of the Employee in lower case, whose salary is null

select LOWER(name) as emp from customers1 WHERE salary is NULL;

create table studentdetails( id int  primary key,
regno int,name varchar(20),age int,Qualification varchar(10),mobno bigint,
mail_id varchar(20),location varchar(20),gender char)

insert into studentdetails(id,gender) values(1,'M'),(2,'M'),
(3,'F'),(4,'F'),(5,'F'),(6,'M')

select Gender,count(gender) 'Count of gender' from studentdetails
group by gender



