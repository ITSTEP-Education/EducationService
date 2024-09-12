USE [products];

SELECT * FROM [dbo].[productitems];

INSERT INTO [dbo].[productitems] (name, description, typeEngeeniring, durationMonth, price)
VALUES 
('c++', 'low-level language', 'back-end', '12', '2000' ),
('c#', 'midle-level language', 'back-end', '12', '2200' ),
('python', 'high-level language', 'back-end', '6', '1200' ),
('js', 'high-level language', 'back-end', '4', '1000' ),
('ts', 'high-level language', 'back-end', '3', '800' ),
('html', 'none', 'front-end', '4', '500' ),
('css', 'none', 'front-end', '4', '500' );

SELECT * FROM [dbo].[productitemlog];
TRUNCATE TABLE [dbo].[productitemlog];

--TRUNCATE TABLE [dbo].[productitems];
--DROP TABLE [dbo].[productitems];

--SELECT * FROM [dbo].[__EFMigrationsHistory];
--DROP TABLE [dbo].[__EFMigrationsHistory];

--DROP DATABASE [productitems];