CREATE OR ALTER VIEW [dbo].[vwInspectionOrderNotesList]
as
 select  ion.Id,
 ion.Datemodified,
 ion.InspectionOrderId,
 ion.Notes,
 ion.Subject,
 ModifiedBy = u.UserName
 from InspectionOrderNotes ion
inner JOIN [User] u ON ion.ModifiedById = u.Id