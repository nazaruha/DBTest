SELECT dbo.tblUsers.Id AS UserId, dbo.tblUsers.Name, dbo.tblRegions.Id AS RegionId, dbo.tblRegions.Name AS Region, dbo.tblCities.Id AS CityId, dbo.tblCities.Name AS City, dbo.tblUserAddresses.Street, dbo.tblUserAddresses.HouseNumber, dbo.tblUserPasswords.Password
FROM   dbo.tblCities INNER JOIN
             dbo.tblRegions ON dbo.tblCities.RegionId = dbo.tblRegions.Id INNER JOIN
             dbo.tblUserAddresses ON dbo.tblCities.Id = dbo.tblUserAddresses.CityId INNER JOIN
             dbo.tblUsers ON dbo.tblUserAddresses.UserId = dbo.tblUsers.Id INNER JOIN
             dbo.tblUserPasswords ON dbo.tblUsers.Id = dbo.tblUserPasswords.UserId