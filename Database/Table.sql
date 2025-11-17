CREATE TABLE Stations (
        StationId INT PRIMARY KEY IDENTITY(1,1),
        StationCode NVARCHAR(10) NOT NULL UNIQUE,
        StationName NVARCHAR(100) NOT NULL,
        StationNameVI NVARCHAR(100) NOT NULL,
        ZoneNumber INT NOT NULL CHECK (ZoneNumber BETWEEN 1 AND 3),
        OrderIndex INT NOT NULL,
        Latitude DECIMAL(10, 8) NULL,
        Longitude DECIMAL(11, 8) NULL,
        IsActive BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME NULL
    );
GO

CREATE TABLE FareRules (
        FareRuleId INT PRIMARY KEY IDENTITY(1,1),
        ZoneFrom INT NOT NULL CHECK (ZoneFrom BETWEEN 1 AND 3),
        ZoneTo INT NOT NULL CHECK (ZoneTo BETWEEN 1 AND 3),
        BaseFare DECIMAL(10,2) NOT NULL CHECK (BaseFare > 0),
        PerKmRate DECIMAL(10,2) DEFAULT 0,
        TicketType NVARCHAR(50) NOT NULL,
        Description NVARCHAR(255) NULL,
        IsActive BIT DEFAULT 1,
        CreatedDate DATETIME DEFAULT GETDATE(),
        UpdatedDate DATETIME NULL,
        CONSTRAINT CK_FareRules_Zones CHECK (ZoneFrom <= ZoneTo)
    );
GO

CREATE TABLE Transactions (
        TransactionId INT PRIMARY KEY IDENTITY(1,1),
        TransactionCode NVARCHAR(50) NOT NULL UNIQUE,
        MachineId NVARCHAR(50) NOT NULL,
        OriginStationId INT NOT NULL,
        DestinationStationId INT NOT NULL,
        TicketType NVARCHAR(50) NOT NULL DEFAULT 'Single',
        Quantity INT DEFAULT 1 CHECK (Quantity BETWEEN 1 AND 4),
        FareAmount DECIMAL(10,2) NOT NULL CHECK (FareAmount > 0),
        Distance DECIMAL(10,2) NULL,
        JourneyTime INT NULL,
        PaymentMethod NVARCHAR(50) NOT NULL,
        PaymentStatus NVARCHAR(50) NOT NULL DEFAULT 'Pending',
        PaymentReference NVARCHAR(100),
        ErrorMessage NVARCHAR(500) NULL,
        CreatedDate DATETIME DEFAULT GETDATE(),
        CompletedDate DATETIME NULL,
        CONSTRAINT FK_Transactions_OriginStation FOREIGN KEY (OriginStationId) 
            REFERENCES Stations(StationId),
        CONSTRAINT FK_Transactions_DestinationStation FOREIGN KEY (DestinationStationId) 
            REFERENCES Stations(StationId)
    );
GO

CREATE TABLE Tickets (
        TicketId INT PRIMARY KEY IDENTITY(1,1),
        TicketCode NVARCHAR(50) NOT NULL UNIQUE,
        TransactionId INT NOT NULL,
        QRCodeData NVARCHAR(500) NOT NULL,
        TicketType NVARCHAR(50) NOT NULL DEFAULT 'Single',
        ValidFrom DATETIME NOT NULL,
        ValidUntil DATETIME NOT NULL,
        Status NVARCHAR(50) DEFAULT 'Active',
        UsedDate DATETIME NULL,
        UsedStationId INT NULL,
        CreatedDate DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Tickets_Transaction FOREIGN KEY (TransactionId) 
            REFERENCES Transactions(TransactionId),
        CONSTRAINT FK_Tickets_UsedStation FOREIGN KEY (UsedStationId) 
            REFERENCES Stations(StationId)
    );
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Transactions_CreatedDate')
BEGIN
    CREATE INDEX IX_Transactions_CreatedDate ON Transactions(CreatedDate DESC);
    PRINT 'Index IX_Transactions_CreatedDate created!';
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Transactions_MachineId')
BEGIN
    CREATE INDEX IX_Transactions_MachineId ON Transactions(MachineId);
    PRINT 'Index IX_Transactions_MachineId created!';
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Tickets_Status')
BEGIN
    CREATE INDEX IX_Tickets_Status ON Tickets(Status);
    PRINT 'Index IX_Tickets_Status created!';
END
GO
