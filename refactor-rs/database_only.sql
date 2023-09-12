USE [master]
GO
/****** Object:  Database [HotelManagementSystem]    Script Date: 12/9/2023 10:01:13 AM ******/
CREATE DATABASE [HotelManagementSystem]
GO
ALTER DATABASE [HotelManagementSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HotelManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HotelManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [HotelManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelManagementSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HotelManagementSystem] SET QUERY_STORE = OFF
GO
USE [HotelManagementSystem]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 12/9/2023 10:01:14 AM ******/
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
/****** Object:  Table [dbo].[admin_user]    Script Date: 12/9/2023 10:01:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin_user](
	[id] [uniqueidentifier] NOT NULL,
	[username] [varchar](255) NOT NULL,
	[email] [varchar](255) NULL,
	[password_hash] [varbinary](max) NOT NULL,
	[password_salt] [varbinary](max) NOT NULL,
	[role_id] [uniqueidentifier] NOT NULL,
	[full_name] [nvarchar](255) NOT NULL,
	[position] [nvarchar](50) NOT NULL,
	[date_of_birth] [datetime] NOT NULL,
	[contact_number] [varchar](50) NULL,
	[identity_number] [varchar](18) NOT NULL,
	[acc_session] [varchar](255) NULL,
	[full_text_search] as concat([username], ' ', isnull([email], ''), ' ', [full_name], ' ', isnull([contact_number], ''), [identity_number]),
	[created] [datetime] NULL,
	[modified] [datetime] NULL,
	[deleted] [bit] NULL,
 CONSTRAINT [PK_admin_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_admin_user_username] ON [dbo].[admin_user]
(
	[username] ASC
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_admin_user_email] ON [dbo].[admin_user]
(
	[email] ASC
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_admin_user_full_name] ON [dbo].[admin_user]
(
	[full_name] ASC
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_admin_user_contact_number] ON [dbo].[admin_user]
(
	[contact_number] ASC
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_admin_user_identity_number] ON [dbo].[admin_user]
(
	[identity_number] ASC
)
GO

ALTER TABLE [dbo].[admin_user] ADD CONSTRAINT [DF_admin_user_created] DEFAULT (getutcdate()) FOR [created]
GO

ALTER TABLE [dbo].[admin_user] ADD CONSTRAINT [DF_admin_user_modified] DEFAULT (getutcdate()) FOR [modified]
GO

ALTER TABLE [dbo].[admin_user] ADD CONSTRAINT [DF_admin_user_deleted] DEFAULT (0) FOR [deleted]
GO

-- create full text search
IF EXISTS ( SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'admin_user'))
    ALTER FULLTEXT INDEX ON [dbo].[admin_user] DISABLE;
GO

IF EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'admin_user'))
    DROP FULLTEXT INDEX ON [dbo].[admin_user];
GO

IF EXISTS (SELECT * FROM sys.fulltextcatalogs ftc WHERE ftc.name = N'fts_ctg_admin_user')
    DROP FULLTEXT CATALOG fts_ctg_admin_user;
GO

IF NOT EXISTS (SELECT * FROM sys.fulltextcatalogs ftc WHERE ftc.name = N'fts_ctg_admin_user')
    CREATE FULLTEXT CATALOG fts_ctg_admin_user WITH ACCENT_SENSITIVITY = OFF AUTHORIZATION dbo;
GO

IF NOT EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'admin_user'))
    CREATE FULLTEXT INDEX ON [dbo].[admin_user] ([full_text_search] LANGUAGE 'English') KEY INDEX [PK_admin_user] ON (fts_ctg_admin_user, FILEGROUP [PRIMARY]) WITH(CHANGE_TRACKING = AUTO, STOPLIST = OFF);
GO

/****** Object:  Table [dbo].[customer]    Script Date: 12/9/2023 10:01:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [uniqueidentifier] NOT NULL,
	[full_name] [nvarchar](255) NOT NULL,
	[email] [varchar](255) NULL,
	[identity_number] [varchar](18) NOT NULL,
	[address] [nvarchar](max) NULL,
	[contact_number] [varchar](20) NOT NULL,
	[full_text_search] as concat(isnull([email], ''), ' ', [full_name], ' ', [contact_number], [identity_number]),
	[created] [datetime] NULL,
	[modified] [datetime] NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_customer_email] ON [dbo].[customer]
(
	[email] ASC
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_customer_full_name] ON [dbo].[customer]
(
	[full_name] ASC
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_customer_contact_number] ON [dbo].[customer]
(
	[contact_number] ASC
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_customer_identity_number] ON [dbo].[customer]
(
	[identity_number] ASC
)
GO

ALTER TABLE [dbo].[customer] ADD CONSTRAINT [DF_customer_created] DEFAULT (getutcdate()) FOR [created]
GO

ALTER TABLE [dbo].[customer] ADD CONSTRAINT [DF_customer_modified] DEFAULT (getutcdate()) FOR [modified]
GO

-- create full text search
IF EXISTS ( SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'customer'))
    ALTER FULLTEXT INDEX ON [dbo].[customer] DISABLE;
GO

IF EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'customer'))
    DROP FULLTEXT INDEX ON [dbo].[customer];
GO

IF EXISTS (SELECT * FROM sys.fulltextcatalogs ftc WHERE ftc.name = N'fts_ctg_customer')
    DROP FULLTEXT CATALOG fts_ctg_customer;
GO

IF NOT EXISTS (SELECT * FROM sys.fulltextcatalogs ftc WHERE ftc.name = N'fts_ctg_customer')
    CREATE FULLTEXT CATALOG fts_ctg_customer WITH ACCENT_SENSITIVITY = OFF AUTHORIZATION dbo;
GO

IF NOT EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'customer'))
    CREATE FULLTEXT INDEX ON [dbo].[customer] ([full_text_search] LANGUAGE 'English') KEY INDEX [PK_customer] ON (fts_ctg_customer, FILEGROUP [PRIMARY]) WITH(CHANGE_TRACKING = AUTO, STOPLIST = OFF);
GO

/****** Object:  Table [dbo].[payment]    Script Date: 12/9/2023 10:01:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment](
	[id] [uniqueidentifier] NOT NULL,
	[payment_type_id] [uniqueidentifier] NOT NULL,
	[reservation_id] [uniqueidentifier] NOT NULL,
	[payment_amount] [decimal](18, 2) NULL,
	[payment_date] [datetime] NOT NULL,
	[created] [datetime] NULL,
	[modified] [datetime] NULL,
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[payment] ADD CONSTRAINT [DF_payment_created] DEFAULT (getutcdate()) FOR [created]
GO

ALTER TABLE [dbo].[payment] ADD CONSTRAINT [DF_payment_modified] DEFAULT (getutcdate()) FOR [modified]
GO

-- create full text search
IF EXISTS ( SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'payment'))
    ALTER FULLTEXT INDEX ON [dbo].[payment] DISABLE;
GO

IF EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'payment'))
    DROP FULLTEXT INDEX ON [dbo].[payment];
GO

IF EXISTS (SELECT * FROM sys.fulltextcatalogs ftc WHERE ftc.name = N'fts_ctg_payment')
    DROP FULLTEXT CATALOG fts_ctg_payment;
GO

IF NOT EXISTS (SELECT * FROM sys.fulltextcatalogs ftc WHERE ftc.name = N'fts_ctg_payment')
    CREATE FULLTEXT CATALOG fts_ctg_payment WITH ACCENT_SENSITIVITY = OFF AUTHORIZATION dbo;
GO

IF NOT EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'payment'))
    CREATE FULLTEXT INDEX ON [dbo].[payment] ([full_text_search] LANGUAGE 'English') KEY INDEX [PK_payment] ON (fts_ctg_payment, FILEGROUP [PRIMARY]) WITH(CHANGE_TRACKING = AUTO, STOPLIST = OFF);
GO

/****** Object:  Table [dbo].[payment_type]    Script Date: 12/9/2023 10:01:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_type](
	[id] [uniqueidentifier] NOT NULL,
	[payment_type_name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_payment_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reception]    Script Date: 12/9/2023 10:01:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reception](
	[reception_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[customer_id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[reservation]    Script Date: 12/9/2023 10:01:14 AM ******/
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
/****** Object:  Table [dbo].[role]    Script Date: 12/9/2023 10:01:14 AM ******/
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
/****** Object:  Table [dbo].[room]    Script Date: 12/9/2023 10:01:14 AM ******/
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
/****** Object:  Table [dbo].[roomStatus]    Script Date: 12/9/2023 10:01:14 AM ******/
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
/****** Object:  Table [dbo].[roomType]    Script Date: 12/9/2023 10:01:14 AM ******/
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
/****** Object:  Table [dbo].[userSessions]    Script Date: 12/9/2023 10:01:14 AM ******/
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

INSERT [dbo].[payment_type] ([payment_type_id], [payment_type_name]) VALUES (1, N'Cash')
INSERT [dbo].[payment_type] ([payment_type_id], [payment_type_name]) VALUES (2, N'Credit Card')
INSERT [dbo].[payment_type] ([payment_type_id], [payment_type_name]) VALUES (3, N'Debit Card')

INSERT [dbo].[role] ([role_id], [role_name]) VALUES (1, N'Manager')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (2, N'Security')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (3, N'Cleaner')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (4, N'Chief')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (5, N'Intern')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (6, N'admin_userant')

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

INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (1, N'Vacant')
INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (2, N'Booked and UnPaid')
INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (3, N'Booked and Paid')
INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (4, N'Checked In and UnPaid')
INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (5, N'Checked In and Paid')
INSERT [dbo].[roomStatus] ([room_status_id], [room_status_name]) VALUES (6, N'Checked Out')

INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (1, N'King Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (2, N'Queen Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (3, N'4-people Family Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (4, N'3-people Family Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (5, N'Single Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (6, N'Couple Room')
INSERT [dbo].[roomType] ([room_type_id], [room_type_name]) VALUES (7, N'4-Bunk Room')

USE [master]
GO
ALTER DATABASE [HotelManagementSystem] SET  READ_WRITE 
GO
