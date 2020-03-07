CREATE TABLE [dbo].[ProductDetails] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [ProductId]     INT          NOT NULL,
    [DatePublished] DATE         NOT NULL,
    [Condition]     INT          NOT NULL,
    [Gender]        INT          NOT NULL,
    [Color]         INT          NOT NULL,
    [Model]         INT          NOT NULL,
    [PublishedBy]   INT          NOT NULL,
    [ShippingFrom]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ProductDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductDetails_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_ProductDetails_User] FOREIGN KEY ([PublishedBy]) REFERENCES [dbo].[User] ([Id])
);

