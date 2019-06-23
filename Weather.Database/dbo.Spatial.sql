CREATE TABLE [dbo].[Spatial]
(
	[Spatial_Id] INT NOT NULL IDENTITY, 
    [Country] NVARCHAR(50) NOT NULL, 
	[City] NVARCHAR(50) NOT NULL, 
    [GeoLocation] [sys].[geography] NOT NULL, 
    CONSTRAINT [PK_Spatial] PRIMARY KEY ([Spatial_Id]) 
)
