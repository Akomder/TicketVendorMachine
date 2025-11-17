USE TicketVendorMachineDB;
GO

DELETE FROM Tickets;
DELETE FROM Transactions;
DELETE FROM FareRules;
DELETE FROM Stations;
GO

DBCC CHECKIDENT ('Tickets', RESEED, 0);
DBCC CHECKIDENT ('Transactions', RESEED, 0);
DBCC CHECKIDENT ('FareRules', RESEED, 0);
DBCC CHECKIDENT ('Stations', RESEED, 0);
GO

INSERT INTO Stations (StationCode, StationName, StationNameVI, ZoneNumber, OrderIndex, Latitude, Longitude) VALUES
('BT', 'Ben Thanh', 'Bến Thành', 1, 1, 10.7719, 106.6981),
('OH', 'Opera House', 'Nhà Hát Thành Phố', 1, 2, 10.7769, 106.7019),
('BS', 'Ba Son', 'Ba Sơn', 1, 3, 10.7794, 106.7061),
('CH', 'City Hall', 'Ủy Ban Nhân Dân', 1, 4, 10.7828, 106.7100),
('TC', 'Tan Cang', 'Tân Cảng', 1, 5, 10.7883, 106.7144),
('TT', 'Thu Thiem', 'Thủ Thiêm', 2, 6, 10.7925, 106.7208),
('AP', 'An Phu', 'An Phú', 2, 7, 10.8011, 106.7383),
('RC', 'Rach Chiec', 'Rạch Chiếc', 2, 8, 10.8089, 106.7544),
('PL', 'Phuoc Long', 'Phước Long', 2, 9, 10.8147, 106.7689),
('BT2', 'Binh Thai', 'Bình Thái', 3, 10, 10.8228, 106.7828),
('TD', 'Thu Duc', 'Thủ Đức', 3, 11, 10.8314, 106.7978),
('HB', 'Hiep Binh', 'Hiệp Bình', 3, 12, 10.8392, 106.8119),
('LB', 'Long Binh', 'Long Bình', 3, 13, 10.8464, 106.8261),
('ST', 'Suoi Tien', 'Suối Tiên', 3, 14, 10.8528, 106.8397);

PRINT CAST(@@ROWCOUNT AS VARCHAR) + ' stations inserted successfully!';
GO

INSERT INTO FareRules (ZoneFrom, ZoneTo, BaseFare, PerKmRate, TicketType, Description) VALUES
(1, 1, 7000, 0, 'Single', 'Zone 1 to Zone 1 - Short distance'),
(2, 2, 7000, 0, 'Single', 'Zone 2 to Zone 2 - Short distance'),
(3, 3, 7000, 0, 'Single', 'Zone 3 to Zone 3 - Short distance'),

(1, 2, 12000, 0, 'Single', 'Zone 1 to Zone 2 - Medium distance'),
(2, 3, 15000, 0, 'Single', 'Zone 2 to Zone 3 - Medium distance'),

(1, 3, 20000, 0, 'Single', 'Zone 1 to Zone 3 - Full line (Ben Thanh to Suoi Tien)'),

(1, 3, 40000, 0, 'DayPass', 'Unlimited travel for one day');

PRINT CAST(@@ROWCOUNT AS VARCHAR) + ' fare rules inserted successfully!';
GO

PRINT 'Inserting Sample Transactions...';

DECLARE @Today DATETIME = GETDATE();
DECLARE @Yesterday DATETIME = DATEADD(DAY, -1, GETDATE());
DECLARE @LastWeek DATETIME = DATEADD(DAY, -7, GETDATE());

INSERT INTO Transactions (TransactionCode, MachineId, OriginStationId, DestinationStationId, TicketType, Quantity, FareAmount, Distance, JourneyTime, PaymentMethod, PaymentStatus, PaymentReference, CreatedDate, CompletedDate)
VALUES
('TXN' + CAST(CAST(GETDATE() AS BIGINT) AS VARCHAR) + '001', 'TVM001', 1, 14, 'Single', 1, 20000, 19.7, 36, 'Credit Card', 'Success', 'CC-' + NEWID(), @Today, @Today),
('TXN' + CAST(CAST(GETDATE() AS BIGINT) AS VARCHAR) + '002', 'TVM001', 14, 1, 'Single', 2, 40000, 19.7, 36, 'QR Code - Momo', 'Success', 'MOMO-' + NEWID(), @Today, @Today),
('TXN' + CAST(CAST(GETDATE() AS BIGINT) AS VARCHAR) + '003', 'TVM002', 6, 10, 'Single', 1, 15000, 9.8, 18, 'QR Code - VNPay', 'Success', 'VNPAY-' + NEWID(), @Today, @Today),
('TXN' + CAST(CAST(GETDATE() AS BIGINT) AS VARCHAR) + '004', 'TVM001', 1, 5, 'Single', 1, 7000, 4.9, 9, 'Credit Card', 'Success', 'CC-' + NEWID(), @Today, @Today),

-- Yesterday's transactions
('TXN' + CAST(CAST(@Yesterday AS BIGINT) AS VARCHAR) + '001', 'TVM001', 1, 8, 'Single', 1, 12000, 9.8, 18, 'QR Code - ZaloPay', 'Success', 'ZALO-' + NEWID(), @Yesterday, @Yesterday),
('TXN' + CAST(CAST(@Yesterday AS BIGINT) AS VARCHAR) + '002', 'TVM002', 3, 11, 'Single', 3, 60000, 14.8, 27, 'Credit Card', 'Success', 'CC-' + NEWID(), @Yesterday, @Yesterday),

-- Last week's transactions
('TXN' + CAST(CAST(@LastWeek AS BIGINT) AS VARCHAR) + '001', 'TVM001', 1, 14, 'DayPass', 1, 40000, 0, 0, 'Credit Card', 'Success', 'CC-' + NEWID(), @LastWeek, @LastWeek),
('TXN' + CAST(CAST(@LastWeek AS BIGINT) AS VARCHAR) + '002', 'TVM003', 5, 12, 'Single', 1, 15000, 12.3, 22, 'QR Code - Momo', 'Success', 'MOMO-' + NEWID(), @LastWeek, @LastWeek),

('TXN' + CAST(CAST(GETDATE() AS BIGINT) AS VARCHAR) + '999', 'TVM001', 1, 14, 'Single', 1, 20000, 19.7, 36, 'Credit Card', 'Failed', NULL, @Today, NULL);

PRINT CAST(@@ROWCOUNT AS VARCHAR) + ' sample transactions inserted successfully!';
GO

PRINT 'Inserting Sample Tickets...';

DECLARE @TransId INT;
DECLARE @TicketCode NVARCHAR(50);
DECLARE @QRData NVARCHAR(500);

DECLARE ticket_cursor CURSOR FOR
SELECT TransactionId, TransactionCode 
FROM Transactions 
WHERE PaymentStatus = 'Success';

OPEN ticket_cursor;
FETCH NEXT FROM ticket_cursor INTO @TransId, @TicketCode;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @QRData = 'HCMC-METRO|' + @TicketCode + '|' + FORMAT(GETDATE(), 'yyyyMMddHHmmss');
    
    INSERT INTO Tickets (TicketCode, TransactionId, QRCodeData, TicketType, ValidFrom, ValidUntil, Status)
    VALUES 
    ('TKT' + CAST(@TransId AS VARCHAR) + '-' + CAST(NEWID() AS VARCHAR), 
     @TransId, 
     @QRData, 
     'Single', 
     GETDATE(), 
     DATEADD(HOUR, 2, GETDATE()), 
     'Active');
    
    FETCH NEXT FROM ticket_cursor INTO @TransId, @TicketCode;
END

CLOSE ticket_cursor;
DEALLOCATE ticket_cursor;

PRINT CAST(@@ROWCOUNT AS VARCHAR) + ' sample tickets created successfully!';
GO

SELECT 'Stations' AS TableName, COUNT(*) AS RecordCount FROM Stations
UNION ALL
SELECT 'Fare Rules', COUNT(*) FROM FareRules
UNION ALL
SELECT 'Transactions', COUNT(*) FROM Transactions
UNION ALL
SELECT 'Tickets', COUNT(*) FROM Tickets;
GO