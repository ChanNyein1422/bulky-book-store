/****** Object:  Table [dbo].[tbBook]    Script Date: 16/05/2023 14:02:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Category] [nvarchar](255) NULL,
	[Author] [nvarchar](255) NULL,
	[Publisher] [nvarchar](255) NULL,
	[PublishDate] [nvarchar](255) NULL,
	[Price] [decimal](18, 2) NULL,
	[UploadedDate] [datetime] NULL,
	[BookUpload] [nvarchar](255) NULL,
	[Thumbnail] [nvarchar](255) NULL,
 CONSTRAINT [PK_tbBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbCategory]    Script Date: 16/05/2023 14:02:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](255) NOT NULL,
	[BookCount] [int] NOT NULL,
 CONSTRAINT [PK_tbCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbOrder]    Script Date: 16/05/2023 14:02:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbOrder](
	[Id] [nvarchar](255) NOT NULL,
	[UserId] [int] NOT NULL,
	[OrderCode] [nvarchar](255) NOT NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[TotalBooks] [int] NULL,
	[OrderedTime] [datetime] NULL,
 CONSTRAINT [PK_tbOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbOrderDetail]    Script Date: 16/05/2023 14:02:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbOrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [nvarchar](255) NOT NULL,
	[BookId] [int] NOT NULL,
	[OrderCode] [nvarchar](255) NULL,
	[Price] [decimal](18, 2) NULL,
	[UserId] [int] NOT NULL,
	[BookName] [nvarchar](255) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_tbOrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbUser]    Script Date: 16/05/2023 14:02:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[UserRole] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tbUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbWishList]    Script Date: 16/05/2023 14:02:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbWishList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[AccessedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tbWishList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbBook] ON 

INSERT [dbo].[tbBook] ([Id], [Title], [Category], [Author], [Publisher], [PublishDate], [Price], [UploadedDate], [BookUpload], [Thumbnail]) VALUES (1032, N'Life of Pi', N'Adventure, Story', N'Yann Martel', N'Bulky', N'2023-05-06', CAST(700.00 AS Decimal(18, 2)), CAST(N'2023-05-14T17:27:01.167' AS DateTime), N'5a428b63-e5f5-4395-82c7-0c40fadb7523.pdf', N'601145e0-afae-497f-a26b-c204f945b962.jpg')
INSERT [dbo].[tbBook] ([Id], [Title], [Category], [Author], [Publisher], [PublishDate], [Price], [UploadedDate], [BookUpload], [Thumbnail]) VALUES (1034, N'Theory of Everything', N'Knowledge', N'Stephen Hawking', N'CA', N'2022-10-07', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-05-14T17:40:44.820' AS DateTime), N'5e2304aa-817c-41e6-9054-e558ad89dde2.pdf', N'14aaca81-0381-4d68-839d-286a42d48639.jpg')
INSERT [dbo].[tbBook] ([Id], [Title], [Category], [Author], [Publisher], [PublishDate], [Price], [UploadedDate], [BookUpload], [Thumbnail]) VALUES (1035, N'Lion King', N'Adventure', N'John Doe', N'Dulky', N'2022-11-10', CAST(750.00 AS Decimal(18, 2)), CAST(N'2023-05-14T17:42:19.517' AS DateTime), N'2552d4d7-4b19-47eb-a74d-4594f9d950b2.pdf', N'4d293a20-d9fd-4a32-89b7-8aa45c6984c7.jpg')
INSERT [dbo].[tbBook] ([Id], [Title], [Category], [Author], [Publisher], [PublishDate], [Price], [UploadedDate], [BookUpload], [Thumbnail]) VALUES (1036, N'Lord of the Ring', N'Adventure', N'dunno', N'dunno', N'2023-02-03', CAST(800.00 AS Decimal(18, 2)), CAST(N'2023-05-14T17:42:59.380' AS DateTime), N'dc56d8ac-10eb-43b0-b967-8fc08acb0d49.pdf', N'91fec76e-8249-4e48-9d3a-f3f4997c0b72.jpg')
INSERT [dbo].[tbBook] ([Id], [Title], [Category], [Author], [Publisher], [PublishDate], [Price], [UploadedDate], [BookUpload], [Thumbnail]) VALUES (1037, N'Interstellar', N'Sci-Fi', N'Christopher Nolan', N'Bulky', N'2014-06-15', CAST(1250.00 AS Decimal(18, 2)), CAST(N'2023-05-14T17:43:43.103' AS DateTime), N'dffe1080-7470-4591-99cc-babe82d3d8dc.pdf', N'dd7b1157-e96b-49c2-921d-80a0b5489318.jpg')
INSERT [dbo].[tbBook] ([Id], [Title], [Category], [Author], [Publisher], [PublishDate], [Price], [UploadedDate], [BookUpload], [Thumbnail]) VALUES (1047, N'Look', N'Sci-Fi', N'Me', N'dunno', N'2023-05-02', CAST(600.00 AS Decimal(18, 2)), CAST(N'2023-05-15T12:00:51.603' AS DateTime), N'2e196223-8b96-4da7-b8ee-6bb4b37c863e.pdf', NULL)
INSERT [dbo].[tbBook] ([Id], [Title], [Category], [Author], [Publisher], [PublishDate], [Price], [UploadedDate], [BookUpload], [Thumbnail]) VALUES (1048, N'asdf', N'Sci-Fi', N'asd', N'asd', N'2023-05-18', CAST(69696.00 AS Decimal(18, 2)), CAST(N'2023-05-15T14:17:20.213' AS DateTime), N'3efd6957-1024-4715-a764-8e38424c6cf2.pdf', NULL)
INSERT [dbo].[tbBook] ([Id], [Title], [Category], [Author], [Publisher], [PublishDate], [Price], [UploadedDate], [BookUpload], [Thumbnail]) VALUES (1049, N'sasdfasd', N'Sci-Fi', N'asdf', N'asdf', N'2023-05-01', CAST(5005.00 AS Decimal(18, 2)), CAST(N'2023-05-15T14:17:55.263' AS DateTime), N'441f1342-16c5-46cd-b92d-ca4e6d41da0f.pdf', NULL)
INSERT [dbo].[tbBook] ([Id], [Title], [Category], [Author], [Publisher], [PublishDate], [Price], [UploadedDate], [BookUpload], [Thumbnail]) VALUES (1050, N'adsfasd', N'Thriller', N'asd', N'ddd', N'2023-05-05', CAST(505.00 AS Decimal(18, 2)), CAST(N'2023-05-15T14:18:12.077' AS DateTime), N'187ff695-bff3-4e9e-83c5-acea0eecce76.pdf', NULL)
INSERT [dbo].[tbBook] ([Id], [Title], [Category], [Author], [Publisher], [PublishDate], [Price], [UploadedDate], [BookUpload], [Thumbnail]) VALUES (1051, N'test book next page', N'Sci-Fi', N'dunno', N'dunno', N'2023-05-04', CAST(550.00 AS Decimal(18, 2)), CAST(N'2023-05-15T14:36:07.343' AS DateTime), N'ef695238-a391-4df6-a365-fe7e4a26715e.pdf', NULL)
SET IDENTITY_INSERT [dbo].[tbBook] OFF
GO
SET IDENTITY_INSERT [dbo].[tbCategory] ON 

INSERT [dbo].[tbCategory] ([Id], [Category], [BookCount]) VALUES (3, N'Thriller', 1)
INSERT [dbo].[tbCategory] ([Id], [Category], [BookCount]) VALUES (4, N'Sci-Fi', 5)
INSERT [dbo].[tbCategory] ([Id], [Category], [BookCount]) VALUES (5, N'Adventure', 2)
INSERT [dbo].[tbCategory] ([Id], [Category], [BookCount]) VALUES (6, N'Story', 0)
INSERT [dbo].[tbCategory] ([Id], [Category], [BookCount]) VALUES (7, N'Knowledge', 1)
SET IDENTITY_INSERT [dbo].[tbCategory] OFF
GO
INSERT [dbo].[tbOrder] ([Id], [UserId], [OrderCode], [TotalAmount], [TotalBooks], [OrderedTime]) VALUES (N'9136b4df-d9e7-42ef-8499-b8bb0bc2d1e9', 11, N'47509E', CAST(4275.00 AS Decimal(18, 2)), 5, CAST(N'2023-05-15T13:01:50.290' AS DateTime))
INSERT [dbo].[tbOrder] ([Id], [UserId], [OrderCode], [TotalAmount], [TotalBooks], [OrderedTime]) VALUES (N'ba9a5d53-448f-4ff5-8aa0-1fc7b7598777', 11, N'607D4F', CAST(1800.00 AS Decimal(18, 2)), 2, CAST(N'2023-05-15T16:09:07.880' AS DateTime))
INSERT [dbo].[tbOrder] ([Id], [UserId], [OrderCode], [TotalAmount], [TotalBooks], [OrderedTime]) VALUES (N'f249cdf7-2ed1-4973-8285-34695c255aad', 11, N'D673E3', CAST(4005.00 AS Decimal(18, 2)), 5, CAST(N'2023-05-15T22:18:14.140' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tbOrderDetail] ON 

INSERT [dbo].[tbOrderDetail] ([Id], [OrderId], [BookId], [OrderCode], [Price], [UserId], [BookName], [Quantity]) VALUES (107, N'9136b4df-d9e7-42ef-8499-b8bb0bc2d1e9', 1034, N'47509E', CAST(3000.00 AS Decimal(18, 2)), 11, N'Theory of Everything', 3)
INSERT [dbo].[tbOrderDetail] ([Id], [OrderId], [BookId], [OrderCode], [Price], [UserId], [BookName], [Quantity]) VALUES (108, N'9136b4df-d9e7-42ef-8499-b8bb0bc2d1e9', 1035, N'47509E', CAST(1500.00 AS Decimal(18, 2)), 11, N'Lion King', 2)
INSERT [dbo].[tbOrderDetail] ([Id], [OrderId], [BookId], [OrderCode], [Price], [UserId], [BookName], [Quantity]) VALUES (109, N'ba9a5d53-448f-4ff5-8aa0-1fc7b7598777', 1034, N'607D4F', CAST(2000.00 AS Decimal(18, 2)), 11, N'Theory of Everything', 2)
INSERT [dbo].[tbOrderDetail] ([Id], [OrderId], [BookId], [OrderCode], [Price], [UserId], [BookName], [Quantity]) VALUES (1109, N'f249cdf7-2ed1-4973-8285-34695c255aad', 1034, N'D673E3', CAST(3000.00 AS Decimal(18, 2)), 11, N'Theory of Everything', 3)
INSERT [dbo].[tbOrderDetail] ([Id], [OrderId], [BookId], [OrderCode], [Price], [UserId], [BookName], [Quantity]) VALUES (1110, N'f249cdf7-2ed1-4973-8285-34695c255aad', 1035, N'D673E3', CAST(1500.00 AS Decimal(18, 2)), 11, N'Lion King', 2)
SET IDENTITY_INSERT [dbo].[tbOrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[tbUser] ON 

INSERT [dbo].[tbUser] ([Id], [Name], [Email], [Password], [UserRole], [CreatedDate]) VALUES (1, N'Chan Nyein Kyaw', N'chan@gmail.com', N'123', N'Admin', CAST(N'2023-05-02T00:00:00.000' AS DateTime))
INSERT [dbo].[tbUser] ([Id], [Name], [Email], [Password], [UserRole], [CreatedDate]) VALUES (11, N'CNK123', N'neo@gmail.com', N'123', N'User', CAST(N'2023-05-05T10:03:33.083' AS DateTime))
INSERT [dbo].[tbUser] ([Id], [Name], [Email], [Password], [UserRole], [CreatedDate]) VALUES (1012, N'test', N'test@gmail.com', N'123', N'User', CAST(N'2023-05-09T10:22:49.690' AS DateTime))
INSERT [dbo].[tbUser] ([Id], [Name], [Email], [Password], [UserRole], [CreatedDate]) VALUES (1015, N'a_test', N'a_test@gmail.com', N'123', N'User', CAST(N'2023-05-12T13:17:34.353' AS DateTime))
INSERT [dbo].[tbUser] ([Id], [Name], [Email], [Password], [UserRole], [CreatedDate]) VALUES (1018, N'a_admin', N'a_admin@gmail.com', N'123', N'Admin', CAST(N'2023-05-12T13:27:44.967' AS DateTime))
INSERT [dbo].[tbUser] ([Id], [Name], [Email], [Password], [UserRole], [CreatedDate]) VALUES (1019, N'test4', N'test4@gmail.com', N'123', N'User', CAST(N'2023-05-12T13:28:01.350' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbUser] OFF
GO
SET IDENTITY_INSERT [dbo].[tbWishList] ON 

INSERT [dbo].[tbWishList] ([Id], [UserId], [BookId], [AccessedTime]) VALUES (22, 12, 1034, CAST(N'2023-05-16T11:45:19.407' AS DateTime))
INSERT [dbo].[tbWishList] ([Id], [UserId], [BookId], [AccessedTime]) VALUES (92, 1012, 1034, CAST(N'2023-05-16T13:57:37.847' AS DateTime))
INSERT [dbo].[tbWishList] ([Id], [UserId], [BookId], [AccessedTime]) VALUES (93, 1012, 1035, CAST(N'2023-05-16T13:57:38.697' AS DateTime))
INSERT [dbo].[tbWishList] ([Id], [UserId], [BookId], [AccessedTime]) VALUES (94, 1012, 1032, CAST(N'2023-05-16T13:57:40.893' AS DateTime))
INSERT [dbo].[tbWishList] ([Id], [UserId], [BookId], [AccessedTime]) VALUES (95, 1012, 1049, CAST(N'2023-05-16T13:57:49.067' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbWishList] OFF
GO
