USE[hairdemo]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 16/08/2020 11:00:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetRoleClaims](
	[Id][int] IDENTITY(1, 1) NOT NULL,
	[RoleId][nvarchar](450) NOT NULL,
	[ClaimType][nvarchar](max) NULL,
	[ClaimValue][nvarchar](max) NULL,
	CONSTRAINT[PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 16/08/2020 11:00:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetRoles](
	[Id][nvarchar](450) NOT NULL,
	[Name][nvarchar](256) NULL,
	[NormalizedName][nvarchar](256) NULL,
	[ConcurrencyStamp][nvarchar](max) NULL,
	CONSTRAINT[PK_AspNetRoles] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 16/08/2020 11:00:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetUserClaims](
	[Id][int] IDENTITY(1, 1) NOT NULL,
	[UserId][nvarchar](450) NOT NULL,
	[ClaimType][nvarchar](max) NULL,
	[ClaimValue][nvarchar](max) NULL,
	CONSTRAINT[PK_AspNetUserClaims] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 16/08/2020 11:00:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetUserLogins](
	[LoginProvider][nvarchar](128) NOT NULL,
	[ProviderKey][nvarchar](128) NOT NULL,
	[ProviderDisplayName][nvarchar](max) NULL,
	[UserId][nvarchar](450) NOT NULL,
	CONSTRAINT[PK_AspNetUserLogins] PRIMARY KEY CLUSTERED
	(
		[LoginProvider] ASC,
		[ProviderKey] ASC
	)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 16/08/2020 11:00:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetUserRoles](
	[UserId][nvarchar](450) NOT NULL,
	[RoleId][nvarchar](450) NOT NULL,
	CONSTRAINT[PK_AspNetUserRoles] PRIMARY KEY CLUSTERED
	(
		[UserId] ASC,
		[RoleId] ASC
	)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 16/08/2020 11:00:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetUsers](
	[Id][nvarchar](450) NOT NULL,
	[UserName][nvarchar](256) NULL,
	[NormalizedUserName][nvarchar](256) NULL,
	[Email][nvarchar](256) NULL,
	[NormalizedEmail][nvarchar](256) NULL,
	[EmailConfirmed][bit] NOT NULL,
	[PasswordHash][nvarchar](max) NULL,
	[SecurityStamp][nvarchar](max) NULL,
	[ConcurrencyStamp][nvarchar](max) NULL,
	[PhoneNumber][nvarchar](max) NULL,
	[PhoneNumberConfirmed][bit] NOT NULL,
	[TwoFactorEnabled][bit] NOT NULL,
	[LockoutEnd][datetimeoffset](7) NULL,
	[LockoutEnabled][bit] NOT NULL,
	[AccessFailedCount][int] NOT NULL,
	CONSTRAINT[PK_AspNetUsers] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 16/08/2020 11:00:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[AspNetUserTokens](
	[UserId][nvarchar](450) NOT NULL,
	[LoginProvider][nvarchar](128) NOT NULL,
	[Name][nvarchar](128) NOT NULL,
	[Value][nvarchar](max) NULL,
	CONSTRAINT[PK_AspNetUserTokens] PRIMARY KEY CLUSTERED
	(
		[UserId] ASC,
		[LoginProvider] ASC,
		[Name] ASC
	)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO
INSERT[dbo].[AspNetRoles]([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES(N'acdda4ef-d395-4bbc-a9e7-1fb8a65c5a6e', N'ContentEditor', N'CONTENTEDITOR', N'3a946004-5fba-428c-867e-61ab1cf92d5f')
GO
INSERT[dbo].[AspNetRoles]([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES(N'ed16f903-ceaf-4a40-83ca-f97c9ec51110', N'Admin', N'ADMIN', N'86eb0fa5-1089-438e-b000-a231b95689a8')
GO
INSERT[dbo].[AspNetUserRoles]([UserId], [RoleId]) VALUES(N'ed20cdcc-ffec-44d3-9e62-479e42c3688b', N'acdda4ef-d395-4bbc-a9e7-1fb8a65c5a6e')
GO
INSERT[dbo].[AspNetUserRoles]([UserId], [RoleId]) VALUES(N'12be3cb1-54a6-419d-ac20-a60ca73bd4ec', N'ed16f903-ceaf-4a40-83ca-f97c9ec51110')
GO
INSERT[dbo].[AspNetUsers]([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'12be3cb1-54a6-419d-ac20-a60ca73bd4ec', N'baxterrpearson@gmail.com', N'BAXTERRPEARSON@GMAIL.COM', N'baxterrpearson@gmail.com', N'BAXTERRPEARSON@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEIjHTa6d3adV914xSHfEFg/ehxZcJmq/2qikwovECaxygRsYXN7QpNobtBa/BUKuXw==', N'VL7FFUZLLDAUYIURL4FXQXQG22CTF23R', N'909037f6-080d-47e0-8013-5366241d78c2', NULL, 0, 0, NULL, 1, 0)
GO
INSERT[dbo].[AspNetUsers]([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'ed20cdcc-ffec-44d3-9e62-479e42c3688b', N'baxter.pearson@gmail.com', N'BAXTER.PEARSON@GMAIL.COM', N'baxter.pearson@gmail.com', N'BAXTER.PEARSON@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEA+V5w8GeyjxVN/77JAFEB1AKJwlsF8WPSTgMpCTlhQdH0vaXYqDwOYQyEnyfFoShQ==', N'HGASR4S6AAN45ICSOP4T2H64LNSR4BCL', N'd45995ea-6f5b-458a-b7a9-ffc947e6c10a', NULL, 0, 0, NULL, 1, 0)
GO
ALTER TABLE[dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT[FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES[dbo].[AspNetRoles]([Id])
ON DELETE CASCADE
GO
ALTER TABLE[dbo].[AspNetRoleClaims] CHECK CONSTRAINT[FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE[dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT[FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES[dbo].[AspNetUsers]([Id])
ON DELETE CASCADE
GO
ALTER TABLE[dbo].[AspNetUserClaims] CHECK CONSTRAINT[FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE[dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT[FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES[dbo].[AspNetUsers]([Id])
ON DELETE CASCADE
GO
ALTER TABLE[dbo].[AspNetUserLogins] CHECK CONSTRAINT[FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE[dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT[FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES[dbo].[AspNetRoles]([Id])
ON DELETE CASCADE
GO
ALTER TABLE[dbo].[AspNetUserRoles] CHECK CONSTRAINT[FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE[dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT[FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES[dbo].[AspNetUsers]([Id])
ON DELETE CASCADE
GO
ALTER TABLE[dbo].[AspNetUserRoles] CHECK CONSTRAINT[FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE[dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT[FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES[dbo].[AspNetUsers]([Id])
ON DELETE CASCADE
GO
ALTER TABLE[dbo].[AspNetUserTokens] CHECK CONSTRAINT[FK_AspNetUserTokens_AspNetUsers_UserId]
GO
