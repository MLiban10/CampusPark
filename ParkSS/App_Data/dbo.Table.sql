﻿CREATE TABLE [dbo].[ParkDB]
(
	[Id] NVARCHAR(50) NOT NULL,
	[Type] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Location] NVARCHAR(50) NOT NULL,
	[BateryStatus] INT NOT NULL,
	[Value] NVARCHAR(50) NOT NULL,
	[Timestamp] SMALLDATETIME NOT NULL
)
