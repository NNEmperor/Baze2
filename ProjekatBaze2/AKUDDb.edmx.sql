
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2021 14:58:23
-- Generated from EDMX file: C:\Users\Nikola\Desktop\ProjekatBaze2\ProjekatBaze2\ProjekatBaze2\AKUDDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AKUDDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_VodiKoreograf]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vodjenje] DROP CONSTRAINT [FK_VodiKoreograf];
GO
IF OBJECT_ID(N'[dbo].[FK_VodiSastav]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vodjenje] DROP CONSTRAINT [FK_VodiSastav];
GO
IF OBJECT_ID(N'[dbo].[FK_SastavPripada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pripadanje] DROP CONSTRAINT [FK_SastavPripada];
GO
IF OBJECT_ID(N'[dbo].[FK_IgracPripada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pripadanje] DROP CONSTRAINT [FK_IgracPripada];
GO
IF OBJECT_ID(N'[dbo].[FK_SastavProba]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Probe] DROP CONSTRAINT [FK_SastavProba];
GO
IF OBJECT_ID(N'[dbo].[FK_IgracNastupa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nastupaju] DROP CONSTRAINT [FK_IgracNastupa];
GO
IF OBJECT_ID(N'[dbo].[FK_KoncertNastupa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nastupaju] DROP CONSTRAINT [FK_KoncertNastupa];
GO
IF OBJECT_ID(N'[dbo].[FK_MuzikaIgrackiKoncert]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Koncerti_IgrackiKoncert] DROP CONSTRAINT [FK_MuzikaIgrackiKoncert];
GO
IF OBJECT_ID(N'[dbo].[FK_NastupaNosnja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nosnje] DROP CONSTRAINT [FK_NastupaNosnja];
GO
IF OBJECT_ID(N'[dbo].[FK_IgrackiKoncert_inherits_Koncert]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Koncerti_IgrackiKoncert] DROP CONSTRAINT [FK_IgrackiKoncert_inherits_Koncert];
GO
IF OBJECT_ID(N'[dbo].[FK_PevackiKoncert_inherits_Koncert]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Koncerti_PevackiKoncert] DROP CONSTRAINT [FK_PevackiKoncert_inherits_Koncert];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Koreografi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Koreografi];
GO
IF OBJECT_ID(N'[dbo].[Sastavi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sastavi];
GO
IF OBJECT_ID(N'[dbo].[Vodjenje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vodjenje];
GO
IF OBJECT_ID(N'[dbo].[Igraci]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Igraci];
GO
IF OBJECT_ID(N'[dbo].[Pripadanje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pripadanje];
GO
IF OBJECT_ID(N'[dbo].[Probe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Probe];
GO
IF OBJECT_ID(N'[dbo].[Koncerti]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Koncerti];
GO
IF OBJECT_ID(N'[dbo].[Nastupaju]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nastupaju];
GO
IF OBJECT_ID(N'[dbo].[Nosnje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nosnje];
GO
IF OBJECT_ID(N'[dbo].[Muzike]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Muzike];
GO
IF OBJECT_ID(N'[dbo].[Koncerti_IgrackiKoncert]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Koncerti_IgrackiKoncert];
GO
IF OBJECT_ID(N'[dbo].[Koncerti_PevackiKoncert]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Koncerti_PevackiKoncert];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Koreografi'
CREATE TABLE [dbo].[Koreografi] (
    [ID_KOR] int IDENTITY(1,1) NOT NULL,
    [IME_KOR] nvarchar(max)  NOT NULL,
    [PR_KOR] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Sastavi'
CREATE TABLE [dbo].[Sastavi] (
    [ID_SS] int IDENTITY(1,1) NOT NULL,
    [IME_SS] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Vodjenje'
CREATE TABLE [dbo].[Vodjenje] (
    [KoreografID_KOR] int  NOT NULL,
    [SastavID_SS] int  NOT NULL
);
GO

-- Creating table 'Igraci'
CREATE TABLE [dbo].[Igraci] (
    [ID_IG] int IDENTITY(1,1) NOT NULL,
    [IME_IG] nvarchar(max)  NOT NULL,
    [PR_IG] nvarchar(max)  NOT NULL,
    [VIS_IG] float  NOT NULL,
    [POL_IG] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pripadanje'
CREATE TABLE [dbo].[Pripadanje] (
    [SastavID_SS] int  NOT NULL,
    [IgracID_IG] int  NOT NULL
);
GO

-- Creating table 'Probe'
CREATE TABLE [dbo].[Probe] (
    [ID_PROB] int IDENTITY(1,1) NOT NULL,
    [SastavID_SS] int  NOT NULL,
    [TIP_PROB] nvarchar(max)  NOT NULL,
    [VR_PROB] datetime  NOT NULL
);
GO

-- Creating table 'Koncerti'
CREATE TABLE [dbo].[Koncerti] (
    [ID_KC] int IDENTITY(1,1) NOT NULL,
    [VR_KC] datetime  NOT NULL,
    [TIP_KC] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Nastupaju'
CREATE TABLE [dbo].[Nastupaju] (
    [IgracID_IG] int  NOT NULL,
    [KoncertID_KC] int  NOT NULL
);
GO

-- Creating table 'Nosnje'
CREATE TABLE [dbo].[Nosnje] (
    [ID_NOS] int IDENTITY(1,1) NOT NULL,
    [NastupaIgracID_IG] int  NOT NULL,
    [NastupaKoncertID_KC] int  NOT NULL,
    [IME_NOS] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Muzike'
CREATE TABLE [dbo].[Muzike] (
    [ID_MUZ] int IDENTITY(1,1) NOT NULL,
    [TIP_MUZ] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Koncerti_IgrackiKoncert'
CREATE TABLE [dbo].[Koncerti_IgrackiKoncert] (
    [MuzikaID_MUZ] int  NOT NULL,
    [IG_KOR] nvarchar(max)  NOT NULL,
    [ID_KC] int  NOT NULL
);
GO

-- Creating table 'Koncerti_PevackiKoncert'
CREATE TABLE [dbo].[Koncerti_PevackiKoncert] (
    [PEV_TIP] nvarchar(max)  NOT NULL,
    [ID_KC] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID_KOR] in table 'Koreografi'
ALTER TABLE [dbo].[Koreografi]
ADD CONSTRAINT [PK_Koreografi]
    PRIMARY KEY CLUSTERED ([ID_KOR] ASC);
GO

-- Creating primary key on [ID_SS] in table 'Sastavi'
ALTER TABLE [dbo].[Sastavi]
ADD CONSTRAINT [PK_Sastavi]
    PRIMARY KEY CLUSTERED ([ID_SS] ASC);
GO

-- Creating primary key on [KoreografID_KOR], [SastavID_SS] in table 'Vodjenje'
ALTER TABLE [dbo].[Vodjenje]
ADD CONSTRAINT [PK_Vodjenje]
    PRIMARY KEY CLUSTERED ([KoreografID_KOR], [SastavID_SS] ASC);
GO

-- Creating primary key on [ID_IG] in table 'Igraci'
ALTER TABLE [dbo].[Igraci]
ADD CONSTRAINT [PK_Igraci]
    PRIMARY KEY CLUSTERED ([ID_IG] ASC);
GO

-- Creating primary key on [SastavID_SS], [IgracID_IG] in table 'Pripadanje'
ALTER TABLE [dbo].[Pripadanje]
ADD CONSTRAINT [PK_Pripadanje]
    PRIMARY KEY CLUSTERED ([SastavID_SS], [IgracID_IG] ASC);
GO

-- Creating primary key on [ID_PROB], [SastavID_SS] in table 'Probe'
ALTER TABLE [dbo].[Probe]
ADD CONSTRAINT [PK_Probe]
    PRIMARY KEY CLUSTERED ([ID_PROB], [SastavID_SS] ASC);
GO

-- Creating primary key on [ID_KC] in table 'Koncerti'
ALTER TABLE [dbo].[Koncerti]
ADD CONSTRAINT [PK_Koncerti]
    PRIMARY KEY CLUSTERED ([ID_KC] ASC);
GO

-- Creating primary key on [IgracID_IG], [KoncertID_KC] in table 'Nastupaju'
ALTER TABLE [dbo].[Nastupaju]
ADD CONSTRAINT [PK_Nastupaju]
    PRIMARY KEY CLUSTERED ([IgracID_IG], [KoncertID_KC] ASC);
GO

-- Creating primary key on [ID_NOS] in table 'Nosnje'
ALTER TABLE [dbo].[Nosnje]
ADD CONSTRAINT [PK_Nosnje]
    PRIMARY KEY CLUSTERED ([ID_NOS] ASC);
GO

-- Creating primary key on [ID_MUZ] in table 'Muzike'
ALTER TABLE [dbo].[Muzike]
ADD CONSTRAINT [PK_Muzike]
    PRIMARY KEY CLUSTERED ([ID_MUZ] ASC);
GO

-- Creating primary key on [ID_KC] in table 'Koncerti_IgrackiKoncert'
ALTER TABLE [dbo].[Koncerti_IgrackiKoncert]
ADD CONSTRAINT [PK_Koncerti_IgrackiKoncert]
    PRIMARY KEY CLUSTERED ([ID_KC] ASC);
GO

-- Creating primary key on [ID_KC] in table 'Koncerti_PevackiKoncert'
ALTER TABLE [dbo].[Koncerti_PevackiKoncert]
ADD CONSTRAINT [PK_Koncerti_PevackiKoncert]
    PRIMARY KEY CLUSTERED ([ID_KC] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KoreografID_KOR] in table 'Vodjenje'
ALTER TABLE [dbo].[Vodjenje]
ADD CONSTRAINT [FK_VodiKoreograf]
    FOREIGN KEY ([KoreografID_KOR])
    REFERENCES [dbo].[Koreografi]
        ([ID_KOR])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SastavID_SS] in table 'Vodjenje'
ALTER TABLE [dbo].[Vodjenje]
ADD CONSTRAINT [FK_VodiSastav]
    FOREIGN KEY ([SastavID_SS])
    REFERENCES [dbo].[Sastavi]
        ([ID_SS])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VodiSastav'
CREATE INDEX [IX_FK_VodiSastav]
ON [dbo].[Vodjenje]
    ([SastavID_SS]);
GO

-- Creating foreign key on [SastavID_SS] in table 'Pripadanje'
ALTER TABLE [dbo].[Pripadanje]
ADD CONSTRAINT [FK_SastavPripada]
    FOREIGN KEY ([SastavID_SS])
    REFERENCES [dbo].[Sastavi]
        ([ID_SS])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IgracID_IG] in table 'Pripadanje'
ALTER TABLE [dbo].[Pripadanje]
ADD CONSTRAINT [FK_IgracPripada]
    FOREIGN KEY ([IgracID_IG])
    REFERENCES [dbo].[Igraci]
        ([ID_IG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IgracPripada'
CREATE INDEX [IX_FK_IgracPripada]
ON [dbo].[Pripadanje]
    ([IgracID_IG]);
GO

-- Creating foreign key on [SastavID_SS] in table 'Probe'
ALTER TABLE [dbo].[Probe]
ADD CONSTRAINT [FK_SastavProba]
    FOREIGN KEY ([SastavID_SS])
    REFERENCES [dbo].[Sastavi]
        ([ID_SS])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SastavProba'
CREATE INDEX [IX_FK_SastavProba]
ON [dbo].[Probe]
    ([SastavID_SS]);
GO

-- Creating foreign key on [IgracID_IG] in table 'Nastupaju'
ALTER TABLE [dbo].[Nastupaju]
ADD CONSTRAINT [FK_IgracNastupa]
    FOREIGN KEY ([IgracID_IG])
    REFERENCES [dbo].[Igraci]
        ([ID_IG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KoncertID_KC] in table 'Nastupaju'
ALTER TABLE [dbo].[Nastupaju]
ADD CONSTRAINT [FK_KoncertNastupa]
    FOREIGN KEY ([KoncertID_KC])
    REFERENCES [dbo].[Koncerti]
        ([ID_KC])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KoncertNastupa'
CREATE INDEX [IX_FK_KoncertNastupa]
ON [dbo].[Nastupaju]
    ([KoncertID_KC]);
GO

-- Creating foreign key on [MuzikaID_MUZ] in table 'Koncerti_IgrackiKoncert'
ALTER TABLE [dbo].[Koncerti_IgrackiKoncert]
ADD CONSTRAINT [FK_MuzikaIgrackiKoncert]
    FOREIGN KEY ([MuzikaID_MUZ])
    REFERENCES [dbo].[Muzike]
        ([ID_MUZ])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MuzikaIgrackiKoncert'
CREATE INDEX [IX_FK_MuzikaIgrackiKoncert]
ON [dbo].[Koncerti_IgrackiKoncert]
    ([MuzikaID_MUZ]);
GO

-- Creating foreign key on [NastupaIgracID_IG], [NastupaKoncertID_KC] in table 'Nosnje'
ALTER TABLE [dbo].[Nosnje]
ADD CONSTRAINT [FK_NastupaNosnja]
    FOREIGN KEY ([NastupaIgracID_IG], [NastupaKoncertID_KC])
    REFERENCES [dbo].[Nastupaju]
        ([IgracID_IG], [KoncertID_KC])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NastupaNosnja'
CREATE INDEX [IX_FK_NastupaNosnja]
ON [dbo].[Nosnje]
    ([NastupaIgracID_IG], [NastupaKoncertID_KC]);
GO

-- Creating foreign key on [ID_KC] in table 'Koncerti_IgrackiKoncert'
ALTER TABLE [dbo].[Koncerti_IgrackiKoncert]
ADD CONSTRAINT [FK_IgrackiKoncert_inherits_Koncert]
    FOREIGN KEY ([ID_KC])
    REFERENCES [dbo].[Koncerti]
        ([ID_KC])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_KC] in table 'Koncerti_PevackiKoncert'
ALTER TABLE [dbo].[Koncerti_PevackiKoncert]
ADD CONSTRAINT [FK_PevackiKoncert_inherits_Koncert]
    FOREIGN KEY ([ID_KC])
    REFERENCES [dbo].[Koncerti]
        ([ID_KC])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------