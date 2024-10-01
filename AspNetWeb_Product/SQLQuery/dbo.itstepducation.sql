USE [db_aac438_itstepeducation];

SELECT * FROM [dbo].[productitems];

INSERT INTO [dbo].[productitems] (name, description, typeEngeeniring, durationMonth, price)
VALUES 
('c++', 'low-level language', 'back-end', '12', '15000' ),
('c#', 'midle-level language', 'back-end', '12', '12000' ),
('python', 'high-level language', 'back-end', '6', '7000' ),
('js', 'high-level language', 'back-end', '5', '5000' ),
('ts', 'high-level language', 'back-end', '5', '6000' );

--TRUNCATE TABLE [dbo].[productitems];
--DROP TABLE [dbo].[productitems];

SELECT * FROM [dbo].[productorders];

INSERT INTO [dbo].[productorders] (name, typeEngeeniring, timeStudy, sumPay, guid, dateTime)
VALUES 
('c++', 'back-end', '12', '15000', 'a1b1cb1', '2024-09-29 04:54' ),
('c#', 'back-end', '12', '12000', 'a1b1cb2', '2024-09-29 05:55' ),
('python', 'back-end', '6', '17000', 'a1b1cb3', '2024-09-29 06:56' );

--TRUNCATE TABLE [dbo].[productorders];

SELECT * FROM [dbo].[clientsdata];

INSERT INTO [dbo].[clientsdata] (firstName, lastName, age, mobile)
VALUES
('kostiantyn', 'polishko', 39, '+38-096-440-19-47'),
('hanna', 'borodina', 29, '+38-050-030-23-47'),
('alla', 'pavlova', 49, '+38-066-344-68-87');

DELETE FROM [dbo].[clientsdata] WHERE firstName='Alla';

--DELETE FROM [dbo].[clientsdata]

SELECT * FROM [dbo].[clientorders];

INSERT INTO [dbo].[clientorders] (name, typeEngeeniring, timeStudy, sumPay, FK_ClientId)
VALUES
('c++', 'back-end', 12, 15000, 8),
('python', 'back-end', 6, 17000, 9),
('c#', 'back-end', 12, 12000, 10);

--TRUNCATE TABLE [dbo].[clientorders]

--SELECT * FROM [dbo].[__EFMigrationsHistory];
--TRUNCATE TABLE [dbo].[__EFMigrationsHistory];
--DROP TABLE [dbo].[__EFMigrationsHistory];

SELECT * FROM [dbo].[productorders];
SELECT * FROM [dbo].[clientsdata];
SELECT * FROM [dbo].[clientorders];
