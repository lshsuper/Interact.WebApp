USE [master]
GO
/****** Object:  Database [Interact]    Script Date: 2019/5/13 星期一 9:34:41 ******/
CREATE DATABASE [Interact]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Interact', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Interact.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Interact_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Interact_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Interact] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Interact].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Interact] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Interact] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Interact] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Interact] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Interact] SET ARITHABORT OFF 
GO
ALTER DATABASE [Interact] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Interact] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Interact] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Interact] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Interact] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Interact] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Interact] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Interact] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Interact] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Interact] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Interact] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Interact] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Interact] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Interact] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Interact] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Interact] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Interact] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Interact] SET RECOVERY FULL 
GO
ALTER DATABASE [Interact] SET  MULTI_USER 
GO
ALTER DATABASE [Interact] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Interact] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Interact] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Interact] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Interact] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Interact', N'ON'
GO
USE [Interact]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 2019/5/13 星期一 9:34:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Activity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[LimitNumber] [int] NOT NULL,
	[SignInNumber] [int] NOT NULL,
	[PlayBillUrl] [varchar](150) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[AuthCode] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ActivityAward]    Script Date: 2019/5/13 星期一 9:34:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ActivityAward](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[ActivityId] [int] NOT NULL,
	[AwardImage] [varchar](150) NOT NULL,
	[WinnerLevel] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 2019/5/13 星期一 9:34:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Login] [varchar](100) NULL,
	[Pwd] [varchar](100) NULL,
	[CreateTime] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SignInRecord]    Script Date: 2019/5/13 星期一 9:34:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SignInRecord](
	[Id] [varchar](32) NOT NULL,
	[OpenId] [varchar](50) NOT NULL,
	[NickName] [varchar](150) NOT NULL,
	[ActivityId] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[HeadImage] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WinnerMenu]    Script Date: 2019/5/13 星期一 9:34:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WinnerMenu](
	[Id] [varchar](32) NOT NULL,
	[SiginInRecoredId] [varchar](32) NOT NULL,
	[ActivityId] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[WinnerLevel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Activity] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Activity] ADD  DEFAULT ((0)) FOR [LimitNumber]
GO
ALTER TABLE [dbo].[Activity] ADD  DEFAULT ((0)) FOR [SignInNumber]
GO
ALTER TABLE [dbo].[Activity] ADD  DEFAULT ('') FOR [PlayBillUrl]
GO
ALTER TABLE [dbo].[Activity] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Activity] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Activity] ADD  DEFAULT ('') FOR [AuthCode]
GO
ALTER TABLE [dbo].[ActivityAward] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[ActivityAward] ADD  DEFAULT ((0)) FOR [ActivityId]
GO
ALTER TABLE [dbo].[ActivityAward] ADD  DEFAULT ('') FOR [AwardImage]
GO
ALTER TABLE [dbo].[ActivityAward] ADD  DEFAULT ((0)) FOR [WinnerLevel]
GO
ALTER TABLE [dbo].[ActivityAward] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT ('') FOR [Login]
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT ('') FOR [Pwd]
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[SignInRecord] ADD  DEFAULT ('') FOR [OpenId]
GO
ALTER TABLE [dbo].[SignInRecord] ADD  DEFAULT ('') FOR [NickName]
GO
ALTER TABLE [dbo].[SignInRecord] ADD  DEFAULT ((0)) FOR [ActivityId]
GO
ALTER TABLE [dbo].[SignInRecord] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[SignInRecord] ADD  DEFAULT ('') FOR [HeadImage]
GO
ALTER TABLE [dbo].[WinnerMenu] ADD  DEFAULT ('') FOR [Id]
GO
ALTER TABLE [dbo].[WinnerMenu] ADD  DEFAULT ('') FOR [SiginInRecoredId]
GO
ALTER TABLE [dbo].[WinnerMenu] ADD  DEFAULT ((0)) FOR [ActivityId]
GO
ALTER TABLE [dbo].[WinnerMenu] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[WinnerMenu] ADD  DEFAULT ((0)) FOR [WinnerLevel]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Activity', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报名限制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Activity', @level2type=N'COLUMN',@level2name=N'LimitNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前签到人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Activity', @level2type=N'COLUMN',@level2name=N'SignInNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动海报' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Activity', @level2type=N'COLUMN',@level2name=N'PlayBillUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Activity', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Activity', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动授权码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Activity', @level2type=N'COLUMN',@level2name=N'AuthCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'奖品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAward', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAward', @level2type=N'COLUMN',@level2name=N'ActivityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'奖品图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAward', @level2type=N'COLUMN',@level2name=N'AwardImage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'奖品等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAward', @level2type=N'COLUMN',@level2name=N'WinnerLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ActivityAward', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管路员账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'Login'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'Pwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信openid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignInRecord', @level2type=N'COLUMN',@level2name=N'OpenId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignInRecord', @level2type=N'COLUMN',@level2name=N'NickName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignInRecord', @level2type=N'COLUMN',@level2name=N'ActivityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignInRecord', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignInRecord', @level2type=N'COLUMN',@level2name=N'HeadImage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签到记录id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WinnerMenu', @level2type=N'COLUMN',@level2name=N'SiginInRecoredId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WinnerMenu', @level2type=N'COLUMN',@level2name=N'ActivityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WinnerMenu', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'奖品等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WinnerMenu', @level2type=N'COLUMN',@level2name=N'WinnerLevel'
GO
USE [master]
GO
ALTER DATABASE [Interact] SET  READ_WRITE 
GO
