﻿CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[IdClient] INT NOT NULL,
	[IdBook] INT NOT NULL, 
	[OrderDate] DATETIMEOFFSET (7) NOT NULL,
	[Returned] INT NOT NULL,
	[Condition] INT NULL,
)