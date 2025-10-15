CREATE TABLE Destinations (
    DestinationID INT PRIMARY KEY IDENTITY(1,1),
    DestinationName NVARCHAR(100),
    Fare INT
);

CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    DestinationName NVARCHAR(100),
    PaymentType NVARCHAR(50),
    Fare INT,
    Timestamp DATETIME DEFAULT GETDATE()
);

INSERT INTO Destinations VALUES
('BenThanh - SuoiTien', 15000),
('BenThanh - ThaoDien', 12000),
('BenThanh - TanSonNhat', 18000);
