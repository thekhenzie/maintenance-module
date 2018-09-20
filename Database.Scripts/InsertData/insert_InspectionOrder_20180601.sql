DECLARE @v_SYSTEM uniqueidentifier;
DECLARE @v_ADMIN uniqueidentifier;
DECLARE @v_UW uniqueidentifier;
DECLARE @v_MANAGER uniqueidentifier;
DECLARE @v_INSPECTOR uniqueidentifier;

SET @v_SYSTEM = (SELECT Id FROM [User] Where UserName = 'SYSTEM');
SET @v_ADMIN = (SELECT Id FROM [User] Where UserName = 'administrator_user');
SET @v_UW = (SELECT Id FROM [User] Where UserName = 'underwriter_user');
SET @v_MANAGER = (SELECT Id FROM [User] Where UserName = 'inspectormanager_user');
SET @v_INSPECTOR = (SELECT Id FROM [User] Where UserName = 'inspector_user');

INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'A802A811-E4C5-4E20-B920-EA9A2D8E20F3'),	NULL,			@v_SYSTEM,	'2018-05-10',	'2018-05-10',	NULL)
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'37C03D53-AD1D-40F1-BC7C-E756545E5125'),	'2018-02-07',	@v_SYSTEM,	'2018-01-07',	'2018-05-11',	'2018-03-07')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'FB02BA62-DB71-4B5D-B12E-CFD0DE8020DB'),	'2018-02-07',	@v_SYSTEM,	'2018-01-07',	'2018-05-12',	'2018-05-07')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'6DB4002A-D7EA-4160-8184-23D05544AE3B'),	'2018-02-17',	@v_ADMIN,	'2018-01-07',	'2018-05-13',	'2018-02-27')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'3E7E930D-1E6E-4223-BE5F-5A61C4799816'),	'2018-02-17',	@v_ADMIN,	'2018-01-07',	'2018-05-14',	'2018-03-27')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'CFE72B11-75FE-4926-AF47-11F9F9FDC1F2'),	'2018-05-15',	@v_ADMIN,	'2018-01-07',	'2018-05-15',	NULL)
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'73F2ABD6-A860-49C3-85A6-5D56B3912671'),	'2018-05-11',	@v_UW,	'2018-01-07',	'2018-05-16',	'2018-05-16')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'A84FC1FA-3D54-47E9-9FEE-2CAE54832258'),	'2018-02-07',	@v_UW,	'2018-01-07',	'2018-05-17',	'2018-05-10')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'0FA78A0F-299D-42CC-9F4D-B70144F061D2'),	'2018-02-07',	@v_UW,	'2018-01-07',	'2018-05-18',	'2018-05-07')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'2318D6A5-E61D-4F9E-AB72-F1A83F0C53F9'),	NULL,			@v_MANAGER,	'2018-05-11',	'2018-05-11',	NULL)
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'4CFD402F-2E5E-4FD9-AA5A-BA6DACF29294'),	NULL,			@v_MANAGER,	'2018-04-26',	'2018-04-23',	NULL)
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'A5FCEA57-0906-4746-AFEC-A940038A8261'),	'2018-02-07',	@v_MANAGER,	'2018-01-07',	'2018-04-24',	'2018-04-07')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'5EF6DBD0-273F-4DA0-99E8-350F4A0727A3'),	'2018-02-07',	@v_INSPECTOR,	'2018-01-07',	'2018-04-25',	'2018-04-07')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'CC0C5854-BE0C-42A7-A52C-1DA311E0F753'),	'2018-02-07',	@v_INSPECTOR,	'2018-01-07',	'2018-04-26',	'2018-04-07')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'D6E03796-5979-4EA9-8ED9-28F0B9C593D9'),	'2018-02-07',	@v_INSPECTOR,	'2018-01-07',	'2018-04-27',	'2018-04-07')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'87E1ADC7-D041-4429-8CBF-D39C7084FB62'),	'2018-04-28',	@v_SYSTEM,	'2018-01-07',	'2018-04-28',	NULL)
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'6A1DE4EE-744C-491B-9F77-B1193EBC71EA'),	'2018-02-02',	@v_SYSTEM,	'2018-01-07',	'2018-04-29',	'2018-04-29')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'2B986C48-16C5-461E-83B8-B03E5FDF8DB6'),	'2018-02-07',	@v_SYSTEM,	'2018-01-07',	'2018-04-30',	'2018-04-07')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'DE2F3998-8CD8-4862-9ED1-E4E08A558025'),	'2018-02-07',	@v_ADMIN,	'2018-01-07',	'2018-05-01',	'2018-04-07')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'3BCBAF90-DF00-4FED-AE73-331E845D910A'),	'2018-02-07',	@v_ADMIN,	'2018-01-07',	'2018-05-02',	'2018-05-02')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'188F5715-093B-47AF-8688-4DA6795CE13C'),	NULL,			@v_ADMIN,	'2018-03-25',	'2018-03-25',	NULL)
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'86BB623C-D906-45AF-9810-085B1F7431AE'),	'2018-03-26',	@v_UW,	'2018-01-07',	'2018-03-26',	NULL)
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'40C7D478-ADB6-4A93-AD49-5299D9BD98A6'),	'2018-03-25',	@v_UW,	'2018-01-07',	'2018-03-27',	'2018-03-27')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'FB404CFF-AEB5-46BB-8977-E5D7002C6D0C'),	'2018-03-25',	@v_SYSTEM,	'2018-01-07',	'2018-03-28',	'2018-03-27')
INSERT INTO [dbo].[InspectionOrder]([Id],[AssignedDate],[InspectorId],[CreatedDate],[StatusDate],[InspectionDate])VALUES(	CONVERT(uniqueidentifier,'B563B7A9-967B-4BED-A862-1C54D83E36F8'),	'2018-03-25',	@v_SYSTEM,	'2018-01-07',	'2018-03-29',	'2018-03-29')


INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'A802A811-E4C5-4E20-B920-EA9A2D8E20F3'),	'Francisco Mercado St. cor. Jose P. Rizal St., Brgy. 5, Poblacion, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PA',	'Jose ',	'Rizal',	'Protacio',	'C',	'SRHO 122518-01',	'HV',	1,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'37C03D53-AD1D-40F1-BC7C-E756545E5125'),	'Ermita, Manila, 1000 Metro Manila, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PQC',	'Andress',	'Bonifacio',	'',	'C',	'SRHO 122518-02',	'HV',	2,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'FB02BA62-DB71-4B5D-B12E-CFD0DE8020DB'),	'A. Mabini Campus, Anonas, Sta. Mesa, Maynila, 1016 Kalakhang Maynila, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PQCI',	'Apolonario ',	'Mabini',	'',	'C',	'SRHO 122518-03',	'HV',	3,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'6DB4002A-D7EA-4160-8184-23D05544AE3B'),	'Sitio Cupang Brgy. San Nicolas, Santa Maria, Luzon 3017, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PUWR',	'Marcelo',	'Del Pilar',	'Hidalgo',	'C',	'SRHO 122518-04',	'HV',	4,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'3E7E930D-1E6E-4223-BE5F-5A61C4799816'),	'Rizal Street, Badoc, Ilocos Norte, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PWU',	'Juan',	'Luna',	'',	'C',	'SRHO 122518-05',	'HV',	5,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'CFE72B11-75FE-4926-AF47-11F9F9FDC1F2'),	'Banlat Road, Tandang Sora , 1116 Quezon City , Metro Manila, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'RTS',	'Melchora',	'Aquino',	'',	'C',	'SRHO 122518-06',	'HV',	6,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'73F2ABD6-A860-49C3-85A6-5D56B3912671'),	'Ayala Ave, Makati, Metro Manila,Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'S',	'Gabriela',	'Silang',	'',	'C',	'SRHO 122518-07',	'HV',	7,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'A84FC1FA-3D54-47E9-9FEE-2CAE54832258'),	'Mount Tirad,Tirad Pass National Shrine-Gregorio Del Pilar,Ilocos Sur, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'UWA',	'Gregorio ',	'Del Pilar',	'',	'C',	'SRHO 122518-08',	'HV',	8,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'0FA78A0F-299D-42CC-9F4D-B70144F061D2'),	'Brgy Kaingen, Kawit, Cavite, 4104, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'UWI',	'Emilio ',	'Aguinaldo',	'',	'C',	'SRHO 122518-09',	'HV',	9,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'2318D6A5-E61D-4F9E-AB72-F1A83F0C53F9'),	'Padre Burgos Ave, Ermita, Manila, 1002 Metro Manila, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PA',	'Mariano',	'Gomez',	'',	'C',	'SRHO 122518-10',	'HV',	10,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'4CFD402F-2E5E-4FD9-AA5A-BA6DACF29294'),	'Padre Burgos Ave, Ermita, Manila, 1002 Metro Manila, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PA',	'Jose',	'Burgos',	'',	'C',	'SRHO 122518-11',	'HV',	11,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'A5FCEA57-0906-4746-AFEC-A940038A8261'),	'Padre Burgos Ave, Ermita, Manila, 1002 Metro Manila, Philippines',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PQC',	'Jacinto',	'Zamora',	'',	'C',	'SRHO 122518-12',	'HV',	12,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'5EF6DBD0-273F-4DA0-99E8-350F4A0727A3'),	'Brooklyn, New York City, New York, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PQCI',	'Michael',	'Jordan',	'His Airness',	'C',	'SRHO 122518-13',	'HV',	13,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'CC0C5854-BE0C-42A7-A52C-1DA311E0F753'),	'New York City, New York, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PUWR',	'Kareem',	'Jabbar',	'Abdul',	'C',	'SRHO 122518-14',	'HV',	14,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'D6E03796-5979-4EA9-8ED9-28F0B9C593D9'),	'West Baden Springs, Indiana, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PWU',	'Larry',	'Bird',	'Big',	'C',	'SRHO 122518-15',	'HV',	15,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'87E1ADC7-D041-4429-8CBF-D39C7084FB62'),	'Philadelphia, Pennsylvania, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'RTS',	'Wilt',	'Chamberlain',	'The Stilt',	'C',	'SRHO 122518-16',	'HV',	16,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'6A1DE4EE-744C-491B-9F77-B1193EBC71EA'),	'East Meadow, New York, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'S',	'Julius',	'Erving',	'Dr.J',	'C',	'SRHO 122518-17',	'HV',	17,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'2B986C48-16C5-461E-83B8-B03E5FDF8DB6'),	'Kingston, Jamaica',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'UWA',	'Patrick',	'Ewing',	'Hoya Destroya',	'C',	'SRHO 122518-18',	'HV',	18,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'DE2F3998-8CD8-4862-9ED1-E4E08A558025'),	'Lansing, Michigan, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'UWI',	'Magic',	'Johnson',	'The Magic',	'C',	'SRHO 122518-19',	'HV',	19,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'3BCBAF90-DF00-4FED-AE73-331E845D910A'),	'Summerfield, Louisiana, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'S',	'Karl',	'Malone',	'The Mailman',	'C',	'SRHO 122518-20',	'HV',	20,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'188F5715-093B-47AF-8688-4DA6795CE13C'),	'Lagos, Nigeria',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PA',	'Hakeem',	'Olajuwon',	'The Dream',	'C',	'SRHO 122518-21',	'HV',	21,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'86BB623C-D906-45AF-9810-085B1F7431AE'),	'Newark, New Jersey, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'RTS',	'Shaquille',	'O''neal',	'Shaq',	'C',	'SRHO 122518-22',	'HV',	22,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'40C7D478-ADB6-4A93-AD49-5299D9BD98A6'),	'Key West, Florida, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'S',	'David',	'Robinson',	'The Admiral',	'C',	'SRHO 122518-23',	'HV',	23,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'FB404CFF-AEB5-46BB-8977-E5D7002C6D0C'),	'Spokane, Washington, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'PWU',	'John',	'Stockton',	'Stock',	'C',	'SRHO 122518-24',	'HV',	24,	14.5852723,	121.061324)
INSERT INTO [dbo].[Policy]([Id],[Address],[AgencyName],[AgencyPhoneNumber],[AgentName],[AgentPhoneNumber],[CoverageA],[E2ValueReplacementCostValue],[ITVPercentage],[InspectionDate],[InspectionStatusId],[InsuredFirstName],[InsuredLastName],[InsuredMiddleName],[MitigationStatusId],[PolicyNumber],[PropertyValueId],[WildfireAssessmentRequired],[Latitude],[Longitude])VALUES(	CONVERT(uniqueidentifier,'B563B7A9-967B-4BED-A862-1C54D83E36F8'),	'Chelyan, West Virginia, United States',	NULL,	NULL,	'Rinoa Heartily',	'+63 (518) 597-2675',	2,	1000000,	90,	'2018-05-07',	'S',	'Jerry',	'West',	'Mr. Clutch',	'C',	'SRHO 122518-25',	'HV',	25,	14.5852723,	121.061324)
