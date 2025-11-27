CREATE TABLE Customer (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100)
);

CREATE TABLE Apartment (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Address NVARCHAR(255) NOT NULL,
    Price INT NOT NULL,
    Rooms INT NOT NULL,
    IsAvailable BIT NOT NULL DEFAULT 1 
);

CREATE TABLE Interest (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    
    ApartmentId INT NOT NULL,
    FOREIGN KEY (ApartmentId) REFERENCES Apartment(Id),

    CustomerId INT NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customer(Id),

    InterestDate DATE NOT NULL
);

INSERT INTO Customer (FirstName, LastName, Phone, Email) VALUES ('משה', 'כהן', '050-1234567', 'moshe@example.com');
INSERT INTO Customer (FirstName, LastName, Phone, Email) VALUES ('דנה', 'לוי', '052-9876543', 'dana@example.com');
INSERT INTO Customer (FirstName, LastName, Phone, Email) VALUES ('חיים', 'ישראלי', '054-0001111', 'haim@example.com');

INSERT INTO Apartment (Address, Price, Rooms) VALUES ('רחוב הרצל 10, תל אביב', 5000, 3);
INSERT INTO Apartment (Address, Price, Rooms) VALUES ('דרך העצמאות 5, חיפה', 3500, 2);
INSERT INTO Apartment (Address, Price, Rooms) VALUES ('שדרות ירושלים 20, ירושלים', 6500, 4);

INSERT INTO Interest (ApartmentId, CustomerId, InterestDate) VALUES (1, 1, GETDATE());
INSERT INTO Interest (ApartmentId, CustomerId, InterestDate) VALUES (2, 2, DATEADD(day, 1, GETDATE()));
INSERT INTO Interest (ApartmentId, CustomerId, InterestDate) VALUES (3, 1, DATEADD(day, 3, GETDATE()));