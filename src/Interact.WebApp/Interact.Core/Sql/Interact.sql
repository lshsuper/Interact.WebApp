/*
Navicat SQL Server Data Transfer

Source Server         : lsh
Source Server Version : 120000
Source Host           : DESKTOP-S0UJ68S:1433
Source Database       : Interact
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 120000
File Encoding         : 65001

Date: 2019-05-12 19:26:36
*/


-- ----------------------------
-- Table structure for Activity
-- ----------------------------
DROP TABLE [dbo].[Activity]
GO
CREATE TABLE [dbo].[Activity] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(150) NOT NULL DEFAULT '' ,
[LimitNumber] int NOT NULL DEFAULT ((0)) ,
[SignInNumber] int NOT NULL DEFAULT ((0)) ,
[PlayBillUrl] varchar(150) NOT NULL DEFAULT '' ,
[CreateTime] datetime NOT NULL DEFAULT (getdate()) ,
[Status] tinyint NOT NULL DEFAULT ((0)) ,
[AuthCode] varchar(10) NOT NULL DEFAULT '' 
)


GO
DBCC CHECKIDENT(N'[dbo].[Activity]', RESEED, 7)
GO

-- ----------------------------
-- Table structure for ActivityAward
-- ----------------------------
DROP TABLE [dbo].[ActivityAward]
GO
CREATE TABLE [dbo].[ActivityAward] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(150) NOT NULL DEFAULT '' ,
[ActivityId] int NOT NULL DEFAULT ((0)) ,
[AwardImage] varchar(150) NOT NULL DEFAULT '' ,
[WinnerLevel] int NOT NULL DEFAULT ((0)) ,
[CreateTime] datetime NOT NULL DEFAULT (getdate()) 
)


GO

-- ----------------------------
-- Table structure for Admin
-- ----------------------------
DROP TABLE [dbo].[Admin]
GO
CREATE TABLE [dbo].[Admin] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(100) NULL DEFAULT '' ,
[Login] varchar(100) NULL DEFAULT '' ,
[Pwd] varchar(100) NULL DEFAULT '' ,
[CreateTime] datetime NULL DEFAULT (getdate()) 
)


GO

-- ----------------------------
-- Table structure for SignInRecord
-- ----------------------------
DROP TABLE [dbo].[SignInRecord]
GO
CREATE TABLE [dbo].[SignInRecord] (
[Id] varchar(32) NOT NULL ,
[OpenId] varchar(50) NOT NULL DEFAULT '' ,
[NickName] varchar(150) NOT NULL DEFAULT '' ,
[ActivityId] int NOT NULL DEFAULT ((0)) ,
[CreateTime] datetime NOT NULL DEFAULT (getdate()) ,
[HeadImage] varchar(150) NOT NULL DEFAULT '' 
)


GO

-- ----------------------------
-- Table structure for WinnerMenu
-- ----------------------------
DROP TABLE [dbo].[WinnerMenu]
GO
CREATE TABLE [dbo].[WinnerMenu] (
[Id] varchar(32) NOT NULL DEFAULT '' ,
[SiginInRecoredId] varchar(32) NOT NULL DEFAULT '' ,
[ActivityId] int NOT NULL DEFAULT ((0)) ,
[CreateTime] datetime NOT NULL ,
[WinnerLevel] int NOT NULL DEFAULT ((0)) 
)


GO

-- ----------------------------
-- Indexes structure for table Activity
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Activity
-- ----------------------------
ALTER TABLE [dbo].[Activity] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table ActivityAward
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ActivityAward
-- ----------------------------
ALTER TABLE [dbo].[ActivityAward] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table SignInRecord
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SignInRecord
-- ----------------------------
ALTER TABLE [dbo].[SignInRecord] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table WinnerMenu
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table WinnerMenu
-- ----------------------------
ALTER TABLE [dbo].[WinnerMenu] ADD PRIMARY KEY ([Id])
GO
