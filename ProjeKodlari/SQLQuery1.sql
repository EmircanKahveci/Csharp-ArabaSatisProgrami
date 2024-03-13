CREATE TABLE [dbo].[Customers] (
	[CustomerNo] INT NOT NULL PRIMARY KEY identity(1,1),
    images image,
    [TcNo]             NVARCHAR (50)  NOT NULL,
    [Name]             NVARCHAR (50)  NOT NULL,
    [LastName]         NVARCHAR (50)  NOT NULL,
    [DateofBirth]      INT            NOT NULL,
    [Profession]       NVARCHAR (50)  NOT NULL,
    [PhoneNumber]      NVARCHAR (50)  NOT NULL,
    [Email]            NVARCHAR (50)  NOT NULL,
    [Address]          NVARCHAR (100) NOT NULL,
    [DrivingLicenseNo] NVARCHAR (50)  NOT NULL,
    [LicenseType]      NVARCHAR (50)  NOT NULL
    
);

