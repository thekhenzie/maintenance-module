CREATE OR ALTER VIEW [dbo].[vwOrderManagementList]
as
SELECT a.*,
 IsLockedByUserName = uIO.UserName
FROM (
 select io.Id,p.PolicyNumber,
 io.InspectionDate,
 io.AssignedDate,io.CreatedDate,
 pg.StreetAddress1,
 pg.StreetAddress2,
 pg.ZipCode,
 InsuredName = p.InsuredFirstName + ' ' + p.InsuredLastName,
 InspectorId = u.Id,
 Inspector = u.FirstName + ' ' + u.LastName,
 Status = i.Name,
 State = s.Name,
 City = c.Name,
 Location = p.Address,
 MitigationStatus = m.name,
 StatusId = i.Id,
 MitigationId = m.Id,
 Username = u.UserName,
 InceptionDate = p.InceptionDate,
 IsLocked = io.isLocked,
 IsLockedById = io.isLockedById,
      DateDifference = CASE 
        WHEN p.InceptionDate IS NULL THEN NULL
        WHEN datediff(DAY, p.InceptionDate, GETDATE()) BETWEEN 0 AND 19 THEN '0-19'
        WHEN datediff(DAY, p.InceptionDate, GETDATE()) BETWEEN 20 AND 39 THEN '20-39'
	WHEN datediff(DAY, p.InceptionDate, GETDATE()) < 0 THEN '0-19'
        ELSE '40 and above'
       END,
	p.Longitude,
	p.Latitude
 from inspectionorder io
inner JOIN policy p ON io.Id = p.Id
left JOIN [User] u ON io.inspectorId = u.Id
left JOIN InspectionStatus i ON p.InspectionStatusId = i.id
left JOIN MitigationStatus m ON p.MitigationStatusId = m.Id
left JOIN InspectionOrderPropertyGeneral PG ON io.Id = PG.Id
left JOIN State s ON pg.StateId = s.Id
left JOIN City c ON pg.CityId = c.Id) a
left JOIN [User] uIO ON a.isLockedById = uIO.Id;

GO


