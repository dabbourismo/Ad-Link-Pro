CREATE TABLE [dbo].[Services]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ServiceName] NVARCHAR(MAX) NOT NULL, 
    [ServicePrice] FLOAT NOT NULL, 
    [ServiceType] NVARCHAR(50) NOT NULL, 
    [ServiceTime] INT NOT NULL

)
