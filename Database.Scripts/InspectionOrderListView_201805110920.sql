CREATE OR ALTER VIEW [dbo].[vwOrderManagementList]
as
 select io.Id,p.PolicyNumber,
io.DateAssigned,io.DateCreated,
  InsuredName = p.InsuredFirstName + ' ' + p.InsuredLastName,
  Inspector = u.UserName,
  Status = i.Name,
  Location = p.Address,
  MitigationStatus = m.name,
     DateDifference = CASE 
        WHEN datediff(DAY, DateAssigned, GETDATE()) BETWEEN 0 AND 19 THEN '0-19'
        WHEN datediff(DAY, DateAssigned, GETDATE()) BETWEEN 20 AND 39 THEN '20-39'
        ELSE '40-59'
       END
 from inspectionorder io
inner JOIN policy p ON io.Id = p.Id
left JOIN [User] u ON io.inspectorId = u.Id
left JOIN InspectionStatus i ON p.InspectionStatusId = i.id
left JOIN MitigationStatus m ON p.MitigationStatusId = m.Id;