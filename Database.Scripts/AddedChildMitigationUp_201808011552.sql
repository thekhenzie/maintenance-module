ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRequirements] DROP CONSTRAINT [PK_InspectionOrderWildfireAssessmentMitigationRequirements];

GO

ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRecommendations] DROP CONSTRAINT [PK_InspectionOrderWildfireAssessmentMitigationRecommendations];

GO

ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] DROP CONSTRAINT [PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements];

GO

ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] DROP CONSTRAINT [PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations];

GO

ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRequirements] ADD [Id] uniqueidentifier NOT NULL DEFAULT newId();

GO

ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRecommendations] ADD [Id] uniqueidentifier NOT NULL DEFAULT newId();

GO

ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] ADD [Id] uniqueidentifier NOT NULL DEFAULT newId();

GO

ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] ADD [Id] uniqueidentifier NOT NULL DEFAULT newId();

GO

ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRequirements] ADD CONSTRAINT [PK_InspectionOrderWildfireAssessmentMitigationRequirements] PRIMARY KEY ([Id]);

GO

ALTER TABLE [InspectionOrderWildfireAssessmentMitigationRecommendations] ADD CONSTRAINT [PK_InspectionOrderWildfireAssessmentMitigationRecommendations] PRIMARY KEY ([Id]);

GO

ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] ADD CONSTRAINT [PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] PRIMARY KEY ([Id]);

GO

ALTER TABLE [InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] ADD CONSTRAINT [PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] PRIMARY KEY ([Id]);

GO

CREATE TABLE [InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations] (
    [IoNWaParentMitigationRecommendationsId] uniqueidentifier NOT NULL,
    [ImageId] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations] PRIMARY KEY ([IoNWaParentMitigationRecommendationsId], [ImageId]),
    CONSTRAINT [FK_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations_Image] FOREIGN KEY ([ImageId]) REFERENCES [Image] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_IoNwaChildMitigationRecommendations_IoNWaParentMitigationRecommendations] FOREIGN KEY ([IoNWaParentMitigationRecommendationsId]) REFERENCES [InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements] (
    [IoNWaParentMitigationRequirementsId] uniqueidentifier NOT NULL,
    [ImageId] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements] PRIMARY KEY ([IoNWaParentMitigationRequirementsId], [ImageId]),
    CONSTRAINT [FK_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements_Image] FOREIGN KEY ([ImageId]) REFERENCES [Image] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_IoNwaChildMitigationRecommendations_IoNWaParentMitigationRequirements] FOREIGN KEY ([IoNWaParentMitigationRequirementsId]) REFERENCES [InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [InspectionOrderWildfireAssessmentChildMitigationRecommendations] (
    [IoWaParentMitigationRecommendationsId] uniqueidentifier NOT NULL,
    [ImageId] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_InspectionOrderWildfireAssessmentChildMitigationRecommendations] PRIMARY KEY ([IoWaParentMitigationRecommendationsId], [ImageId]),
    CONSTRAINT [FK_InspectionOrderWildfireAssessmentChildMitigationRecommendations_Image] FOREIGN KEY ([ImageId]) REFERENCES [Image] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_IoWaMitigationRecommendations_IoWaParentMitigationRecommendations] FOREIGN KEY ([IoWaParentMitigationRecommendationsId]) REFERENCES [InspectionOrderWildfireAssessmentMitigationRecommendations] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [InspectionOrderWildfireAssessmentChildMitigationRequirements] (
    [IoWaParentMitigationRequirementsId] uniqueidentifier NOT NULL,
    [ImageId] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_InspectionOrderWildfireAssessmentChildMitigationRequirements] PRIMARY KEY ([IoWaParentMitigationRequirementsId], [ImageId]),
    CONSTRAINT [FK_InspectionOrderWildfireAssessmentChildMitigationRequirements_Image] FOREIGN KEY ([ImageId]) REFERENCES [Image] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_IoWaMitigationRequirements_IoWaParentMitigationRequirements] FOREIGN KEY ([IoWaParentMitigationRequirementsId]) REFERENCES [InspectionOrderWildfireAssessmentMitigationRequirements] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_InspectionOrderWildfireAssessmentMitigationRequirements_InspectionOrderWildfireAssessmentMitigationId] ON [InspectionOrderWildfireAssessmentMitigationRequirements] ([InspectionOrderWildfireAssessmentMitigationId]);

GO

CREATE INDEX [IX_InspectionOrderWildfireAssessmentMitigationRecommendations_InspectionOrderWildfireAssessmentMitigationId] ON [InspectionOrderWildfireAssessmentMitigationRecommendations] ([InspectionOrderWildfireAssessmentMitigationId]);

GO

CREATE INDEX [IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements_InspectionOrderPropertyNonWildfireAssessmentMitigationId] ON [InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements] ([InspectionOrderPropertyNonWildfireAssessmentMitigationId]);

GO

CREATE INDEX [IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations_InspectionOrderPropertyNonWildfireId] ON [InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations] ([InspectionOrderPropertyNonWildfireId]);

GO

CREATE INDEX [IX_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations_ImageId] ON [InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations] ([ImageId]);

GO

CREATE INDEX [IX_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements_ImageId] ON [InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements] ([ImageId]);

GO

CREATE INDEX [IX_InspectionOrderWildfireAssessmentChildMitigationRecommendations_ImageId] ON [InspectionOrderWildfireAssessmentChildMitigationRecommendations] ([ImageId]);

GO

CREATE INDEX [IX_InspectionOrderWildfireAssessmentChildMitigationRequirements_ImageId] ON [InspectionOrderWildfireAssessmentChildMitigationRequirements] ([ImageId]);

GO