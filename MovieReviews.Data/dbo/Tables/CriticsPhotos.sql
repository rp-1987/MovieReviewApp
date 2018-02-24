CREATE TABLE [dbo].[CriticsPhotos] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [CriticId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__CriticsPh__Criti__173876EA] FOREIGN KEY ([CriticId]) REFERENCES [dbo].[Critics] ([Id])
);

