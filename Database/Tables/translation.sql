CREATE TABLE [dbo].[translation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [English] NVARCHAR(MAX) NOT NULL , 
    [Hungarian] NVARCHAR(MAX) NOT NULL, 
    [Spanish] NVARCHAR(MAX) NOT NULL, 
    [Chinese] NVARCHAR(MAX) NOT NULL, 
    [Portugese] NVARCHAR(MAX) NOT NULL
)
