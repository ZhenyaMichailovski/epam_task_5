--- Book
insert into dbo.Book(Name, Author, Genre, Returned, Condition)
values('Book1', 'Author1', 'Genre1', 1, 1),
('Book2', 'Author2', 'Genre2', 2, 2),
('Book3', 'Author3', 'Genre3', 1, 3),
('Book4', 'Author4', 'Genre4', 2, 1),
('Book5', 'Author5', 'Genre5', 1, 2)

--- Client
insert into dbo.Client(FIO, DateOfBirth, Sex)
values('FIO1', '2001-12-12 12:12:12', 'Sex1'),
('FIO2', '2001-11-12 12:12:12', 'Sex2'),
('FIO3', '2001-10-12 12:12:12', 'Sex3'),
('FIO4', '2001-9-12 12:12:12', 'Sex4'),
('FIO5', '2001-8-12 12:12:12', 'Sex5')

--- Order
insert into dbo.[Order](IdBook, IdClient, OrderDate,ReturnCondition)
values(1, 1, '2002-11-12 12:12:12',NULL),
(2, 2, '2003-11-12 12:12:12', 1),
(3, 3, '2004-11-12 12:12:12', NULL),
(4, 4, '2005-11-12 12:12:12', 2),
(5, 5, '2006-11-12 12:12:12', 3)