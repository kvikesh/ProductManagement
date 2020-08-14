USE [ProductDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 8/14/2020 11:39:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 8/14/2020 11:39:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[SubCategoryId] [int] NOT NULL,
	[Description] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 8/14/2020 11:39:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Watch')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([Id], [Name], [SubCategoryId], [Description]) VALUES (1, N'Apple ', 1, N'Apple Watch 38 mm Stainless Steel Stainless Steel Case with Modern Buckle')
INSERT [dbo].[Item] ([Id], [Name], [SubCategoryId], [Description]) VALUES (2, N'Fastrack ', 2, N'Fastrack 38024PP25 Minimalists Analog Watch - For Men & Women')
INSERT [dbo].[Item] ([Id], [Name], [SubCategoryId], [Description]) VALUES (4, N'Skmei 1258', 3, N'Skmei 1258 Black Chronograph Digital Digital Watch - For Men')
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[SubCategory] ON 

INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (1, N'Smart Watch', 1)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (2, N'Analog Watch', 1)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (3, N'Digital Watch', 1)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (4, N'Hybrid Watch', 1)
SET IDENTITY_INSERT [dbo].[SubCategory] OFF
ALTER TABLE [dbo].[Item]  WITH CHECK ADD FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[SubCategory] ([Id])
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [CHK_LENGTH] CHECK  ((len([Name])>=(3) AND len([Name])<=(12)))
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [CHK_LENGTH]
GO
