ALTER TABLE [dbo].[Order]
	ADD CONSTRAINT [FK_Client_Order]
	FOREIGN KEY (IdClient)
	REFERENCES dbo.[Client] (Id)
