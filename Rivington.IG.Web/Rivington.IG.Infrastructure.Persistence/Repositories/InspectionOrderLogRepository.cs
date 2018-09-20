using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rivington.IG.Domain;
using Rivington.IG.Domain.CustomCodes;
using Rivington.IG.Domain.InspectionOrderLog;
using Rivington.IG.Domain.Models.Constants;
using Rivington.IG.Domain.Models.InspectionOrderLog;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderLogRepository : RepositoryBase<InspectionOrderLogs>, IInspectionOrderLog
    {
        private readonly IRivingtonContext context;
        private readonly IAccountRepository _accountRepository;

        public InspectionOrderLogRepository(IRivingtonContext context, IAccountRepository accountRepository) : base(context)
        {
            this.context = context;
            _accountRepository = accountRepository;
        }

        public IQueryable<InspectionOrderLogs> GetIOLogs(Guid id)
        {
            return Context.Set<InspectionOrderLogs>()
                .Where(x => x.InspectionOrderId == id && x.Action == InspectionOrderLogActionsConstants.UpdatedInspectionOrderStatus).Select(x => new InspectionOrderLogs { ActionDescription = x.ActionDescription, DateCreated = x.DateCreated });
        }

        public async Task<InspectionOrder> RetrieveIO(Guid id)
        {
            return Context.Set<InspectionOrder>()
              .Include(x => x.Policy)
              .Include(x => x.Inspector)               
              .Include(x => x.Policy.MitigationStatus)
              .Include(x => x.Policy.InspectionStatus)
              .Include(x => x.Policy.PropertyValue)
              .Include(x => x.Notes)

            #region Property
              .Include(x => x.Property)
              .Include(x => x.Property.General)
              .Include(x => x.Property.General.City)
              .Include(x => x.Property.General.State)
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
              .Include(x => x.Property.NonWildfireAssessment.Mitigation.Recommendations)
              .Include(x => x.Property.NonWildfireAssessment.Mitigation.Requirements)

            #endregion

            #region Wildfire

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
              .Include(x => x.WildfireAssessment.Mitigation.Recommendations)
              .Include(x => x.WildfireAssessment.Mitigation.Requirements)

            #endregion

              .SingleOrDefault(x => x.Id.Equals(id));
        }

        public async void SaveIOLog(string action, string actionDescription, Guid id)
        {
            bool ioLogSwitch = Convert.ToBoolean(AppSettings.Configuration["EnableInspectionOrderLogs"]);

            if (ioLogSwitch)
            {
                var inspectionOrder = await this.RetrieveIO(id);

                this.UpdateInspectionOrder(inspectionOrder);

                string ioString = Utils.SerializeObjectToJson(inspectionOrder);

                var currentUser = this.context.GetCurrentUser();
                var user = _accountRepository.Retrieve(currentUser);

                InspectionOrderLogs inspectionOrderLogs = new InspectionOrderLogs
                {
                    InspectionOrderJsonData = ioString,
                    Action = action,
                    ActionDescription = actionDescription,
                    DateCreated = DateTime.Now,
                    InspectionOrderId = id,
                    CreatedById = user.Id
                };

                context.Set<InspectionOrderLogs>().Add(inspectionOrderLogs);

                context.SaveChanges();
            }
        }

        public void UpdateInspectionOrder(InspectionOrder ent)
        {
            ent.LastUpdatedDate = DateTime.Now;

            var dbSet = context.Set<InspectionOrder>();
            var existingIO = dbSet.SingleOrDefault(a => a.Id == ent.Id);

            context.Entry(existingIO).CurrentValues.SetValues(ent);

            context.SaveChanges();
        }
    }
}
