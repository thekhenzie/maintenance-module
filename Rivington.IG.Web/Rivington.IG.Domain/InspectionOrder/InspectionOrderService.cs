using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Rivington.IG.Domain.Account;
using Rivington.IG.Domain.CustomCodes;
using Rivington.IG.Domain.Models.Constants;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.ViewModel;
using Rivington.IG.Infrastructure.Security;

namespace Rivington.IG.Domain
{
    public class InspectionOrderService : IInspectionOrderService
    {
        private readonly IInspectionOrderRepository _inspectionOrderRepository;
        private readonly IAccountcontrollerService _accountcontrollerService;
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public InspectionOrderService(
            IInspectionOrderRepository inspectionOrderRepository,
            IAccountRepository accountRepository,
            IAccountcontrollerService accountcontrollerService,
            UserManager<ApplicationUser> userManager)
        {
            _inspectionOrderRepository = inspectionOrderRepository;
            _accountRepository = accountRepository;
            _accountcontrollerService = accountcontrollerService;
            _userManager = userManager;
        }

        public InspectionOrder Save(Guid id, InspectionOrder inspectionOrder)
        {
            InspectionOrder result = null;
            var foundid = _inspectionOrderRepository.Retrieve(id);
            if (foundid == null)
            {
                inspectionOrder.CreatedDate = DateTime.Now;
                inspectionOrder.AssignedDate = DateTime.Now;
                result = _inspectionOrderRepository.Create(inspectionOrder);
            }
            else
            {
                result = _inspectionOrderRepository.Update(id, inspectionOrder);
            }
            return result;
        }

        public InspectionOrder ProcessIO(InspectionOrder inspectionOrder, Guid assignedById)
        {
            // From Pending Assignment to Ready To Schedule
            //if (inspectionOrder.InspectorId != null &&
            //    inspectionOrder.Policy.InspectionStatusId == InspectionStatusConstants.PendingAssignment)
            //{
            //    inspectionOrder.Policy.InspectionStatusId = InspectionStatusConstants.ReadyToSchedule;
            //}

            // From Ready To Schedule to Scheduled
            //if (inspectionOrder.Policy.InspectionStatusId == InspectionStatusConstants.ReadyToSchedule &&
            //    inspectionOrder.InspectionDate != null)
            //{
            //    inspectionOrder.Policy.InspectionStatusId = InspectionStatusConstants.Scheduled;
            //}

            switch (inspectionOrder.Policy.InspectionStatusId)
            {
                case InspectionStatusConstants.PendingAssignment:
                    inspectionOrder.CreatedDate = DateTime.Now.Date;
                    break;

                case InspectionStatusConstants.ReadyToSchedule:
                    inspectionOrder.AssignedDate = DateTime.Now.Date;
                    inspectionOrder.AssignedById = assignedById;
                    break;

                case InspectionStatusConstants.Scheduled:
                    if (inspectionOrder.AssignedById == null)
                    {
                        inspectionOrder.AssignedDate = DateTime.Now.Date;
                        inspectionOrder.AssignedById = assignedById;
                    }
                    this.SendInsuredEmailOnScheduled(inspectionOrder, Domain.CustomCodes.AppSettings.WebHost);
                    break;

                default:
                    break;
            }

            if (inspectionOrder.Policy.MitigationStatusId == MitigationStatusConstants.OutstandingItems ||
                    inspectionOrder.Policy.MitigationStatusId == MitigationStatusConstants.Completed ||
                    inspectionOrder.Policy.MitigationStatusId == MitigationStatusConstants.NoneRequired)
            {
                _inspectionOrderRepository.SendEmailToInsured(
                    Domain.CustomCodes.AppSettings.WebHost,
                    Domain.CustomCodes.AppSettings.EmailSender,
                    inspectionOrder);
            }

            return inspectionOrder;
        }

        public bool SendInsuredEmailOnScheduled(InspectionOrder inspectionOrder, string webHost)
        {
            try
            {
                var selectedInspector = _accountRepository.Retrieve(Guid.Parse(inspectionOrder.InspectorId.ToString()));

                var emailBody = new StringBuilder();
                emailBody.AppendLine($"<p>Dear {inspectionOrder.Policy.InsuredFirstName},</p>");
                emailBody.AppendLine($"<p>Here is the schedule of the inspection of your property: <strong>{inspectionOrder.InspectionDate:MMMM dd, yyyy}</strong></p>");
                emailBody.AppendLine("<p>Your inspection order details:</p>");
                emailBody.AppendLine($"<p>Policy Number: {inspectionOrder.Policy.PolicyNumber}</p>");
                emailBody.AppendLine($"<p>Insured Name: {inspectionOrder.Policy.InsuredFirstName} {inspectionOrder.Policy.InsuredLastName}</p>");
                emailBody.AppendLine($"<p>Inception Date: {inspectionOrder.Policy.InceptionDate:MMMM dd, yyyy}</p>");
                emailBody.AppendLine($"<p><i><small>Please keep this details for future reference.</small></i></p>");
                emailBody.AppendLine("<p>Your property will be inspected by one of our expert. </p>");
                emailBody.AppendLine("<h4>Inspector Details:</h4>");

                var sPhotoPath =
                    selectedInspector.ProfilePhoto != null ?
                        selectedInspector.ProfilePhoto.FilePath :
                        "StaticFiles/default-user-profile-image.jpg";

                emailBody.AppendLine($"<img src='{webHost}/{sPhotoPath}' width ='150' height='150' >");

                emailBody.AppendLine($"<p><b>Inspector Name:</b> {selectedInspector.FirstName} {selectedInspector.LastName}</p>");

                emailBody.AppendLine($"<p><b>Inspector Email:</b> {selectedInspector.Email}</p>");
                emailBody.AppendLine("<p>Sincerely,<br>Inspector Gadget</br></p> ");

                _accountcontrollerService.SendEmail("Inspection Schedule", inspectionOrder.Policy.InsuredEmail,
                    emailBody.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Error on sending email to Insured.");
            }

            return true;
        }

        public async Task<bool> SendEmailToManager(InspectionOrder inspectionOrder, string webHost)
        {
            try
            { 
                var selectedManager = await _userManager.FindByIdAsync(inspectionOrder.AssignedById.ToString());

                var managerfullName = selectedManager.FirstName + " " + selectedManager.LastName;

                var emailBody = new StringBuilder();
                emailBody.AppendLine($"<p>Dear {managerfullName} ,</p>");
                emailBody.AppendLine($"<p>The Inspection Order with Policy: {inspectionOrder.Policy.PolicyNumber}</p>");
                emailBody.AppendLine("<p>is now pending for your review</p>");

                _accountcontrollerService.SendEmail("Inspection Report Review", selectedManager.Email,
                    emailBody.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Error on sending email to Manager.");
            }

            return true;
        }

        public async Task<bool> SendEmailToInspector(InspectionOrder inspectionOrder, string webHost)
        {
            try
            {
                var selectedInspector = await _userManager.FindByIdAsync(inspectionOrder.InspectorId.ToString());
                
                var inspectorFullName = selectedInspector.FirstName + " " + selectedInspector.LastName;

                var selectedManager = await _userManager.FindByIdAsync(inspectionOrder.AssignedById.ToString());

                var managerfullName = selectedManager.FirstName + " " + selectedManager.LastName;

                var emailBody = new StringBuilder();
                emailBody.AppendLine($"<p>Dear {inspectorFullName} ,</p>");
                emailBody.AppendLine($"<p>The Inspection Order with Policy: {inspectionOrder.Policy.PolicyNumber}</p>");
                emailBody.AppendLine($"<p>has been rejected by {managerfullName}</p>");
                emailBody.AppendLine("<p>please see inspection order notes for further explanation</p>");

                _accountcontrollerService.SendEmail("Inspection Report Review", selectedInspector.Email,
                    emailBody.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Error on sending email to Manager.");
            }

            return true;
        }

        public async Task<bool> SendEmailToUnderWriter(InspectionOrder inspectionOrder, string webHost)
        {
            try
            {
                var selectedUnderWriter = await _userManager.FindByIdAsync(inspectionOrder.CreatedById.ToString());

                var underWriterFullName = selectedUnderWriter.FirstName + " " + selectedUnderWriter.LastName;

                var emailBody = new StringBuilder();
                emailBody.AppendLine($"<p>Dear {underWriterFullName} ,</p>");
                emailBody.AppendLine($"<p>The Inspection Order with Policy: {inspectionOrder.Policy.PolicyNumber}</p>");
                emailBody.AppendLine("<p>is now pending for your review</p>");

                _accountcontrollerService.SendEmail("Inspection Report Review", selectedUnderWriter.Email,
                    emailBody.ToString());

            }
            catch (Exception e)
            {
                throw new Exception("Error on sending email to Manager.");
            }

            return true;
        }

        public async Task<bool> SendEmailToInspectionPUWR(InspectionOrder inspectionOrder, string webHost)
        {
            try
            {
                var selectedInspector = await _userManager.FindByIdAsync(inspectionOrder.InspectorId.ToString());

                var inspectorFullName = selectedInspector.FirstName + " " + selectedInspector.LastName;
                var emailBody = new StringBuilder();
                emailBody.AppendLine($"<p>Dear {inspectorFullName} ,</p>");
                emailBody.AppendLine($"<p>The Inspection Order with Policy: {inspectionOrder.Policy.PolicyNumber}</p>");
                emailBody.AppendLine("<p>has been approved and is now pending for under writer review.</p>");

                _accountcontrollerService.SendEmail("Inspection Report Review", selectedInspector.Email,
                    emailBody.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Error on sending email to Manager.");
            }

            return true;
        }

        public async Task<bool> SendEmailToInspectionUWI(InspectionOrder inspectionOrder, string webHost)
        {
            try
            {
                var selectedUnderWriter = await _userManager.FindByIdAsync(inspectionOrder.CreatedById.ToString());

                var underWriterFullName = selectedUnderWriter.FirstName + " " + selectedUnderWriter.LastName;

                var selectedInspector = await _userManager.FindByIdAsync(inspectionOrder.InspectorId.ToString());

                var inspectorFullName = selectedInspector.FirstName + " " + selectedInspector.LastName;

                var emailBody = new StringBuilder();
                emailBody.AppendLine($"<p>Dear {inspectorFullName} ,</p>");
                emailBody.AppendLine($"<p>The Inspection Order with Policy: {inspectionOrder.Policy.PolicyNumber}</p>");
                emailBody.AppendLine($"<p>has been rejected by {underWriterFullName}</p>");
                emailBody.AppendLine("<p>please see inspection order notes for further explanation</p>");

                _accountcontrollerService.SendEmail("Inspection Report Review", selectedInspector.Email,
                    emailBody.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Error on sending email to Manager.");
            }

            return true;
        }

        public async Task<bool> SendEmailToInspectionUWA(InspectionOrder inspectionOrder, string webHost)
        {
            try
            {
                var selectedInspector = await _userManager.FindByIdAsync(inspectionOrder.InspectorId.ToString());

                var inspectorFullName = selectedInspector.FirstName + " " + selectedInspector.LastName;

                var selectedUnderWriter = await _userManager.FindByIdAsync(inspectionOrder.CreatedById.ToString());

                var underWriterFullName = selectedUnderWriter.FirstName + " " + selectedUnderWriter.LastName;

                var emailBody = new StringBuilder();
                emailBody.AppendLine($"<p>Dear {inspectorFullName} ,</p>");
                emailBody.AppendLine($"<p>The Inspection Order with Policy: {inspectionOrder.Policy.PolicyNumber}</p>");
                emailBody.AppendLine($"<p>has been accepted by {underWriterFullName}</p>");

                _accountcontrollerService.SendEmail("Inspection Report Review", selectedInspector.Email,
                    emailBody.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Error on sending email to Manager.");
            }

            return true;
        }

        public string GenerateRiskSummary(Guid id)
        {
            var inspectionOrder = _inspectionOrderRepository.RetrieveForGeneratingRiskSummary(id);

            string insuranceRemarks, yearBuilt, occupancyType, framingType, primaryExteriorWallCovering, primaryRoofCovering, electricalConcernDetail, plumbingType, electricalServiceAmperage, waterHeaterAge, coverageA, e2ValueReplacementCostValue, lacksSeismicStrapping, plumbingConcernsDetails, woodStoveOrFirePlace, domesticHelp, businessAgricultureOnPremises, fireAndBurglarAlarms, bearInvasionConcerns = "";

            #region Property General
            if (inspectionOrder.Property?.General != null)
            {
                yearBuilt = inspectionOrder.Property.General.YearBuilt == null ? EmptyFieldHandler("Year Built") : inspectionOrder.Property.General.YearBuilt.ToString();
                occupancyType = inspectionOrder.Property.General.OccupancyType == null ? EmptyFieldHandler("Occupancy Type") : inspectionOrder.Property.General.OccupancyType.Name?.ToLower();
                waterHeaterAge = inspectionOrder.Property.General.WaterHeaterAge == 0 ? EmptyFieldHandler("Water Heater Age") : inspectionOrder.Property.General.WaterHeaterAge.ToString();
                domesticHelp = inspectionOrder.Property.General.DomesticHelp?.Id != "YE" ? "The insured does not employ domestic workers in the home." : "The insured employs the following domestic workers: " + string.Join(", ", inspectionOrder.Property.General.DomesticHelpTypes) + "<???>";

                if (inspectionOrder.Property.General.FireAlarm != null && inspectionOrder.Property.General.FireAlarmType != null && inspectionOrder.Property.General.BurglarAlarm != null && inspectionOrder.Property.General.BurglarAlarmType != null)
                {
                    fireAndBurglarAlarms = inspectionOrder.Property.General.FireAlarm.Id == "Y" && inspectionOrder.Property.General.FireAlarmType.Id == "C" && inspectionOrder.Property.General.BurglarAlarm.Id == "Y" && inspectionOrder.Property.General.BurglarAlarmType.Id == "C" ? "The insured has central station fire and burglar alarms in the home." : "Fire Alarm: " + inspectionOrder.Property.General.FireAlarm.Name + " (" + inspectionOrder.Property.General.FireAlarmType.Name + ").  Burglar Alarm: " + inspectionOrder.Property.General.BurglarAlarm.Name + " (" + inspectionOrder.Property.General.BurglarAlarmType.Name + ").  ???";
                }
                else
                {
                    fireAndBurglarAlarms = EmptyFieldHandler("Fire and/or Burglar Alarms");
                }

            }
            else
            {
                yearBuilt = EmptyFieldHandler("Year Built");
                occupancyType = EmptyFieldHandler("Occupancy Type");
                waterHeaterAge = EmptyFieldHandler("Water Heater Age");
                domesticHelp = EmptyFieldHandler("Domestic Help Type(s)");
                fireAndBurglarAlarms = EmptyFieldHandler("Fire and/or Burglar Alarms");
            }
            #endregion

            #region Property Home Detail
            if (inspectionOrder.Property?.HomeDetail != null)
            {
                framingType = inspectionOrder.Property.HomeDetail.FramingType == null ? EmptyFieldHandler("Framing Type") : inspectionOrder.Property.HomeDetail.FramingType.Name?.ToLower();
                primaryExteriorWallCovering = inspectionOrder.Property.HomeDetail.PrimaryExteriorWallCovering == null ? EmptyFieldHandler("Primary Exterior Wall Covering") : inspectionOrder.Property.HomeDetail.PrimaryExteriorWallCovering.Name?.ToLower();
                primaryRoofCovering = inspectionOrder.Property.HomeDetail.PrimaryRoofCovering == null ? EmptyFieldHandler("Primary Roof Covering") : inspectionOrder.Property.HomeDetail.PrimaryRoofCovering.Name?.ToLower();
            }
            else
            {
                framingType = EmptyFieldHandler("Framing Type");
                primaryExteriorWallCovering = EmptyFieldHandler("Primary Exterior Wall Covering");
                primaryRoofCovering = EmptyFieldHandler("Primary Roof Covering");
            }
            #endregion

            #region Property Building Concern
            if (inspectionOrder.Property?.BuildingConcern != null)
            {
                electricalConcernDetail = inspectionOrder.Property.BuildingConcern.ElectricalConcernDetails?.Count(x => x.ElectricalConcernDetailId == "NF") > 0 ? string.Join(", ", inspectionOrder.Property.BuildingConcern.ElectricalConcernDetails.Select(x => x.ElectricalConcernDetail)) + "<???>" : "No electrical concerns were observed at time of inspection.";

                if (inspectionOrder.Property.BuildingConcern.PlumbingConcernDetails?.Count() > 0)
                {
                    lacksSeismicStrapping = inspectionOrder.Property.BuildingConcern.PlumbingConcernDetails.FirstOrDefault().PlumbingConcernDetailId == "WHLSS" ? "does not have" : "has";
                }
                else
                {
                    lacksSeismicStrapping = EmptyFieldHandler("Plumbing Concert Detail");
                }
                plumbingConcernsDetails = inspectionOrder.Property.BuildingConcern.PlumbingConcernDetails?.Count(x => x.PlumbingConcernDetailId == "NF") > 0 ? "The following plumbing concerns exist: " + string.Join(", ", inspectionOrder.Property.BuildingConcern.PlumbingConcernDetails.Select(x => x.PlumbingConcernDetail)) + "<???>" : "No evidence of leaks, and no plumbing concerns were observed at time of inspection.";
            }
            else
            {
                electricalConcernDetail = "No electrical concerns were observed at time of inspection.";
                lacksSeismicStrapping = EmptyFieldHandler("Plumbing Concert Detail");
                plumbingConcernsDetails = "No evidence of leaks, and no plumbing concerns were observed at time of inspection.";
            }
            #endregion

            #region Property Interior Detail

            if (inspectionOrder.Property?.InteriorDetail != null)
            {
                electricalServiceAmperage = inspectionOrder.Property.InteriorDetail.ElectricalServiceAmperage ?? EmptyFieldHandler("Electrical Service Amperage");

                string plumbingTypeIfEmpty = inspectionOrder.Property.InteriorDetail.TypeOfPlumbings?.Count > 0 ? "The plumbing in the homse is" + string.Join(", ", inspectionOrder.Property.InteriorDetail.TypeOfPlumbings.Select(x => x.TypeOfPlumbing)) + "<???>" : EmptyFieldHandler("Plumbing Type");
                plumbingType = inspectionOrder.Property.InteriorDetail.TypeOfPlumbings?.Count == 1 ? "The plumbing throughout the home is " + inspectionOrder.Property.InteriorDetail.TypeOfPlumbings.FirstOrDefault().TypeOfPlumbing?.ToString().ToLower() : plumbingTypeIfEmpty;
            }
            else
            {
                electricalServiceAmperage = EmptyFieldHandler("Electrical Service Amperage"); 
                plumbingType = EmptyFieldHandler("Plumbing Type"); 
            }
            #endregion

            #region Policy
            if (inspectionOrder.Policy != null)
            {
                if (inspectionOrder.Policy.CoverageA != null && inspectionOrder.Policy.E2ValueReplacementCostValue != null)
                {
                    coverageA = inspectionOrder.Policy.CoverageA.ToString();
                    e2ValueReplacementCostValue = inspectionOrder.Policy.E2ValueReplacementCostValue.ToString();

                    int? coverageAPrivate = inspectionOrder.Policy.CoverageA;
                    int? e2ValueReplacementCostValuePrivate = inspectionOrder.Policy.E2ValueReplacementCostValue;

                    string roundedComputation = Math.Round((decimal.Parse(e2ValueReplacementCostValuePrivate.ToString()) - decimal.Parse(coverageAPrivate.ToString())) / decimal.Parse(coverageAPrivate.ToString()), 0).ToString();
                    if (e2ValueReplacementCostValuePrivate >= coverageAPrivate * .95 && e2ValueReplacementCostValuePrivate <= coverageAPrivate * 1.05)
                    {
                        insuranceRemarks = "adequate";
                    }
                    else if (e2ValueReplacementCostValuePrivate < coverageAPrivate * .95)
                    {
                        insuranceRemarks = roundedComputation + " underinsured";
                    }
                    else
                    {
                        insuranceRemarks = roundedComputation + " overinsured";
                    }
                }
                else
                {
                    coverageA = EmptyFieldHandler("Coverage A");
                    e2ValueReplacementCostValue = EmptyFieldHandler("e2Value Replacement Cost Value");
                    insuranceRemarks = EmptyFieldHandler("Insurance Budget");
                }
            }
            else
            {
                coverageA = EmptyFieldHandler("Coverage A");
                e2ValueReplacementCostValue = EmptyFieldHandler("e2Value Replacement Cost Value");
                insuranceRemarks = EmptyFieldHandler("Insurance Budget");
            }
            #endregion

            #region Wildfire Assement External Fuel Source
            if (inspectionOrder.WildfireAssessment?.ExternalFuelSource != null)
            {
                woodStoveOrFirePlace = inspectionOrder.WildfireAssessment.ExternalFuelSource.WoodStoveOrFireplace ? "The insured has a wood-burning fireplace/wood stove in their home. It is a secondary source of heat.  It appears that the woodstove was installed in a workmanlike manner and does have adequate clearance.  <???>" : string.Empty;
            }
            else
            {
                woodStoveOrFirePlace = string.Empty;
            }
            #endregion

            #region Property Additional Exposure

            if (inspectionOrder.Property.AdditionalExposure != null)
            {
                businessAgricultureOnPremises = inspectionOrder.Property.AdditionalExposure.BusinessAgricultureonPremises ? "The owner runs a business or agriculture on premises.  <???>" : string.Empty;

                string bearInavsionConcernDetails = inspectionOrder.Property.AdditionalExposure.BearInvasionConcernDetails?.Count > 0 ? "The following bear invasion concerns exist:" + string.Join(", ", inspectionOrder.Property.AdditionalExposure.BearInvasionConcernDetails.Select(x => x.BearInvasionConcernDetail)) : string.Empty;
                bearInvasionConcerns = inspectionOrder.Property.AdditionalExposure.BearInvasionConcern ? "The insured’s residence is in an area that is known to be inhabited by bears. " + bearInavsionConcernDetails : string.Empty;
            }
            else
            {
                businessAgricultureOnPremises = string.Empty;
                bearInvasionConcerns = string.Empty;
            }
            #endregion

            var riskSummary = new StringBuilder();
            riskSummary.AppendLine($"The insured’s residence was built in {yearBuilt}.");
            riskSummary.AppendLine($"This is the insured’s {occupancyType}.");
            riskSummary.AppendLine($"\nThe home is {framingType} framed with {primaryExteriorWallCovering} exterior siding and {primaryRoofCovering} roofing. There are(is an) attached <???>.");
            riskSummary.AppendLine($"Interior features of the home include <???>.");
            riskSummary.AppendLine($"\nThe home has {electricalServiceAmperage}-amp service with <???>. {electricalConcernDetail}");
            riskSummary.AppendLine($"\n{plumbingType}. The hot water heater is {waterHeaterAge} years old and {lacksSeismicStrapping} seismic safety strapping. {plumbingConcernsDetails}");
            if (woodStoveOrFirePlace != string.Empty) riskSummary.AppendLine($"\n{woodStoveOrFirePlace}");
            riskSummary.AppendLine($"\n{domesticHelp}");
            if (businessAgricultureOnPremises != string.Empty) riskSummary.AppendLine($"\n{businessAgricultureOnPremises}");
            riskSummary.AppendLine($"\n{fireAndBurglarAlarms}");
            riskSummary.AppendLine($"\n<???> Comment on any prior losses the insured has had, report on dogs in the home, or any other ");
            riskSummary.AppendLine($"Items worth noting to underwriter.  <???> ");
            if (bearInvasionConcerns != string.Empty) riskSummary.AppendLine($"\n{bearInvasionConcerns}");
            riskSummary.AppendLine($"\nThe requested Coverage A amount is $ {coverageA}");
            riskSummary.AppendLine($"Upon inspection, the calculated Replacement Cost Value is $ {e2ValueReplacementCostValue}");
            riskSummary.AppendLine($"\nAs written, the coverage appears to be {insuranceRemarks}.The Replacement Cost Value report is attached. ");


            return riskSummary.ToString();
        }

        
        public ReportTitleViewModel ConvertToTitlePageProperties(InspectionOrder inspectionOrder)
        {
            ReportTitleViewModel reportTitleView = new ReportTitleViewModel { };
            if (inspectionOrder != null)
            {
                if (inspectionOrder.Policy == null) inspectionOrder.Policy = new Policy();
                if (inspectionOrder.Inspector == null) inspectionOrder.Inspector = new ApplicationUser();

                reportTitleView = new ReportTitleViewModel
                {
                    Id = inspectionOrder.Id,
                    InsuredFullname = inspectionOrder.Policy.InsuredFirstName + ' ' + inspectionOrder.Policy.InsuredLastName,
                    InsuredAddress = inspectionOrder.Policy.Address,
                    InsuredCityStateZipCode = inspectionOrder.Policy.InsuredCity + ' ' + inspectionOrder.Policy.InsuredState + ' ' + inspectionOrder.Policy.InsuredZipCode,
                    InspectorFullName = inspectionOrder.Inspector.FirstName + ' ' + inspectionOrder.Inspector.LastName,
                    InspectorEmail = inspectionOrder.Inspector.Email,
                    InspectorMobileNumber = inspectionOrder.Inspector.MobileNumber,
                    AgentName = inspectionOrder.Policy.AgentName,
                    AgencyName = inspectionOrder.Policy.AgencyName,
                    AgentPhoneNumber = inspectionOrder.Policy.AgentPhoneNumber,
                    InspectionDate = inspectionOrder.InspectionDate,
                    PolicyNumber = inspectionOrder.Policy.PolicyNumber,
                    Photo = inspectionOrder.PropertyPhoto?.Photos?.OrderBy(x => x.Image.CreatedAt).FirstOrDefault(x => x.PhotoTypeId == "RC")?.Image.FilePath
                };
            }

            return reportTitleView;
        }

        #region Helper Methods
        private string EmptyFieldHandler(string field) {
            return $"<You may insert {field} here>";
        }
        #endregion
    }
}