CREATE TABLE [dbo].[MovieReviews] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [MovieId]         INT            NOT NULL,
    [CriticId]        INT            NOT NULL,
    [ReviewSynopsis]  VARCHAR (5000) NOT NULL,
    [IsGood]          BIT            CONSTRAINT [DF_MovieReviews_IsGood] DEFAULT ((0)) NOT NULL,
    [ReviewRatingNum] NUMERIC (6, 2) NOT NULL,
    [ReviewRatingDen] NUMERIC (6, 2) NOT NULL,
    [ReviewUrl]       VARCHAR (500)  NULL,
    CONSTRAINT [PK__MovieRev__3214EC07CF6FDBDD] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__MovieRevi__Criti__1B0907CE] FOREIGN KEY ([CriticId]) REFERENCES [dbo].[Critics] ([Id]),
    CONSTRAINT [FK__MovieRevi__Movie__1A14E395] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movies] ([Id])
);

