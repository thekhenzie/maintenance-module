DROP TABLE [InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations];

GO

DROP TABLE [InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements];

GO

DROP TABLE [InspectionOrderWildfireAssessmentChildMitigationRecommendations];

GO

DROP TABLE [InspectionOrderWildfireAssessmentChildMitigationRequirements];

GO

ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRequirements] DROP CONSTRAINT [PK_InspectionOrderWildfireAssessmentMitigationRequirements];

GO

DROP INDEX [IX_InspectionOrderWildfireAssessmentMitigationRequirements_InspectionOrderWildfireAssessmentMitigationId] ON [InspectionOrderWildfireAssessmentMitigationRequirements];

GO

ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRecommendations] DROP CONSTRAINT [PK_InspectionOrderWildfireAssessmentMitigationRecommendations];

GO

DROP INDEX [IX_InspectionOrderWildfireAssessmentMitigationRecommendations_InspectionOrderWildfireAssessmentMitigationId] ON [InspectionOrderWildfireAssessmentMitigationRecommendations];

GO

ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] DROP CONSTRAINT [PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements];

GO

DROP INDEX [IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements_InspectionOrderPropertyNonWildfireAssessmentMitigationId] ON [InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements];

GO

ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] DROP CONSTRAINT [PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations];

GO

DROP INDEX [IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations_InspectionOrderPropertyNonWildfireId] ON [InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'InspectionOrderWildfireAssessmentMitigationRequirements') AND [c].[name] = N'Id');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRequirements] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRequirements] DROP COLUMN [Id];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'InspectionOrderWildfireAssessmentMitigationRecommendations') AND [c].[name] = N'Id');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRecommendations] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRecommendations] DROP COLUMN [Id];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements') AND [c].[name] = N'Id');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] DROP COLUMN [Id];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations') AND [c].[name] = N'Id');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] DROP COLUMN [Id];

GO

ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRequirements] ADD CONSTRAINT [PK_InspectionOrderWildfireAssessmentMitigationRequirements] PRIMARY KEY ([InspectionOrderWildfireAssessmentMitigationId], [ImageId]);

GO

ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRecommendations] ADD CONSTRAINT [PK_InspectionOrderWildfireAssessmentMitigationRecommendations] PRIMARY KEY ([InspectionOrderWildfireAssessmentMitigationId], [ImageId]);

GO

ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] ADD CONSTRAINT [PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] PRIMARY KEY ([InspectionOrderPropertyNonWildfireAssessmentMitigationId], [ImageId]);

GO

ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] ADD CONSTRAINT [PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] PRIMARY KEY ([InspectionOrderPropertyNonWildfireId], [ImageId]);

GO