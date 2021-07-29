delete from LibraryBooks
delete from LibraryCategories
delete from LibraryUsers
delete from LibraryRoles
delete from LibraryUserDetails
delete from LibraryCities
delete from LibraryCountries

SET IDENTITY_INSERT [dbo].[LibraryCategories] ON 
INSERT [dbo].[LibraryCategories] ([Id], [Name]) VALUES (1, N'Library')
INSERT [dbo].[LibraryCategories] ([Id], [Name]) VALUES (2, N'Personal')
SET IDENTITY_INSERT [dbo].[LibraryCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[LibraryBooks] ON 
INSERT [dbo].[LibraryBooks] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (1, N'Rome',3000.0000, 10, 1)
INSERT [dbo].[LibraryBooks] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (2, N'Literature', 20.0000, 20, 1)
INSERT [dbo].[LibraryBooks] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (3, N'Comedy', 40.0000, 21, 1)
INSERT [dbo].[LibraryBooks] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (4, N'Poetry', 2500.0000, 5, 2)
INSERT [dbo].[LibraryBooks] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (5, N'Biography',  5000.0000, 9, 2)
INSERT [dbo].[LibraryBooks] ([Id], [Name], [UnitPrice], [StockAmount], [CategoryId]) VALUES (6, N'History',  2500.0000, 27, 1)
SET IDENTITY_INSERT [dbo].[LibraryBooks] OFF 
GO
set identity_insert LibraryRoles on
insert into LibraryRoles (Id,Name) values (1,'Admin')
insert into LibraryRoles (Id,Name) values (2,'User')
set identity_insert LibraryRoles off
go
set identity_insert LibraryCountries on
insert into LibraryCountries (Id,Name) values (1,'Turkey')
insert into LibraryCountries (Id,Name) values (2,'United States')
set identity_insert LibraryCountries off
go
set identity_insert LibraryCities on
insert into LibraryCities (Id, Name, CountryId) values (1, 'Ankara', 1)
insert into LibraryCities (Id, Name, CountryId) values (2, 'Amasya', 1)
insert into LibraryCities (Id, Name, CountryId) values (3, 'Nevşehir', 1)
insert into LibraryCities (Id, Name, CountryId) values (4, 'Canada', 2)
set identity_insert LibraryCities off
go
set identity_insert LibraryUserDetails on
insert into LibraryUserDetails (Id, EMail, CountryId, CityId, Address) values (1, 'erdal@sarısen.com', 1, 1, 'Etimesgut')
insert into LibraryUserDetails (Id, EMail, CountryId, CityId, Address) values (2, 'ragnar@lodbrok.com', 2, 4, 'Manitoba')
set identity_insert LibraryUserDetails off
go
set identity_insert LibraryUsers on
insert into LibraryUsers (Id, UserName, Password, Active, RoleId, UserDetailId) values (1, 'erdal', 'sarısen', 1, 1, 1)
insert into LibraryUsers (Id, UserName, Password, Active, RoleId, UserDetailId) values (2, 'ragnar', 'lodbrok', 1, 2, 2)
set identity_insert LibraryUsers off
go
