using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.OrderManagement;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.CustomCodes;
using Rivington.IG.Domain.Models.Views;
using Rivington.IG.Domain.Models.ViewModel;
using EntityFrameworkCore.Triggers;
using Rivington.IG.Domain.InspectionOrderLog;
using Rivington.IG.Domain.ViewModel;
using System.Net.Mail;
using System.Text;
using Rivington.IG.Domain.Models.Constants;
using Rivington.IG.Domain.Models.Utils;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderRepository : RepositoryBase<InspectionOrder>, IInspectionOrderRepository
    {
        private readonly IRivingtonContext context;
        private readonly RivingtonContext _dbSet;
        private readonly IInspectionOrderMitigationRepository _ioMitigationRepository;
        private readonly IImageService _imageService;
        private readonly IImageRepository _imageRepository;
        private readonly IInspectionOrderLog _inspectionOrderLog;

        public InspectionOrderRepository(
            IRivingtonContext context,
            RivingtonContext dbSet,
            IInspectionOrderMitigationRepository ioMitigationRepository,
            IImageService imageService,
            IImageRepository imageRepository,
            IInspectionOrderLog inspectionOrderLog) : base(context)
        {
            this.context = context;
            _dbSet = dbSet;
            _ioMitigationRepository = ioMitigationRepository;
            _imageService = imageService;
            _imageRepository = imageRepository;
            _inspectionOrderLog = inspectionOrderLog;
        }

        public InspectionOrder Retrieve(Guid id)
        {
            return Context.Set<InspectionOrder>().Include(x => x.Policy)
                .Include(x => x.Inspector)
                .Include(x => x.Policy.MitigationStatus)
                .Include(x => x.Policy.InspectionStatus)
                .Include(x => x.Policy.PropertyValue)
                .Include(x => x.Property)
                .Include(x => x.Property.General)
                .Include(x => x.Property.General.City)
                .Include(x => x.Property.General.State)
                .SingleOrDefault(x => x.Id.Equals(id));
        }

        public InspectionOrder RetrieveForGeneratingRiskSummary(Guid id)
        {
            return Context.Set<InspectionOrder>().Include(x => x.Policy)
                .Include(x => x.Property)
                .Include(x => x.Property.General)
                .Include(x => x.Property.General.OccupancyType)
                .Include(x => x.Property.General.DomesticHelpTypes)
                .Include(x => x.Property.General.FireAlarm)
                .Include(x => x.Property.General.FireAlarmType)
                .Include(x => x.Property.General.BurglarAlarm)
                .Include(x => x.Property.General.BurglarAlarmType)
                .Include(x => x.Property.InteriorDetail)
                .Include(x => x.Property.InteriorDetail.TypeOfPlumbings).ThenInclude(x => x.TypeOfPlumbing)
                .Include(x => x.Property.HomeDetail)
                .Include(x => x.Property.HomeDetail.FramingType)
                .Include(x => x.Property.HomeDetail.PrimaryExteriorWallCovering)
                .Include(x => x.Property.HomeDetail.PrimaryRoofCovering)
                .Include(x => x.Property.BuildingConcern)
                .Include(x => x.Property.BuildingConcern.PlumbingConcernDetails).ThenInclude(x => x.PlumbingConcernDetail)
                .Include(x => x.Property.BuildingConcern.ElectricalConcernDetails).ThenInclude(x => x.ElectricalConcernDetail)
                .Include(x => x.WildfireAssessment)
                .Include(x => x.WildfireAssessment.ExternalFuelSource)
                .Include(x => x.Property.AdditionalExposure)
                .Include(x => x.Property.AdditionalExposure.BearInvasionConcernDetails).ThenInclude(x => x.BearInvasionConcernDetail)
                .SingleOrDefault(x => x.Id.Equals(id));
        }

        public new InspectionOrder RetrieveReportTitlePage(Guid id)
        {
            return Context.Set<InspectionOrder>().Include(x => x.Policy)
                .Include(x => x.Inspector)
                .Include(x => x.PropertyPhoto).ThenInclude(x => x.Photos).ThenInclude(x => x.Image)
                .SingleOrDefault(x => x.Id.Equals(id));
        }

        public new InspectionOrder RetrievePolicyPremiumCredits(Guid id)
        {
            return Context.Set<InspectionOrder>()
                .Include(x => x.Property.General).ThenInclude(x => x.PolicyPremiumCredits).ThenInclude(x => x.PolicyPremiumCredit)
                .SingleOrDefault(x => x.Id.Equals(id));
        }

        public new InspectionOrder RetrieveRiskSummary(Guid id)
        {
            return Context.Set<InspectionOrder>()
                .SingleOrDefault(x => x.Id.Equals(id));
        }

        public RetrieveResult<InspectionOrder> RetrieveWithInlcude(DataSourceRequest request, DateTime? scheduledDate)
        {
            //var dbSet = context.Set<InspectionOrder>();

            var dbSet = context.Set<InspectionOrder>()
               .Include(x => x.Inspector)
               .Include(x => x.Policy)
               .Include(x => x.Policy.InspectionStatus)
               .AsQueryable();

            if (scheduledDate != null)
            {
                scheduledDate = scheduledDate.Value.ToUniversalTime().ToLocalTime();

                dbSet = dbSet.Where(x => x.Policy.InspectionDate == scheduledDate
                 && x.Policy.InspectionStatusId.Equals("S"));
            }

            return Retrieve(dbSet, request);

        }

        public void InsertOrUpdateIO(InspectionOrder ent)
        {
            string action;
            string actionDescription;

            var dbSet = context.Set<InspectionOrder>();
            var existingIO = dbSet
                .Include(x => x.Policy)
                .Include(x => x.Property)
                .Include(x => x.Property.General)
                .SingleOrDefault(a => a.Id == ent.Id);

            if (existingIO == null)
            {
                dbSet.Add(ent);
                action = InspectionOrderLogActionsConstants.UpdatedInspectionOrderStatus;
                actionDescription = InspectionOrderLogActionsConstants.CreatedInspectionOrder;
            }
            else
            {
                if (ent.Policy.InspectionStatusId != existingIO.Policy.InspectionStatusId)
                {
                    action = InspectionOrderLogActionsConstants.UpdatedInspectionOrderStatus;
                    actionDescription = this.GetStatus(ent.Policy.InspectionStatusId);
                }
                else
                {
                    action = InspectionOrderLogActionsConstants.UpdatedInspectionOrder;
                    actionDescription = InspectionOrderLogActionsConstants.UpdatedInspectionOrder;
                }

                context.Entry(existingIO).CurrentValues.SetValues(ent);

                if (ent.Policy != null)
                {
                    var policyDbSet = context.Set<Policy>();
                    var policy = policyDbSet
                        .SingleOrDefault(a => a.Id == ent.Id);

                    if (policy == null)
                    {
                        dbSet.Add(ent);
                    }
                    else
                    {
                        context.Entry(policy).CurrentValues.SetValues(ent.Policy);
                    }
                }

                var propertyGeneral = new InspectionOrderPropertyGeneral();
                propertyGeneral = ent.Property.General;

                if (propertyGeneral != null)
                {
                    var generalDbSet = context.Set<InspectionOrderPropertyGeneral>();
                    var general = generalDbSet
                        .SingleOrDefault(a => a.Id == ent.Id);

                    if (general == null)
                    {
                        dbSet.Add(ent);
                    }
                    else
                    {
                        context.Entry(general).CurrentValues.SetValues(propertyGeneral);
                    }
                }
            }

            context.SaveChanges();

            _inspectionOrderLog.SaveIOLog(action, actionDescription, ent.Id);
        }

        private string GetStatus(string status)
        {

            string updatedStatus = "";

            switch (status)
            {
                case "PA":
                    updatedStatus = "Changed Status to Pending Assignment";
                    break;
                case "RTS":
                    updatedStatus = "Changed Status to Ready To Schedule";
                    break;
                case "S":
                    updatedStatus = "Changed Status to Scheduled";
                    break;
                case "PQC":
                    updatedStatus = "Changed Status to Pending QC";
                    break;
                case "PQCI":
                    updatedStatus = "Changed Status to Pending QC Items";
                    break;
                case "PUWR":
                    updatedStatus = "Changed Status to Pending UW Review";
                    break;
                case "PWU":
                    updatedStatus = "Changed Status to Pending Write-Up";
                    break;
                case "UWA":
                    updatedStatus = "Changed Status to UW Approved";
                    break;
                case "UWI":
                    updatedStatus = "Changed Status to UW Issues";
                    break;
                default:
                    break;
            }
            return updatedStatus;
        }

        public void UpdateIOChecklist(InspectionOrder modifiedIO)
        {
            UpdateIOProperty(modifiedIO);
            UpdateIOWildfireAssessment(modifiedIO);

            if (modifiedIO.RiskSummary != null)
                UpdateIORiskSummary(modifiedIO);

            context.SaveChanges();
            
            _inspectionOrderLog.SaveIOLog(InspectionOrderLogActionsConstants.UpdatedChecklist, InspectionOrderLogActionsConstants.UpdatedChecklist, modifiedIO.Id);
        }

        public RetrieveResult<InspectionOrderView> RetrieveView(DataSourceRequest request, DateTime? scheduledDate, DateTime? assignedDate)
        {
            var dbSet = context.Set<InspectionOrderView>().AsQueryable();

            if (scheduledDate != null)
            {
                dbSet = dbSet.Where(x => x.InspectionDate == scheduledDate
                && x.Status.Equals("Scheduled"));
            }

            if (assignedDate != null)
            {
                dbSet = dbSet.Where(x => x.AssignedDate == assignedDate
                && x.Status.Equals("Ready To Schedule"));
            }

            return Retrieve(dbSet, request);
        }

        public IQueryable<InspectionOrderView> RetrieveIOView()
        {
            return context.Set<InspectionOrderView>().AsQueryable();
        }

        #region Property
        public InspectionOrderProperty RetrieveIOProperty(Guid id)
        {
            return Context.Set<InspectionOrderProperty>()
              .AsNoTracking()
              .Include(x => x.General)
              .Include(x => x.General.DomesticHelpTypes)
              .Include(x => x.General.PolicyPremiumCredits)
              .Include(x => x.General.WildfireCredits)

              .Include(x => x.InteriorDetail)
              .Include(x => x.InteriorDetail.FlooringTypes)
              .Include(x => x.InteriorDetail.KitchenBathCabinets)
              .Include(x => x.InteriorDetail.KitchenBathCounters)
              .Include(x => x.InteriorDetail.QualityClassUpgrades)
              .Include(x => x.InteriorDetail.TypeOfPlumbings)

              .Include(x => x.HomeDetail)
              .Include(x => x.HomeDetail.Locales)

              .Include(x => x.BuildingConcern)
              .Include(x => x.BuildingConcern.ExteriorBuildingConcernDetails)
              .Include(x => x.BuildingConcern.RoofConcernDetails)
              .Include(x => x.BuildingConcern.ElectricalConcernDetails)
              .Include(x => x.BuildingConcern.PlumbingConcernDetails)
              .Include(x => x.BuildingConcern.OtherStructureConcernDetails)
              .Include(x => x.BuildingConcern.SurroundingAreaConcernDetails)

              .Include(x => x.DetachedStructure)
              .Include(x => x.DetachedStructure.OutbuildingDetails)
              .Include(x => x.DetachedStructure.OtherDetachedStructuresDetails)

              .Include(x => x.AdditionalExposure)
              .Include(x => x.AdditionalExposure.BearInvasionConcernDetails)

              .Include(x => x.HighValueKitchen)
              .Include(x => x.HighValueKitchen.Appliances).ThenInclude(x => x.ApplianceBrand)
              .Include(x => x.HighValueKitchen.Appliances).ThenInclude(x => x.ApplianceType)

              .Include(x => x.HighValueBath)
              .Include(x => x.HighValueBath.BathroomFloors)
              .Include(x => x.HighValueBath.BathroomVanities)
              .Include(x => x.HighValueBath.BathroomCounters)
              .Include(x => x.HighValueBath.BathroomFixtures)
              .Include(x => x.HighValueBath.TubsAndShowers)

              .Include(x => x.HighValueFloorToCeiling)
              .Include(x => x.HighValueFloorToCeiling.FloorCoverings)
              .Include(x => x.HighValueFloorToCeiling.Ceilings)
              .Include(x => x.HighValueFloorToCeiling.InteriorWallCoverings)
              .Include(x => x.HighValueFloorToCeiling.WallTrims)
              .Include(x => x.HighValueFloorToCeiling.WindowStyles)
              .Include(x => x.HighValueFloorToCeiling.WindowBrands)

              .Include(x => x.HighValueInteriorFeature)
              .Include(x => x.HighValueInteriorFeature.InteriorDoorTypes)
              .Include(x => x.HighValueInteriorFeature.DoorHardwares)
              .Include(x => x.HighValueInteriorFeature.RoomWithCabinetrys)
              .Include(x => x.HighValueInteriorFeature.LightingTypes)
              .Include(x => x.HighValueInteriorFeature.FireplaceTypes)
              .Include(x => x.HighValueInteriorFeature.Staircases)
              .Include(x => x.HighValueInteriorFeature.MiscellaneousExtraFeatures)

              .SingleOrDefault(x => x.Id.Equals(id));
        }

        private void UpdateIORiskSummary(InspectionOrder modifiedIO)
        {
            var dbSet = context.Set<InspectionOrder>();
            var existingIO = dbSet
              .SingleOrDefault(a => a.Id == modifiedIO.Id);

            if (existingIO != null)
            {
                existingIO.RiskSummary = modifiedIO.RiskSummary;
            }
        }
        private void UpdateIOProperty(InspectionOrder modifiedIO)
        {
            if (modifiedIO.Property == null) return;

            var dbSet = context.Set<InspectionOrder>();
            var existingIO = dbSet
              .Include(x => x.Property)
              .Include(x => x.Property.General)
              .Include(x => x.Property.General.DomesticHelpTypes)
              .Include(x => x.Property.General.PolicyPremiumCredits)
              .Include(x => x.Property.General.WildfireCredits)

              .Include(x => x.Property.InteriorDetail)
              .Include(x => x.Property.InteriorDetail.FlooringTypes)
              .Include(x => x.Property.InteriorDetail.KitchenBathCabinets)
              .Include(x => x.Property.InteriorDetail.KitchenBathCounters)
              .Include(x => x.Property.InteriorDetail.QualityClassUpgrades)
              .Include(x => x.Property.InteriorDetail.TypeOfPlumbings)

              .Include(x => x.Property.HomeDetail)
              .Include(x => x.Property.HomeDetail.Locales)

              .Include(x => x.Property.BuildingConcern)
              .Include(x => x.Property.BuildingConcern.ExteriorBuildingConcernDetails)
              .Include(x => x.Property.BuildingConcern.RoofConcernDetails)
              .Include(x => x.Property.BuildingConcern.ElectricalConcernDetails)
              .Include(x => x.Property.BuildingConcern.PlumbingConcernDetails)
              .Include(x => x.Property.BuildingConcern.OtherStructureConcernDetails)
              .Include(x => x.Property.BuildingConcern.SurroundingAreaConcernDetails)

              .Include(x => x.Property.DetachedStructure)
              .Include(x => x.Property.DetachedStructure.OutbuildingDetails)
              .Include(x => x.Property.DetachedStructure.OtherDetachedStructuresDetails)

              .Include(x => x.Property.AdditionalExposure)
              .Include(x => x.Property.AdditionalExposure.BearInvasionConcernDetails)

              .Include(x => x.Property.HighValueKitchen)
              .Include(x => x.Property.HighValueKitchen.Appliances)

              .Include(x => x.Property.HighValueBath)
              .Include(x => x.Property.HighValueBath.BathroomFloors)
              .Include(x => x.Property.HighValueBath.BathroomVanities)
              .Include(x => x.Property.HighValueBath.BathroomCounters)
              .Include(x => x.Property.HighValueBath.BathroomFixtures)
              .Include(x => x.Property.HighValueBath.TubsAndShowers)

              .Include(x => x.Property.HighValueFloorToCeiling)
              .Include(x => x.Property.HighValueFloorToCeiling.FloorCoverings)
              .Include(x => x.Property.HighValueFloorToCeiling.Ceilings)
              .Include(x => x.Property.HighValueFloorToCeiling.InteriorWallCoverings)
              .Include(x => x.Property.HighValueFloorToCeiling.WallTrims)
              .Include(x => x.Property.HighValueFloorToCeiling.WindowStyles)
              .Include(x => x.Property.HighValueFloorToCeiling.WindowBrands)

              .Include(x => x.Property.HighValueInteriorFeature)
              .Include(x => x.Property.HighValueInteriorFeature.InteriorDoorTypes)
              .Include(x => x.Property.HighValueInteriorFeature.DoorHardwares)
              .Include(x => x.Property.HighValueInteriorFeature.RoomWithCabinetrys)
              .Include(x => x.Property.HighValueInteriorFeature.LightingTypes)
              .Include(x => x.Property.HighValueInteriorFeature.FireplaceTypes)
              .Include(x => x.Property.HighValueInteriorFeature.Staircases)
              .Include(x => x.Property.HighValueInteriorFeature.MiscellaneousExtraFeatures)

              .SingleOrDefault(a => a.Id.Equals(modifiedIO.Id));

            if (existingIO == null)
            {
                throw new Exception("Inspection Order does not exist");
            }

            if (existingIO.Property == null)
            {
                existingIO.Property = new InspectionOrderProperty { Id = existingIO.Id };
                //context.Set<InspectionOrderProperty>().Attach(existingIO.Property);
                context.Entry(existingIO.Property).State = EntityState.Added;
            }

            if (modifiedIO.Property != null)
            {
                modifiedIO.Property.Id = existingIO.Id;
                context.Entry(existingIO.Property).CurrentValues.SetValues(modifiedIO.Property);
            }

            UpdateIOPropertyGeneral(existingIO, modifiedIO);
            UpdateIOPropertyInteriorDetail(existingIO, modifiedIO);
            UpdateIOPropertyHomeDetail(existingIO, modifiedIO);
            UpdateIOPropertyBuildingConcern(existingIO, modifiedIO);
            UpdateIOPropertyDetachedStructure(existingIO, modifiedIO);
            UpdateIOPropertyAdditionalExposure(existingIO, modifiedIO);
            UpdateIOPropertyHighValueKitchen(existingIO, modifiedIO);
            UpdateIOPropertyHighValueBath(existingIO, modifiedIO);
            UpdateIOPropertyHighValueFloorToCeiling(existingIO, modifiedIO);
            UpdateIOPropertyHighValueInteriorFeature(existingIO, modifiedIO);
        }

        private void UpdateIOPropertyGeneral(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.Property?.General;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.Property.General;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderPropertyGeneral { Id = existingIO.Property.Id };
                //context.Set<InspectionOrderPropertyGeneral>().Attach(existingIO.Property.General);
                context.Entry(existingCategory).State = EntityState.Added;
            }

            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region DomesticHelpTypes
            {
                if (existingCategory.DomesticHelpTypes == null)
                {
                    existingCategory.DomesticHelpTypes = new List<InspectionOrderPropertyGeneralDomesticHelpTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyGeneralDomesticHelpTypes>();

                // delete item from database that are not in the modifiedIO.Property.General.DomesticHelpTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyGeneralId.Equals(categoryId)))
                    if (!category.DomesticHelpTypes.Any(x => x.DomesticHelpTypeId.Equals(existingItem.DomesticHelpTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.DomesticHelpTypes.AsNotNull())
                {
                    item.InspectionOrderPropertyGeneralId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyGeneralId.Equals(item.InspectionOrderPropertyGeneralId) &&
                      x.DomesticHelpTypeId.Equals(item.DomesticHelpTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion DomesticHelpTypes

            #region PolicyPremiumCredits
            {
                if (existingCategory.PolicyPremiumCredits == null)
                {
                    existingCategory.PolicyPremiumCredits = new List<InspectionOrderPropertyGeneralPolicyPremiumCredits>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyGeneralPolicyPremiumCredits>();

                // delete item from database that are not in the modifiedIO.Property.General.PolicyPremiumCredits collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyGeneralId.Equals(categoryId)))
                    if (!category.PolicyPremiumCredits.Any(x => x.PolicyPremiumCreditId.Equals(existingItem.PolicyPremiumCreditId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.PolicyPremiumCredits.AsNotNull())
                {
                    item.InspectionOrderPropertyGeneralId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyGeneralId.Equals(item.InspectionOrderPropertyGeneralId) &&
                      x.PolicyPremiumCreditId.Equals(item.PolicyPremiumCreditId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion PolicyPremiumCredits

            #region WildfireCredits
            {
                if (existingCategory.WildfireCredits == null)
                {
                    existingCategory.WildfireCredits = new List<InspectionOrderPropertyGeneralWildfireCredits>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyGeneralWildfireCredits>();

                // delete item from database that are not in the modifiedIO.Property.General.WildfireCredits collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyGeneralId.Equals(categoryId)))
                    if (!category.WildfireCredits.Any(x => x.WildfireCreditId.Equals(existingItem.WildfireCreditId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.WildfireCredits.AsNotNull())
                {
                    item.InspectionOrderPropertyGeneralId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyGeneralId.Equals(item.InspectionOrderPropertyGeneralId) &&
                      x.WildfireCreditId.Equals(item.WildfireCreditId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion WildfireCredits
        }

        private void UpdateIOPropertyInteriorDetail(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.Property?.InteriorDetail;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.Property.InteriorDetail;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderPropertyInteriorDetail { Id = existingIO.Property.Id };
                context.Entry(existingCategory).State = EntityState.Added;
            }

            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region FlooringTypes
            {
                if (existingCategory.FlooringTypes == null)
                {
                    existingCategory.FlooringTypes = new List<InspectionOrderPropertyInteriorDetailFlooringTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyInteriorDetailFlooringTypes>();

                // delete item from database that are not in the modifiedIO.Property.InteriorDetail.FlooringTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyInteriorDetailId.Equals(categoryId)))
                    if (!category.FlooringTypes.Any(x => x.FlooringTypeId.Equals(existingItem.FlooringTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.FlooringTypes.AsNotNull())
                {
                    item.InspectionOrderPropertyInteriorDetailId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyInteriorDetailId.Equals(item.InspectionOrderPropertyInteriorDetailId) &&
                      x.FlooringTypeId.Equals(item.FlooringTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion FlooringTypes

            #region KitchenBathCabinets
            {
                if (existingCategory.KitchenBathCabinets == null)
                {
                    existingCategory.KitchenBathCabinets = new List<InspectionOrderPropertyInteriorDetailKitchenBathCabinets>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyInteriorDetailKitchenBathCabinets>();

                // delete item from database that are not in the modifiedIO.Property.InteriorDetail.KitchenBathCabinets collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyInteriorDetailId.Equals(categoryId)))
                    if (!category.KitchenBathCabinets.Any(x => x.KitchenBathCabinetId.Equals(existingItem.KitchenBathCabinetId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.KitchenBathCabinets.AsNotNull())
                {
                    item.InspectionOrderPropertyInteriorDetailId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyInteriorDetailId.Equals(item.InspectionOrderPropertyInteriorDetailId) &&
                      x.KitchenBathCabinetId.Equals(item.KitchenBathCabinetId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion KitchenBathCabinets

            #region KitchenBathCounters
            {
                if (existingCategory.KitchenBathCounters == null)
                {
                    existingCategory.KitchenBathCounters = new List<InspectionOrderPropertyInteriorDetailKitchenBathCounters>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyInteriorDetailKitchenBathCounters>();

                // delete item from database that are not in the modifiedIO.Property.InteriorDetail.KitchenBathCounters collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyInteriorDetailId.Equals(categoryId)))
                    if (!category.KitchenBathCounters.Any(x => x.KitchenBathCounterId.Equals(existingItem.KitchenBathCounterId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.KitchenBathCounters.AsNotNull())
                {
                    item.InspectionOrderPropertyInteriorDetailId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyInteriorDetailId.Equals(item.InspectionOrderPropertyInteriorDetailId) &&
                      x.KitchenBathCounterId.Equals(item.KitchenBathCounterId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion KitchenBathCounters

            #region QualityClassUpgrades
            {
                if (existingCategory.QualityClassUpgrades == null)
                {
                    existingCategory.QualityClassUpgrades = new List<InspectionOrderPropertyInteriorDetailQualityClassUpgrades>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyInteriorDetailQualityClassUpgrades>();

                // delete item from database that are not in the modifiedIO.Property.InteriorDetail.QualityClassUpgrades collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyInteriorDetailId.Equals(categoryId)))
                    if (!category.QualityClassUpgrades.Any(x => x.QualityClassUpgradeId.Equals(existingItem.QualityClassUpgradeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.QualityClassUpgrades.AsNotNull())
                {
                    item.InspectionOrderPropertyInteriorDetailId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyInteriorDetailId.Equals(item.InspectionOrderPropertyInteriorDetailId) &&
                      x.QualityClassUpgradeId.Equals(item.QualityClassUpgradeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion QualityClassUpgrades

            #region TypeOfPlumbings
            {
                if (existingCategory.TypeOfPlumbings == null)
                {
                    existingCategory.TypeOfPlumbings = new List<InspectionOrderPropertyInteriorDetailTypeOfPlumbings>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyInteriorDetailTypeOfPlumbings>();

                // delete item from database that are not in the modifiedIO.Property.InteriorDetail.TypeOfPlumbings collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyInteriorDetailId.Equals(categoryId)))
                    if (!category.TypeOfPlumbings.Any(x => x.TypeOfPlumbingId.Equals(existingItem.TypeOfPlumbingId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.TypeOfPlumbings.AsNotNull())
                {
                    item.InspectionOrderPropertyInteriorDetailId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyInteriorDetailId.Equals(item.InspectionOrderPropertyInteriorDetailId) &&
                      x.TypeOfPlumbingId.Equals(item.TypeOfPlumbingId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion TypeOfPlumbings
        }

        private void UpdateIOPropertyHomeDetail(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.Property?.HomeDetail;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.Property.HomeDetail;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderPropertyHomeDetail { Id = existingIO.Property.Id };
                context.Entry(existingCategory).State = EntityState.Added;
            }

            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region Locales
            {
                if (existingCategory.Locales == null)
                {
                    existingCategory.Locales = new List<InspectionOrderPropertyHomeDetailLocales>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHomeDetailLocales>();

                // delete item from database that are not in the modifiedIO.Property.HomeDetail.Locales collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHomeDetailId.Equals(categoryId)))
                    if (!category.Locales.Any(x => x.LocaleId.Equals(existingItem.LocaleId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.Locales.AsNotNull())
                {
                    item.InspectionOrderPropertyHomeDetailId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHomeDetailId.Equals(item.InspectionOrderPropertyHomeDetailId) &&
                      x.LocaleId.Equals(item.LocaleId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion Locales
        }

        private void UpdateIOPropertyBuildingConcern(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.Property?.BuildingConcern;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.Property.BuildingConcern;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderPropertyBuildingConcern { Id = existingIO.Property.Id };
                context.Entry(existingCategory).State = EntityState.Added;
            }

            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region ExteriorBuildingConcernDetails
            {
                if (existingCategory.ExteriorBuildingConcernDetails == null)
                {
                    existingCategory.ExteriorBuildingConcernDetails = new List<InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails>();

                // delete item from database that are not in the modifiedIO.Property.BuildingConcern.ExteriorBuildingConcernDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyBuildingConcernId.Equals(categoryId)))
                    if (!category.ExteriorBuildingConcernDetails.Any(x => x.ExteriorBuildingConcernDetailId.Equals(existingItem.ExteriorBuildingConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.ExteriorBuildingConcernDetails.AsNotNull())
                {
                    item.InspectionOrderPropertyBuildingConcernId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyBuildingConcernId.Equals(item.InspectionOrderPropertyBuildingConcernId) &&
                      x.ExteriorBuildingConcernDetailId.Equals(item.ExteriorBuildingConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion ExteriorBuildingConcernDetails

            #region RoofConcernDetails
            {
                if (existingCategory.RoofConcernDetails == null)
                {
                    existingCategory.RoofConcernDetails = new List<InspectionOrderPropertyBuildingConcernRoofConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyBuildingConcernRoofConcernDetails>();

                // delete item from database that are not in the modifiedIO.Property.BuildingConcern.RoofConcernDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyBuildingConcernId.Equals(categoryId)))
                    if (!category.RoofConcernDetails.Any(x => x.RoofConcernDetailId.Equals(existingItem.RoofConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.RoofConcernDetails.AsNotNull())
                {
                    item.InspectionOrderPropertyBuildingConcernId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyBuildingConcernId.Equals(item.InspectionOrderPropertyBuildingConcernId) &&
                      x.RoofConcernDetailId.Equals(item.RoofConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion RoofConcernDetails

            #region ElectricalConcernDetails
            {
                if (existingCategory.ElectricalConcernDetails == null)
                {
                    existingCategory.ElectricalConcernDetails = new List<InspectionOrderPropertyBuildingConcernElectricalConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyBuildingConcernElectricalConcernDetails>();

                // delete item from database that are not in the modifiedIO.Property.BuildingConcern.ElectricalConcernDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyBuildingConcernId.Equals(categoryId)))
                    if (!category.ElectricalConcernDetails.Any(x => x.ElectricalConcernDetailId.Equals(existingItem.ElectricalConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.ElectricalConcernDetails.AsNotNull())
                {
                    item.InspectionOrderPropertyBuildingConcernId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyBuildingConcernId.Equals(item.InspectionOrderPropertyBuildingConcernId) &&
                      x.ElectricalConcernDetailId.Equals(item.ElectricalConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion ElectricalConcernDetails

            #region PlumbingConcernDetails
            {
                if (existingCategory.PlumbingConcernDetails == null)
                {
                    existingCategory.PlumbingConcernDetails = new List<InspectionOrderPropertyBuildingConcernPlumbingConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyBuildingConcernPlumbingConcernDetails>();

                // delete item from database that are not in the modifiedIO.Property.BuildingConcern.PlumbingConcernDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyBuildingConcernId.Equals(categoryId)))
                    if (!category.PlumbingConcernDetails.Any(x => x.PlumbingConcernDetailId.Equals(existingItem.PlumbingConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.PlumbingConcernDetails.AsNotNull())
                {
                    item.InspectionOrderPropertyBuildingConcernId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyBuildingConcernId.Equals(item.InspectionOrderPropertyBuildingConcernId) &&
                      x.PlumbingConcernDetailId.Equals(item.PlumbingConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion PlumbingConcernDetails

            #region OtherStructureConcernDetails
            {
                if (existingCategory.OtherStructureConcernDetails == null)
                {
                    existingCategory.OtherStructureConcernDetails = new List<InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails>();

                // delete item from database that are not in the modifiedIO.Property.BuildingConcern.OtherStructureConcernDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyBuildingConcernId.Equals(categoryId)))
                    if (!category.OtherStructureConcernDetails.Any(x => x.OtherStructureConcernDetailId.Equals(existingItem.OtherStructureConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.OtherStructureConcernDetails.AsNotNull())
                {
                    item.InspectionOrderPropertyBuildingConcernId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyBuildingConcernId.Equals(item.InspectionOrderPropertyBuildingConcernId) &&
                      x.OtherStructureConcernDetailId.Equals(item.OtherStructureConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion OtherStructureConcernDetails

            #region SurroundingAreaConcernDetails
            {
                if (existingCategory.SurroundingAreaConcernDetails == null)
                {
                    existingCategory.SurroundingAreaConcernDetails = new List<InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails>();

                // delete item from database that are not in the modifiedIO.Property.BuildingConcern.SurroundingAreaConcernDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyBuildingConcernId.Equals(categoryId)))
                    if (!category.SurroundingAreaConcernDetails.Any(x => x.SurroundingAreaConcernDetailId.Equals(existingItem.SurroundingAreaConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.SurroundingAreaConcernDetails.AsNotNull())
                {
                    item.InspectionOrderPropertyBuildingConcernId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyBuildingConcernId.Equals(item.InspectionOrderPropertyBuildingConcernId) &&
                      x.SurroundingAreaConcernDetailId.Equals(item.SurroundingAreaConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion SurroundingAreaConcernDetails
        }

        private void UpdateIOPropertyDetachedStructure(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.Property?.DetachedStructure;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.Property.DetachedStructure;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderPropertyDetachedStructure { Id = existingIO.Property.Id };
                context.Entry(existingCategory).State = EntityState.Added;
            }

            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region OutbuildingDetails
            {
                if (existingCategory.OutbuildingDetails == null)
                {
                    existingCategory.OutbuildingDetails = new List<InspectionOrderPropertyDetachedStructureOutbuildingDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyDetachedStructureOutbuildingDetails>();

                // delete item from database that are not in the modifiedIO.Property.DetachedStructure.OutbuildingDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyDetachedStructureId.Equals(categoryId)))
                    if (!category.OutbuildingDetails.Any(x => x.OutbuildingDetailId.Equals(existingItem.OutbuildingDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.OutbuildingDetails.AsNotNull())
                {
                    item.InspectionOrderPropertyDetachedStructureId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyDetachedStructureId.Equals(item.InspectionOrderPropertyDetachedStructureId) &&
                      x.OutbuildingDetailId.Equals(item.OutbuildingDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion OutbuildingDetails

            #region OtherDetachedStructuresDetails
            {
                if (existingCategory.OtherDetachedStructuresDetails == null)
                {
                    existingCategory.OtherDetachedStructuresDetails = new List<InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails>();

                // delete item from database that are not in the modifiedIO.Property.DetachedStructure.OtherDetachedStructuresDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyDetachedStructureId.Equals(categoryId)))
                    if (!category.OtherDetachedStructuresDetails.Any(x => x.OtherDetachedStructuresDetailId.Equals(existingItem.OtherDetachedStructuresDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.OtherDetachedStructuresDetails.AsNotNull())
                {
                    item.InspectionOrderPropertyDetachedStructureId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyDetachedStructureId.Equals(item.InspectionOrderPropertyDetachedStructureId) &&
                      x.OtherDetachedStructuresDetailId.Equals(item.OtherDetachedStructuresDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion OtherDetachedStructuresDetails
        }

        private void UpdateIOPropertyAdditionalExposure(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.Property?.AdditionalExposure;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.Property.AdditionalExposure;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderPropertyAdditionalExposure { Id = existingIO.Property.Id };
                context.Entry(existingCategory).State = EntityState.Added;
            }

            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region BearInvasionConcernDetails
            {
                if (existingCategory.BearInvasionConcernDetails == null)
                {
                    existingCategory.BearInvasionConcernDetails = new List<InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails>();

                // delete item from database that are not in the modifiedIO.Property.AdditionalExposure.BearInvasionConcernDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyAdditionalExposureId.Equals(categoryId)))
                    if (!category.BearInvasionConcernDetails.Any(x => x.BearInvasionConcernDetailId.Equals(existingItem.BearInvasionConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.BearInvasionConcernDetails.AsNotNull())
                {
                    item.InspectionOrderPropertyAdditionalExposureId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyAdditionalExposureId.Equals(item.InspectionOrderPropertyAdditionalExposureId) &&
                      x.BearInvasionConcernDetailId.Equals(item.BearInvasionConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion BearInvasionConcernDetails
        }

        private void UpdateIOPropertyHighValueKitchen(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.Property?.HighValueKitchen;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.Property.HighValueKitchen;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderPropertyHighValueKitchen { Id = existingIO.Property.Id };
                context.Entry(existingCategory).State = EntityState.Added;
            }

            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region ApplianceTypes
            {
                if (existingCategory.Appliances == null)
                {
                    existingCategory.Appliances = new List<InspectionOrderPropertyHighValueKitchenAppliances>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueKitchenAppliances>();

                // delete item from database that are not in the modifiedIO.Property.HighValueKitchen.ApplianceTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueKitchenId.Equals(categoryId)))
                    if (!category.Appliances.Any(x => x.ApplianceTypeId.Equals(existingItem.ApplianceTypeId) && x.ApplianceBrandId.Equals(existingItem.ApplianceBrandId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.Appliances.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueKitchenId = categoryId;
                    item.ApplianceBrand = null;
                    item.ApplianceType = null;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueKitchenId.Equals(item.InspectionOrderPropertyHighValueKitchenId) &&
                      x.ApplianceTypeId.Equals(item.ApplianceTypeId) &&
                      x.ApplianceBrandId.Equals(item.ApplianceBrandId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion ApplianceTypes
        }

        private void UpdateIOPropertyHighValueBath(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.Property?.HighValueBath;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.Property.HighValueBath;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderPropertyHighValueBath { Id = existingIO.Property.Id };
                context.Entry(existingCategory).State = EntityState.Added;
            }

            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region BathroomFloors
            {
                if (existingCategory.BathroomFloors == null)
                {
                    existingCategory.BathroomFloors = new List<InspectionOrderPropertyHighValueBathBathroomFloors>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueBathBathroomFloors>();

                // delete item from database that are not in the modifiedIO.Property.HighValueBath.BathroomFloors collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueBathId.Equals(categoryId)))
                    if (!category.BathroomFloors.Any(x => x.BathroomFloorId.Equals(existingItem.BathroomFloorId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.BathroomFloors.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueBathId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueBathId.Equals(item.InspectionOrderPropertyHighValueBathId) &&
                      x.BathroomFloorId.Equals(item.BathroomFloorId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion BathroomFloors

            #region BathroomVanities
            {
                if (existingCategory.BathroomVanities == null)
                {
                    existingCategory.BathroomVanities = new List<InspectionOrderPropertyHighValueBathBathroomVanities>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueBathBathroomVanities>();

                // delete item from database that are not in the modifiedIO.Property.HighValueBath.BathroomVanities collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueBathId.Equals(categoryId)))
                    if (!category.BathroomVanities.Any(x => x.BathroomVanityId.Equals(existingItem.BathroomVanityId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.BathroomVanities.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueBathId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueBathId.Equals(item.InspectionOrderPropertyHighValueBathId) &&
                      x.BathroomVanityId.Equals(item.BathroomVanityId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion BathroomVanities

            #region BathroomCounters
            {
                if (existingCategory.BathroomCounters == null)
                {
                    existingCategory.BathroomCounters = new List<InspectionOrderPropertyHighValueBathBathroomCounters>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueBathBathroomCounters>();

                // delete item from database that are not in the modifiedIO.Property.HighValueBath.BathroomCounters collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueBathId.Equals(categoryId)))
                    if (!category.BathroomCounters.Any(x => x.BathroomCounterId.Equals(existingItem.BathroomCounterId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.BathroomCounters.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueBathId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueBathId.Equals(item.InspectionOrderPropertyHighValueBathId) &&
                      x.BathroomCounterId.Equals(item.BathroomCounterId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion BathroomCounters

            #region BathroomFixtures
            {
                if (existingCategory.BathroomFixtures == null)
                {
                    existingCategory.BathroomFixtures = new List<InspectionOrderPropertyHighValueBathBathroomFixtures>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueBathBathroomFixtures>();

                // delete item from database that are not in the modifiedIO.Property.HighValueBath.BathroomFixtures collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueBathId.Equals(categoryId)))
                    if (!category.BathroomFixtures.Any(x => x.BathroomFixtureId.Equals(existingItem.BathroomFixtureId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.BathroomFixtures.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueBathId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueBathId.Equals(item.InspectionOrderPropertyHighValueBathId) &&
                      x.BathroomFixtureId.Equals(item.BathroomFixtureId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion BathroomFixtures

            #region TubsAndShowers
            {
                if (existingCategory.TubsAndShowers == null)
                {
                    existingCategory.TubsAndShowers = new List<InspectionOrderPropertyHighValueBathTubsAndShowers>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueBathTubsAndShowers>();

                // delete item from database that are not in the modifiedIO.Property.HighValueBath.TubsAndShowers collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueBathId.Equals(categoryId)))
                    if (!category.TubsAndShowers.Any(x => x.TubAndShowerId.Equals(existingItem.TubAndShowerId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.TubsAndShowers.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueBathId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueBathId.Equals(item.InspectionOrderPropertyHighValueBathId) &&
                      x.TubAndShowerId.Equals(item.TubAndShowerId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion TubsAndShowers
        }

        private void UpdateIOPropertyHighValueFloorToCeiling(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.Property?.HighValueFloorToCeiling;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.Property.HighValueFloorToCeiling;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderPropertyHighValueFloorToCeiling { Id = existingIO.Property.Id };
                context.Entry(existingCategory).State = EntityState.Added;
            }

            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region FloorCoverings
            {
                if (existingCategory.FloorCoverings == null)
                {
                    existingCategory.FloorCoverings = new List<InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings>();

                // delete item from database that are not in the modifiedIO.Property.HighValueFloorToCeiling.FloorCoverings collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(categoryId)))
                    if (!category.FloorCoverings.Any(x => x.FloorCoveringId.Equals(existingItem.FloorCoveringId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.FloorCoverings.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueFloorToCeilingId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(item.InspectionOrderPropertyHighValueFloorToCeilingId) &&
                      x.FloorCoveringId.Equals(item.FloorCoveringId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion FloorCoverings

            #region Ceilings
            {
                if (existingCategory.Ceilings == null)
                {
                    existingCategory.Ceilings = new List<InspectionOrderPropertyHighValueFloorToCeilingCeilings>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueFloorToCeilingCeilings>();

                // delete item from database that are not in the modifiedIO.Property.HighValueFloorToCeiling.Ceilings collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(categoryId)))
                    if (!category.Ceilings.Any(x => x.CeilingId.Equals(existingItem.CeilingId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.Ceilings.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueFloorToCeilingId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(item.InspectionOrderPropertyHighValueFloorToCeilingId) &&
                      x.CeilingId.Equals(item.CeilingId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion Ceilings

            #region InteriorWallCoverings
            {
                if (existingCategory.InteriorWallCoverings == null)
                {
                    existingCategory.InteriorWallCoverings = new List<InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings>();

                // delete item from database that are not in the modifiedIO.Property.HighValueFloorToCeiling.InteriorWallCoverings collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(categoryId)))
                    if (!category.InteriorWallCoverings.Any(x => x.InteriorWallCoveringId.Equals(existingItem.InteriorWallCoveringId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.InteriorWallCoverings.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueFloorToCeilingId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(item.InspectionOrderPropertyHighValueFloorToCeilingId) &&
                      x.InteriorWallCoveringId.Equals(item.InteriorWallCoveringId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion InteriorWallCoverings

            #region WallTrims
            {
                if (existingCategory.WallTrims == null)
                {
                    existingCategory.WallTrims = new List<InspectionOrderPropertyHighValueFloorToCeilingWallTrims>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueFloorToCeilingWallTrims>();

                // delete item from database that are not in the modifiedIO.Property.HighValueFloorToCeiling.WallTrims collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(categoryId)))
                    if (!category.WallTrims.Any(x => x.WallTrimId.Equals(existingItem.WallTrimId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.WallTrims.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueFloorToCeilingId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(item.InspectionOrderPropertyHighValueFloorToCeilingId) &&
                      x.WallTrimId.Equals(item.WallTrimId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion WallTrims

            #region WindowStyles
            {
                if (existingCategory.WindowStyles == null)
                {
                    existingCategory.WindowStyles = new List<InspectionOrderPropertyHighValueFloorToCeilingWindowStyles>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueFloorToCeilingWindowStyles>();

                // delete item from database that are not in the modifiedIO.Property.HighValueFloorToCeiling.WindowStyles collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(categoryId)))
                    if (!category.WindowStyles.Any(x => x.WindowStyleId.Equals(existingItem.WindowStyleId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.WindowStyles.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueFloorToCeilingId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(item.InspectionOrderPropertyHighValueFloorToCeilingId) &&
                      x.WindowStyleId.Equals(item.WindowStyleId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion WindowStyles

            #region WindowBrands
            {
                if (existingCategory.WindowBrands == null)
                {
                    existingCategory.WindowBrands = new List<InspectionOrderPropertyHighValueFloorToCeilingWindowBrands>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueFloorToCeilingWindowBrands>();

                // delete item from database that are not in the modifiedIO.Property.HighValueFloorToCeiling.WindowBrands collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(categoryId)))
                    if (!category.WindowBrands.Any(x => x.WindowBrandId.Equals(existingItem.WindowBrandId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.WindowBrands.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueFloorToCeilingId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueFloorToCeilingId.Equals(item.InspectionOrderPropertyHighValueFloorToCeilingId) &&
                      x.WindowBrandId.Equals(item.WindowBrandId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion WindowBrands
        }

        private void UpdateIOPropertyHighValueInteriorFeature(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.Property?.HighValueInteriorFeature;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.Property.HighValueInteriorFeature;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderPropertyHighValueInteriorFeature { Id = existingIO.Property.Id };
                context.Entry(existingCategory).State = EntityState.Added;
            }

            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region InteriorDoorTypes
            {
                if (existingCategory.InteriorDoorTypes == null)
                {
                    existingCategory.InteriorDoorTypes = new List<InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes>();

                // delete item from database that are not in the modifiedIO.Property.HighValueInteriorFeature.InteriorDoorTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(categoryId)))
                    if (!category.InteriorDoorTypes.Any(x => x.InteriorDoorTypeId.Equals(existingItem.InteriorDoorTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.InteriorDoorTypes.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueInteriorFeatureId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(item.InspectionOrderPropertyHighValueInteriorFeatureId) &&
                      x.InteriorDoorTypeId.Equals(item.InteriorDoorTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion InteriorDoorTypes

            #region DoorHardwares
            {
                if (existingCategory.DoorHardwares == null)
                {
                    existingCategory.DoorHardwares = new List<InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares>();

                // delete item from database that are not in the modifiedIO.Property.HighValueInteriorFeature.DoorHardwares collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(categoryId)))
                    if (!category.DoorHardwares.Any(x => x.DoorHardwareId.Equals(existingItem.DoorHardwareId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.DoorHardwares.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueInteriorFeatureId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(item.InspectionOrderPropertyHighValueInteriorFeatureId) &&
                      x.DoorHardwareId.Equals(item.DoorHardwareId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion DoorHardwares

            #region RoomWithCabinetrys
            {
                if (existingCategory.RoomWithCabinetrys == null)
                {
                    existingCategory.RoomWithCabinetrys = new List<InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry>();

                // delete item from database that are not in the modifiedIO.Property.HighValueInteriorFeature.RoomWithCabinetrys collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(categoryId)))
                    if (!category.RoomWithCabinetrys.Any(x => x.RoomWithCabinetryId.Equals(existingItem.RoomWithCabinetryId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.RoomWithCabinetrys.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueInteriorFeatureId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(item.InspectionOrderPropertyHighValueInteriorFeatureId) &&
                      x.RoomWithCabinetryId.Equals(item.RoomWithCabinetryId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion RoomWithCabinetrys

            #region LightingTypes
            {
                if (existingCategory.LightingTypes == null)
                {
                    existingCategory.LightingTypes = new List<InspectionOrderPropertyHighValueInteriorFeatureLightingTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueInteriorFeatureLightingTypes>();

                // delete item from database that are not in the modifiedIO.Property.HighValueInteriorFeature.LightingTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(categoryId)))
                    if (!category.LightingTypes.Any(x => x.LightingTypeId.Equals(existingItem.LightingTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.LightingTypes.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueInteriorFeatureId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(item.InspectionOrderPropertyHighValueInteriorFeatureId) &&
                      x.LightingTypeId.Equals(item.LightingTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion LightingTypes

            #region FireplaceTypes
            {
                if (existingCategory.FireplaceTypes == null)
                {
                    existingCategory.FireplaceTypes = new List<InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes>();

                // delete item from database that are not in the modifiedIO.Property.HighValueInteriorFeature.FireplaceTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(categoryId)))
                    if (!category.FireplaceTypes.Any(x => x.FireplaceTypeId.Equals(existingItem.FireplaceTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.FireplaceTypes.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueInteriorFeatureId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(item.InspectionOrderPropertyHighValueInteriorFeatureId) &&
                      x.FireplaceTypeId.Equals(item.FireplaceTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion FireplaceTypes

            #region Staircases
            {
                if (existingCategory.Staircases == null)
                {
                    existingCategory.Staircases = new List<InspectionOrderPropertyHighValueInteriorFeatureStaircases>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueInteriorFeatureStaircases>();

                // delete item from database that are not in the modifiedIO.Property.HighValueInteriorFeature.Staircases collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(categoryId)))
                    if (!category.Staircases.Any(x => x.StaircaseId.Equals(existingItem.StaircaseId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.Staircases.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueInteriorFeatureId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(item.InspectionOrderPropertyHighValueInteriorFeatureId) &&
                      x.StaircaseId.Equals(item.StaircaseId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion Staircases

            #region MiscellaneousExtraFeatures
            {
                if (existingCategory.MiscellaneousExtraFeatures == null)
                {
                    existingCategory.MiscellaneousExtraFeatures = new List<InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures>();
                }

                var itemDbSet = context.Set<InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures>();

                // delete item from database that are not in the modifiedIO.Property.HighValueInteriorFeature.MiscellaneousExtraFeatures collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(categoryId)))
                    if (!category.MiscellaneousExtraFeatures.Any(x => x.MiscellaneousExtraFeatureId.Equals(existingItem.MiscellaneousExtraFeatureId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.MiscellaneousExtraFeatures.AsNotNull())
                {
                    item.InspectionOrderPropertyHighValueInteriorFeatureId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderPropertyHighValueInteriorFeatureId.Equals(item.InspectionOrderPropertyHighValueInteriorFeatureId) &&
                      x.MiscellaneousExtraFeatureId.Equals(item.MiscellaneousExtraFeatureId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        // context.Entry(existingItem).CurrentValues.SetValues(item); // no need to update since we're only updating a single id
                    }
                }
            }
            #endregion MiscellaneousExtraFeatures
        }
        #endregion Property

        #region Wild Fire Assessment
        public InspectionOrderWildfireAssessment RetrieveIOWildFire(Guid id)
        {
            return Context.Set<InspectionOrderWildfireAssessment>()
                .AsNoTracking()
                .Include(x => x.Roof)
                .Include(x => x.Roof.OtherRoofCoverings)
                .Include(x => x.Roof.RoofConcernDetails)
                .Include(x => x.Roof.RoofVentings)
                .Include(x => x.Roof.GutterTypes)

                .Include(x => x.FoundationToFrame)

                .Include(x => x.ExteriorSiding)
                .Include(x => x.ExteriorSiding.OtherWallCoverings)
                .Include(x => x.ExteriorSiding.SidingConditionConcernDetails)

                .Include(x => x.Window)
                .Include(x => x.Window.WindowGlassTypes)
                .Include(x => x.Window.WindowFramingTypes)
                .Include(x => x.Window.WindowStyles)
                .Include(x => x.Window.WindowScreenTypes)
                .Include(x => x.Window.InteriorWindowCoveringTypes)
                .Include(x => x.Window.ExteriorWindowCoveringTypes)
                .Include(x => x.Window.WindowConcernsDetails)

                .Include(x => x.DeckAndBalcony)
                .Include(x => x.DeckAndBalcony.PorchDeckBalconyConstructions)
                .Include(x => x.DeckAndBalcony.DeckConditionConcernsDetails)

                .Include(x => x.FencingAndOtherAttachment)
                .Include(x => x.FencingAndOtherAttachment.FencingTypes)
                .Include(x => x.FencingAndOtherAttachment.FenceConditionConcernDetails)
                .Include(x => x.FencingAndOtherAttachment.OtherAttachmentTypes)
                .Include(x => x.FencingAndOtherAttachment.OutbuildingDetails)
                .Include(x => x.FencingAndOtherAttachment.OtherDetachedStructuresDetails)

                .Include(x => x.Surrounding)

                .Include(x => x.AccessAndFireProtection)

                .Include(x => x.ExternalFuelSource)
                .Include(x => x.ExternalFuelSource.ExternalFuelSourceTypes)


                .SingleOrDefault(x => x.Id.Equals(id));
        }

        private void UpdateIOWildfireAssessment(InspectionOrder modifiedIO)
        {
            if (modifiedIO.WildfireAssessment == null) return;

            var dbSet = context.Set<InspectionOrder>();
            var existingIO = dbSet
              .Include(x => x.WildfireAssessment)
              .Include(x => x.WildfireAssessment.Roof)
              .Include(x => x.WildfireAssessment.Roof.OtherRoofCoverings)
              .Include(x => x.WildfireAssessment.Roof.RoofConcernDetails)
              .Include(x => x.WildfireAssessment.Roof.RoofVentings)
              .Include(x => x.WildfireAssessment.Roof.GutterTypes)

              .Include(x => x.WildfireAssessment.FoundationToFrame)

              .Include(x => x.WildfireAssessment.ExteriorSiding)
              .Include(x => x.WildfireAssessment.ExteriorSiding.OtherWallCoverings)
              .Include(x => x.WildfireAssessment.ExteriorSiding.SidingConditionConcernDetails)

              .Include(x => x.WildfireAssessment.Window)
              .Include(x => x.WildfireAssessment.Window.WindowGlassTypes)
              .Include(x => x.WildfireAssessment.Window.WindowFramingTypes)
              .Include(x => x.WildfireAssessment.Window.WindowStyles)
              .Include(x => x.WildfireAssessment.Window.WindowScreenTypes)
              .Include(x => x.WildfireAssessment.Window.InteriorWindowCoveringTypes)
              .Include(x => x.WildfireAssessment.Window.ExteriorWindowCoveringTypes)
              .Include(x => x.WildfireAssessment.Window.WindowConcernsDetails)

              .Include(x => x.WildfireAssessment.DeckAndBalcony)
              .Include(x => x.WildfireAssessment.DeckAndBalcony.PorchDeckBalconyConstructions)
              .Include(x => x.WildfireAssessment.DeckAndBalcony.DeckConditionConcernsDetails)

              .Include(x => x.WildfireAssessment.FencingAndOtherAttachment)
              .Include(x => x.WildfireAssessment.FencingAndOtherAttachment.FencingTypes)
              .Include(x => x.WildfireAssessment.FencingAndOtherAttachment.FenceConditionConcernDetails)
              .Include(x => x.WildfireAssessment.FencingAndOtherAttachment.OtherAttachmentTypes)
              .Include(x => x.WildfireAssessment.FencingAndOtherAttachment.OutbuildingDetails)
              .Include(x => x.WildfireAssessment.FencingAndOtherAttachment.OtherDetachedStructuresDetails)

              .Include(x => x.WildfireAssessment.Surrounding)

              .Include(x => x.WildfireAssessment.AccessAndFireProtection)

              .Include(x => x.WildfireAssessment.ExternalFuelSource)
              .Include(x => x.WildfireAssessment.ExternalFuelSource.ExternalFuelSourceTypes)

              .SingleOrDefault(a => a.Id.Equals(modifiedIO.Id));

            if (existingIO == null)
            {
                throw new Exception("Inspection Order does not exist");
            }

            if (existingIO.WildfireAssessment == null)
            {
                existingIO.WildfireAssessment = new InspectionOrderWildfireAssessment { Id = existingIO.Id };
                //context.Set<InspectionOrderProperty>().Attach(existingIO.Property);
                context.Entry(existingIO.WildfireAssessment).State = EntityState.Added;
            }

            if (modifiedIO.WildfireAssessment != null)
            {
                modifiedIO.WildfireAssessment.Id = existingIO.Id;
                context.Entry(existingIO.WildfireAssessment).CurrentValues.SetValues(modifiedIO.WildfireAssessment);
            }

            UpdateIOWildFireRoof(existingIO, modifiedIO);
            UpdateIOWildFireFoundationToFrame(existingIO, modifiedIO);
            UpdateIOWildFireExteriorSiding(existingIO, modifiedIO);
            UpdateIOWildFireWindows(existingIO, modifiedIO);
            UpdateIOWildFireDecksAndBalconies(existingIO, modifiedIO);
            UpdateIOWildFireFencingAndOtherAttachments(existingIO, modifiedIO);
            UpdateIOWildFireSurroundings(existingIO, modifiedIO);
            UpdateIOWildFireAccessAndFireProtection(existingIO, modifiedIO);
            UpdateIOWildFireExternalFuelsource(existingIO, modifiedIO);
        }

        private void UpdateIOWildFireRoof(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.WildfireAssessment?.Roof;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.WildfireAssessment.Roof;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderWildfireAssessmentRoof { Id = existingIO.WildfireAssessment.Id };
                //context.Set<InspectionOrderWildfireAssessmentRoof>().Attach(existingIO.WildfireAssessment.Roof);
                context.Entry(existingCategory).State = EntityState.Added;
            }
            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region Other Roof Covering
            {
                if (existingCategory.OtherRoofCoverings == null)
                {
                    existingCategory.OtherRoofCoverings = new List<InspectionOrderWildfireAssessmentRoofOtherRoofCoverings>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentRoofOtherRoofCoverings>();

                // delete item from database that are not in the modifiedIO.WildFire.Roof.OtherRoofCoverings collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentRoofId.Equals(categoryId)))
                    if (!category.OtherRoofCoverings.Any(x => x.OtherRoofCoveringId.Equals(existingItem.OtherRoofCoveringId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.OtherRoofCoverings.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentRoofId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentRoofId.Equals(item.InspectionOrderWildfireAssessmentRoofId) &&
                      x.OtherRoofCoveringId.Equals(item.OtherRoofCoveringId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Roof Concern Details
            {
                if (existingCategory.RoofConcernDetails == null)
                {
                    existingCategory.RoofConcernDetails = new List<InspectionOrderWildfireAssessmentRoofRoofConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentRoofRoofConcernDetails>();

                // delete item from database that are not in the modifiedIO.WildFire.Roof.RoofConcernDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentRoofId.Equals(categoryId)))
                    if (!category.RoofConcernDetails.Any(x => x.RoofConcernDetailId.Equals(existingItem.RoofConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.RoofConcernDetails.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentRoofId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentRoofId.Equals(item.InspectionOrderWildfireAssessmentRoofId) &&
                      x.RoofConcernDetailId.Equals(item.RoofConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Roof Venting
            {
                if (existingCategory.RoofVentings == null)
                {
                    existingCategory.RoofVentings = new List<InspectionOrderWildfireAssessmentRoofRoofVentings>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentRoofRoofVentings>();

                // delete item from database that are not in the modifiedIO.WildFire.Roof.RoofVentings collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentRoofId.Equals(categoryId)))
                    if (!category.RoofVentings.Any(x => x.RoofVentingId.Equals(existingItem.RoofVentingId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.RoofVentings.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentRoofId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentRoofId.Equals(item.InspectionOrderWildfireAssessmentRoofId) &&
                      x.RoofVentingId.Equals(item.RoofVentingId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Gutter Type
            {
                if (existingCategory.GutterTypes == null)
                {
                    existingCategory.GutterTypes = new List<InspectionOrderWildfireAssessmentRoofGutterTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentRoofGutterTypes>();

                // delete item from database that are not in the modifiedIO.WildFire.Roof.GutterTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentRoofId.Equals(categoryId)))
                    if (!category.GutterTypes.Any(x => x.GutterTypeId.Equals(existingItem.GutterTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.GutterTypes.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentRoofId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentRoofId.Equals(item.InspectionOrderWildfireAssessmentRoofId) &&
                      x.GutterTypeId.Equals(item.GutterTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

        }

        private void UpdateIOWildFireFoundationToFrame(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.WildfireAssessment?.FoundationToFrame;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.WildfireAssessment.FoundationToFrame;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderWildfireAssessmentFoundationToFrame { Id = existingIO.WildfireAssessment.Id };
                //context.Set<InspectionOrderWildfireAssessmentFoundationToFrame>().Attach(existingIO.WildfireAssessment.FoundationToFrame);
                context.Entry(existingCategory).State = EntityState.Added;
            }
            context.Entry(existingCategory).CurrentValues.SetValues(category);
        }

        private void UpdateIOWildFireExteriorSiding(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.WildfireAssessment?.ExteriorSiding;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.WildfireAssessment.ExteriorSiding;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderWildfireAssessmentExteriorSiding { Id = existingIO.WildfireAssessment.Id };
                //context.Set<InspectionOrderWildfireAssessmentExteriorSiding>().Attach(existingIO.WildfireAssessment.ExteriorSiding);
                context.Entry(existingCategory).State = EntityState.Added;
            }
            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region Other Wall Coverings
            {
                if (existingCategory.OtherWallCoverings == null)
                {
                    existingCategory.OtherWallCoverings = new List<InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings>();

                // delete item from database that are not in the modifiedIO.WildFire.ExteriorSiding.OtherWallCoverings collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentExteriorSidingId.Equals(categoryId)))
                    if (!category.OtherWallCoverings.Any(x => x.OtherWallCoveringId.Equals(existingItem.OtherWallCoveringId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.OtherWallCoverings.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentExteriorSidingId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentExteriorSidingId.Equals(item.InspectionOrderWildfireAssessmentExteriorSidingId) &&
                      x.OtherWallCoveringId.Equals(item.OtherWallCoveringId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Siding Condition Concerns Details
            {
                if (existingCategory.SidingConditionConcernDetails == null)
                {
                    existingCategory.SidingConditionConcernDetails = new List<InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails>();

                // delete item from database that are not in the modifiedIO.WildFire.ExteriorSiding.SidingConditionConcernDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentExteriorSidingId.Equals(categoryId)))
                    if (!category.SidingConditionConcernDetails.Any(x => x.SidingConditionConcernDetailId.Equals(existingItem.SidingConditionConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.SidingConditionConcernDetails.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentExteriorSidingId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentExteriorSidingId.Equals(item.InspectionOrderWildfireAssessmentExteriorSidingId) &&
                      x.SidingConditionConcernDetailId.Equals(item.SidingConditionConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion
        }

        private void UpdateIOWildFireWindows(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.WildfireAssessment?.Window;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.WildfireAssessment.Window;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderWildfireAssessmentWindow { Id = existingIO.WildfireAssessment.Id };
                //context.Set<InspectionOrderWildfireAssessmentWindow>().Attach(existingIO.WildfireAssessment.Window);
                context.Entry(existingCategory).State = EntityState.Added;
            }
            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region Window Glass Type
            {
                if (existingCategory.WindowGlassTypes == null)
                {
                    existingCategory.WindowGlassTypes = new List<InspectionOrderWildfireAssessmentWindowWindowGlassTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentWindowWindowGlassTypes>();

                // delete item from database that are not in the modifiedIO.WildFire.Window.WindowGlassTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentWindowId.Equals(categoryId)))
                    if (!category.WindowGlassTypes.Any(x => x.WindowGlassTypeId.Equals(existingItem.WindowGlassTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.WindowGlassTypes.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentWindowId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentWindowId.Equals(item.InspectionOrderWildfireAssessmentWindowId) &&
                      x.WindowGlassTypeId.Equals(item.WindowGlassTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Window Framing Type
            {
                if (existingCategory.WindowFramingTypes == null)
                {
                    existingCategory.WindowFramingTypes = new List<InspectionOrderWildfireAssessmentWindowWindowFramingTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentWindowWindowFramingTypes>();

                // delete item from database that are not in the modifiedIO.WildFire.Window.WindowFramingTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentWindowId.Equals(categoryId)))
                    if (!category.WindowFramingTypes.Any(x => x.WindowFramingTypeId.Equals(existingItem.WindowFramingTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.WindowFramingTypes.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentWindowId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentWindowId.Equals(item.InspectionOrderWildfireAssessmentWindowId) &&
                      x.WindowFramingTypeId.Equals(item.WindowFramingTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Window Styles
            {
                if (existingCategory.WindowStyles == null)
                {
                    existingCategory.WindowStyles = new List<InspectionOrderWildfireAssessmentWindowWindowStyles>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentWindowWindowStyles>();

                // delete item from database that are not in the modifiedIO.WildFire.Window.WindowStyles collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentWindowId.Equals(categoryId)))
                    if (!category.WindowStyles.Any(x => x.WindowStyleId.Equals(existingItem.WindowStyleId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.WindowStyles.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentWindowId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentWindowId.Equals(item.InspectionOrderWildfireAssessmentWindowId) &&
                      x.WindowStyleId.Equals(item.WindowStyleId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Window Screen Type
            {
                if (existingCategory.WindowScreenTypes == null)
                {
                    existingCategory.WindowScreenTypes = new List<InspectionOrderWildfireAssessmentWindowWindowScreenTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentWindowWindowScreenTypes>();

                // delete item from database that are not in the modifiedIO.WildFire.Window.WindowScreenTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentWindowId.Equals(categoryId)))
                    if (!category.WindowScreenTypes.Any(x => x.WindowScreenTypeId.Equals(existingItem.WindowScreenTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.WindowScreenTypes.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentWindowId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentWindowId.Equals(item.InspectionOrderWildfireAssessmentWindowId) &&
                      x.WindowScreenTypeId.Equals(item.WindowScreenTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Window Interior Covering Type
            {
                if (existingCategory.InteriorWindowCoveringTypes == null)
                {
                    existingCategory.InteriorWindowCoveringTypes = new List<InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes>();

                // delete item from database that are not in the modifiedIO.WildFire.Window.InteriorWindowCoveringTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentWindowId.Equals(categoryId)))
                    if (!category.InteriorWindowCoveringTypes.Any(x => x.InteriorWindowCoveringTypeId.Equals(existingItem.InteriorWindowCoveringTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.InteriorWindowCoveringTypes.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentWindowId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentWindowId.Equals(item.InspectionOrderWildfireAssessmentWindowId) &&
                      x.InteriorWindowCoveringTypeId.Equals(item.InteriorWindowCoveringTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Window Exterior Covering Type
            {
                if (existingCategory.ExteriorWindowCoveringTypes == null)
                {
                    existingCategory.ExteriorWindowCoveringTypes = new List<InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes>();

                // delete item from database that are not in the modifiedIO.WildFire.Window.ExteriorWindowCoveringTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentWindowId.Equals(categoryId)))
                    if (!category.ExteriorWindowCoveringTypes.Any(x => x.ExteriorWindowCoveringTypeId.Equals(existingItem.ExteriorWindowCoveringTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.ExteriorWindowCoveringTypes.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentWindowId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentWindowId.Equals(item.InspectionOrderWildfireAssessmentWindowId) &&
                      x.ExteriorWindowCoveringTypeId.Equals(item.ExteriorWindowCoveringTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Window Concern Details
            {
                if (existingCategory.WindowConcernsDetails == null)
                {
                    existingCategory.WindowConcernsDetails = new List<InspectionOrderWildfireAssessmentWindowWindowConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentWindowWindowConcernDetails>();

                // delete item from database that are not in the modifiedIO.WildFire.Window.WindowConcernsDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentWindowId.Equals(categoryId)))
                    if (!category.WindowConcernsDetails.Any(x => x.WindowConcernDetailId.Equals(existingItem.WindowConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.WindowConcernsDetails.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentWindowId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentWindowId.Equals(item.InspectionOrderWildfireAssessmentWindowId) &&
                      x.WindowConcernDetailId.Equals(item.WindowConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

        }

        private void UpdateIOWildFireDecksAndBalconies(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.WildfireAssessment?.DeckAndBalcony;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.WildfireAssessment.DeckAndBalcony;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderWildfireAssessmentDeckAndBalcony { Id = existingIO.WildfireAssessment.Id };
                //context.Set<InspectionOrderWildfireAssessmentDeckAndBalcony>().Attach(existingIO.WildfireAssessment.DeckAndBalcony);
                context.Entry(existingCategory).State = EntityState.Added;
            }
            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region Porch, Deck, Balcony Construction
            {
                if (existingCategory.PorchDeckBalconyConstructions == null)
                {
                    existingCategory.PorchDeckBalconyConstructions = new List<InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions>();

                // delete item from database that are not in the modifiedIO.WildFire.DeckAndBalcony.PorchDeckBalconyConstructions collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentDeckAndBalconyId.Equals(categoryId)))
                    if (!category.PorchDeckBalconyConstructions.Any(x => x.PorchDeckBalconyConstructionId.Equals(existingItem.PorchDeckBalconyConstructionId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.PorchDeckBalconyConstructions.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentDeckAndBalconyId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentDeckAndBalconyId.Equals(item.InspectionOrderWildfireAssessmentDeckAndBalconyId) &&
                      x.PorchDeckBalconyConstructionId.Equals(item.PorchDeckBalconyConstructionId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Deck Condition Concerns Details
            {
                if (existingCategory.DeckConditionConcernsDetails == null)
                {
                    existingCategory.DeckConditionConcernsDetails = new List<InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails>();

                // delete item from database that are not in the modifiedIO.WildFire.DeckAndBalcony.DeckConditionConcernsDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentDeckAndBalconyId.Equals(categoryId)))
                    if (!category.DeckConditionConcernsDetails.Any(x => x.DeckConditionConcernDetailId.Equals(existingItem.DeckConditionConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.DeckConditionConcernsDetails.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentDeckAndBalconyId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentDeckAndBalconyId.Equals(item.InspectionOrderWildfireAssessmentDeckAndBalconyId) &&
                      x.DeckConditionConcernDetailId.Equals(item.DeckConditionConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion
        }

        private void UpdateIOWildFireFencingAndOtherAttachments(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.WildfireAssessment?.FencingAndOtherAttachment;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.WildfireAssessment.FencingAndOtherAttachment;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderWildfireAssessmentFencingAndOtherAttachment { Id = existingIO.WildfireAssessment.Id };
                //context.Set<InspectionOrderWildfireAssessmentFencingAndOtherAttachment>().Attach(existingIO.WildfireAssessment.FencingAndOtherAttachment);
                context.Entry(existingCategory).State = EntityState.Added;
            }
            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region Fencing Type
            {
                if (existingCategory.FencingTypes == null)
                {
                    existingCategory.FencingTypes = new List<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes>();

                // delete item from database that are not in the modifiedIO.WildFire.FencingAndOtherAttachment.FencingTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId.Equals(categoryId)))
                    if (!category.FencingTypes.Any(x => x.FencingTypeId.Equals(existingItem.FencingTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.FencingTypes.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId.Equals(item.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId) &&
                      x.FencingTypeId.Equals(item.FencingTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Fence Condition Concerns Details
            {
                if (existingCategory.FenceConditionConcernDetails == null)
                {
                    existingCategory.FenceConditionConcernDetails = new List<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails>();

                // delete item from database that are not in the modifiedIO.WildFire.FencingAndOtherAttachment.FenceConditionConcernDetails collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId.Equals(categoryId)))
                    if (!category.FenceConditionConcernDetails.Any(x => x.FenceConditionConcernDetailId.Equals(existingItem.FenceConditionConcernDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.FenceConditionConcernDetails.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId.Equals(item.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId) &&
                      x.FenceConditionConcernDetailId.Equals(item.FenceConditionConcernDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Other Attachments Type
            {
                if (existingCategory.OtherAttachmentTypes == null)
                {
                    existingCategory.OtherAttachmentTypes = new List<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes>();

                // delete item from database that are not in the modifiedIO.WildFire.FencingAndOtherAttachment.FencingTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId.Equals(categoryId)))
                    if (!category.OtherAttachmentTypes.Any(x => x.OtherAttachmentTypeId.Equals(existingItem.OtherAttachmentTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.OtherAttachmentTypes.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId.Equals(item.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId) &&
                      x.OtherAttachmentTypeId.Equals(item.OtherAttachmentTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Outbuilding Details
            {
                if (existingCategory.OutbuildingDetails == null)
                {
                    existingCategory.OutbuildingDetails = new List<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails>();

                // delete item from database that are not in the modifiedIO.WildFire.FencingAndOtherAttachment.FencingTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId.Equals(categoryId)))
                    if (!category.OutbuildingDetails.Any(x => x.OutbuildingDetailId.Equals(existingItem.OutbuildingDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.OutbuildingDetails.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId.Equals(item.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId) &&
                      x.OutbuildingDetailId.Equals(item.OutbuildingDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion

            #region Other Detached Structures Details
            {
                if (existingCategory.OtherDetachedStructuresDetails == null)
                {
                    existingCategory.OtherDetachedStructuresDetails = new List<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails>();

                // delete item from database that are not in the modifiedIO.WildFire.FencingAndOtherAttachment.FencingTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId.Equals(categoryId)))
                    if (!category.OtherDetachedStructuresDetails.Any(x => x.OtherDetachedStructuresDetailId.Equals(existingItem.OtherDetachedStructuresDetailId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.OtherDetachedStructuresDetails.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId.Equals(item.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId) &&
                      x.OtherDetachedStructuresDetailId.Equals(item.OtherDetachedStructuresDetailId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion
        }

        private void UpdateIOWildFireSurroundings(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.WildfireAssessment?.Surrounding;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.WildfireAssessment.Surrounding;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderWildfireAssessmentSurrounding { Id = existingIO.WildfireAssessment.Id };
                //context.Set<InspectionOrderWildfireAssessmentSurrounding>().Attach(existingIO.WildfireAssessment.Surrounding);
                context.Entry(existingCategory).State = EntityState.Added;
            }
            context.Entry(existingCategory).CurrentValues.SetValues(category);
        }

        private void UpdateIOWildFireAccessAndFireProtection(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.WildfireAssessment?.AccessAndFireProtection;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.WildfireAssessment.AccessAndFireProtection;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderWildfireAssessmentAccessAndFireProtection { Id = existingIO.WildfireAssessment.Id };
                //context.Set<InspectionOrderWildfireAssessmentAccessAndFireProtection>().Attach(existingIO.WildfireAssessment.AccessAndFireProtection);
                context.Entry(existingCategory).State = EntityState.Added;
            }
            context.Entry(existingCategory).CurrentValues.SetValues(category);
        }

        private void UpdateIOWildFireExternalFuelsource(InspectionOrder existingIO, InspectionOrder modifiedIO)
        {
            var category = modifiedIO.WildfireAssessment?.ExternalFuelSource;
            if (category == null) return;
            category.Id = existingIO.Id;

            var existingCategory = existingIO.WildfireAssessment.ExternalFuelSource;
            if (existingCategory == null)
            {
                existingCategory = new InspectionOrderWildfireAssessmentExternalFuelSource { Id = existingIO.WildfireAssessment.Id };
                //context.Set<InspectionOrderWildfireAssessmentExternalFuelSource>().Attach(existingIO.WildfireAssessment.ExternalFuelSource);
                context.Entry(existingCategory).State = EntityState.Added;
            }
            context.Entry(existingCategory).CurrentValues.SetValues(category);
            var categoryId = existingCategory.Id;

            #region External Fuel Source Type
            {
                if (existingCategory.ExternalFuelSourceTypes == null)
                {
                    existingCategory.ExternalFuelSourceTypes = new List<InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes>();
                }

                var itemDbSet = context.Set<InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes>();

                // delete item from database that are not in the modifiedIO.WildFire.ExternalFuelSource.ExternalFuelSourceTypes collection
                foreach (var existingItem in itemDbSet.AsQueryable().Where(x => x.InspectionOrderWildfireAssessmentExternalFuelSourceId.Equals(categoryId)))
                    if (!category.ExternalFuelSourceTypes.Any(x => x.ExternalFuelSourceTypeId.Equals(existingItem.ExternalFuelSourceTypeId)))
                        itemDbSet.Remove(existingItem);

                foreach (var item in category.ExternalFuelSourceTypes.AsNotNull())
                {
                    item.InspectionOrderWildfireAssessmentExternalFuelSourceId = categoryId;

                    var existingItem = itemDbSet.SingleOrDefault(x =>
                      x.InspectionOrderWildfireAssessmentExternalFuelSourceId.Equals(item.InspectionOrderWildfireAssessmentExternalFuelSourceId) &&
                      x.ExternalFuelSourceTypeId.Equals(item.ExternalFuelSourceTypeId));

                    if (existingItem == null)
                    {
                        itemDbSet.Add(item);
                    }
                    else
                    {
                        context.Entry(existingItem).CurrentValues.SetValues(item);
                    }
                }
            }
            #endregion
        }

        #endregion

        public Image InsertOrUpdateIoPropertyPhoto(InspectionOrder ioFromClient)
        {
            var existingIo = Context.Set<InspectionOrder>()
                .Include(x => x.PropertyPhoto)
                .ThenInclude(x => x.Photos)
                .SingleOrDefault(x => x.Id.Equals(ioFromClient.Id));

            if (existingIo == null)
                throw new Exception("Inspection Order not found.");

            var propertyPhoto = existingIo.PropertyPhoto;
            if (propertyPhoto == null)
            {
                propertyPhoto = new InspectionOrderPropertyPhoto { Id = ioFromClient.Id };
                context.Entry(propertyPhoto).State = EntityState.Added;
            }

            if (propertyPhoto.Photos == null)
            {
                propertyPhoto.Photos = new List<InspectionOrderPropertyPhotoPhotos>();
            }

            var pmFromClient = ioFromClient.PropertyPhoto.Photos.First();
            pmFromClient.InspectionOrderPropertyPhotoId = propertyPhoto.Id;

            var phDbSet = context.Set<InspectionOrderPropertyPhotoPhotos>();

            var imageFromClient = pmFromClient.Image;

            var isAdd = (imageFromClient.Id == Guid.Empty);
            var newId = Guid.NewGuid();

            if (isAdd)
            {
                imageFromClient.Id = newId;
                _imageService.UpdateImageFile(imageFromClient, newId);

                pmFromClient.Image = imageFromClient;
                phDbSet.Add(pmFromClient);

                context.SaveChanges();

                return pmFromClient.Image;
            }
            else // update
            {
                var existingPm = phDbSet.SingleOrDefault(
                    w => w.InspectionOrderPropertyPhotoId == pmFromClient.InspectionOrderPropertyPhotoId &&
                         w.ImageId == imageFromClient.Id);

                if (existingPm == null)
                    throw new Exception("Image not found.");

                context.Entry(existingPm).CurrentValues.SetValues(pmFromClient);

                // this means that the image file from the client has changed
                if (imageFromClient.File != null)
                {
                    _imageService.UpdateImageFile(imageFromClient, newId);

                    var existingImage = _imageRepository.Retrieve(existingPm.ImageId);

                    context.Entry(existingImage).CurrentValues.SetValues(imageFromClient);

                    try
                    {
                        context.SaveChanges();

                        _imageService.DeleteImageFileInDisk(existingPm.Image.FilePath);
                        _imageService.DeleteImageFileInDisk(existingPm.Image.ThumbnailPath);

                        return existingPm.Image;
                    }
                    catch (Exception e)
                    {


                    }
                }
                else
                {
                    context.SaveChanges();
                }


                return imageFromClient;
            }
        }

        public InspectionOrderWildfireAssessment RetrieveIOWildFireWithFieldNames(Guid id)
        {
            return Context.Set<InspectionOrderWildfireAssessment>()
                .AsNoTracking()
                .Include(x => x.Roof)
                .Include(x => x.Roof.PrimaryRoofCovering)
                .Include(x => x.Roof.SecondaryRoofCovering)
                .Include(x => x.Roof.OtherRoofCoverings).ThenInclude(li => li.OtherRoofCovering)
                .Include(x => x.Roof.RoofType)
                .Include(x => x.Roof.RoofShape)
                .Include(x => x.Roof.RoofPitch)
                .Include(x => x.Roof.RoofConcernDetails).ThenInclude(li => li.RoofConcernDetail)
                .Include(x => x.Roof.RoofVentings).ThenInclude(li => li.RoofVenting)
                .Include(x => x.Roof.GutterTypes).ThenInclude(li => li.GutterType)
                .Include(x => x.Roof.EavesType)

                .Include(x => x.FoundationToFrame)
                .Include(x => x.FoundationToFrame.FoundationType)
                .Include(x => x.FoundationToFrame.FramingType)

                .Include(x => x.ExteriorSiding)
                .Include(x => x.ExteriorSiding.PrimaryExteriorWallCovering)
                .Include(x => x.ExteriorSiding.SecondaryExteriorWallCovering)
                .Include(x => x.ExteriorSiding.OtherWallCoverings).ThenInclude(li => li.OtherWallCovering)
                .Include(x => x.ExteriorSiding.SidingConditionConcernDetails).ThenInclude(li => li.SidingConditionConcernDetail)

                .Include(x => x.Window)
                .Include(x => x.Window.WindowGlassTypes).ThenInclude(li => li.WindowGlassType)
                .Include(x => x.Window.WindowFramingTypes).ThenInclude(li => li.WindowFramingType)
                .Include(x => x.Window.WindowStyles).ThenInclude(li => li.WindowStyle)
                .Include(x => x.Window.WindowScreenTypes).ThenInclude(li => li.WindowScreenType)
                .Include(x => x.Window.InteriorWindowCoveringTypes).ThenInclude(li => li.InteriorWindowCoveringType)
                .Include(x => x.Window.ExteriorWindowCoveringTypes).ThenInclude(li => li.ExteriorWindowCoveringType)
                .Include(x => x.Window.WindowConcernsDetails).ThenInclude(li => li.WindowConcernDetail)

                .Include(x => x.DeckAndBalcony)
                .Include(x => x.DeckAndBalcony.PorchDeckBalconyConstructions).ThenInclude(li => li.PorchDeckBalconyConstruction)
                .Include(x => x.DeckAndBalcony.DeckConditionConcernsDetails).ThenInclude(li => li.DeckConditionConcernDetail)

                .Include(x => x.FencingAndOtherAttachment)
                .Include(x => x.FencingAndOtherAttachment.FencingTypes).ThenInclude(li => li.FencingType)
                .Include(x => x.FencingAndOtherAttachment.FenceConditionConcernDetails).ThenInclude(li => li.FenceConditionConcernDetail)
                .Include(x => x.FencingAndOtherAttachment.OtherAttachmentTypes).ThenInclude(li => li.OtherAttachmentType)
                .Include(x => x.FencingAndOtherAttachment.OutbuildingDetails).ThenInclude(li => li.OutbuildingDetail)
                .Include(x => x.FencingAndOtherAttachment.OtherDetachedStructuresDetails).ThenInclude(li => li.OtherDetachedStructuresDetail)

                .Include(x => x.Surrounding)

                .Include(x => x.AccessAndFireProtection)
                .Include(x => x.AccessAndFireProtection.FireDepartmentStaffing)

                .Include(x => x.ExternalFuelSource)
                .Include(x => x.ExternalFuelSource.ExternalFuelSourceTypes).ThenInclude(li => li.ExternalFuelSourceType)

                .SingleOrDefault(x => x.Id.Equals(id));
        }

        public WildFireViewModel ConvertWildfireToView(InspectionOrderWildfireAssessment inspectionOrderWildFire)
        {
            if (inspectionOrderWildFire == null)
                inspectionOrderWildFire = new InspectionOrderWildfireAssessment();

            if (inspectionOrderWildFire.Roof == null)
                inspectionOrderWildFire.Roof = new InspectionOrderWildfireAssessmentRoof();
            if (inspectionOrderWildFire.FoundationToFrame == null)
                inspectionOrderWildFire.FoundationToFrame = new InspectionOrderWildfireAssessmentFoundationToFrame();
            if (inspectionOrderWildFire.ExteriorSiding == null)
                inspectionOrderWildFire.ExteriorSiding = new InspectionOrderWildfireAssessmentExteriorSiding();
            if (inspectionOrderWildFire.Window == null)
                inspectionOrderWildFire.Window = new InspectionOrderWildfireAssessmentWindow();
            if (inspectionOrderWildFire.DeckAndBalcony == null)
                inspectionOrderWildFire.DeckAndBalcony = new InspectionOrderWildfireAssessmentDeckAndBalcony();
            if (inspectionOrderWildFire.FencingAndOtherAttachment == null)
                inspectionOrderWildFire.FencingAndOtherAttachment = new InspectionOrderWildfireAssessmentFencingAndOtherAttachment();
            if (inspectionOrderWildFire.Surrounding == null)
                inspectionOrderWildFire.Surrounding = new InspectionOrderWildfireAssessmentSurrounding();
            if (inspectionOrderWildFire.AccessAndFireProtection == null)
                inspectionOrderWildFire.AccessAndFireProtection = new InspectionOrderWildfireAssessmentAccessAndFireProtection();
            if (inspectionOrderWildFire.ExternalFuelSource == null)
                inspectionOrderWildFire.ExternalFuelSource = new InspectionOrderWildfireAssessmentExternalFuelSource();

            WildFireViewModel wildfireView = new WildFireViewModel
            {
                #region Roof Fields

                PrimaryRoofCoveringName = inspectionOrderWildFire.Roof.PrimaryRoofCovering?.Name,
                SecondaryRoofCoveringName = inspectionOrderWildFire.Roof.SecondaryRoofCovering?.Name,
                OtherRoofTypeName = inspectionOrderWildFire.Roof.OtherRoofCoverings?.Select(x => x.OtherRoofCovering?.Name).ToArray(),
                RoofShapeName = inspectionOrderWildFire.Roof.RoofShape?.Name,
                RoofPitchName = inspectionOrderWildFire.Roof.RoofPitch?.Name,
                RoofConcernDetailsName = inspectionOrderWildFire.Roof.RoofConcernDetails?.Select(x => x.RoofConcernDetail?.Name).ToArray(),
                CombustibleMaterialsOnRoof = inspectionOrderWildFire.Roof.CombustibleMaterialsOnRoof,
                CombustibleMaterialsOnRoofComment = inspectionOrderWildFire.Roof.CombustibleMaterialsonRoofComment,
                RoofVentingName = inspectionOrderWildFire.Roof.RoofVentings?.Select(x => x.RoofVenting?.Name).ToArray(),
                VentingOpeningAllowEntry = inspectionOrderWildFire.Roof.VentingOpeningAllowEmberEntry,
                VentingCoveringsizeComment = inspectionOrderWildFire.Roof.VentingMeshCoveringSizeComment,
                GutterTypeName = inspectionOrderWildFire.Roof.GutterTypes?.Select(x => x.GutterType?.Name).ToArray(),
                GutterComments = inspectionOrderWildFire.Roof.GutterComment,
                EavesTypeName = inspectionOrderWildFire.Roof.EavesType?.Name,
                EavesAllowEmberEntry = inspectionOrderWildFire.Roof.EavesAllowEmberEntry,
                EavesComment = inspectionOrderWildFire.Roof.EavesComment,

                #endregion

                #region Foundation to Frame Fields

                OpeningsEmberEntry = inspectionOrderWildFire.FoundationToFrame.OpeningsEmberEntry,
                OpeningsEmberEntryComments = inspectionOrderWildFire.FoundationToFrame.OpeningsEmberEntryComment,
                ElevatedWithCombustibleMaterials = inspectionOrderWildFire.FoundationToFrame.ElevatedwithCombustibleMaterial,
                ElevatedWithCombustibleMaterialsComments = inspectionOrderWildFire.FoundationToFrame.ElevatedwithCombustibleMaterialsComment,
                FoundationTypeName = inspectionOrderWildFire.FoundationToFrame.FoundationType?.Name,
                FoundationTypeComment = inspectionOrderWildFire.FoundationToFrame.FoundationComment,
                FramingTypeName = inspectionOrderWildFire.FoundationToFrame.FramingType?.Name,

                #endregion

                #region Exterior Siding Fields

                PrimaryExteriorWallCoveringName = inspectionOrderWildFire.ExteriorSiding.PrimaryExteriorWallCovering?.Name,
                SecondaryExteriorWallCoveringName = inspectionOrderWildFire.ExteriorSiding.SecondaryExteriorWallCovering?.Name,
                OtherWallCoverings = inspectionOrderWildFire.ExteriorSiding.OtherWallCoverings?.Select(x => x.OtherWallCovering?.Name).ToArray(),
                NonCombustibleSiding = inspectionOrderWildFire.ExteriorSiding.NonCombustibleSiding,
                SidingConditionConcernsDetails = inspectionOrderWildFire.ExteriorSiding.SidingConditionConcernDetails?.Select(x => x.SidingConditionConcernDetail?.Name).ToArray(),
                SidingConditionComments = inspectionOrderWildFire.ExteriorSiding.SidingConditionComment,

                #endregion

                #region Windows Fields

                WindowSusceptibleToFlame = inspectionOrderWildFire.Window.WindowSusceptibletoFlame,
                WindowGlassTypeNames = inspectionOrderWildFire.Window.WindowGlassTypes?.Select(x => x.WindowGlassType?.Name).ToArray(),
                WindowFramingTypeNames = inspectionOrderWildFire.Window.WindowFramingTypes?.Select(x => x.WindowFramingType?.Name).ToArray(),
                WindowStylesName = inspectionOrderWildFire.Window.WindowStyles?.Select(x => x.WindowStyle?.Name).ToArray(),
                WindowScreenTypeNames = inspectionOrderWildFire.Window.WindowScreenTypes?.Select(x => x.WindowScreenType?.Name).ToArray(),
                InteriorWindowCoveringTypeNames = inspectionOrderWildFire.Window.InteriorWindowCoveringTypes?.Select(x => x.InteriorWindowCoveringType?.Name).ToArray(),
                ExteriorWindowCoveringTypeNames = inspectionOrderWildFire.Window.ExteriorWindowCoveringTypes?.Select(x => x.ExteriorWindowCoveringType?.Name).ToArray(),
                WindowConcernDetails = inspectionOrderWildFire.Window.WindowConcernsDetails?.Select(x => x.WindowConcernDetail?.Name).ToArray(),
                WindowNotes = inspectionOrderWildFire.Window.WindowNote,

                #endregion

                #region Decks & Balconies Fields

                AttachedPorchesDecksOrBalconies = inspectionOrderWildFire.DeckAndBalcony.AttachedPorcheDeckorBalcony,
                PorchDeckBalconyConstruction = inspectionOrderWildFire.DeckAndBalcony.PorchDeckBalconyConstructions?.Select(x => x.PorchDeckBalconyConstruction?.Name).ToArray(),
                PorchDeckBalconyCovered = inspectionOrderWildFire.DeckAndBalcony.PorchDeckBalconyCovered,
                CoveringMaterial = inspectionOrderWildFire.DeckAndBalcony.CoveringMaterial,
                DeckConditionConcernsDetailsName = inspectionOrderWildFire.DeckAndBalcony.DeckConditionConcernsDetails?.Select(x => x.DeckConditionConcernDetail?.Name).ToArray(),
                AttachedStructuresComments = inspectionOrderWildFire.DeckAndBalcony.AttachedStructuresComment,
                CombustibleMaterialsOnDeck = inspectionOrderWildFire.DeckAndBalcony.CombustibleMaterialsONDeckBalconyPorch,
                CombustibleMaterialsOnDeckDescription = inspectionOrderWildFire.DeckAndBalcony.CombustiblesONDeckBalconyPorchDescription,
                CombustibleMaterialsUnderDeck = inspectionOrderWildFire.DeckAndBalcony.CombustibleMaterialsUNDERDeckBalconyPorch,
                CombustibleMaterialsUnderDeckDescription = inspectionOrderWildFire.DeckAndBalcony.CombustiblesUNDERDeckBalconyPorchDescription,

                #endregion

                #region Fencing & Other Attachments Fields

                FencingWithin30Feet = inspectionOrderWildFire.FencingAndOtherAttachment.FencingWithin30Feet,
                FencingTypeNames = inspectionOrderWildFire.FencingAndOtherAttachment.FencingTypes?.Select(x => x.FencingType?.Name).ToArray(),
                FenceConditionconcernDetailsName = inspectionOrderWildFire.FencingAndOtherAttachment.FenceConditionConcernDetails?.Select(x => x.FenceConditionConcernDetail?.Name).ToArray(),
                FenceComments = inspectionOrderWildFire.FencingAndOtherAttachment.FenceComment,
                OtherAttachmentTypesName = inspectionOrderWildFire.FencingAndOtherAttachment.OtherAttachmentTypes?.Select(x => x.OtherAttachmentType?.Name).ToArray(),
                OutbuildingDetailNames = inspectionOrderWildFire.FencingAndOtherAttachment.OutbuildingDetails?.Select(x => x.OutbuildingDetail?.Name).ToArray(),
                OtherDetachedStructureDetailsName = inspectionOrderWildFire.FencingAndOtherAttachment.OtherDetachedStructuresDetails?.Select(x => x.OtherDetachedStructuresDetail?.Name).ToArray(),

                #endregion

                #region Surroundings

                Combustible05Feet = inspectionOrderWildFire.Surrounding.Combustible05Feet,
                Combustible05FeetComment = inspectionOrderWildFire.Surrounding.Combustible05FeetComment,
                Combustible530Feet = inspectionOrderWildFire.Surrounding.Combustible530Feet,
                Combustible530FeetComment = inspectionOrderWildFire.Surrounding.Combustible530FeetComment,
                Combustbile30100Feet = inspectionOrderWildFire.Surrounding.Combustible30100Feet,
                Combustible30100Feetcomments = inspectionOrderWildFire.Surrounding.Combustible30100FeetComment,
                AdditionalstructureContributor = inspectionOrderWildFire.Surrounding.AdditionalStructuresContributor,
                AdditionalstructureContributorComment = inspectionOrderWildFire.Surrounding.AdditionalStructuresContributorComment,
                TopographicalEnvironmentContributor = inspectionOrderWildFire.Surrounding.TopographicalEnvironmentalContributor,
                TopographicalEnvironmentContributorComment = inspectionOrderWildFire.Surrounding.TopographicalEnvironmentalContributorComment,
                VolatileVegetation = inspectionOrderWildFire.Surrounding.VolatileVegetationBeyond100Feet,
                VolatilevegetationComment = inspectionOrderWildFire.Surrounding.VolatileVegetationBeyond100FeetComment,
                NeighboringResidences = inspectionOrderWildFire.Surrounding.NeighboringResidence,
                NeighboringResidencesComment = inspectionOrderWildFire.Surrounding.NeighboringResidenceComment,

                #endregion

                #region Access & Fire Protection

                TimelyResponseConcern = inspectionOrderWildFire.AccessAndFireProtection.TimelyResponseConcern,
                TimelyResponseConcernComment = inspectionOrderWildFire.AccessAndFireProtection.TimelyResponseConcernComment,
                AddressHardToRead = inspectionOrderWildFire.AccessAndFireProtection.AddressHardtoRead,
                AddressReadabilitycomment = inspectionOrderWildFire.AccessAndFireProtection.AddressReadabilityComment,
                BridgeConcern = inspectionOrderWildFire.AccessAndFireProtection.BridgeConcern,
                BridgeConcernComment = inspectionOrderWildFire.AccessAndFireProtection.BridgeConcernComment,
                RespondingFireDepartment = inspectionOrderWildFire.AccessAndFireProtection.RespondingFireDepartment,
                FireDepartmentStaffingName = inspectionOrderWildFire.AccessAndFireProtection.FireDepartmentStaffing?.Name,
                FireDepartmentDistanceToHome = inspectionOrderWildFire.AccessAndFireProtection.FireDepartmentDistancetoHome,
                FireDepartmentTravelTimeToHome = inspectionOrderWildFire.AccessAndFireProtection.FireDepartmentTravelTimetoHome,
                NearestFireHydrant = inspectionOrderWildFire.AccessAndFireProtection.NearestFireHydrant,
                AlternateWaterSourceIfNoHydrant = inspectionOrderWildFire.AccessAndFireProtection.AlternateWaterSourceIfNoHydrant,

                #endregion

                #region External Fuel Source

                ExternalFuelSource = inspectionOrderWildFire.ExternalFuelSource.ExternalFuelSource,
                ExternalFuelSourceTypeNames = inspectionOrderWildFire.ExternalFuelSource.ExternalFuelSourceTypes?.Select(x => x.ExternalFuelSourceType?.Name).ToArray(),
                ExternalFuelSourceDistanceFromHome = inspectionOrderWildFire.ExternalFuelSource.ExternalFuelSourceDistanceFromHome,
                WoodStoveFireplace = inspectionOrderWildFire.ExternalFuelSource.WoodStoveOrFireplace,
                WoodStorageLocation = inspectionOrderWildFire.ExternalFuelSource.WoodStorageLocation,
                FirePreventiveMeasures = inspectionOrderWildFire.ExternalFuelSource.FirePeventiveMeasure

                #endregion
            };

            return wildfireView;
        }

        public void UpdateInspectionOrder(InspectionOrder ent)
        {
            ent.LastUpdatedDate = DateTime.Now;

            var dbSet = context.Set<InspectionOrder>();
            var existingIO = dbSet.SingleOrDefault(a => a.Id == ent.Id);

            context.Entry(existingIO).CurrentValues.SetValues(ent);

            context.SaveChanges();
        }

        private IQueryable<InspectionOrderView> RetrieveIoMapItList(
            Guid? inspectionOrderId,
            string inspectionStatusId,
            Guid? inspectorId,
            DateTime? inceptionDate,
            string location,
            string mitigationStatusId,
            string dateDifference,
            DateTime? inspectionDate)
        {
            var list = _dbSet.InspectionOrderView
                .AsNoTracking()
                .AsQueryable();

            if (inspectionOrderId.HasValue)
                list = list.Where(x => x.Id.Equals(inspectionOrderId));

            if (!string.IsNullOrEmpty(inspectionStatusId))
                list = list.Where(x => x.StatusId.Equals(inspectionStatusId));

            if (inspectorId.HasValue)
                list = list.Where(x => x.InspectorId.Equals(inspectorId));
            
            if (inceptionDate.HasValue)
                list = list.Where(x => x.InceptionDate.Equals(inceptionDate));

            if (!string.IsNullOrEmpty(location))
            {
                list = list.Where(x =>
                    x.Location.ToLower().Contains(location.ToLower()) ||
                    x.State.ToLower().Contains(location.ToLower()) ||
                    x.City.ToLower().Contains(location.ToLower()) ||
                    x.StreetAddress1.ToLower().Contains(location.ToLower()) ||
                    x.StreetAddress2.ToLower().Contains(location.ToLower()) ||
                    x.ZipCode.ToLower().Contains(location.ToLower())
                );
            }

            if (!string.IsNullOrEmpty(mitigationStatusId))
                list = list.Where(x => x.MitigationId.Equals(mitigationStatusId));

            if (!string.IsNullOrEmpty(dateDifference))
                list = list.Where(x => x.DateDifference.Equals(dateDifference));

            if (inspectionDate.HasValue)
                list = list.Where(x => x.InspectionDate.Equals(inspectionDate));

            return list.AsQueryable();
        }

        public IQueryable<InspectionOrderView> RetrieveMobileIoMapItList(
            Guid? inspectionOrderId,
            string inspectionStatusId,
            Guid? inspectorId,
            DateTime? inceptionDate,
            string location,
            string mitigationStatusId,
            string dateDifference,
            DateTime? inspectionDate,
            bool isLock)
        {
            var list = RetrieveIoMapItList(
                inspectionOrderId,
                inspectionStatusId,
                inspectorId,
                inceptionDate,
                location,
                mitigationStatusId,
                dateDifference,
                inspectionDate);

            return list.Where(x => x.IsLocked == isLock).AsQueryable();
        }

        public IQueryable<InspectionOrderView> RetrieveIoMapItList(Guid? inspectorId)
        {
            return RetrieveIoMapItList(
                null,
                InspectionStatus.Scheduled.Id,
                inspectorId,
                null,
                string.Empty,
                string.Empty,
                string.Empty,
                null);
        }

        public InspectionOrderView RetrieveIoMapItByIoId(Guid? inspectionOrderId)
        {
            return RetrieveIoMapItList(
                inspectionOrderId,
                string.Empty,
                null,
                null,
                string.Empty,
                string.Empty,
                string.Empty,
                null).SingleOrDefault();
        }

        public void SendEmailToInsured(string webHost, string fromEmail, InspectionOrder io)
        {
            string url = "";
            string emailSubject = "";
            var sbEmailBody = new StringBuilder();

            if (io.Policy.MitigationStatusId == MitigationStatusConstants.OutstandingItems)
            {
                url = $"{webHost}/order-management/inspection-order/mitigation/insured/{io.Id}";
                emailSubject = "Pending Mitigation Items";

                sbEmailBody.Append($"<p> Dear {io.Policy.InsuredFirstName},</p> ");
                sbEmailBody.Append("<p>To complete the mitigation items, please click the link below:</p> ");
                sbEmailBody.AppendFormat("<a href={0}>{0}</a>", url);
                sbEmailBody.AppendFormat("<p>For your login credentials:</p>");
                sbEmailBody.AppendFormat("<p>Please use your Policy Number as your username.");
                sbEmailBody.AppendFormat("<p>For your password, please use your last name.</p>");
            }
            else if(io.Policy.MitigationStatusId == MitigationStatusConstants.Completed)
            {
                url = $"{webHost}/order-management/inspection-order/report/insured/{io.Id}";
                emailSubject = "Completed Mitigation Items";

                sbEmailBody.Append($"<p> Dear {io.Policy.InsuredFirstName},</p> ");
                sbEmailBody.Append("<p>You're mitigation items are already completed, please click the link below if you want to download the report:</p> ");
                sbEmailBody.AppendFormat("<a href={0}>{0}</a>", url);
                sbEmailBody.AppendFormat("<p>For your login credentials:</p>");
                sbEmailBody.AppendFormat("<p>Please use your Policy Number as your username.");
                sbEmailBody.AppendFormat("<p>For your password, please use your last name.</p>");
            }
            else
            {
                url = $"{webHost}/order-management/inspection-order/report/insured/{io.Id}";
                emailSubject = "Inspection Completed";

                sbEmailBody.Append($"<p> Dear {io.Policy.InsuredFirstName},</p> ");
                sbEmailBody.Append("<p>The inspection in your property is already completed, please click the link below if you want to download the report:</p> ");
                sbEmailBody.AppendFormat("<a href={0}>{0}</a>", url);
                sbEmailBody.AppendFormat("<p>For your login credentials:</p>");
                sbEmailBody.AppendFormat("<p>Please use your Policy Number as your username.");
                sbEmailBody.AppendFormat("<p>For your password, please use your last name.</p>");
            }

            EmailUtils.SendEmail(webHost, fromEmail, AppSettings.Configuration["TemporaryInsuredEmail"], emailSubject, sbEmailBody.ToString());
        }

        public InspectionOrder RetrieveIoByPolicyNumber(string policyNumber, string lastName)
        {
            return context.Set<InspectionOrder>().Include(io => io.Policy)
                .FirstOrDefault(io => io.Policy.PolicyNumber == policyNumber && 
                    io.Policy.InsuredLastName == lastName);
        }

        public bool RetrieveByPolicyNumber(string policyNumber)
        {
            var dbSet = context.Set<InspectionOrder>().SingleOrDefault(x => x.Policy.PolicyNumber == policyNumber);

            return dbSet != null;
        }
    }
}