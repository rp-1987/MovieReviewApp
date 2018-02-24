CREATE TABLE [dbo].[Critics] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [CriticName]  VARCHAR (100) NOT NULL,
    [Publication] VARCHAR (100) NULL,
    [IsTopCritic] BIT           CONSTRAINT [DF_Critics_IsTopCritic] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__Critics__3214EC07578B23F1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

