
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/10/2018 18:32:13
-- Generated from EDMX file: C:\Users\shmac\Documents\!GB\C#3-3\SpamTools\SpamLib\Data\SpamDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SpamDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MailingListRecipient_MailingList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailingListRecipient] DROP CONSTRAINT [FK_MailingListRecipient_MailingList];
GO
IF OBJECT_ID(N'[dbo].[FK_MailingListRecipient_Recipient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailingListRecipient] DROP CONSTRAINT [FK_MailingListRecipient_Recipient];
GO
IF OBJECT_ID(N'[dbo].[FK_ServerScheduleTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleTasks] DROP CONSTRAINT [FK_ServerScheduleTask];
GO
IF OBJECT_ID(N'[dbo].[FK_SenderScheduleTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleTasks] DROP CONSTRAINT [FK_SenderScheduleTask];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduleTaskMailingList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleTasks] DROP CONSTRAINT [FK_ScheduleTaskMailingList];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailScheduleTask_Email]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmailScheduleTask] DROP CONSTRAINT [FK_EmailScheduleTask_Email];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailScheduleTask_ScheduleTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmailScheduleTask] DROP CONSTRAINT [FK_EmailScheduleTask_ScheduleTask];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Recipients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recipients];
GO
IF OBJECT_ID(N'[dbo].[Servers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servers];
GO
IF OBJECT_ID(N'[dbo].[Senders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Senders];
GO
IF OBJECT_ID(N'[dbo].[ScheduleTasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduleTasks];
GO
IF OBJECT_ID(N'[dbo].[Emails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emails];
GO
IF OBJECT_ID(N'[dbo].[MailingLists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailingLists];
GO
IF OBJECT_ID(N'[dbo].[MailingListRecipient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailingListRecipient];
GO
IF OBJECT_ID(N'[dbo].[EmailScheduleTask]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailScheduleTask];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Recipients'
CREATE TABLE [dbo].[Recipients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Servers'
CREATE TABLE [dbo].[Servers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Port] int  NOT NULL,
    [UseSSL] bit  NOT NULL
);
GO

-- Creating table 'Senders'
CREATE TABLE [dbo].[Senders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ScheduleTasks'
CREATE TABLE [dbo].[ScheduleTasks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Time] datetime  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Server_Id] int  NOT NULL,
    [Sender_Id] int  NOT NULL,
    [MailingList_Id] int  NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'MailingLists'
CREATE TABLE [dbo].[MailingLists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'MailingListRecipient'
CREATE TABLE [dbo].[MailingListRecipient] (
    [MailingLists_Id] int  NOT NULL,
    [Recipients_Id] int  NOT NULL
);
GO

-- Creating table 'EmailScheduleTask'
CREATE TABLE [dbo].[EmailScheduleTask] (
    [Emails_Id] int  NOT NULL,
    [ScheduleTask_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Recipients'
ALTER TABLE [dbo].[Recipients]
ADD CONSTRAINT [PK_Recipients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Servers'
ALTER TABLE [dbo].[Servers]
ADD CONSTRAINT [PK_Servers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Senders'
ALTER TABLE [dbo].[Senders]
ADD CONSTRAINT [PK_Senders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ScheduleTasks'
ALTER TABLE [dbo].[ScheduleTasks]
ADD CONSTRAINT [PK_ScheduleTasks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailingLists'
ALTER TABLE [dbo].[MailingLists]
ADD CONSTRAINT [PK_MailingLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MailingLists_Id], [Recipients_Id] in table 'MailingListRecipient'
ALTER TABLE [dbo].[MailingListRecipient]
ADD CONSTRAINT [PK_MailingListRecipient]
    PRIMARY KEY CLUSTERED ([MailingLists_Id], [Recipients_Id] ASC);
GO

-- Creating primary key on [Emails_Id], [ScheduleTask_Id] in table 'EmailScheduleTask'
ALTER TABLE [dbo].[EmailScheduleTask]
ADD CONSTRAINT [PK_EmailScheduleTask]
    PRIMARY KEY CLUSTERED ([Emails_Id], [ScheduleTask_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MailingLists_Id] in table 'MailingListRecipient'
ALTER TABLE [dbo].[MailingListRecipient]
ADD CONSTRAINT [FK_MailingListRecipient_MailingList]
    FOREIGN KEY ([MailingLists_Id])
    REFERENCES [dbo].[MailingLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Recipients_Id] in table 'MailingListRecipient'
ALTER TABLE [dbo].[MailingListRecipient]
ADD CONSTRAINT [FK_MailingListRecipient_Recipient]
    FOREIGN KEY ([Recipients_Id])
    REFERENCES [dbo].[Recipients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailingListRecipient_Recipient'
CREATE INDEX [IX_FK_MailingListRecipient_Recipient]
ON [dbo].[MailingListRecipient]
    ([Recipients_Id]);
GO

-- Creating foreign key on [Server_Id] in table 'ScheduleTasks'
ALTER TABLE [dbo].[ScheduleTasks]
ADD CONSTRAINT [FK_ServerScheduleTask]
    FOREIGN KEY ([Server_Id])
    REFERENCES [dbo].[Servers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServerScheduleTask'
CREATE INDEX [IX_FK_ServerScheduleTask]
ON [dbo].[ScheduleTasks]
    ([Server_Id]);
GO

-- Creating foreign key on [Sender_Id] in table 'ScheduleTasks'
ALTER TABLE [dbo].[ScheduleTasks]
ADD CONSTRAINT [FK_SenderScheduleTask]
    FOREIGN KEY ([Sender_Id])
    REFERENCES [dbo].[Senders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SenderScheduleTask'
CREATE INDEX [IX_FK_SenderScheduleTask]
ON [dbo].[ScheduleTasks]
    ([Sender_Id]);
GO

-- Creating foreign key on [MailingList_Id] in table 'ScheduleTasks'
ALTER TABLE [dbo].[ScheduleTasks]
ADD CONSTRAINT [FK_ScheduleTaskMailingList]
    FOREIGN KEY ([MailingList_Id])
    REFERENCES [dbo].[MailingLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduleTaskMailingList'
CREATE INDEX [IX_FK_ScheduleTaskMailingList]
ON [dbo].[ScheduleTasks]
    ([MailingList_Id]);
GO

-- Creating foreign key on [Emails_Id] in table 'EmailScheduleTask'
ALTER TABLE [dbo].[EmailScheduleTask]
ADD CONSTRAINT [FK_EmailScheduleTask_Email]
    FOREIGN KEY ([Emails_Id])
    REFERENCES [dbo].[Emails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ScheduleTask_Id] in table 'EmailScheduleTask'
ALTER TABLE [dbo].[EmailScheduleTask]
ADD CONSTRAINT [FK_EmailScheduleTask_ScheduleTask]
    FOREIGN KEY ([ScheduleTask_Id])
    REFERENCES [dbo].[ScheduleTasks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailScheduleTask_ScheduleTask'
CREATE INDEX [IX_FK_EmailScheduleTask_ScheduleTask]
ON [dbo].[EmailScheduleTask]
    ([ScheduleTask_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------