SELECT dbo.tblUserRoles.RoleId, dbo.tblRoles.Name AS Role
FROM   dbo.tblRoles LEFT JOIN
             dbo.tblUserRoles ON dbo.tblRoles.Id = dbo.tblUserRoles.RoleId
WHERE dbo.tblUserRoles.UserId =