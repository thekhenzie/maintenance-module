CREATE OR ALTER VIEW [dbo].[vwInspectionStatusGroupings]
as
select 
StatusId = s.Id,
Status = s.Name,
ZeroToNineteenDays =  (SELECT COUNT(Id)
	FROM vwOrderManagementList vw where DateDifference = '0-19' and s.Name = vw.Status),
TwentyToThirtyNineDays = (SELECT COUNT(Id)
	FROM vwOrderManagementList vw where DateDifference = '20-39' and s.Name = vw.Status),
FortyToFiftyNineDays = (SELECT COUNT(Id)
	FROM vwOrderManagementList vw where DateDifference = '40-59' and s.Name = vw.Status)
from InspectionStatus s