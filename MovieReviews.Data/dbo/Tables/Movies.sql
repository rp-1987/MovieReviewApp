CREATE TABLE [dbo].[Movies] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [MovieName]   VARCHAR (100)  NOT NULL,
    [ReleaseDate] DATETIME       NULL,
    [Rating]      VARCHAR (10)   NULL,
    [Director]    VARCHAR (200)  NULL,
    [Studio]      VARCHAR (200)  NULL,
    [Synopsis]    VARCHAR (5000) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

