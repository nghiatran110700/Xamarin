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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_InitialCreate')
BEGIN
    CREATE TABLE [AssetType] (
        [AssetTypeK] uniqueidentifier NOT NULL,
        [AssetTypeName] nvarchar(100) NULL,
        CONSTRAINT [PK_AssetType] PRIMARY KEY ([AssetTypeK])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_InitialCreate')
BEGIN
    CREATE TABLE [Tenancy] (
        [TenancyK] uniqueidentifier NOT NULL,
        [TenancyName] nvarchar(100) NULL,
        CONSTRAINT [PK_Tenancy] PRIMARY KEY ([TenancyK])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_InitialCreate')
BEGIN
    CREATE TABLE [UserTB] (
        [UserK] uniqueidentifier NOT NULL,
        [Username] nvarchar(100) NULL,
        [PasswordHash] nvarchar(100) NULL,
        CONSTRAINT [PK_UserTB] PRIMARY KEY ([UserK])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_InitialCreate')
BEGIN
    CREATE TABLE [LocationTB] (
        [LocationK] uniqueidentifier NOT NULL,
        [LocationName] nvarchar(100) NULL,
        [TenancyK] uniqueidentifier NULL,
        CONSTRAINT [PK_LocationTB] PRIMARY KEY ([LocationK]),
        CONSTRAINT [FK_LocationTB_Tenancy_TenancyK] FOREIGN KEY ([TenancyK]) REFERENCES [Tenancy] ([TenancyK]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_InitialCreate')
BEGIN
    CREATE TABLE [Asset] (
        [AccessK] uniqueidentifier NOT NULL,
        [Accessname] nvarchar(100) NULL,
        [AccessPercent] float NULL,
        [TimeRead] float NULL,
        [Title] nvarchar(100) NULL,
        [AssetTypeK] uniqueidentifier NULL,
        [LocationK] uniqueidentifier NULL,
        CONSTRAINT [PK_Asset] PRIMARY KEY ([AccessK]),
        CONSTRAINT [FK_Asset_AssetType_AssetTypeK] FOREIGN KEY ([AssetTypeK]) REFERENCES [AssetType] ([AssetTypeK]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Asset_LocationTB_LocationK] FOREIGN KEY ([LocationK]) REFERENCES [LocationTB] ([LocationK]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_InitialCreate')
BEGIN
    CREATE INDEX [IX_Asset_AssetTypeK] ON [Asset] ([AssetTypeK]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_InitialCreate')
BEGIN
    CREATE INDEX [IX_Asset_LocationK] ON [Asset] ([LocationK]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_InitialCreate')
BEGIN
    CREATE INDEX [IX_LocationTB_TenancyK] ON [LocationTB] ([TenancyK]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220323033445_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220323033445_InitialCreate', N'5.0.15');
END;
GO

COMMIT;
GO

