CREATE OR ALTER VIEW [dbo].[vwUserManagementList]
as
 select 
u.Id,
u.FirstName,
u.LastName,
u.MiddleName,
u.CreatedDate,
u.LastModifiedDate,
u.DisplayName,
u.StreetAddress1,
u.StreetAddress2,
u.[State],
u.City,
u.MobileNumber,
u.ZipCode,
u.Email,
r.Id as RoleId,
r.Name as RoleName,
ProfilePhotoPath = i.FilePath,
i.ThumbnailPath,
  UserStatus = CASE 
        WHEN u.LastModifiedDate is null 
			THEN 'New'
        WHEN u.IsActivated = 0 
			THEN 'Inactive' 
        ELSE 'Active' 
		END
from [User] u
INNER JOIN UserRole ur ON u.Id = ur.UserId
INNER JOIN [Role] r ON ur.RoleId = r.Id
LEFT JOIN [Image] i ON u.ProfilePhotoId = i.Id


	