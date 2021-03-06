USE [master]
GO
/****** Object:  Database [VMO_HotelManagement]    Script Date: 5/26/2022 10:19:55 AM ******/
CREATE DATABASE [VMO_HotelManagement]
GO
USE [VMO_HotelManagement]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 5/26/2022 10:19:57 AM ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
/****** Object:  UserDefinedFunction [dbo].[reserv_id_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[reserv_id_get] (@cus_id int, @room_type_id int) RETURNS INTEGER
AS
BEGIN
	DECLARE @id INTEGER
	SET @id= (SELECT TOP 1 rs.[reservation_id]
					FROM [dbo].[reservation] rs
					WHERE rs.[customer_id] = @cus_id AND rs.[expected_room_type_id] = @room_type_id
					ORDER BY rs.[reservation_id] desc)
	RETURN @id
END
GO
/****** Object:  UserDefinedFunction [dbo].[reserv_id_get2]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[reserv_id_get2] (@cus_id int, @room_id int) RETURNS INTEGER
AS
BEGIN
	DECLARE @id INTEGER
	SET @id= (SELECT TOP 1 rc.[reservation_id]
					FROM [dbo].[reception] rc
					WHERE rc.[room_id] = @room_id AND rc.[customer_id] = @cus_id AND rc.[reception_status] = 'In Progress'
					ORDER BY rc.[reception_id] desc)
	RETURN @id
END
GO
/****** Object:  UserDefinedFunction [dbo].[room_status_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[room_status_get] (@room_id int) RETURNS INTEGER
AS
BEGIN
	DECLARE @id INTEGER
	SET @id= (SELECT TOP 1 r.[room_status_id] 
					FROM [dbo].[room] r 
					WHERE r.[room_id] = @room_id AND r.[room_status_id] IN (2, 3))
	RETURN @id
END
GO
/****** Object:  UserDefinedFunction [dbo].[top_available_room_by_type_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[top_available_room_info_by_type_get] '10'

-- FUNCTION GET TOP AVAILABLE ROOM BY ROOM TYPE
CREATE FUNCTION [dbo].[top_available_room_by_type_get] (@type int) RETURNS INTEGER
AS
BEGIN
	DECLARE @id INTEGER
	SET @id= (SELECT TOP 1 r.[room_id]
				FROM [dbo].[roomType] rt, [dbo].[roomStatus] rs, [dbo].[room] r
				WHERE rt.[room_type_id] = r.[room_type_id] AND rs.[room_status_id] = r.[room_status_id] AND r.[room_status_id] IN (1, 6) AND r.[room_type_id] = @type
				ORDER BY r.[room_type_id])
	RETURN @id
END
GO
/****** Object:  UserDefinedFunction [dbo].[top_reserv_available_room_by_type_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[top_reserv_available_room_by_type_get] (@type int) RETURNS INTEGER
AS
BEGIN
	DECLARE @id INTEGER
	SET @id= (SELECT TOP 1 r.[room_id]
					FROM [dbo].[roomType] rt, [dbo].[roomStatus] rs, [dbo].[room] r
					WHERE rt.[room_type_id] = r.[room_type_id] AND rs.[room_status_id] = r.[room_status_id] AND r.[room_status_id] IN (2, 3) AND r.[room_type_id] = @type
					ORDER BY r.[room_type_id])
	RETURN @id
END
GO
/****** Object:  Table [dbo].[account]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[acc_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[emp_id] [int] NULL,
	[acc_username] [varchar](60) NOT NULL,
	[acc_password] [varchar](60) NOT NULL,
	[role_id] [int] NOT NULL,
	[acc_session] [varchar](200) NULL,
	[raw_password] [varchar](50) NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[acc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[customer_id] [int] NOT NULL,
	[customer_first_name] [nvarchar](50) NULL,
	[customer_last_name] [nvarchar](50) NULL,
	[customer_address] [varchar](100) NULL,
	[customer_contact_number] [varchar](50) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[emp_id] [int] NOT NULL,
	[emp_name] [nvarchar](50) NULL,
	[emp_position] [varchar](50) NULL,
	[emp_dob] [date] NULL,
	[emp_contact_number] [varchar](50) NULL,
	[emp_identity_number] [numeric](15, 0) NOT NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment](
	[payment_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[payment_type_id] [int] NOT NULL,
	[reservation_id] [int] NOT NULL,
	[payment_amount] [decimal](10, 2) NULL,
	[payment_date] [datetime] NULL,
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[paymentType]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paymentType](
	[payment_type_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[payment_type_name] [varchar](50) NULL,
 CONSTRAINT [PK_paymentType] PRIMARY KEY CLUSTERED 
(
	[payment_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reception]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reception](
	[reception_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[customer_id] [varchar](50) NOT NULL,
	[reservation_id] [int] NOT NULL,
	[room_id] [int] NOT NULL,
	[check_in_date] [datetime] NOT NULL,
	[expected_check_out_date] [datetime] NOT NULL,
	[check_out_date] [datetime] NULL,
	[reception_status] [varchar](50) NULL,
 CONSTRAINT [PK_reception] PRIMARY KEY CLUSTERED 
(
	[reception_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reservation]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservation](
	[reservation_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[customer_id] [int] NOT NULL,
	[expected_check_in_date] [datetime] NOT NULL,
	[day_stay_number] [int] NOT NULL,
	[expected_room_type_id] [varchar](50) NOT NULL,
	[reservation_status] [varchar](50) NULL,
 CONSTRAINT [PK_reservation] PRIMARY KEY CLUSTERED 
(
	[reservation_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[role_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[role_name] [varchar](50) NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[room]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[room](
	[room_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[room_number] [int] NULL,
	[room_type_id] [int] NULL,
	[room_status_id] [int] NULL,
 CONSTRAINT [PK_room] PRIMARY KEY CLUSTERED 
(
	[room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roomStatus]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roomStatus](
	[room_status_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[room_status_name] [varchar](50) NULL,
 CONSTRAINT [PK_roomStatus] PRIMARY KEY CLUSTERED 
(
	[room_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roomType]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roomType](
	[room_type_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[room_type_name] [varchar](50) NULL,
 CONSTRAINT [PK_roomType] PRIMARY KEY CLUSTERED 
(
	[room_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userSessions]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userSessions](
	[Id] [nvarchar](449) NOT NULL,
	[Value] [varbinary](max) NOT NULL,
	[ExpiresAtTime] [datetimeoffset](7) NOT NULL,
	[SlidingExpirationInSeconds] [bigint] NULL,
	[AbsoluteExpiration] [datetimeoffset](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[account] ON 

INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (1, 1, N'thanhtung', N'$2a$13$juh.DMRv6gVSGOxYhpYWX.naPhwspKOd.abEVc.VhVk9tc2JODQWq', 1, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJpZCI6IjEwOTkwMjY0MTciLCJuYmYiOjE2NTM1MzM0MjIsImV4cCI6MTY1MzU0MDYyMiwiaWF0IjoxNjUzNTMzNDIyfQ.Ef5MRIf5VxeGA-fa_MAT9Vy7MPYmmHiy4gRtt77rWpU', N'tung')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (2, 2, N'khanhvy', N'$2a$13$mV5QS7CAFMCf3Do77eHqiOLosCqvhWbGeYoWDcvXEXZJkByB9HA46', 2, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJpZCI6IjEwOTkwMjY0MTgiLCJuYmYiOjE2NTM1MzM1MjcsImV4cCI6MTY1MzU0MDcyNywiaWF0IjoxNjUzNTMzNTI3fQ.vs6s0b8dtqrhSwjIe0IFKN3zfijood4_ldIS_8MQI6c', N'vy')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (3, 3, N'linhlan', N'$2a$13$9CBOT0s8u3RByJNj6GTFQuzQ/cdix/g0A22W7ZO20m46vgwmui7Ie', 1, NULL, N'lan')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (4, 4, N'thanhlong', N'$2y$13$jgdVAYsjNHJl1eDCHver9.J00DWvxCOGmHXeGsjzZfDmQWxICBobq', 1, NULL, N'long')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (6, 6, N'hoangviet', N'$2y$13$eJ1g2yoYPq8/DHgvF8uUyeP99YF11SXsrXdLf1irCc5FhxPW9QAq2', 3, NULL, N'viet')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (8, 8, N'thuydung', N'$2y$13$UBelcbz.yFyZDnAquNStX.OcehtQL64Bi0VNVNWDmzNGBxK31RNwW', 4, NULL, N'dung')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (9, 9, N'phuongthao', N'$2y$13$2lcRK3cqydUhPKjB8wnIA..rRf8u1Znmm2SBA0pFbq6a0V4YTKevu', 6, NULL, N'thao')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (12, 7, N'hoangminh', N'$2y$13$pGC..hedHOqfstf8OLWWpe6mBaEzT0A7sYq4NriqT0FNfVPUvnZ2G', 5, NULL, N'minh')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (16, 10, N'anhquan', N'$2y$13$VZinCr21fEJopiJvdNN9nucm9a.fn3DLQ3aPSSemhreBIYBRk7xDG', 5, NULL, N'quan')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (19, 11, N'dotoan', N'$2y$13$1ImBJWG9Ea2eemEZfnktNet6mYzPap2fAc6fCq/5bQr6b23hmmhc2', 6, NULL, N'toan')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (31, 5, N'ngochoang1', N'$2y$13$vy1IRvvpbz.KksVyUUIPEOoruMfGO7HCylaS/RaHX7jxiiBplLzai', 5, NULL, N'hoang')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (33, 13, N'khanhly', N'$2y$13$HLco5i5MedYZp1hPVydzXu2k5RMH86HJ.MSSrR6kDjzyTCg1Qe89i', 4, NULL, N'ly')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (34, 14, N'leonguyen', N'$2a$13$uSrgI51MvgSINrBGB/oPAeXdqq8.wGBHALPbCc3iGHRwEEnuDT4s6', 5, NULL, N'leo')
INSERT [dbo].[account] ([acc_id], [emp_id], [acc_username], [acc_password], [role_id], [acc_session], [raw_password]) VALUES (35, 15, N'linhtrang', N'$2a$13$vwYly9I8vHRw/Tfx2xCRkOldu351zZSzElfZLX4Eai6yLdDRrWRn6', 5, NULL, N'trang')
SET IDENTITY_INSERT [dbo].[account] OFF
GO
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (1, N'Van Thoang', N'Hoang', N'Kham Thien - Dong Da', N'0123456789')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (2, N'Van Hau', N'Tran', N'Hoan Kiem - HBT - HN', N'0123456788')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (3, N'Van Thinh', N'Trinh', N'Hoang Quoc Viet - Bac Tu Liem', N'0123456787')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (4, N'Van Tung', N'Dang', N'Xuan Thuy - Cau Giay', N'0123456786')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (5, N'Thuy Hang', N'Hoang', N'Dong Tam - HBT - HN', N'0123456785')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (6, N'Khanh Vy', N'Phan', N'Dong Tam - HBT - HN', N'0123456787')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (7, N'Thanh Tung', N'Nguyen', N'Cau Giay - Ha Noi', N'0123456786')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (8, N'Ngoc Hoang', N'Hoang', N'Kung Dinh - Sky', N'0983275388')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (9, N'Hoang Khoa', N'Nguyen', N'Ho Chi Minh', N'0913275380')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (10, N'Ly Ly', N'Pham', N'Ho Chi Minh', N'0913275888')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (11, N'Thu Phuong', N'Nguyen', N'2cngõ 144/4 Quan Nhân, Nhân Chính, Thanh Xuân', N'0903253626')
INSERT [dbo].[customer] ([customer_id], [customer_first_name], [customer_last_name], [customer_address], [customer_contact_number]) VALUES (12, N'Hoang Dung', N'Nguyen', N'Da Nang', N'0913275381')
GO
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (0, N'Ngoc Hoang Hoang', N'Ground Floor', CAST(N'1999-11-03' AS Date), N'0983275386', CAST(1099026416 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (1, N'Thanh Tung', N'Ground Floor', CAST(N'1999-03-10' AS Date), N'0123456798', CAST(1099026417 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (2, N'Khanh Vy', N'Second Floor', CAST(N'2004-04-17' AS Date), N'0123456797', CAST(1099026418 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (3, N'Linh Lan', N'Third Floor', CAST(N'1972-04-07' AS Date), N'0123456796', CAST(1099026419 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (4, N'Thanh Long', N'Ground Floor', CAST(N'1970-08-25' AS Date), N'0123456795', CAST(1099026420 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (6, N'Hoang Viet', N'Second Floor', CAST(N'1999-05-28' AS Date), N'0123456794', CAST(1099026421 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (8, N'Thuy Dung', N'Second Floor', CAST(N'1999-10-03' AS Date), N'0123456793', CAST(1099026422 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (9, N'Phuong Thao', N'Fourth Floor', CAST(N'1999-10-03' AS Date), N'0987776892', CAST(1099026423 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (10, N'Anh Quan', N'Ground Floor', CAST(N'1999-02-01' AS Date), N'0913275383', CAST(1099026424 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (11, N'Do Toan', N'Ground Floor', CAST(N'1999-09-03' AS Date), N'0902273356', CAST(1099026425 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (12, N'Hoang Minh', N'Fourth Floor', CAST(N'1995-07-22' AS Date), N'0123456791', CAST(1099026426 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (13, N'Khanh Ly', N'Ground Floor', CAST(N'1998-10-09' AS Date), N'0983275380', CAST(1099026415 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (14, N'Leo', N'Fourth Floor', CAST(N'1997-01-02' AS Date), N'0902273351', CAST(1099026414 AS Numeric(15, 0)))
INSERT [dbo].[employee] ([emp_id], [emp_name], [emp_position], [emp_dob], [emp_contact_number], [emp_identity_number]) VALUES (15, N'Linh Trang ', N'Fourth Floor', CAST(N'1999-01-29' AS Date), N'0903253626', CAST(1099026413 AS Numeric(15, 0)))
GO
SET IDENTITY_INSERT [dbo].[payment] ON 

INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (1, 1, 5, CAST(100000.00 AS Decimal(10, 2)), CAST(N'2022-04-29T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (2, 1, 6, CAST(80000.00 AS Decimal(10, 2)), CAST(N'2022-05-04T09:46:45.040' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (3, 1, 8, CAST(95000.00 AS Decimal(10, 2)), CAST(N'2022-05-03T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (4, 1, 9, CAST(90000.00 AS Decimal(10, 2)), CAST(N'2022-05-05T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (5, 1, 7, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-04-29T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (8, 1, 17, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-04-25T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (11, 1, 5, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-11T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (12, 1, 22, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-19T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (13, 1, 21, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-22T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (14, 1, 24, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-23T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (15, 1, 26, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-24T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (16, 1, 27, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (17, 1, 28, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-24T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (21, 1, 36, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (22, 1, 34, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-26T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (23, 1, 25, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (24, 1, 38, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (25, 1, 39, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[payment] ([payment_id], [payment_type_id], [reservation_id], [payment_amount], [payment_date]) VALUES (26, 1, 37, CAST(85000.00 AS Decimal(10, 2)), CAST(N'2022-05-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[payment] OFF
GO
SET IDENTITY_INSERT [dbo].[paymentType] ON 

INSERT [dbo].[paymentType] ([payment_type_id], [payment_type_name]) VALUES (1, N'Cash')
INSERT [dbo].[paymentType] ([payment_type_id], [payment_type_name]) VALUES (2, N'Credit Card')
INSERT [dbo].[paymentType] ([payment_type_id], [payment_type_name]) VALUES (3, N'Debit Card')
SET IDENTITY_INSERT [dbo].[paymentType] OFF
GO
SET IDENTITY_INSERT [dbo].[reception] ON 

INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (9, N'4', 5, 5, CAST(N'2022-04-28T00:00:00.000' AS DateTime), CAST(N'2022-04-29T00:00:00.000' AS DateTime), CAST(N'2022-04-29T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (10, N'3', 6, 6, CAST(N'2022-05-02T08:59:24.943' AS DateTime), CAST(N'2022-05-04T08:59:24.943' AS DateTime), CAST(N'2022-05-04T09:46:45.040' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (15, N'2', 8, 3, CAST(N'2022-05-01T00:00:00.000' AS DateTime), CAST(N'2022-05-03T00:00:00.000' AS DateTime), CAST(N'2022-05-03T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (17, N'5', 9, 1, CAST(N'2022-05-05T00:00:00.000' AS DateTime), CAST(N'2022-05-08T00:00:00.000' AS DateTime), CAST(N'2022-05-26T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (18, N'1', 7, 2, CAST(N'2022-04-29T00:00:00.000' AS DateTime), CAST(N'2022-04-30T00:00:00.000' AS DateTime), CAST(N'2022-04-30T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (20, N'5', 17, 4, CAST(N'2022-04-25T00:00:00.000' AS DateTime), CAST(N'2022-04-30T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (21, N'4', 5, 5, CAST(N'2022-04-28T00:00:00.000' AS DateTime), CAST(N'2022-04-29T00:00:00.000' AS DateTime), CAST(N'2022-04-29T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (23, N'5', 9, 1, CAST(N'2022-05-05T00:00:00.000' AS DateTime), CAST(N'2022-05-08T00:00:00.000' AS DateTime), CAST(N'2022-05-26T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (24, N'9', 22, 1, CAST(N'2022-05-20T00:00:00.000' AS DateTime), CAST(N'2022-05-22T00:00:00.000' AS DateTime), CAST(N'2022-05-26T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (25, N'4', 5, 5, CAST(N'2022-04-28T00:00:00.000' AS DateTime), CAST(N'2022-04-29T00:00:00.000' AS DateTime), CAST(N'2022-04-29T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (26, N'9', 21, 5, CAST(N'2022-05-20T00:00:00.000' AS DateTime), CAST(N'2022-05-22T00:00:00.000' AS DateTime), CAST(N'2022-05-22T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (27, N'2', 24, 5, CAST(N'2022-05-24T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (28, N'2', 25, 12, CAST(N'2022-05-24T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (29, N'5', 26, 1, CAST(N'2022-05-28T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime), CAST(N'2022-05-26T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (33, N'9', 27, 4, CAST(N'2022-05-24T00:00:00.000' AS DateTime), CAST(N'2022-05-26T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (34, N'5', 28, 11, CAST(N'2022-05-24T00:00:00.000' AS DateTime), CAST(N'2022-05-27T00:00:00.000' AS DateTime), CAST(N'2022-05-27T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (35, N'6', 34, 13, CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-26T00:00:00.000' AS DateTime), CAST(N'2022-05-26T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (36, N'7', 36, 15, CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (37, N'5', 37, 5, CAST(N'2022-05-26T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime), N'Done')
INSERT [dbo].[reception] ([reception_id], [customer_id], [reservation_id], [room_id], [check_in_date], [expected_check_out_date], [check_out_date], [reception_status]) VALUES (38, N'12', 38, 4, CAST(N'2022-05-27T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime), NULL, N'In Progress')
SET IDENTITY_INSERT [dbo].[reception] OFF
GO
SET IDENTITY_INSERT [dbo].[reservation] ON 

INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (5, 4, CAST(N'2022-04-28T00:00:00.000' AS DateTime), 1, N'5', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (6, 3, CAST(N'2022-05-02T00:00:00.000' AS DateTime), 2, N'3', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (7, 1, CAST(N'2022-04-29T00:00:00.000' AS DateTime), 1, N'2', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (8, 2, CAST(N'2022-05-01T00:00:00.000' AS DateTime), 2, N'3', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (9, 5, CAST(N'2022-05-05T00:00:00.000' AS DateTime), 3, N'1', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (17, 5, CAST(N'2022-04-25T00:00:00.000' AS DateTime), 5, N'4', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (21, 9, CAST(N'2022-05-20T00:00:00.000' AS DateTime), 2, N'5', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (22, 9, CAST(N'2022-05-20T00:00:00.000' AS DateTime), 2, N'1', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (23, 5, CAST(N'2022-05-19T00:00:00.000' AS DateTime), 1, N'2', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (24, 2, CAST(N'2022-05-24T00:00:00.000' AS DateTime), 1, N'5', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (25, 2, CAST(N'2022-05-24T00:00:00.000' AS DateTime), 1, N'6', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (26, 5, CAST(N'2022-05-28T00:00:00.000' AS DateTime), 2, N'1', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (27, 9, CAST(N'2022-05-24T00:00:00.000' AS DateTime), 2, N'4', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (28, 5, CAST(N'2022-05-24T00:00:00.000' AS DateTime), 3, N'5', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (34, 6, CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'5', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (36, 7, CAST(N'2022-05-25T00:00:00.000' AS DateTime), 5, N'5', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (37, 5, CAST(N'2022-05-26T00:00:00.000' AS DateTime), 4, N'5', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (38, 12, CAST(N'2022-05-27T00:00:00.000' AS DateTime), 3, N'4', N'Done')
INSERT [dbo].[reservation] ([reservation_id], [customer_id], [expected_check_in_date], [day_stay_number], [expected_room_type_id], [reservation_status]) VALUES (39, 6, CAST(N'2022-05-28T00:00:00.000' AS DateTime), 2, N'6', N'In Progress')
SET IDENTITY_INSERT [dbo].[reservation] OFF
GO
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([role_id], [role_name]) VALUES (1, N'Manager')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (2, N'Security')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (3, N'Cleaner')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (4, N'Chief')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (5, N'Intern')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (6, N'Accountant')
SET IDENTITY_INSERT [dbo].[role] OFF
GO
SET IDENTITY_INSERT [dbo].[room] ON 

INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (1, 101, 1, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (2, 102, 2, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (3, 103, 3, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (4, 104, 4, 5)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (5, 105, 5, 6)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (6, 106, 3, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (7, 201, 4, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (8, 202, 4, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (9, 203, 3, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (10, 204, 4, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (11, 205, 5, 6)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (12, 206, 6, 3)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (13, 301, 5, 6)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (14, 302, 6, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (15, 303, 5, 6)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (16, 304, 6, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (17, 305, 2, 1)
INSERT [dbo].[room] ([room_id], [room_number], [room_type_id], [room_status_id]) VALUES (18, 306, 1, 1)
SET IDENTITY_INSERT [dbo].[room] OFF
GO
SET IDENTITY_INSERT [dbo].[roomStatus] ON 

INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (1, N'Vacant')
INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (2, N'Booked and UnPaid')
INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (3, N'Booked and Paid')
INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (4, N'Checked In and UnPaid')
INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (5, N'Checked In and Paid')
INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (6, N'Checked Out')
SET IDENTITY_INSERT [dbo].[roomStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[roomType] ON 

INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (1, N'King Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (2, N'Queen Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (3, N'4-people Family Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (4, N'3-people Family Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (5, N'Single Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (6, N'Couple Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (7, N'4-Bunk Room')
SET IDENTITY_INSERT [dbo].[roomType] OFF
GO
INSERT [dbo].[userSessions] ([Id], [Value], [ExpiresAtTime], [SlidingExpirationInSeconds], [AbsoluteExpiration]) VALUES (N'0de3a280-68e6-c1d4-bfe7-c1efa442e88c', 0x0200000047DA6F1307F7432176AC2270827817A7, CAST(N'2022-05-27T02:53:47.4139526+00:00' AS DateTimeOffset), 86400, NULL)
INSERT [dbo].[userSessions] ([Id], [Value], [ExpiresAtTime], [SlidingExpirationInSeconds], [AbsoluteExpiration]) VALUES (N'14d4dbab-b619-f658-5fa4-ac8338545a53', 0x02000005B4E2A0392B2F9661690C20B52D79B344000855736572496E666F0000019B7B226163635F757365726E616D65223A227468616E6874756E67222C226163635F70617373776F7264223A22243261243133246A75682E444D527636675653474F785968705957582E6E6150687773704B4F642E61624556632E5668566B397463324A4F44515771222C226163635F6E616D65223A225468616E682054756E67222C226163635F726F6C65223A224D616E61676572222C226163635F646F62223A22313939392D30332D31305430303A30303A3030222C226163635F636F6E746163745F6E756D626572223A2230313233343536373938222C226163635F73657373696F6E223A2265794A68624763694F694A49557A49314E694973496E523563434936496B705856434A392E65794A755957316C496A6F6956476868626D6767564856755A794973496D35695A6949364D5459314D7A51354D5467354F4377695A586877496A6F784E6A55304D446B324E6A6B344C434A70595851694F6A45324E544D304F5445344F5468392E6B464D476D42315A3464717742425A34686731455135786C66554D776948557832477855375257764F6A67227D00095F757365726E616D65000000097468616E6874756E6700054775657374000000074D616E6167657200055F6E616D650000000A5468616E682054756E6700065F746F6B656E000000B165794A68624763694F694A49557A49314E694973496E523563434936496B705856434A392E65794A755957316C496A6F6956476868626D6767564856755A794973496D35695A6949364D5459314D7A51354D5467354F4377695A586877496A6F784E6A55304D446B324E6A6B344C434A70595851694F6A45324E544D304F5445344F5468392E6B464D476D42315A3464717742425A34686731455135786C66554D776948557832477855375257764F6A67, CAST(N'2022-05-26T15:20:12.0894848+00:00' AS DateTimeOffset), 86400, NULL)
INSERT [dbo].[userSessions] ([Id], [Value], [ExpiresAtTime], [SlidingExpirationInSeconds], [AbsoluteExpiration]) VALUES (N'3ff21b54-edf8-e23b-94c7-fa9af64a839a', 0x020000055BCCE7CD7AD612138253D7D455D5D12E000855736572496E666F000001BF7B226163635F757365726E616D65223A227468616E6874756E67222C226163635F70617373776F7264223A22243261243133246A75682E444D527636675653474F785968705957582E6E6150687773704B4F642E61624556632E5668566B397463324A4F44515771222C226163635F6E616D65223A225468616E682054756E67222C226163635F6964656E746974795F636F6465223A302C226163635F726F6C65223A224D616E61676572222C226163635F646F62223A22313939392D30332D31305430303A30303A3030222C226163635F636F6E746163745F6E756D626572223A2230313233343536373938222C226163635F73657373696F6E223A2265794A68624763694F694A49557A49314E694973496E523563434936496B705856434973496D4E3065534936496B705856434A392E65794A705A434936496A45774F546B774D6A59304D5463694C434A75596D59694F6A45324E544D314D7A4D304D6A4973496D5634634349364D5459314D7A55304D4459794D69776961574630496A6F784E6A557A4E544D7A4E44497966512E4566354D5249663556786547412D66615F4D4154395679374D50596D6D4869793467527474373772577055227D00095F757365726E616D65000000097468616E6874756E6700054775657374000000074D616E6167657200055F6E616D650000000A5468616E682054756E6700065F746F6B656E000000BF65794A68624763694F694A49557A49314E694973496E523563434936496B705856434973496D4E3065534936496B705856434A392E65794A705A434936496A45774F546B774D6A59304D5463694C434A75596D59694F6A45324E544D314D7A4D304D6A4973496D5634634349364D5459314D7A55304D4459794D69776961574630496A6F784E6A557A4E544D7A4E44497966512E4566354D5249663556786547412D66615F4D4154395679374D50596D6D4869793467527474373772577055, CAST(N'2022-05-27T02:53:55.8719626+00:00' AS DateTimeOffset), 86400, NULL)
INSERT [dbo].[userSessions] ([Id], [Value], [ExpiresAtTime], [SlidingExpirationInSeconds], [AbsoluteExpiration]) VALUES (N'646040fd-4706-d6e2-f76f-469845e834e4', 0x02000000617569869EEBA3FBDBD21FF04C82DF38, CAST(N'2022-05-26T10:33:10.2342992+00:00' AS DateTimeOffset), 86400, NULL)
GO
/****** Object:  Index [Index_ExpiresAtTime]    Script Date: 5/26/2022 10:19:58 AM ******/
CREATE NONCLUSTERED INDEX [Index_ExpiresAtTime] ON [dbo].[userSessions]
(
	[ExpiresAtTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[avail_num_room_type_list_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[avail_num_room_type_list_get]
AS
BEGIN
	SELECT r.[room_type_id], COUNT(r.[room_type_id]) 'count'
	FROM [dbo].[room] r
	WHERE r.[room_status_id] IN (1,6)
	GROUP BY r.[room_type_id]
	ORDER BY r.[room_type_id]
END
GO
/****** Object:  StoredProcedure [dbo].[available_room_info_by_type_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[available_room_info_by_type_get] (@type int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [roomType]
		WHERE room_type_id = @type
		)
		BEGIN
			SELECT rt.[room_type_name], r.[room_number], rs.[room_status_name]
			FROM [dbo].[roomType] rt, [dbo].[roomStatus] rs, [dbo].[room] r
			WHERE rt.[room_type_id] = r.[room_type_id] AND rs.[room_status_id] = r.[room_status_id] AND r.[room_status_id] IN (1,6) AND r.[room_type_id] = @type
			ORDER BY r.[room_type_id]
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find room type id = '
			PRINT @IN + CONVERT(varchar,@type,100)
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[available_room_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[customer_info_number_get] '0123456789'


-- GET LIST OF ALL AVAILABLE ROOM
CREATE PROCEDURE [dbo].[available_room_info_get]
AS
BEGIN
	SELECT r.[room_type_id], rt.[room_type_name], r.[room_number], rs.[room_status_name]
	FROM [dbo].[roomType] rt, [dbo].[roomStatus] rs, [dbo].[room] r
	WHERE rt.[room_type_id] = r.[room_type_id] AND rs.[room_status_id] = r.[room_status_id] AND r.[room_status_id] IN (1, 6)
	ORDER BY r.[room_type_id]
END
GO
/****** Object:  StoredProcedure [dbo].[booked_room_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[vacant_room_info_get]

-- GET ALL BOOKED ROOMS
CREATE PROCEDURE [dbo].[booked_room_info_get]
AS
BEGIN
	SELECT r.[room_type_id], r.[room_number], rT.[room_type_name], rS.[room_status_name]
	FROM [dbo].[room] r, [dbo].[roomType] rT, [dbo].[roomStatus] rS
	WHERE r.[room_status_id] = rS.[room_status_id] AND r.[room_type_id] = rT.[room_type_id] AND r.[room_status_id] IN (2, 3)
	ORDER BY r.[room_id]
END
GO
/****** Object:  StoredProcedure [dbo].[cus_id_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[cus_info_delete] '7'

-- GET BASIC INFO OF ONE EMPLOYEE BY ID
CREATE PROCEDURE [dbo].[cus_id_get] (@id int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [customer]
		WHERE customer_id = @id
		)
		BEGIN
			SELECT c.[customer_id], [customer_first_name], [customer_last_name] , c.[customer_address], c.[customer_contact_number]
			FROM [dbo].[customer] c
			WHERE c.[customer_id] = @id
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find customer with id = '
			PRINT @IN + CONVERT(varchar,@id,100)
		END
END
GO
/****** Object:  StoredProcedure [dbo].[cus_info_delete]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[cus_info_get]

-- DELETE CUSTOMER'S INFO BY ID
CREATE PROCEDURE [dbo].[cus_info_delete] (@id int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [customer]
		WHERE customer_id = @id
		)
		BEGIN
			DELETE FROM [customer] WHERE [customer_id] = @id
			PRINT 'Employee Data Deleted'
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find customer with id = '
			PRINT @IN + CONVERT(varchar,@id,100)
		END
END
GO
/****** Object:  StoredProcedure [dbo].[cus_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[emp_id_get] '100'

-- GET LIST OF ALL CUSTOMERS
CREATE PROCEDURE [dbo].[cus_info_get]
AS
BEGIN
	SELECT c.[customer_id], [customer_first_name], [customer_last_name] , c.[customer_address], c.[customer_contact_number]
	FROM [dbo].[customer] c
	ORDER BY c.[customer_id]
END
GO
/****** Object:  StoredProcedure [dbo].[cus_info_insert]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cus_info_insert] (@id int, @fname nvarchar(50), @lname nvarchar(50), @address varchar(50), @num varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [customer]
		WHERE customer_id = @id
		)
		BEGIN
			PRINT 'Account is already in use. Please try another one.'
		END
	ELSE
		BEGIN
			INSERT INTO [dbo].[customer]
					   ([customer_id]
					   ,[customer_first_name]
					   ,[customer_last_name]
					   ,[customer_address]
					   ,[customer_contact_number])
				 VALUES (@id,@fname,@lname,@address,@num)
			PRINT 'New Customer Data Inserted.'
		END
END
GO
/****** Object:  StoredProcedure [dbo].[cus_info_update]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[cus_info_insert] '6','khanhvy1','vy','Khanh Vy','Phan','Hai Ba Trung','0123456787'

-- UPDATE CUSTOMER
CREATE PROCEDURE [dbo].[cus_info_update] (@id int, @fname nvarchar(50), @lname nvarchar(50), @address varchar(50), @num varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [customer]
		WHERE customer_id = @id
		)
		BEGIN
			UPDATE [dbo].[customer]
				SET customer_first_name = @fname, customer_last_name = @lname, customer_address = @address, customer_contact_number = @num
				WHERE customer_id = @id

			PRINT 'Customer Data Updated.'
		END
END
GO
/****** Object:  StoredProcedure [dbo].[customer_and_time_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[customer_and_time_info_get]
AS
BEGIN
	SELECT c.[customer_first_name] + SPACE(1) + c.[customer_last_name] 'customer_full_name', c.[customer_contact_number], c.[customer_address], COUNT(rc.[customer_id]) 'count'
	FROM [dbo].[reception] rc, [dbo].[customer] c
	WHERE rc.[customer_id] = c.[customer_id]
	GROUP BY c.[customer_first_name], c.[customer_last_name], c.[customer_contact_number], c.[customer_address]
	ORDER BY 'count' desc
END
GO
/****** Object:  StoredProcedure [dbo].[customer_by_last_name_search]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[customer_by_name_search] 'a'

-- SEARCH FOR CUSTOMER BY LAST NAME
CREATE PROCEDURE [dbo].[customer_by_last_name_search] (@search_string varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [customer]
		WHERE [customer_last_name] LIKE '%' + @search_string + '%'
		)
		BEGIN
			SELECT *
			FROM [dbo].[customer]
			WHERE [customer_last_name] LIKE '%' + @search_string +'%'
		END
	ELSE
		BEGIN
			PRINT 'There are no customer with such last name.'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[customer_by_name_search]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[least_popular_room_type_get]


-- SEARCH FUNCTION
-- SEARCH FOR CUSTOMER BY FIRST NAME
CREATE PROCEDURE [dbo].[customer_by_name_search] (@search_string varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [customer]
		WHERE [customer_first_name] LIKE '%' + @search_string + '%'
		)
		BEGIN
			SELECT *
			FROM [dbo].[customer]
			WHERE [customer_first_name] LIKE '%' + @search_string +'%'
		END
	ELSE
		BEGIN
			PRINT 'There are no customer with such name.'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[customer_by_num_search]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[customer_by_last_name_search] 'phan'

-- SEARCH FOR CUSTOMER BY CONTACT NUMBER
CREATE PROCEDURE [dbo].[customer_by_num_search] (@search_string varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [customer]
		WHERE [customer_contact_number] = @search_string
		)
		BEGIN
			SELECT *
			FROM [dbo].[customer]
			WHERE [customer_contact_number] = @search_string
		END
	ELSE
		BEGIN
			PRINT 'There are no customer with such number.'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[customer_check_in_room_list]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[customer_check_in_room_list] 
AS
BEGIN
	SELECT c.[customer_id], c.[customer_first_name], c.[customer_last_name], c.[customer_contact_number], r.[room_number], rt.[room_type_name], rst.[room_status_name], rc.[check_in_date], rc.[expected_check_out_date]
		FROM [dbo].[reception] rc, [dbo].[customer] c, [dbo].[room] r, [dbo].[roomType] rt, [dbo].[roomStatus] rst
		WHERE rc.[reception_status] ='In Progress' AND rc.[customer_id] = c.[customer_id] AND r.[room_id] = rc.[room_id] AND rt.[room_type_id] = r.[room_type_id] AND rst.[room_status_id] = r.[room_status_id]
		ORDER BY rc.[reservation_id] desc
END
GO
/****** Object:  StoredProcedure [dbo].[customer_id_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[customer_id_get]
AS
BEGIN
	SELECT TOP 1 c.[customer_id]+1 'customer_id'
	FROM [dbo].[customer] c
	ORDER BY c.[customer_id] desc
END
GO
/****** Object:  StoredProcedure [dbo].[customer_info_number_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[need_clean_room_info_get]

---- GET ROOM BY ROOM TYPE
--CREATE PROCEDURE [dbo].[room_type_info_get]
--AS
--BEGIN
--	SELECT *
--	FROM [dbo].[room] r, [dbo].[roomType] rT
--	WHERE r.[room_type_id] = rT.[room_type_id]
--END
--GO
-- EXEC [dbo].[room_type_info_get]

-- GET CUSTOMER INFO FROM CONTACT NUMBER
CREATE PROCEDURE [dbo].[customer_info_number_get] (@num varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [customer]
		WHERE customer_contact_number = @num
		)
		BEGIN
			SELECT *
			FROM [dbo].[customer] c
			WHERE [customer_contact_number] = @num
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find customer with number = '
			PRINT @IN + CONVERT(varchar,@num,100)
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[customer_reserv_room_by_contact_number]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[customer_reserv_room_by_contact_number] (@num varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [customer]
		WHERE customer_contact_number = @num
		)
		BEGIN
			SELECT rs.[reservation_id], c.[customer_id], c.[customer_first_name], c.[customer_last_name], c.[customer_contact_number], rs.[expected_check_in_date], rs.[day_stay_number], rt.[room_type_name]
			FROM [dbo].[reservation] rs, [dbo].[customer] c, [dbo].[roomType] rt
			WHERE rs.[customer_id] = c.[customer_id] AND c.[customer_contact_number] = @num AND rs.[expected_room_type_id] = rt.[room_type_id] AND rs.[reservation_status] = 'In Progress'
			ORDER BY rs.[reservation_id] desc
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find customer with number = '
			PRINT @IN + CONVERT(varchar,@num,100)
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[customer_reserv_room_list]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[customer_reserv_room_list] 
AS
BEGIN
	SELECT c.[customer_id], c.[customer_first_name], c.[customer_last_name], c.[customer_address], c.[customer_contact_number], rt.[room_type_name], rs.[expected_check_in_date], rs.[expected_check_in_date] + rs.[day_stay_number] 'expected_check_out_date'
	FROM [dbo].[reservation] rs, [dbo].[customer] c, [dbo].[roomType] rt
	WHERE rs.[customer_id] = c.[customer_id] AND rs.[expected_room_type_id] = rt.[room_type_id] AND rs.[reservation_status] = 'In Progress'
	ORDER BY rs.[reservation_id] desc
END
GO
/****** Object:  StoredProcedure [dbo].[emp_id_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[emp_info_delete] '100'

-- GET BASIC INFO OF ONE EMPLOYEE BY ID
CREATE PROCEDURE [dbo].[emp_id_get] (@id int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [employee]
		WHERE emp_id = @id
		)
		BEGIN
			SELECT e.[emp_id], [emp_name], [acc_username], [acc_password], r.[role_id], e.[emp_position], e.[emp_dob], e.[emp_contact_number]
			FROM [dbo].[employee] e, [dbo].[account] a, [dbo].[role] r
			WHERE e.[emp_id] = a.[emp_id] AND a.[role_id] = r.[role_id] AND e.[emp_id] = @id
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find employee with id = '
			PRINT @IN + CONVERT(varchar,@id,100)
		END
END
GO
/****** Object:  StoredProcedure [dbo].[emp_info_delete]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[emp_info_get]

-- DELETE EMPLOYEE'S INFO BY ID
CREATE PROCEDURE [dbo].[emp_info_delete] (@id int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [employee]
		WHERE emp_id = @id
		)
		BEGIN
			DELETE FROM [employee] WHERE [emp_id] = @id
			DELETE FROM [account] WHERE [emp_id] = @id
			PRINT 'Employee Data Deleted'
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find employee with id = '
			PRINT @IN + CONVERT(varchar,@id,100)
		END
END
GO
/****** Object:  StoredProcedure [dbo].[emp_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [dbo].[cus_id_get] '6'
--EXEC [dbo].[cus_info_update] '6','Khanh Vy','Phan','Dong Tam','0123456787'
--EXEC [dbo].[cus_id_get] '6'

-- GET LIST OF ALL EMPLOYEES
CREATE PROCEDURE [dbo].[emp_info_get]
AS
BEGIN
	SELECT e.[emp_id], [emp_name], [acc_username], [acc_password], r.[role_id], e.[emp_position], e.[emp_dob], e.[emp_contact_number]
	FROM [dbo].[employee] e, [dbo].[account] a, [dbo].[role] r
	WHERE e.[emp_id] = a.[emp_id] AND a.[role_id] = r.[role_id]
	ORDER BY e.[emp_id]
END
GO
/****** Object:  StoredProcedure [dbo].[emp_info_get_ex]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[emp_info_get_ex] 
AS

BEGIN
	
	-- get danh sách employee
	SELECT e.emp_id, emp_name, emp_dob, role_name, emp_position, emp_contact_number
	FROM [dbo].[account] a, [dbo].[employee] e, [dbo].[role] r
	WHERE a.[emp_id] = e.[emp_id] and r.[role_id] = a.[role_id]
	ORDER BY a.emp_id ASC

END
GO
/****** Object:  StoredProcedure [dbo].[emp_info_insert]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[emp_info_insert] (@id int, @username varchar(60), @pwd varchar(60), @name nvarchar(50), @pos varchar(50), @dob datetime, @num varchar(50), @role_id int, @identity_num int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [account]
		WHERE acc_username = @username
		) OR EXISTS (SELECT 1 FROM [employee]
		WHERE emp_id = @id
		)
		BEGIN
			PRINT 'Account is already in use. Please try another one.'
		END
	ELSE
		BEGIN
			INSERT INTO [dbo].[account]
						([emp_id]
						,[acc_username]
						,[acc_password]
						,[role_id]) 
				VALUES (@id,@username,@pwd,@role_id)
			INSERT INTO [dbo].[employee]
					   ([emp_id]
					   ,[emp_name]
					   ,[emp_position]
					   ,[emp_dob]
					   ,[emp_contact_number]
					   ,[emp_identity_number])
				VALUES (@id,@name,@pos,@dob,@num,@identity_num)
			PRINT 'New Employee Data Inserted.'
		END
END
GO
/****** Object:  StoredProcedure [dbo].[emp_info_update]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[emp_info_update] (@id int, @name nvarchar(50), @pos varchar(50), @dob datetime, @num varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [employee]
		WHERE emp_id = @id
		)
		BEGIN
			UPDATE [dbo].[employee]
				SET emp_name = @name, emp_position = @pos, emp_dob = @dob, emp_contact_number = @num
				WHERE emp_id = @id

			PRINT 'Employee Data Updated.'
		END
END
GO
/****** Object:  StoredProcedure [dbo].[employee_by_name_search]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[employee_by_name_search] (@search_string varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [employee]
		WHERE [emp_name] LIKE '%' + @search_string + '%'
		)
		BEGIN
			SELECT *
			FROM [dbo].[employee]
			WHERE [emp_name] LIKE '%' + @search_string +'%'
		END
	ELSE
		BEGIN
			PRINT 'There are no employee with such name.'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[employee_by_num_search]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[employee_by_num_search] (@search_string varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [employee]
		WHERE [emp_contact_number] = @search_string
		)
		BEGIN
			SELECT *
			FROM [dbo].[employee]
			WHERE [emp_contact_number] = @search_string
		END
	ELSE
		BEGIN
			PRINT 'There are no employee with such number.'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[employee_id_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[employee_id_get]
AS
BEGIN
	SELECT TOP 1 e.[emp_id]+1 'emp_id'
	FROM [dbo].[employee] e
	ORDER BY e.[emp_id] desc
END
GO
/****** Object:  StoredProcedure [dbo].[in_use_room_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[unpaid_room_info_get]

-- GET ALL ROOMS IN USE
CREATE PROCEDURE [dbo].[in_use_room_info_get]
AS
BEGIN
	SELECT r.[room_type_id], r.[room_number], rT.[room_type_name], rS.[room_status_name]
	FROM [dbo].[room] r, [dbo].[roomType] rT, [dbo].[roomStatus] rs
	WHERE r.[room_type_id] = rT.[room_type_id] AND r.[room_status_id] in (4,5) AND r.[room_status_id] = rs.[room_status_id]
	ORDER BY r.[room_id]
END
GO
/****** Object:  StoredProcedure [dbo].[least_popular_room_type_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[most_popular_room_type_get]

-- LEAST POPULAR ROOM TYPE
CREATE PROCEDURE [dbo].[least_popular_room_type_get]
AS
BEGIN
	SELECT rt.[room_type_name], COUNT(rc.[room_id]) 'count'
	FROM [dbo].[room] r, [dbo].[reservation] rs, [dbo].[reception] rc, [dbo].[roomType] rt
	WHERE r.[room_type_id] = rs.[expected_room_type_id] AND rs.[expected_room_type_id] = rt.[room_type_id] AND rc.[room_id] = r.[room_id]
	GROUP BY rt.[room_type_name]
	ORDER BY 'count' asc
END
GO
/****** Object:  StoredProcedure [dbo].[most_popular_room_type_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[customer_and_time_info_get]

-- MOST POPULAR ROOM TYPE
CREATE PROCEDURE [dbo].[most_popular_room_type_get]
AS
BEGIN
	SELECT rt.[room_type_name], COUNT(rc.[room_id]) 'count'
	FROM [dbo].[room] r, [dbo].[reservation] rs, [dbo].[reception] rc, [dbo].[roomType] rt
	WHERE r.[room_type_id] = rs.[expected_room_type_id] AND rs.[expected_room_type_id] = rt.[room_type_id] AND rc.[room_id] = r.[room_id]
	GROUP BY rt.[room_type_name]
	ORDER BY 'count' desc
END
GO
/****** Object:  StoredProcedure [dbo].[need_clean_room_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[in_use_room_info_get]

-- GET ROOMS NEED TO BE CLEANED
CREATE PROCEDURE [dbo].[need_clean_room_info_get]
AS
BEGIN
	SELECT r.[room_type_id], r.[room_number], rT.[room_type_name], rS.[room_status_name]
	FROM [dbo].[room] r, [dbo].[roomType] rT, [dbo].[roomStatus] rs
	WHERE r.[room_type_id] = rT.[room_type_id] AND r.[room_status_id] = 6 AND r.[room_status_id] = rs.[room_status_id]
	ORDER BY r.[room_id]
END
GO
/****** Object:  StoredProcedure [dbo].[new_account_insert_ex]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[new_account_insert_ex](@id int, @roleID int, @pos varchar(50), @name varchar(50), @dob date, @num varchar(50),@username varchar(50), @psw varchar(50))
AS

BEGIN

	-- insert account mới
	INSERT INTO [dbo].[employee](emp_id, emp_name, emp_position, emp_dob, emp_contact_number)
	VALUES (@id, @name, @pos, @dob, @num)
	INSERT INTO [dbo].[account](acc_id, emp_id, acc_username, acc_password, role_id)
	VALUES (@id, @id, @username, @psw, @roleID)

END
GO
/****** Object:  StoredProcedure [dbo].[order_num_between_dates_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[order_num_between_dates_get] (@date1 datetime, @date2 datetime)
AS
BEGIN
	SELECT @date1 'date1', @date2 'date2', COUNT([customer_id]) 'count'
	FROM [dbo].[reception] rc
	WHERE [check_in_date] >= @date1 AND [expected_check_out_date] <= @date2
END
GO
/****** Object:  StoredProcedure [dbo].[order_num_in_month_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[order_num_in_month_get] (@date datetime)
AS
BEGIN
	SELECT MONTH(@date) 'date1', YEAR(@date) 'date2', COUNT([customer_id]) 'count'
	FROM [dbo].[reception] rc
	WHERE MONTH([check_in_date]) = MONTH(@date) AND MONTH([expected_check_out_date]) = MONTH(@date)
END
GO
/****** Object:  StoredProcedure [dbo].[order_num_in_year_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[order_num_in_year_get] (@date datetime)
AS
BEGIN
	SELECT YEAR(@date) 'date', COUNT([customer_id]) 'count'
	FROM [dbo].[reception] rc
	WHERE YEAR([check_in_date]) = YEAR(@date) AND YEAR([expected_check_out_date]) = YEAR(@date)
END
GO
/****** Object:  StoredProcedure [dbo].[paid_room_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[booked_room_info_get]

-- GET ALL PAID ROOMS
CREATE PROCEDURE [dbo].[paid_room_info_get]
AS
BEGIN
	SELECT r.[room_type_id], r.[room_number], rT.[room_type_name], rS.[room_status_name]
	FROM [dbo].[room] r, [dbo].[roomType] rT, [dbo].[roomStatus] rs
	WHERE r.[room_type_id] = rT.[room_type_id] AND r.[room_status_id] in (3,5) AND r.[room_status_id] = rs.[room_status_id]
	ORDER BY r.[room_id]
END
GO
/****** Object:  StoredProcedure [dbo].[reservation_id_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[reservation_id_get] (@cus_id int, @room_type_id int)
AS
BEGIN
	SELECT TOP 1 rs.[reservation_id]
		FROM [dbo].[reservation] rs
		WHERE rs.[customer_id] = @cus_id AND rs.[expected_room_type_id] = @room_type_id AND rs.[reservation_status] = 'In Progress'
		ORDER BY rs.[reservation_id] desc
END
GO
/****** Object:  StoredProcedure [dbo].[reservation_room_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[reservation_room_get] (@room_type_id int)
AS
BEGIN
	DECLARE @room_id int

	IF EXISTS (SELECT 1 FROM [roomType]
		WHERE room_type_id = @room_type_id
		)
		BEGIN
			SET @room_id = (SELECT [dbo].[top_reserv_available_room_by_type_get] (@room_type_id))

			SELECT @room_id 'room_id', rt.[room_type_name], r.[room_status_id], rs.[expected_check_in_date], rs.[expected_check_in_date] + rs.[day_stay_number] 'expected_check_out_date', c.[customer_first_name] + SPACE(1) + c.[customer_last_name] 'customer_full_name', c.[customer_contact_number]
			FROM [dbo].[reservation] rs, [dbo].[roomType] rt, [dbo].[customer] c, [dbo].[room] r
			WHERE rs.[expected_room_type_id] = rt.[room_type_id] AND rs.[expected_room_type_id] = @room_type_id AND c.[customer_id] = rs.[customer_id] AND r.[room_id] = @room_id AND rs.[reservation_status] = 'In Progress'
			ORDER BY rs.[reservation_id] desc
		END
	ELSE
		BEGIN
			PRINT 'Cannot get information'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[reservation_room_list_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[reservation_room_list_get]
AS
BEGIN
	SELECT rt.[room_type_name], rs.[expected_check_in_date], rs.[expected_check_in_date] + rs.[day_stay_number] 'expected_check_out_date', c.[customer_first_name] + SPACE(1) + c.[customer_last_name] 'customer_full_name', c.[customer_contact_number]
	FROM [dbo].[reservation] rs, [dbo].[customer] c, [dbo].[roomType] rt
	WHERE rt.[room_type_id] = rs.[expected_room_type_id] AND c.[customer_id] = rs.[customer_id] AND rs.[reservation_status] = 'In Progress'
	ORDER BY rs.[reservation_id] desc
END
GO
/****** Object:  StoredProcedure [dbo].[room_booking]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[room_booking] (@cus_id int, @check_in_date datetime, @day int, @room_type_id int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [dbo].[customer]
		WHERE customer_id = @cus_id
		) AND EXISTS (SELECT 1 FROM [dbo].[roomType]
		WHERE room_type_id = @room_type_id
		)
		BEGIN
			INSERT INTO [dbo].[reservation]
						([customer_id]
						,[expected_check_in_date]
						,[day_stay_number]
						,[expected_room_type_id])
				VALUES (@cus_id,@check_in_date,@day,@room_type_id)


			UPDATE [dbo].[room]
				SET room_status_id = 2
				WHERE room_id = [dbo].[top_available_room_by_type_get] (@room_type_id)

			UPDATE [dbo].[reservation]
				SET reservation_status = 'In Progress'
				WHERE reservation_id = [dbo].[reserv_id_get] (@cus_id,@room_type_id)
		END
	ELSE
		BEGIN
			PRINT 'Cannot book room with such information'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[room_checking_in]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[room_checking_in] (@cus_id int, @type int)
AS
BEGIN
	DECLARE @check_in_state int, @room_id int, @reserve_id int
		
	IF EXISTS (SELECT 1 FROM [roomType]
		WHERE room_type_id = @type
		)
		BEGIN
			SET @reserve_id = (SELECT [dbo].[reserv_id_get] (@cus_id, @type))
			SET @room_id = (SELECT [dbo].[top_reserv_available_room_by_type_get] (@type))
			SET @check_in_state = (SELECT [dbo].[room_status_get] (@room_id))
			
			INSERT INTO [dbo].[reception]
						([reservation_id]
						,[customer_id]
						,[room_id]
						,[check_in_date]
						,[expected_check_out_date])
				EXEC [dbo].[top_reservation_room_get] @cus_id, @type

			UPDATE [dbo].[reservation]
				SET reservation_status = 'Done'
				WHERE reservation_id = @reserve_id

			UPDATE [dbo].[reception]
				SET reception_status = 'In Progress'
				WHERE reservation_id = @reserve_id
			
			IF (@check_in_state = 2)
				BEGIN
					UPDATE [dbo].[room]
						SET room_status_id = 4
						WHERE room_id = @room_id
				END
			ELSE IF (@check_in_state = 3)
				BEGIN
					UPDATE [dbo].[room]
						SET room_status_id = 5
						WHERE room_id = @room_id
				END

			SELECT rs.[customer_id], rc.[room_id], rs.[expected_room_type_id] 'room_type_id', rc.[check_in_date], rc.[expected_check_out_date]
				FROM [dbo].[reservation] rs, [dbo].[reception] rc
				WHERE rs.[reservation_id] = rc.[reservation_id] AND rc.[room_id] = @room_id AND rc.[reservation_id] = @reserve_id
				ORDER BY rs.[reservation_id] desc
		END
	ELSE
		BEGIN
			PRINT 'Cannot check in with such information'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[room_checking_out]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[room_checking_out] (@cus_id int, @room_id int, @check_out_date datetime, @payment_type_id int, @payment_amount decimal(10,2))
AS
BEGIN
	DECLARE @reserve_id int

	IF EXISTS (SELECT 1 FROM [room]
		WHERE room_id = @room_id
		)
		BEGIN
			SET @reserve_id = (SELECT [dbo].[reserv_id_get2] (@cus_id, @room_id))

			UPDATE [dbo].[reception]
				SET check_out_date = @check_out_date, reception_status = 'Done'
				WHERE reservation_id = @reserve_id

			UPDATE [dbo].[room]
				SET room_status_id = 6
				WHERE room_id = @room_id

			INSERT INTO [dbo].[payment]
						([payment_type_id]
						,[reservation_id]
						,[payment_amount]
						,[payment_date])
					VALUES (@payment_type_id, @reserve_id, @payment_amount, @check_out_date)

			SELECT rc.[customer_id], rc.[room_id], r.[room_type_id], rc.[check_in_date], rc.[check_out_date], p.[payment_type_id], p.[payment_amount], p.[payment_date]
				FROM [dbo].[reception] rc, [dbo].payment p, [dbo].[room] r
				WHERE p.[reservation_id] = rc.[reservation_id] AND rc.[reservation_id] = @reserve_id AND r.[room_id] = rc.[room_id] AND rc.[reception_status] = 'Done'
		END
	ELSE
		BEGIN
			PRINT 'Cannot check out with such information'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[room_info_by_type_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[room_info_by_type_get] (@type int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [roomType]
		WHERE room_type_id = @type
		)
		BEGIN
			SELECT rt.[room_type_name], r.[room_number], rs.[room_status_name]
			FROM [dbo].[roomType] rt, [dbo].[roomStatus] rs, [dbo].[room] r
			WHERE rt.[room_type_id] = r.[room_type_id] AND rs.[room_status_id] = r.[room_status_id] AND r.[room_type_id] = @type
			ORDER BY r.[room_type_id]
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find room type id = '
			PRINT @IN + CONVERT(varchar,@type,100)
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[room_info_delete]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[room_info_get]

-- DELETE ROOM'S INFO BY ID
CREATE PROCEDURE [dbo].[room_info_delete] (@num varchar(50))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [room]
		WHERE room_number = @num
		)
		BEGIN
			DELETE FROM [room] WHERE [room_number] = @num
			PRINT 'Room Data Deleted'
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find room number = '
			PRINT @IN + CONVERT(varchar,@num,100)
		END
END
GO
/****** Object:  StoredProcedure [dbo].[room_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[cus_id_get] '7'

-- GET LIST OF ALL ROOMS
CREATE PROCEDURE [dbo].[room_info_get]
AS
BEGIN
	SELECT r.[room_number], rT.[room_type_name], rS.[room_status_name]
	FROM [dbo].[room] r, [dbo].[roomType] rT, [dbo].[roomStatus] rS
	WHERE r.[room_status_id] = rS.[room_status_id] AND r.[room_type_id] = rT.[room_type_id]
END
GO
/****** Object:  StoredProcedure [dbo].[room_number_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[room_info_delete] '101'

-- GET ROOM INFO BY ROOM NUMBER
CREATE PROCEDURE [dbo].[room_number_get] (@num int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [room]
		WHERE room_number = @num
		)
		BEGIN
			SELECT r.[room_number], rT.[room_type_name], rS.[room_status_name]
			FROM [dbo].[room] r, [dbo].[roomType] rT, [dbo].[roomStatus] rS
			WHERE r.[room_status_id] = rS.[room_status_id] AND r.[room_type_id] = rT.[room_type_id] AND r.[room_number] = @num
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find room number '
			PRINT @IN + CONVERT(varchar,@num,100)
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[room_vacant_convert]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[room_vacant_convert]
AS
BEGIN	
	UPDATE [dbo].[room]
		SET [room_status_id] = 1
		WHERE [room_id] IN (SELECT r.[room_id] 
						FROM [dbo].[room] r 
						WHERE r.[room_status_id] = 6)
	PRINT 'All checked-out rooms have been converted into vacant status!'
END
GO
/****** Object:  StoredProcedure [dbo].[single_room_vacant_convert]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[room_vacant_convert]

-- update a single room_status to VACANT
CREATE PROCEDURE [dbo].[single_room_vacant_convert] (@room_id int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [room]
		WHERE room_id = @room_id
		)
		BEGIN
			UPDATE [dbo].[room]
				SET room_status_id = 1
				WHERE room_id = @room_id

			SELECT r.[room_number], rT.[room_type_name], rS.[room_status_name]
			FROM [dbo].[room] r, [dbo].[roomType] rT, [dbo].[roomStatus] rS
			WHERE r.[room_status_id] = rS.[room_status_id] AND r.[room_type_id] = rT.[room_type_id] AND r.[room_id] = @room_id
		END
	ELSE
		BEGIN
			PRINT 'Cannot convert such room'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[single_user_password_update]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----EXEC [dbo].[single_user_session_info_get] 'thanhtung'
----EXEC [dbo].[single_user_session_info_update] 'thanhtung','tung','Thanh Tun','1999-03-10','0123456798'
----EXEC [dbo].[single_user_session_info_get] 'thanhtung'

-- UPDATE PASSWORD OF A SINGLE USER
CREATE PROCEDURE [dbo].[single_user_password_update] (@acc_username varchar(60), @acc_new_password varchar(60))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [account]
		WHERE [acc_username] = @acc_username
		)
		BEGIN
			UPDATE [dbo].[account]
				SET acc_password = @acc_new_password
				WHERE acc_username = @acc_username
		END
	ELSE
		BEGIN
			PRINT 'Update user password failed!'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[single_user_session_id_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[single_user_session_info_get] 'thanhtung'

-- CHECK USER WITH USERNAME AND PASSWORD
CREATE PROCEDURE [dbo].[single_user_session_id_get] (@acc_username varchar(60), @acc_password varchar(70))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [account]
		WHERE [acc_username] = @acc_username
		)
		BEGIN
			SELECT a.[acc_username], a.[acc_password], e.[emp_name] 'acc_name', r.[role_name] 'acc_role', e.[emp_dob] 'acc_dob', e.[emp_contact_number] 'acc_contact_number'
			FROM [dbo].[employee] e, [dbo].[account] a, [dbo].[role] r
			WHERE e.[emp_id] = a.[emp_id] AND r.[role_id] = a.[role_id] AND a.[acc_username] = @acc_username AND a.[acc_password] = @acc_password
			ORDER BY a.[acc_id]
		END
	ELSE
		BEGIN
			PRINT 'There are no account with that username.'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[single_user_session_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[single_user_session_info_get] (@acc_username varchar(60))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [account]
		WHERE [acc_username] = @acc_username
		)
		BEGIN
			SELECT a.[acc_username], a.[acc_password], a.[acc_session], e.[emp_name] 'acc_name', r.[role_name] 'acc_role', e.[emp_dob] 'acc_dob', e.[emp_contact_number] 'acc_contact_number'
			FROM [dbo].[employee] e, [dbo].[account] a, [dbo].[role] r
			WHERE e.[emp_id] = a.[emp_id] AND r.[role_id] = a.[role_id] AND a.[acc_username] = @acc_username
		END
	ELSE
		BEGIN
			PRINT 'There are no account with that username.'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[single_user_session_info_update]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[single_user_session_info_update] (@acc_username varchar(60), @acc_name varchar(50), @acc_dob datetime, @acc_contact_number varchar(50))
AS
BEGIN
	DECLARE @emp_id int
	SET @emp_id = (SELECT e.[emp_id] FROM [dbo].[employee] e, [dbo].[account] a WHERE e.[emp_id] = a.[emp_id] AND a.[acc_username] = @acc_username)
	IF EXISTS (SELECT 1 FROM [account]
		WHERE [acc_username] = @acc_username
		) 
		BEGIN
			UPDATE [dbo].[employee]
				SET emp_name = @acc_name, emp_dob = @acc_dob, emp_contact_number = @acc_contact_number
				WHERE emp_id = @emp_id
		END
	ELSE
		BEGIN
			PRINT 'Update user information failed!'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[top_available_room_info_by_type_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[available_room_info_by_type_get] '10'

-- PROCEDURE GET TOP AVAILABLE ROOM BY ROOM TYPE
CREATE PROCEDURE [dbo].[top_available_room_info_by_type_get] (@type int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [roomType]
		WHERE room_type_id = @type
		)
		BEGIN
			SELECT TOP 1 r.[room_id]
			FROM [dbo].[roomType] rt, [dbo].[roomStatus] rs, [dbo].[room] r
			WHERE rt.[room_type_id] = r.[room_type_id] AND rs.[room_status_id] = r.[room_status_id] AND r.[room_status_id] IN (1, 6) AND r.[room_type_id] = @type
			ORDER BY r.[room_type_id]
		END
	ELSE
		BEGIN
			DECLARE @IN VARCHAR(500)
			SET @IN = 'Cannot find room type id = '
			PRINT @IN + CONVERT(varchar,@type,100)
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[top_reservation_room_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[top_reservation_room_get] (@cus_id int, @type int)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [roomType]
		WHERE room_type_id = @type
		)
		BEGIN
			SELECT TOP 1 rs.[reservation_id], rs.[customer_id], [dbo].[top_reserv_available_room_by_type_get] (@type) 'room_id', rs.[expected_check_in_date], rs.[expected_check_in_date] + rs.[day_stay_number] 'expected_check_out_date'
			FROM [dbo].[reservation] rs, [dbo].[roomType] rt
			WHERE rs.[expected_room_type_id] = rt.[room_type_id] AND rs.[customer_id] = @cus_id AND rs.[expected_room_type_id] = @type AND rs.[reservation_status] = 'In Progress'
			ORDER BY rs.[reservation_id] desc
		END
	ELSE
		BEGIN
			PRINT 'Cannot get information'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[total_num_room_type_list_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[total_num_room_type_list_get]
AS
BEGIN
	SELECT r.[room_type_id], COUNT(r.[room_type_id]) 'count'
	FROM [dbo].[room] r
	GROUP BY r.[room_type_id]
	ORDER BY r.[room_type_id]
END
GO
/****** Object:  StoredProcedure [dbo].[unpaid_room_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[paid_room_info_get]

-- GET ALL BOOKED AND UNPAID ROOMS
CREATE PROCEDURE [dbo].[unpaid_room_info_get]
AS
BEGIN
	SELECT r.[room_type_id], r.[room_number], rT.[room_type_name], rS.[room_status_name]
	FROM [dbo].[room] r, [dbo].[roomType] rT, [dbo].[roomStatus] rs
	WHERE r.[room_type_id] = rT.[room_type_id] AND r.[room_status_id] in (2, 4) AND r.[room_status_id] = rs.[room_status_id]
	ORDER BY r.[room_id]
END
GO
/****** Object:  StoredProcedure [dbo].[user_password_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_password_get] (@acc_username varchar(60))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [account]
		WHERE [acc_username] = @acc_username
		)
		BEGIN
			SELECT a.[acc_username], a.[acc_password]
			FROM [dbo].[account] a
			WHERE a.[acc_username] = @acc_username
		END
	ELSE
		BEGIN
			PRINT 'There are no account with that username.'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[user_password_session_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_password_session_get] (@acc_username varchar(60))
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [account]
		WHERE [acc_username] = @acc_username
		)
		BEGIN
			SELECT a.[acc_username], a.[acc_password], a.[acc_session], e.[emp_identity_number] 'acc_identity_code'
			FROM [dbo].[account] a, [dbo].[employee] e
			WHERE a.[acc_username] = @acc_username AND e.[emp_id] = a.[emp_id]
		END
	ELSE
		BEGIN
			PRINT 'There are no account with that username.'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[user_session_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_session_info_get]
AS
BEGIN
	SELECT a.[acc_username], a.[acc_password], a.[acc_session], e.[emp_name] 'acc_name', r.[role_name] 'acc_role', e.[emp_dob] 'acc_dob', e.[emp_contact_number] 'acc_contact_number'
	FROM [dbo].[employee] e, [dbo].[account] a, [dbo].[role] r
	WHERE e.[emp_id] = a.[emp_id] AND r.[role_id] = a.[role_id]
	ORDER BY a.[acc_id]
END
GO
/****** Object:  StoredProcedure [dbo].[user_session_start]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_session_start] (@acc_username varchar(60), @acc_session varchar(200))
AS
BEGIN
	UPDATE [dbo].[account]
		SET acc_session = @acc_session
		WHERE acc_username = @acc_username

	SELECT a.[acc_username], a.[acc_password], a.[acc_session], e.[emp_name] 'acc_name', r.[role_name] 'acc_role', e.[emp_dob] 'acc_dob', e.[emp_contact_number] 'acc_contact_number'
		FROM [dbo].[employee] e, [dbo].[account] a, [dbo].[role] r
		WHERE e.[emp_id] = a.[emp_id] AND r.[role_id] = a.[role_id] AND a.[acc_username] = @acc_username
END
GO
/****** Object:  StoredProcedure [dbo].[vacant_room_info_get]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- EXEC [dbo].[room_number_get] '301'

-- GET ALL VACANT ROOMS
CREATE PROCEDURE [dbo].[vacant_room_info_get]
AS
BEGIN
	SELECT r.[room_type_id], r.[room_number], rT.[room_type_name], rs.[room_status_name]
	FROM [dbo].[room] r, [dbo].[roomType] rT, [dbo].roomStatus rs
	WHERE r.[room_type_id] = rT.[room_type_id] AND r.[room_status_id] = 1 AND r.[room_status_id] = rs.[room_status_id]
	ORDER BY r.[room_id]
END
GO
/****** Object:  StoredProcedure [dbo].[vip_room_booking]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vip_room_booking] (@cus_id int, @check_in_date datetime, @day int, @room_type_id int, @payment_type_id int, @payment_amount decimal(10,2), @payment_date datetime)
AS
BEGIN
	DECLARE @reserve_id INT, @room_id int

	IF EXISTS (SELECT 1 FROM [customer]
		WHERE [customer_id] = @cus_id
		) AND EXISTS (SELECT 1 FROM [roomType]
		WHERE [room_type_id] = @room_type_id
		)
		BEGIN			
			
			INSERT INTO [dbo].[reservation]
						([customer_id]
						,[expected_check_in_date]
						,[day_stay_number]
						,[expected_room_type_id])
				VALUES (@cus_id,@check_in_date,@day,@room_type_id)

			SET @reserve_id = (SELECT [dbo].[reserv_id_get] (@cus_id, @room_type_id))
			SET @room_id = (SELECT [dbo].[top_available_room_by_type_get] (@room_type_id))
			
			UPDATE [dbo].[room]
				SET room_status_id = 3
				WHERE room_id = @room_id

			
			UPDATE [dbo].[reservation]
				SET reservation_status = 'In Progress'
				WHERE reservation_id = @reserve_id

			INSERT INTO [dbo].[payment]
						([payment_type_id]
						,[reservation_id]
						,[payment_amount]
						,[payment_date])
					VALUES (@payment_type_id, @reserve_id, @payment_amount, @payment_date)
		END
	ELSE
		BEGIN
			PRINT 'Cannot book room with such information'
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[vip_room_checking_out]    Script Date: 5/26/2022 10:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vip_room_checking_out] (@cus_id int, @room_id int, @check_out_date datetime)
AS
BEGIN
	DECLARE @reserve_id int

	IF EXISTS (SELECT 1 FROM [room]
		WHERE room_id = @room_id
		)
		BEGIN
			SET @reserve_id = (SELECT [dbo].[reserv_id_get2] (@cus_id, @room_id))

			UPDATE [dbo].[reception]
				SET check_out_date = @check_out_date, reception_status = 'Done'
				WHERE reservation_id = @reserve_id

			UPDATE [dbo].[room]
				SET room_status_id = 6
				WHERE room_id = @room_id

			SELECT rc.[customer_id], rc.[room_id], r.[room_type_id], rc.[check_in_date], rc.[check_out_date], p.[payment_type_id], p.[payment_amount], p.[payment_date]
				FROM [dbo].[reception] rc, [dbo].payment p, [dbo].[room] r
				WHERE p.[reservation_id] = rc.[reservation_id] AND rc.[reservation_id] = @reserve_id AND r.[room_id] = rc.[room_id] AND rc.[reception_status] = 'Done'
		END
	ELSE
		BEGIN
			PRINT 'Cannot check out with such information'
		END	
END
GO
USE [master]
GO
ALTER DATABASE [VMO_HotelManagement] SET  READ_WRITE 
GO
