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

Date: 2019-05-14 03:34:30
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
-- Records of Activity
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Activity] ON
GO
INSERT INTO [dbo].[Activity] ([Id], [Name], [LimitNumber], [SignInNumber], [PlayBillUrl], [CreateTime], [Status], [AuthCode]) VALUES (N'7', N'测试活动', N'100', N'21', N'9', N'2019-05-12 10:51:31.000', N'0', N'xx')
GO
GO
SET IDENTITY_INSERT [dbo].[Activity] OFF
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
[CreateTime] datetime NOT NULL DEFAULT (getdate()) 
)


GO
DBCC CHECKIDENT(N'[dbo].[ActivityAward]', RESEED, 2)
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
-- Records of ActivityAward
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ActivityAward] ON
GO
INSERT INTO [dbo].[ActivityAward] ([Id], [Name], [ActivityId], [AwardImage], [CreateTime]) VALUES (N'1', N'iphone', N'7', N'http://shulehudong.oss-cn-hangzhou.aliyuncs.com/images/2/2018/11/JMMWURxm4NtRwrCrgrrXcG599MT0XG.jpg', N'2019-05-13 22:22:11.723')
GO
GO
INSERT INTO [dbo].[ActivityAward] ([Id], [Name], [ActivityId], [AwardImage], [CreateTime]) VALUES (N'2', N'mac', N'7', N'http://shulehudong.oss-cn-hangzhou.aliyuncs.com/images/2/2018/11/I6hYsHh3wQHOobV3HzD3HZHfBbsVYh.jpg', N'2019-05-13 22:23:46.797')
GO
GO
SET IDENTITY_INSERT [dbo].[ActivityAward] OFF
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
-- Records of Admin
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Admin] ON
GO
INSERT INTO [dbo].[Admin] ([Id], [Name], [Login], [Pwd], [CreateTime]) VALUES (N'1', N'admin', N'admin', N'admin', N'2019-05-12 00:10:17.527')
GO
GO
SET IDENTITY_INSERT [dbo].[Admin] OFF
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
-- Records of SignInRecord
-- ----------------------------
INSERT INTO [dbo].[SignInRecord] ([Id], [OpenId], [NickName], [ActivityId], [CreateTime], [HeadImage]) VALUES (N'eb7123b4a4b240f3b3563d9fb15838a6', N'ogBFH5_uDmF5mBuQewgB2ivGcTuY', N'劉帥', N'7', N'2019-05-12 23:28:05.360', N'http://thirdwx.qlogo.cn/mmopen/vi_32/vziclTVLC9kOEFryVwb2qLnmz96pIeD07KmvT0nT7R5s9NJndYwlwnaYJB3BJxXdTO8bOZn9y1qGqPqIwB06Aww/132')
GO
GO
INSERT INTO [dbo].[SignInRecord] ([Id], [OpenId], [NickName], [ActivityId], [CreateTime], [HeadImage]) VALUES (N'xx', N'xxx', N'xxx', N'7', N'2019-05-12 17:14:05.733', N'http://cdn.huodongxing.com/Content/app/appom/283413686227632.jpg')
GO
GO
INSERT INTO [dbo].[SignInRecord] ([Id], [OpenId], [NickName], [ActivityId], [CreateTime], [HeadImage]) VALUES (N'xxx', N'xxxxxxx', N'xxxsaxsxsxsxasx', N'7', N'2019-05-14 00:24:30.813', N'http://cdn.huodongxing.com/Content/app/appom/763410748647663.png')
GO
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
[ActivityAwardId] int NOT NULL DEFAULT ((0)) 
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
'COLUMN', N'ActivityAwardId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'奖品等级'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'WinnerMenu'
, @level2type = 'COLUMN', @level2name = N'ActivityAwardId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'奖品等级'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'WinnerMenu'
, @level2type = 'COLUMN', @level2name = N'ActivityAwardId'
GO

-- ----------------------------
-- Records of WinnerMenu
-- ----------------------------
INSERT INTO [dbo].[WinnerMenu] ([Id], [SiginInRecoredId], [ActivityId], [CreateTime], [ActivityAwardId]) VALUES (N'390d46edc9934e95b9c0891b150e2702', N'xx', N'7', N'2019-05-14 03:33:18.130', N'1')
GO
GO
INSERT INTO [dbo].[WinnerMenu] ([Id], [SiginInRecoredId], [ActivityId], [CreateTime], [ActivityAwardId]) VALUES (N'8dc9ccef255a491fa88e10886e6eaed7', N'eb7123b4a4b240f3b3563d9fb15838a6', N'7', N'2019-05-14 03:33:13.930', N'1')
GO
GO
INSERT INTO [dbo].[WinnerMenu] ([Id], [SiginInRecoredId], [ActivityId], [CreateTime], [ActivityAwardId]) VALUES (N'ad6b046def8144df821141c0930f7ee0', N'xxx', N'7', N'2019-05-14 03:33:23.163', N'1')
GO
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
