IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblUserPasswords]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblUserPasswords](
  [UserId] [int] NOT NULL,
  [Password] [nvarchar](20) NOT NULL,

  CONSTRAINT [PK_tblUserPasswords] PRIMARY KEY CLUSTERED 
  (  [UserId] ASC, [Password] ASC ),

  CONSTRAINT [FK_tblUserPasswords_tblUsers] FOREIGN KEY([UserId])
  REFERENCES [dbo].[tblUsers] ([Id]),
);'