CREATE TABLE [dbo].[ContactTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [PhoneNumber] NVARCHAR(20) NOT NULL, 
    [EmailAddress] NVARCHAR(100) NOT NULL
)
