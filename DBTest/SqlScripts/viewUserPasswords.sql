SELECT dbo.tblUsers.Name, dbo.tblUserPasswords.Password
FROM   dbo.tblUserPasswords LEFT JOIN
             dbo.tblUsers ON dbo.tblUserPasswords.UserId = dbo.tblUsers.Id
WHERE dbo.tblUsers.Name = @NameField AND dbo.tblUserPasswords.Password = @PasswordField