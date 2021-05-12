delete from Books
delete from Categories
delete from Users
delete from Roles
delete from UserDetails
delete from Cities
delete from Countries

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
set identity_insert Roles on
insert into Roles (Id,Name) values (1,'Admin')
insert into Roles (Id,Name) values (2,'User')
set identity_insert Roles off
go
set identity_insert Countries on
insert into Countries (Id,Name) values (1,'Turkey')
insert into Countries (Id,Name) values (2,'United States')
set identity_insert Countries off
go
set identity_insert Cities on
insert into Cities (Id, Name, CountryId) values (1, 'Ankara', 1)
insert into Cities (Id, Name, CountryId) values (2, 'Amasya', 1)
insert into Cities (Id, Name, CountryId) values (3, 'Nevşehir', 1)
insert into Cities (Id, Name, CountryId) values (4, 'Canada', 2)
set identity_insert Cities off
go
set identity_insert UserDetails on
insert into UserDetails (Id, EMail, CountryId, CityId, Address) values (1, 'erdal@sarısen.com', 1, 1, 'Etimesgut')
insert into UserDetails (Id, EMail, CountryId, CityId, Address) values (2, 'ragnar@lodbrok.com', 2, 4, 'Manitoba')
set identity_insert UserDetails off
go
set identity_insert Users on
insert into Users (Id, UserName, Password, Active, RoleId, UserDetailId) values (1, 'erdal', 'sarısen', 1, 1, 1)
insert into Users (Id, UserName, Password, Active, RoleId, UserDetailId) values (2, 'ragnar', 'lodbrok', 1, 2, 2)
set identity_insert Users off
go
