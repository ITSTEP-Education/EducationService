--USE [db_aac438_itstepeducation];

USE [products]

INSERT INTO [dbo].[productitems] (name, description, typeEngeeniring, durationMonth, price)
VALUES 
('c++', 'low-level language', 'back-end', '12', '15000' ),
('c#', 'midle-level language', 'back-end', '12', '12000' ),
('python', 'high-level language', 'back-end', '6', '7000' ),
('js', 'high-level language', 'back-end', '5', '5000' ),
('ts', 'high-level language', 'back-end', '5', '6000' );

SELECT * FROM [dbo].[productitems];

--TRUNCATE TABLE [dbo].[productitems];
--DROP TABLE [dbo].[productitems];

--SELECT * FROM [dbo].[__EFMigrationsHistory];
--DROP TABLE [dbo].[__EFMigrationsHistory];

--DROP DATABASE [productitems];