CREATE TABLE [dbo].[MoviePosters] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [MovieId]     INT             NOT NULL,
    [PosterImage] VARBINARY (MAX) NULL,
    [MimeType]    VARCHAR (200)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movies] ([Id])
);

