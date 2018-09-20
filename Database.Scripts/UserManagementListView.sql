CREATE OR ALTER VIEW [dbo].[vwUserManagementList]
as
 select 
u.Id,
u.FirstName,
u.LastName,
u.MiddleName,
u.CreatedDate,
u.LastModifiedDate,
u.ProfilePhoto,
u.DisplayName,
u.StreetAddress1,
u.StreetAddress2,
u.[State],
u.City,
u.MobileNumber,
u.ZipCode,
r.Id as RoleId,
r.Name as RoleName
 from [User] u
INNER JOIN UserRole ur ON u.Id = ur.UserId
INNER JOIN [Role] r ON ur.RoleId = r.Id


	