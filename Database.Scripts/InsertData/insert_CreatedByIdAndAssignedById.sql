DECLARE @v_UW uniqueidentifier;
DECLARE @v_MANAGER uniqueidentifier;
DECLARE @v_INSPECTOR uniqueidentifier;

SET @v_UW = (SELECT Id FROM [User] Where UserName = 'underwriter_user');
SET @v_MANAGER = (SELECT Id FROM [User] Where UserName = 'inspectormanager_user');
SET @v_INSPECTOR = (SELECT Id FROM [User] Where UserName = 'inspector_user');


UPDATE InspectionOrder
SET
CreatedById = @v_UW
WHERE
CreatedById IS NULL

UPDATE io
SET
AssignedById = @v_MANAGER
FROM InspectionOrder io
INNER JOIN [policy] p ON io.Id = p.Id
WHERE
io.AssignedById IS NULL AND p.InspectionStatusId NOT IN ('PA')

UPDATE io
SET
InspectorId = @v_INSPECTOR
FROM InspectionOrder io
INNER JOIN [policy] p ON io.Id = p.Id
WHERE
io.InspectorId IS NULL AND p.InspectionStatusId NOT IN ('PA')

GO
