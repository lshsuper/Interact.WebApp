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

Date: 2019-05-13 00:52:13
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Activity', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'活动名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'活动名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Activity', 
'COLUMN', N'LimitNumber')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'报名限制'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'LimitNumber'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'报名限制'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'LimitNumber'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Activity', 
'COLUMN', N'SignInNumber')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'当前签到人数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'SignInNumber'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'当前签到人数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'SignInNumber'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Activity', 
'COLUMN', N'PlayBillUrl')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'活动海报'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'PlayBillUrl'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'活动海报'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'PlayBillUrl'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Activity', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Activity', 
'COLUMN', N'Status')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'活动状态'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'Status'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'活动状态'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'Status'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Activity', 
'COLUMN', N'AuthCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'活动授权码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'AuthCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'活动授权码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Activity'
, @level2type = 'COLUMN', @level2name = N'AuthCode'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'ActivityAward', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'奖品名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ActivityAward'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'奖品名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ActivityAward'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'ActivityAward', 
'COLUMN', N'ActivityId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'活动id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ActivityAward'
, @level2type = 'COLUMN', @level2name = N'ActivityId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'活动id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ActivityAward'
, @level2type = 'COLUMN', @level2name = N'ActivityId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'ActivityAward', 
'COLUMN', N'AwardImage')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'奖品图片'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ActivityAward'
, @level2type = 'COLUMN', @level2name = N'AwardImage'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'奖品图片'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ActivityAward'
, @level2type = 'COLUMN', @level2name = N'AwardImage'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'ActivityAward', 
'COLUMN', N'WinnerLevel')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'奖品等级'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ActivityAward'
, @level2type = 'COLUMN', @level2name = N'WinnerLevel'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'奖品等级'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ActivityAward'
, @level2type = 'COLUMN', @level2name = N'WinnerLevel'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'ActivityAward', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ActivityAward'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ActivityAward'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Admin', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'管理员名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Admin'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'管理员名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Admin'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Admin', 
'COLUMN', N'Login')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'管路员账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Admin'
, @level2type = 'COLUMN', @level2name = N'Login'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'管路员账号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Admin'
, @level2type = 'COLUMN', @level2name = N'Login'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Admin', 
'COLUMN', N'Pwd')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'管理员密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Admin'
, @level2type = 'COLUMN', @level2name = N'Pwd'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'管理员密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Admin'
, @level2type = 'COLUMN', @level2name = N'Pwd'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Admin', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Admin'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Admin'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SignInRecord', 
'COLUMN', N'OpenId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'微信openid'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SignInRecord'
, @level2type = 'COLUMN', @level2name = N'OpenId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'微信openid'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SignInRecord'
, @level2type = 'COLUMN', @level2name = N'OpenId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SignInRecord', 
'COLUMN', N'NickName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'微信昵称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SignInRecord'
, @level2type = 'COLUMN', @level2name = N'NickName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'微信昵称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SignInRecord'
, @level2type = 'COLUMN', @level2name = N'NickName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SignInRecord', 
'COLUMN', N'ActivityId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'活动id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SignInRecord'
, @level2type = 'COLUMN', @level2name = N'ActivityId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'活动id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SignInRecord'
, @level2type = 'COLUMN', @level2name = N'ActivityId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SignInRecord', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SignInRecord'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SignInRecord'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SignInRecord', 
'COLUMN', N'HeadImage')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'微信头像'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SignInRecord'
, @level2type = 'COLUMN', @level2name = N'HeadImage'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'微信头像'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SignInRecord'
, @level2type = 'COLUMN', @level2name = N'HeadImage'
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
[CreateTime] datetime NOT NULL DEFAULT (getdate()) ,
[WinnerLevel] int NOT NULL DEFAULT ((0)) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'WinnerMenu', 
'COLUMN', N'SiginInRecoredId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'签到记录id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'WinnerMenu'
, @level2type = 'COLUMN', @level2name = N'SiginInRecoredId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'签到记录id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'WinnerMenu'
, @level2type = 'COLUMN', @level2name = N'SiginInRecoredId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'WinnerMenu', 
'COLUMN', N'ActivityId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'活动id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'WinnerMenu'
, @level2type = 'COLUMN', @level2name = N'ActivityId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'活动id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'WinnerMenu'
, @level2type = 'COLUMN', @level2name = N'ActivityId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'WinnerMenu', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'WinnerMenu'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'WinnerMenu'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'WinnerMenu', 
'COLUMN', N'WinnerLevel')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'奖品等级'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'WinnerMenu'
, @level2type = 'COLUMN', @level2name = N'WinnerLevel'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'奖品等级'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'WinnerMenu'
, @level2type = 'COLUMN', @level2name = N'WinnerLevel'
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
