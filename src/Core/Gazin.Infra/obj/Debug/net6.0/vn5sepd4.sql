

CREATE DATABASE GAZIN;
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220330085718_Initial')
BEGIN
    CREATE SEQUENCE [DesenvolvedorSequencia] AS int START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220330085718_Initial')
BEGIN
    CREATE SEQUENCE [NiveisSequencia] AS int START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220330085718_Initial')
BEGIN
    CREATE TABLE [Niveis] (
        [Id] int NOT NULL DEFAULT (NEXT VALUE FOR NiveisSequencia),
        [Nivel] varchar(100) NOT NULL,
        CONSTRAINT [PK_Niveis] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220330085718_Initial')
BEGIN
    CREATE TABLE [Desenvolvedores] (
        [Id] int NOT NULL DEFAULT (NEXT VALUE FOR DesenvolvedorSequencia),
        [NivelId] int NOT NULL,
        [Nome] varchar(100) NOT NULL,
        [Sexo] char(1) NOT NULL,
        [DataNascimento] DateTime NOT NULL,
        [Idade] int NOT NULL,
        [Hobby] Varchar(60) NOT NULL,
        CONSTRAINT [PK_Desenvolvedores] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Desenvolvedores_Niveis_NivelId] FOREIGN KEY ([NivelId]) REFERENCES [Niveis] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220330085718_Initial')
BEGIN
    CREATE INDEX [IX_Desenvolvedores_NivelId] ON [Desenvolvedores] ([NivelId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220330085718_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220330085718_Initial', N'6.0.3');
END;
GO

COMMIT;
GO

