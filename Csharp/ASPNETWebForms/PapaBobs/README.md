Database Design

Add this inside the App_Data under PapaBobs.Web

CREATE TABLE [dbo].[Orders] (
    [OrderId]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Size]         INT              NOT NULL,
    [Crust]        INT              NOT NULL,
    [Sausage]      BIT              DEFAULT ((0)) NOT NULL,
    [Pepperoni]    BIT              DEFAULT ((0)) NOT NULL,
    [Onions]       BIT              DEFAULT ((0)) NOT NULL,
    [GreenPeppers] BIT              DEFAULT ((0)) NOT NULL,
    [TotalCost]    SMALLMONEY       DEFAULT ((0)) NOT NULL,
    [Name]         NVARCHAR (50)    NOT NULL,
    [Address]      NVARCHAR (50)    NOT NULL,
    [Zip]          NVARCHAR (50)    NOT NULL,
    [Phone]        NVARCHAR (50)    NOT NULL,
    [PaymentType]  INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC)
);
