CREATE TABLE [dbo].[Weather]
(
	[Weather_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Spatial_Id] INT NOT NULL, 
    [Temperature] FLOAT NULL, 
	[Temperature_Feels] FLOAT NOT NULL, 
    [Weather_Type_Id] int NOT NULL, 
    [Wind_Direction_Id] INT NULL, 
    [Humidity] FLOAT NULL, 
    [Air_Quality_Num] INT NULL, 
    CONSTRAINT [FK_Weather_Spatial] FOREIGN KEY ([Spatial_Id]) REFERENCES [Spatial]([Spatial_Id]), 
    CONSTRAINT [FK_Weather_Weather_Types] FOREIGN KEY ([Weather_Type_Id]) REFERENCES [Weather_Types]([Weather_Type_Id]),
	CONSTRAINT [FK_Weather_Wind_Directions] FOREIGN KEY ([Wind_Direction_Id]) REFERENCES [Wind_Directions]([Wind_Direction_Id])
 
)
