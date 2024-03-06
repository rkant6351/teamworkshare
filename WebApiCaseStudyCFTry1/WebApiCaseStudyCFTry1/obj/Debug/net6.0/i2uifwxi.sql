IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Administrators] (
    [AdminId] int NOT NULL IDENTITY,
    [AdminEmail] nvarchar(max) NOT NULL,
    [AdminFullName] nvarchar(max) NOT NULL,
    [AdminPhoneNumber] nvarchar(max) NOT NULL,
    [AdminPassword] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Administrators] PRIMARY KEY ([AdminId])
);
GO

CREATE TABLE [Categories] (
    [CategoryId] int NOT NULL IDENTITY,
    [CategoryName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
);
GO

CREATE TABLE [Sellers] (
    [SellerId] int NOT NULL IDENTITY,
    [SellerEmail] nvarchar(max) NOT NULL,
    [SellerFullName] nvarchar(max) NOT NULL,
    [SellerPhoneNumber] nvarchar(max) NOT NULL,
    [SellerAddress] nvarchar(max) NOT NULL,
    [SellerPassword] nvarchar(max) NOT NULL,
    [SellerGender] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Sellers] PRIMARY KEY ([SellerId])
);
GO

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [FullName] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Gender] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Products] (
    [ProductId] int NOT NULL IDENTITY,
    [ProductName] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [QuantityInStock] int NOT NULL,
    [CategoryId] int NOT NULL,
    [SellerId] int NOT NULL,
    [CategoriesCategoryId] int NULL,
    [SellersSellerId] int NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
    CONSTRAINT [FK_Products_Categories_CategoriesCategoryId] FOREIGN KEY ([CategoriesCategoryId]) REFERENCES [Categories] ([CategoryId]),
    CONSTRAINT [FK_Products_Sellers_SellersSellerId] FOREIGN KEY ([SellersSellerId]) REFERENCES [Sellers] ([SellerId])
);
GO

CREATE TABLE [Orders] (
    [OrderId] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [OrderDate] datetime2 NULL,
    [ShippingAddress] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NULL,
    [Amount] decimal(18,2) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
    CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Cart] (
    [CartId] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL,
    [Amount] decimal(18,2) NULL,
    [CreatedAt] datetime2 NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY ([CartId]),
    CONSTRAINT [FK_Cart_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Cart_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Order_items] (
    [OrderItemId] int NOT NULL IDENTITY,
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL,
    [ItemTotalPrice] decimal(18,2) NULL,
    [OrdersOrderId] int NULL,
    [ProductsProductId] int NULL,
    CONSTRAINT [PK_Order_items] PRIMARY KEY ([OrderItemId]),
    CONSTRAINT [FK_Order_items_Orders_OrdersOrderId] FOREIGN KEY ([OrdersOrderId]) REFERENCES [Orders] ([OrderId]),
    CONSTRAINT [FK_Order_items_Products_ProductsProductId] FOREIGN KEY ([ProductsProductId]) REFERENCES [Products] ([ProductId])
);
GO

CREATE TABLE [Payments] (
    [PaymentId] int NOT NULL IDENTITY,
    [OrderId] int NOT NULL,
    [PaymentDate] datetime2 NULL,
    [PaymentStatus] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([PaymentId]),
    CONSTRAINT [FK_Payments_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Cart_ProductId] ON [Cart] ([ProductId]);
GO

CREATE INDEX [IX_Cart_UserId] ON [Cart] ([UserId]);
GO

CREATE INDEX [IX_Order_items_OrdersOrderId] ON [Order_items] ([OrdersOrderId]);
GO

CREATE INDEX [IX_Order_items_ProductsProductId] ON [Order_items] ([ProductsProductId]);
GO

CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
GO

CREATE INDEX [IX_Payments_OrderId] ON [Payments] ([OrderId]);
GO

CREATE INDEX [IX_Products_CategoriesCategoryId] ON [Products] ([CategoriesCategoryId]);
GO

CREATE INDEX [IX_Products_SellersSellerId] ON [Products] ([SellersSellerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240219163248_QuitQDb-Mig', N'6.0.27');
GO

COMMIT;
GO

