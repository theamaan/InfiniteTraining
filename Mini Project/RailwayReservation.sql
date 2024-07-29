create database railwayReservationSystem

-- Create Users Table
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    role VARCHAR(10) NOT NULL CHECK (role IN ('user', 'admin'))
);

-- Create Trains Table
CREATE TABLE Trains (
    train_id INT IDENTITY(1,1) PRIMARY KEY,
    train_number VARCHAR(10) NOT NULL,
    train_name VARCHAR(50) NOT NULL,
    source VARCHAR(50) NOT NULL,
    destination VARCHAR(50) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    class_of_travel VARCHAR(10) NOT NULL,
    status VARCHAR(10) NOT NULL CHECK (status IN ('active', 'inactive')),
    seats_available INT NOT NULL
);

-- Create Bookings Table
CREATE TABLE Bookings (
    booking_id INT IDENTITY(1,1) PRIMARY KEY,
    train_id INT NOT NULL,
    user_id INT NOT NULL,
    booking_date DATETIME NOT NULL,
    seats_booked INT NOT NULL,
    status VARCHAR(10) NOT NULL CHECK (status IN ('confirmed', 'cancelled')),
    FOREIGN KEY (train_id) REFERENCES Trains(train_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

-- Create Cancellations Table
CREATE TABLE Cancellations (
    cancellation_id INT IDENTITY(1,1) PRIMARY KEY,
    booking_id INT NOT NULL,
    cancellation_date DATETIME NOT NULL,
    seats_cancelled INT NOT NULL,
    FOREIGN KEY (booking_id) REFERENCES Bookings(booking_id)
);

select * from dbo.Users;
select * from dbo.Trains;
select * from Bookings;
select * from Cancellations;