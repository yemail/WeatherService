USE [Weather]
GO
/****** Object:  Table [dbo].[Air_Quality_Types]    Script Date: 9/7/2016 7:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Air_Quality_Types](
	[Air_Quality_Type_Id] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Start] [int] NOT NULL,
	[End] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Air_Quality_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location_Aware_Message]    Script Date: 9/7/2016 7:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location_Aware_Message](
	[Message_Id] [int] IDENTITY(1,1) NOT NULL,
	[Spatial_Id] [int] NOT NULL,
	[Message] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Message_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Spatial]    Script Date: 9/7/2016 7:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spatial](
	[Spatial_Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[GeoLocation] [geography] NOT NULL,
 CONSTRAINT [PK_Spatial] PRIMARY KEY CLUSTERED 
(
	[Spatial_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Weather]    Script Date: 9/7/2016 7:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weather](
	[Weather_Id] [int] IDENTITY(1,1) NOT NULL,
	[Spatial_Id] [int] NOT NULL,
	[Temperature] [float] NULL,
	[Temperature_Feels] [float] NOT NULL,
	[Weather_Type_Id] [int] NOT NULL,
	[Wind_Speed] [int] NULL,
	[Wind_Direction_Id] [int] NULL,
	[Humidity] [float] NULL,
	[Air_Quality_Num] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Weather_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Weather_Types]    Script Date: 9/7/2016 7:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weather_Types](
	[Weather_Type_Id] [int] NOT NULL,
	[Weather_Type] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Weather_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wind_Directions]    Script Date: 9/7/2016 7:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Wind_Directions](
	[Wind_Direction_Id] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Wind_Direction_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Wind_Levels]    Script Date: 9/7/2016 7:26:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wind_Levels](
	[Wind_Level_Id] [int] NOT NULL,
	[Level] [nchar](10) NOT NULL,
	[Speed_Start] [int] NULL,
	[Speed_End] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Wind_Level_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Air_Quality_Types] ([Air_Quality_Type_Id], [Description], [Start], [End]) VALUES (10, N'Good', 0, 99)
GO
INSERT [dbo].[Air_Quality_Types] ([Air_Quality_Type_Id], [Description], [Start], [End]) VALUES (20, N'Fair', 100, 199)
GO
INSERT [dbo].[Air_Quality_Types] ([Air_Quality_Type_Id], [Description], [Start], [End]) VALUES (30, N'Poor', 200, 10000)
GO
SET IDENTITY_INSERT [dbo].[Location_Aware_Message] ON 

GO
INSERT [dbo].[Location_Aware_Message] ([Message_Id], [Spatial_Id], [Message]) VALUES (1, 1, N'Welcome to Microsoft Suzhou. We offer equal opportunities.')
GO
INSERT [dbo].[Location_Aware_Message] ([Message_Id], [Spatial_Id], [Message]) VALUES (2, 2, N'Welcome to Microsoft Beijing.  We offer equal opportunities.')
GO
SET IDENTITY_INSERT [dbo].[Location_Aware_Message] OFF
GO
SET IDENTITY_INSERT [dbo].[Spatial] ON 

GO
INSERT [dbo].[Spatial] ([Spatial_Id], [Country], [City], [GeoLocation]) VALUES (1, N'China', N'Suzhou', 0xE6100000010C58AB764D48573F4092B1DAFCBF245E40)
GO
INSERT [dbo].[Spatial] ([Spatial_Id], [Country], [City], [GeoLocation]) VALUES (2, N'China', N'Beijing', 0xE6100000010C39F06AB933F54340E20511A969195D40)
GO
SET IDENTITY_INSERT [dbo].[Spatial] OFF
GO
SET IDENTITY_INSERT [dbo].[Weather] ON 

GO
INSERT [dbo].[Weather] ([Weather_Id], [Spatial_Id], [Temperature], [Temperature_Feels], [Weather_Type_Id], [Wind_Speed], [Wind_Direction_Id], [Humidity], [Air_Quality_Num]) VALUES (1, 1, 27, 29, 20, 5, 30, 82, 63)
GO
INSERT [dbo].[Weather] ([Weather_Id], [Spatial_Id], [Temperature], [Temperature_Feels], [Weather_Type_Id], [Wind_Speed], [Wind_Direction_Id], [Humidity], [Air_Quality_Num]) VALUES (2, 2, 21, 23, 10, 18, 10, 15, 101)
GO
SET IDENTITY_INSERT [dbo].[Weather] OFF
GO
INSERT [dbo].[Weather_Types] ([Weather_Type_Id], [Weather_Type]) VALUES (10, N'Sunny')
GO
INSERT [dbo].[Weather_Types] ([Weather_Type_Id], [Weather_Type]) VALUES (20, N'Rainy')
GO
INSERT [dbo].[Weather_Types] ([Weather_Type_Id], [Weather_Type]) VALUES (30, N'Cloudy')
GO
INSERT [dbo].[Wind_Directions] ([Wind_Direction_Id], [Description]) VALUES (10, N'N')
GO
INSERT [dbo].[Wind_Directions] ([Wind_Direction_Id], [Description]) VALUES (20, N'S')
GO
INSERT [dbo].[Wind_Directions] ([Wind_Direction_Id], [Description]) VALUES (30, N'NNE')
GO
INSERT [dbo].[Wind_Levels] ([Wind_Level_Id], [Level], [Speed_Start], [Speed_End]) VALUES (10, N'1         ', 0, 5)
GO
INSERT [dbo].[Wind_Levels] ([Wind_Level_Id], [Level], [Speed_Start], [Speed_End]) VALUES (20, N'2         ', 5, 10)
GO
INSERT [dbo].[Wind_Levels] ([Wind_Level_Id], [Level], [Speed_Start], [Speed_End]) VALUES (30, N'3         ', 10, 20)
GO
INSERT [dbo].[Wind_Levels] ([Wind_Level_Id], [Level], [Speed_Start], [Speed_End]) VALUES (40, N'4         ', 20, 30)
GO
ALTER TABLE [dbo].[Location_Aware_Message]  WITH CHECK ADD  CONSTRAINT [FK_Location_Aware_Message_Spatial] FOREIGN KEY([Spatial_Id])
REFERENCES [dbo].[Spatial] ([Spatial_Id])
GO
ALTER TABLE [dbo].[Location_Aware_Message] CHECK CONSTRAINT [FK_Location_Aware_Message_Spatial]
GO
ALTER TABLE [dbo].[Weather]  WITH CHECK ADD  CONSTRAINT [FK_Weather_Spatial] FOREIGN KEY([Spatial_Id])
REFERENCES [dbo].[Spatial] ([Spatial_Id])
GO
ALTER TABLE [dbo].[Weather] CHECK CONSTRAINT [FK_Weather_Spatial]
GO
ALTER TABLE [dbo].[Weather]  WITH CHECK ADD  CONSTRAINT [FK_Weather_Weather_Types] FOREIGN KEY([Weather_Type_Id])
REFERENCES [dbo].[Weather_Types] ([Weather_Type_Id])
GO
ALTER TABLE [dbo].[Weather] CHECK CONSTRAINT [FK_Weather_Weather_Types]
GO
ALTER TABLE [dbo].[Weather]  WITH CHECK ADD  CONSTRAINT [FK_Weather_Wind_Directions] FOREIGN KEY([Wind_Direction_Id])
REFERENCES [dbo].[Wind_Directions] ([Wind_Direction_Id])
GO
ALTER TABLE [dbo].[Weather] CHECK CONSTRAINT [FK_Weather_Wind_Directions]
GO
