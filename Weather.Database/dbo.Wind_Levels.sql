CREATE TABLE [dbo].[Wind_Levels]
(
	[Wind_Level_Id] INT NOT NULL PRIMARY KEY, 
	[Level] NCHAR(10) NOT NULL, 
    [Speed_Start] INT NULL, 
    [Speed_End] INT NULL
)
