CREATE TABLE [dbo].[CartProduct] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [CartId]   INT           NOT NULL,
    [Code]     VARCHAR (100) NOT NULL,
    [Quantity] INT           NOT NULL,
    CONSTRAINT [PK_CartProduct] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CartProduct_Cart] FOREIGN KEY ([CartId]) REFERENCES [dbo].[Cart] ([Id])
);





