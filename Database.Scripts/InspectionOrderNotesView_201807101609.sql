CREATE OR ALTER VIEW [dbo].[vwInspectionOrderNotesList]
as
 select  ion.Id,
 ion.Datemodified,
 ion.InspectionOrderId,
 ion.Notes,
 ion.Subject,
 UserName = u.Username,
 ModifiedBy = u.FirstName + ' ' + u.LastName
 from InspectionOrderNotes ion
inner JOIN [User] u ON ion.ModifiedById = u.Id