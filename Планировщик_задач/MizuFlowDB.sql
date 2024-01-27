use MizuFlowDB;-- Таблица USER

CREATE TABLE [dbo].[USER] (
    [ID_User] INT IDENTITY (1, 1) NOT NULL,
    [Login] NVARCHAR(100) NOT NULL,
    [Password] NVARCHAR(100) NOT NULL,
    [User_Name] NVARCHAR(100) NOT NULL,
    [User_Surname] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NULL,
    [Phone] NVARCHAR(15) NULL,
    [Contact] NVARCHAR(255) NULL,
    [Description] NVARCHAR(255) NULL,
    PRIMARY KEY CLUSTERED ([ID_User] ASC)
);
SELECT * FROM [dbo].[USER];

-- Таблица GROUP
CREATE TABLE [dbo].[Task_Group] ( --НАЗВАНИЕ ПОМЕНЯЛА ХАПИСКУ ИСПРАВИТЬ
    [ID_Group] INT IDENTITY (1, 1) NOT NULL,
    [Group_Name] NVARCHAR(100) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID_Group] ASC)
);

-- Таблица TASK
CREATE TABLE [dbo].[TASK] (
    [ID_Task] INT IDENTITY (1, 1) NOT NULL,
    [Task_UserID] INT NOT NULL,
    [Task_Name] NVARCHAR(100) NOT NULL,
    [CreationDateTime] DATETIME NOT NULL,
    [Deadline] DATETIME NOT NULL, --ВМЕСТО исправиоа DATE DATETIME
    [Priority] INT NULL,
    [IsWork] BIT NULL,
    [isCheck] BIT NULL,
    [CheckTime] DATETIME NULL,
    [Task_ID_Group] INT NULL,
    PRIMARY KEY CLUSTERED ([ID_Task] ASC),
    CONSTRAINT [FK_TASK_USER] FOREIGN KEY ([Task_UserID]) REFERENCES [dbo].[USER] ([ID_User]),
    CONSTRAINT [FK_TASK_GROUP] FOREIGN KEY ([Task_ID_Group]) REFERENCES [dbo].[Task_Group] ([ID_Group])
);


-- Таблица SUBTASKS
CREATE TABLE [dbo].[SUBTASKS] (
    [ID_Subtask] INT IDENTITY (1, 1) NOT NULL,
    [TaskID] INT NULL,
    [Subtask_Name] NVARCHAR(200) NOT NULL,
    [isCheck] BIT NULL,
    PRIMARY KEY CLUSTERED ([ID_Subtask] ASC),
    CONSTRAINT [FK_SUBTASK_TASK] FOREIGN KEY ([TaskID]) REFERENCES [dbo].[TASK] ([ID_Task])
);

-- Таблица TASK_ATTACHMENT
CREATE TABLE [dbo].[TASK_ATTACHMENT] (
    [ID_Task_Attachments] INT IDENTITY (1, 1) NOT NULL,
    [TA_UserID] INT NULL,
    [TA_TaskID] INT NULL,
    [TA_SubtaskID] INT NULL,
    [ImagePath] NVARCHAR(255) NULL,
    [Image] VARBINARY(MAX) NULL,
    [FilePath] NVARCHAR(255) NULL,
    [File] VARBINARY(MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID_Task_Attachments] ASC),
    CONSTRAINT [FK_TA_USER] FOREIGN KEY ([TA_UserID]) REFERENCES [dbo].[USER] ([ID_User]),
    CONSTRAINT [FK_TA_TASK] FOREIGN KEY ([TA_TaskID]) REFERENCES [dbo].[TASK] ([ID_Task]),
    CONSTRAINT [FK_TA_SUBTASK] FOREIGN KEY ([TA_SubtaskID]) REFERENCES [dbo].[SUBTASKS] ([ID_Subtask])
);

-- Drop table USER
DROP TABLE [dbo].[USER];

-- Drop table GROUP
DROP TABLE [dbo].[Task_Group];

-- Drop table TASK_ATTACHMENT
DROP TABLE [dbo].[TASK_ATTACHMENT];

-- Drop table SUBTASKS
DROP TABLE [dbo].[SUBTASKS];

-- Drop table TASK
DROP TABLE [dbo].[TASK];

