CREATE OR ALTER VIEW [dbo].[vwOrderManagementList]
as
 select io.Id,p.PolicyNumber,
 io.InspectionDate,
 io.StatusDate,
  io.AssignedDate,io.CreatedDate,
  InsuredName = p.InsuredFirstName + ' ' + p.InsuredLastName,
  Inspector = u.UserName,
  Status = i.Name,
  Location = p.Address,
  MitigationStatus = m.name,
     DateDifference = CASE 
        WHEN i.Name = 'Pending Assignment'
			Then Case
				when datediff(DAY, io.CreatedDate, GETDATE()) BETWEEN 0 AND 19 THEN '0-19'
				when datediff(DAY, io.CreatedDate, GETDATE()) BETWEEN 20 AND 39 THEN '20-39'
				ELSE '40-59'
				End
		WHEN i.Name = 'Ready To Schedule'
			Then Case
				when datediff(DAY, io.AssignedDate, GETDATE()) BETWEEN 0 AND 19 THEN '0-19'
				when datediff(DAY, io.AssignedDate, GETDATE()) BETWEEN 20 AND 39 THEN '20-39'
				ELSE '40-59'
				End
		WHEN i.Name = 'Scheduled'
			Then Case
				when datediff(DAY, io.InspectionDate , GETDATE()) BETWEEN 0 AND 19 THEN '0-19'
				when datediff(DAY, io.InspectionDate, GETDATE()) BETWEEN 20 AND 39 THEN '20-39'
				ELSE '40-59'
				End
        ELSE
			   Case
				when datediff(DAY, StatusDate , GETDATE()) BETWEEN 0 AND 19 THEN '0-19'
				when datediff(DAY, StatusDate, GETDATE()) BETWEEN 20 AND 39 THEN '20-39'
				ELSE '40-59'
				End
       END
 from inspectionorder io
inner JOIN policy p ON io.Id = p.Id
left JOIN [User] u ON io.inspectorId = u.Id
left JOIN InspectionStatus i ON p.InspectionStatusId = i.id
left JOIN MitigationStatus m ON p.MitigationStatusId = m.Id;