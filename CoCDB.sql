IF DB_ID(N'CoCDB') IS NULL
BEGIN
    CREATE DATABASE CoCDB;
END
GO

USE CoCDB;
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users (
        id          INT IDENTITY(1,1) NOT NULL,
        nome        NVARCHAR(200)     NOT NULL,
        email       NVARCHAR(320)     NOT NULL,
        data_nasc   DATE              NULL,
        nif         INT               NULL,
        aprovador   BIT               NOT NULL CONSTRAINT DF_Users_aprovador DEFAULT (0),
        admin       BIT               NOT NULL CONSTRAINT DF_Users_admin     DEFAULT (0),
        aprovando   BIT               NOT NULL CONSTRAINT DF_Users_aprovando DEFAULT (0),
        foto        VARBINARY(MAX)    NULL,      -- ficheiro (imagem) guardado como binário

        CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (id),
        CONSTRAINT UQ_Users_email UNIQUE (email)
    );
END
GO
