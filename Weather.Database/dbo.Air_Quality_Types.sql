CREATE TABLE [dbo].[Air_Quality_Types]
(
	[Air_Quality_Type_Id] INT NOT NULL  PRIMARY KEY, 
	[Description] NVARCHAR(50) NOT NULL, 
	[Start] INT NOT NULL, 
	[End] INT NOT NULL

)
