CREATE TABLE [dbo].[Product] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Code]             VARCHAR (150)  NOT NULL,
    [isActive]         BIT            NOT NULL,
    [Name]             VARCHAR (50)   NOT NULL,
    [Image]            VARCHAR (1000) NOT NULL,
    [ShortDescription] VARCHAR (2000) NOT NULL,
    [Price]            DECIMAL (18)   NOT NULL,
    [ShippingPrice]    DECIMAL (18)   NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);



