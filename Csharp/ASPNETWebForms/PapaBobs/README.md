#PapaBobs Databases

Add these inside PapaBobs.Web App_Data folder by running these scripts


Orders

```

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
    [Completed]    BIT              DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC)
);


```

PizzaPrice


```

CREATE TABLE [dbo].[PizzaPrice] (
    [Id]               INT        NOT NULL,
    [SmallSizeCost]    SMALLMONEY NOT NULL,
    [MediumSizeCost]   SMALLMONEY NOT NULL,
    [LargeSizeCost]    SMALLMONEY NOT NULL,
    [ThickCrustCost]   SMALLMONEY NOT NULL,
    [ThinCrustCost]    SMALLMONEY NOT NULL,
    [RegularCrustCost] SMALLMONEY NOT NULL,
    [SausageCost]      SMALLMONEY NOT NULL,
    [PepperoniCost]    SMALLMONEY NOT NULL,
    [OnionsCost]       SMALLMONEY NOT NULL,
    [GreenPeppersCost] SMALLMONEY NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

```

Prices consecutively

ID Small Med....
1 12.0000	14.0000	16.0000	2.0000	0.0000	0.0000	2.0000	1.5000	1.0000	1.0000
