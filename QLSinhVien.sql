USE [QLSinhVien]
GO
/****** Object:  Table [dbo].[LopHoc]    Script Date: 12/29/2021 6:54:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_LopHoc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 12/29/2021 6:54:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDStudent] [varchar](20) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DOB] [date] NULL,
	[POB] [nvarchar](50) NULL,
	[IDLopHoc] [bigint] NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LopHoc] ON 

INSERT [dbo].[LopHoc] ([ID], [Name]) VALUES (1, N'CNTTK41A')
INSERT [dbo].[LopHoc] ([ID], [Name]) VALUES (2, N'CNTTK41B')
INSERT [dbo].[LopHoc] ([ID], [Name]) VALUES (3, N'CNTTK42C')
INSERT [dbo].[LopHoc] ([ID], [Name]) VALUES (4, N'CNTTK42D')
INSERT [dbo].[LopHoc] ([ID], [Name]) VALUES (5, N'CNTTK42K')
SET IDENTITY_INSERT [dbo].[LopHoc] OFF
GO
SET IDENTITY_INSERT [dbo].[SinhVien] ON 

INSERT [dbo].[SinhVien] ([ID], [IDStudent], [FirstName], [LastName], [DOB], [POB], [IDLopHoc]) VALUES (2, N'10002', N'Chang Wook', N'Ji', CAST(N'2000-08-12' AS Date), N'Hàn Quốc', 1)
INSERT [dbo].[SinhVien] ([ID], [IDStudent], [FirstName], [LastName], [DOB], [POB], [IDLopHoc]) VALUES (3, N'15545', N'Ngọc Như', N'Lê', CAST(N'2000-11-20' AS Date), N'Huế', 3)
INSERT [dbo].[SinhVien] ([ID], [IDStudent], [FirstName], [LastName], [DOB], [POB], [IDLopHoc]) VALUES (4, N'10009', N'Anh Minh', N'Trần', CAST(N'2000-11-20' AS Date), N'Đà Nẵng', 2)
SET IDENTITY_INSERT [dbo].[SinhVien] OFF
GO
