CREATE TABLE [dbo].[Location_Aware_Message]
(
	[Message_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	  [Spatial_Id] INT NOT NULL, 
	[Message] VARCHAR(MAX) NULL,
	CONSTRAINT [FK_Location_Aware_Message_Spatial] FOREIGN KEY ([Spatial_Id]) REFERENCES [Spatial]([Spatial_Id])
)
