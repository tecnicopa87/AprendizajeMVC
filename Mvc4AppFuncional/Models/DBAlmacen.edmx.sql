
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/13/2019 09:53:21
-- Generated from EDMX file: c:\users\alfonso\documents\visual studio 2012\Projects\Mvc4AppFuncional\Models\DBAlmacen.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Almacen];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Cotizacio__NoCli__15502E78]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cotizacion] DROP CONSTRAINT [FK__Cotizacio__NoCli__15502E78];
GO
IF OBJECT_ID(N'[dbo].[FK_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bodega] DROP CONSTRAINT [FK_Category];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bodega]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bodega];
GO
IF OBJECT_ID(N'[dbo].[Categoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categoria];
GO
IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Cotizacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cotizacion];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bodegas'
CREATE TABLE [dbo].[Bodegas] (
    [IdCategoria] int  NOT NULL,
    [FechaIngreso] datetime  NULL,
    [Responsable] varchar(50)  NULL,
    [Codigo] varchar(50)  NULL,
    [Descripcion] varchar(50)  NULL,
    [Unidad] nchar(10)  NULL,
    [Cantidad] float  NULL,
    [Costo] decimal(19,4)  NULL,
    [CveProvedor] nchar(10)  NULL,
    [PrecioMenor] decimal(19,4)  NULL,
    [PrecioMayor] decimal(19,4)  NULL,
    [Identificador] bigint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [IdCategoria] int  NOT NULL,
    [NombreCategoria] varchar(50)  NULL
);
GO

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [NoCliente] int  NOT NULL,
    [NombreCliente] varchar(50)  NULL,
    [GiroEmpresarial] varchar(50)  NULL
);
GO

-- Creating table 'Cotizacions'
CREATE TABLE [dbo].[Cotizacions] (
    [Id] int  NOT NULL,
    [NoCliente] int  NOT NULL,
    [FechaCotizacion] datetime  NULL,
    [Gironegocio] varchar(50)  NULL,
    [Monto] decimal(19,4)  NULL
);
GO

-- Creating table 'VentasSet'
CREATE TABLE [dbo].[VentasSet] (
    [FolioVenta] bigint IDENTITY(1,1) NOT NULL,
    [FechaRealizacion] nvarchar(max)  NOT NULL,
    [MontoSubtotal] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Identificador] in table 'Bodegas'
ALTER TABLE [dbo].[Bodegas]
ADD CONSTRAINT [PK_Bodegas]
    PRIMARY KEY CLUSTERED ([Identificador] ASC);
GO

-- Creating primary key on [IdCategoria] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([IdCategoria] ASC);
GO

-- Creating primary key on [NoCliente] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([NoCliente] ASC);
GO

-- Creating primary key on [Id] in table 'Cotizacions'
ALTER TABLE [dbo].[Cotizacions]
ADD CONSTRAINT [PK_Cotizacions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [FolioVenta] in table 'VentasSet'
ALTER TABLE [dbo].[VentasSet]
ADD CONSTRAINT [PK_VentasSet]
    PRIMARY KEY CLUSTERED ([FolioVenta] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCategoria] in table 'Bodegas'
ALTER TABLE [dbo].[Bodegas]
ADD CONSTRAINT [FK_Category]
    FOREIGN KEY ([IdCategoria])
    REFERENCES [dbo].[Categorias]
        ([IdCategoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Category'
CREATE INDEX [IX_FK_Category]
ON [dbo].[Bodegas]
    ([IdCategoria]);
GO

-- Creating foreign key on [NoCliente] in table 'Cotizacions'
ALTER TABLE [dbo].[Cotizacions]
ADD CONSTRAINT [FK__Cotizacio__NoCli__15502E78]
    FOREIGN KEY ([NoCliente])
    REFERENCES [dbo].[Clientes]
        ([NoCliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Cotizacio__NoCli__15502E78'
CREATE INDEX [IX_FK__Cotizacio__NoCli__15502E78]
ON [dbo].[Cotizacions]
    ([NoCliente]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------