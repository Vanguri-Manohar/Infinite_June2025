
use Assignment1
CREATE TABLE Trains (
    tno INT PRIMARY KEY,
    tname VARCHAR(50),
    [from] VARCHAR(50),
    dest VARCHAR(50),
    price DECIMAL(10, 2),
    class_of_travel VARCHAR(50),
    train_status VARCHAR(10),
    seats_available INT
)


CREATE TABLE Admins (
    username VARCHAR(50) PRIMARY KEY,
    password VARCHAR(50),
    role VARCHAR(10) DEFAULT 'admin')


CREATE TABLE Users (
	userid INT PRIMARY KEY IDENTITY,
    username VARCHAR(50),
    password VARCHAR(50),
    role VARCHAR(10) DEFAULT 'user'
)


CREATE TABLE Bookings (
    booking_id INT PRIMARY KEY IDENTITY,
    tno INT,
    userid INT,
    seats_booked INT,
    booking_date DATETIME,
    status varchar(50) default 'active',
    FOREIGN KEY (tno) REFERENCES Trains(tno)
)


alter table Bookings add constraint
fk_userid foreign key(userid) references 
Users(userid)

alter table Bookings drop constraint
fk_username 


alter table Bookings add constraint
fk_tno foreign key(tno) references 
Trains(tno)
drop table Bookings



CREATE TABLE Cancellations (
    cancellation_id INT PRIMARY KEY IDENTITY,
    booking_id INT,
    seats_cancelled INT,
    cancellation_date DATETIME,
    status varchar(50) default 'active',
    FOREIGN KEY (booking_id) REFERENCES Bookings(booking_id)
)

INSERT INTO Trains VALUES 
(12211, 'vandebharath', 'chennai', 'banglore', 2345, 'economy', 'inactive', 120),
(14543, 'rajadhani express', 'chennai', 'delhi', 3500, '1AC', 'active', 24),
(25545, 'godavari express', 'visakhapatnam', 'secundrabad', 3000, '2AC', 'active', 54)

INSERT INTO Users VALUES 
('Manohar', 'Manohar123', 'admin'),
('Dinesh', 'Dinesh123', 'user')

select * from Users
select * from Trains
select * from admins

select * from Bookings
select * from Cancellations

alter table bookings add Name varchar(50)

update Trains set train_status='active' where tno=14543


insert into Users(username,password) values('Dinesh','Dinesh123'),('Jaya','Jaya123'),('Siva','Siva123')

insert into admins(username,password) values('Manohar','Manohar123')



CREATE TRIGGER trg_UpdateBookingStatus
ON Trains
AFTER UPDATE
AS
BEGIN
    
    UPDATE b
    SET b.status = i.train_status
    FROM Bookings b
    INNER JOIN inserted i ON b.tno = i.tno;
END





