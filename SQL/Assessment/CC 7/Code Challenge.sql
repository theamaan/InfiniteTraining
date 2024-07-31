create database cc7;
use cc7;

create table dbo.books (
    id int identity primary key,
    title varchar(20),
    author varchar(20),
    isbn bigint,
    published_date datetime
);
select * from books;
insert into dbo.books (title, author, isbn, published_date) values
('My First SQL book', 'Mary Parker', 981483029127, '2012-02-22 12:08:17'),
('My Second SQL book', 'John Mayer', 857300923713, '1972-07-03 09:22:45'),
('My Third SQL book', 'Cary Flint', 523120967812, '2015-10-18 14:05:44');
SELECT * FROM dbo.books WHERE author LIKE '%er';


create table dbo.reviews (
    id int identity primary key,
    book_id int,
    reviewer_name varchar(20),
    content varchar(20),
	rating int,
    published_date datetime
);
select * from reviews;
insert into dbo.reviews (book_id, reviewer_name, content, rating,published_date) values
(1, 'John Smith', 'My First Review',4,'2017-012-10 05:50:11'),
(2, 'John Smith', 'My Second Review',5, '2017-10-13 15:05:12'),
(3, 'Alice Walker', 'Third Review',1,'2017-10-22 23:47:10');

select b.title, b.author, r.reviewer_name from dbo.books b inner join dbo.reviews r on b.id = r.book_id;

select reviewer_name from reviews group by reviewer_name having count(*) >1;

create table customers(
	ID int identity primary key,
    NAME varchar(50),
    AGE int,
	ADDRESS varchar(50),
    salary float
);

insert into customers(NAME, AGE, ADDRESS, salary) values
('Ramesh', 32, 'Ahmedabad', 2000.00),
('Khilan', 25, 'Delhi', 1500.00),
('Kaushik', 23, 'Kota', 1500.00),
('Chaitali',25,'Mumbai',6500.00),
('Hardik',27,'Bhopal',8500.00),
('Komal',22,'MP',4500.00),
('Muffy', 24, 'Indore', 10000.00);
select * from customers
select name from customers where address like '%o%';

create table orders(
oid int,
date datetime,
customer_id int,
amount int
);
insert into orders(oid, date, customer_id, amount) values
(102, '2009-10-08 00:00:00', 3, 3000),
(100, '2009-10-08 00:00:00', 3, 1500),
(101, '2009-11-20 00:00:00', 2, 1560),
(103, '2008-05-20 00:00:00', 4, 2060);

select * from orders;

select convert(date, date) AS OrderDate, count(distinct customer_id) as TotalCustomers
from orders
group by convert(date, date)
order by OrderDate;

create table studentdetails (
    StudentID int PRIMARY KEY,
    RegisterNo int,
    Name varchar(20),
    Age int,
    Qualification varchar(20),
    MobileNo varchar(10),
    Mail_id varchar(50),
    Location varchar(30),
    Gender char(1)
);
insert into studentdetails (StudentID, RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender)
values
    (1, 2, 'Sai', 22, 'B.E.', '9891828485', 'Sai@Gmail.com', 'Chennai', 'M'),
    (2, 3, 'Kumar', 20, 'BSC', '9891823425', 'Kumar@Gmail.com', 'Madurai', 'M'),
    (3, 4, 'Selvi', 22, 'B.Tech', '9891238485', 'Delvi@Gmail.com', 'Salem', 'F'),
    (4, 5, 'Nisha', 25, 'M.E.', '9891238485', 'Nisha@Gmail.com', 'Therni', 'F'),
    (5, 6, 'SaiSaran', 21, 'B.A.', '9231828485', 'Saran@Gmail.com', 'Madurai', 'F'),
    (6, 7, 'Tom', 23, 'BCA', '9891821235', 'Tom@Gmail.com', 'Pune', 'M');

select Gender, count(*) as Total_Count from studentdetails group by Gender;