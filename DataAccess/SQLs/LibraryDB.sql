delete from Books
delete from Categories

SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Library')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Personal')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (1, N'Rome',3000.0000, 10, 1)
INSERT [dbo].[Books] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (2, N'Literature', 20.0000, 20, 1)
INSERT [dbo].[Books] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (3, N'Comedy', 40.0000, 21, 1)
INSERT [dbo].[Books] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (4, N'Poetry', 2500.0000, 5, 2)
INSERT [dbo].[Books] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (5, N'Biography',  5000.0000, 9, 2)
INSERT [dbo].[Books] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (6, N'History',  2500.0000, 27, 1)
SET IDENTITY_INSERT [dbo].[Books] OFF 
GO