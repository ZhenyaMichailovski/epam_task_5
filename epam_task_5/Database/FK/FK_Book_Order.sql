ALTER TABLE [dbo].[Order]
	ADD CONSTRAINT [FK_Book_Order]
	FOREIGN KEY (IdBook)
	REFERENCES dbo.[Book] (Id)
