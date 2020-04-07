CREATE TABLE [dbo].[Cart] (
    [Id]              INT  IDENTITY (1, 1) NOT NULL,
    [UserId]          INT  NOT NULL,
    [DateLastUpdated] DATE NOT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cart_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);





