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