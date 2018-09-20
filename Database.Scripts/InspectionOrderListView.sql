CREATE OR ALTER VIEW [dbo].[vwOrderManagementList]
as
 select io.Id,p.PolicyNumber,
io.DateAssigned,io.DateCreated,
  InsuredName = p.InsuredFirstName + ' ' + p.InsuredLastName,
  Inspector = u.UserName,
  Status = i.Name,
  Location = p.Address,
  MitigationStatus = m.Name,
     DateDifference = CASE 
        WHEN datediff(DAY, DateAssigned, GETDATE()) BETWEEN 0 AND 19 THEN '0-19'
        WHEN datediff(DAY, DateAssigned, GETDATE()) BETWEEN 20 AND 38 THEN '20-38'
        ELSE '39-57'
       END
 from inspectionorder io
INNER JOIN policy p ON io.Id = p.Id
INNER JOIN [User] u ON io.inspectorId = u.Id
INNER JOIN InspectionStatus i ON p.InspectionStatusId = i.id
INNER JOIN MitigationStatus m ON p.MitigationStatusId = m.Id;