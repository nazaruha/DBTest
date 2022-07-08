IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblUserAddresses]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblUserAddresses](
  [UserId] [int] NOT NULL,
  [CityId] [int] NOT NULL,
  [Street] [nvarchar](150) NOT NULL,
  [HouseNumber] [nvarchar](50) NOT NULL,

 CONSTRAINT [PK_tblUserAddresses] PRIMARY KEY CLUSTERED 
 (  [UserId] ASC ),

 CONSTRAINT [FK_tblUserAddresses_tblUsers] FOREIGN KEY([UserId])
  REFERENCES [dbo].[tblUsers] ([Id]),

 CONSTRAINT [FK_tblUserAddresses_tblCities] FOREIGN KEY([CityId])
  REFERENCES [dbo].[tblCities] ([Id])
);'