using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using System;
using Rivington.IG.Domain.Models.Views;
using System.Collections.Generic;
using Rivington.IG.Domain.Models.ViewModel;
using System.Linq;
using Rivington.IG.Domain.ViewModel;

namespace Rivington.IG.Domain
{
    public interface IInspectionOrderRepository : IRepository<InspectionOrder>
    {
        RetrieveResult<InspectionOrder> RetrieveWithInlcude(DataSourceRequest request, DateTime? scheduledDate);
        void InsertOrUpdateIO(InspectionOrder ent);
        void UpdateIOChecklist(InspectionOrder newIO);
        InspectionOrderProperty RetrieveIOProperty(Guid id);
        InspectionOrderWildfireAssessment RetrieveIOWildFire(Guid id);
        InspectionOrderWildfireAssessment RetrieveIOWildFireWithFieldNames(Guid id);
        RetrieveResult<InspectionOrderView> RetrieveView(DataSourceRequest request, DateTime? scheduledDate, DateTime? assignedDate);
        Image InsertOrUpdateIoPropertyPhoto(InspectionOrder ioFromClient);
        InspectionOrder Retrieve(Guid id);
        InspectionOrder RetrieveForGeneratingRiskSummary(Guid id);
        InspectionOrder RetrieveRiskSummary(Guid id);
        InspectionOrder RetrieveReportTitlePage(Guid id);
        InspectionOrder RetrievePolicyPremiumCredits(Guid id);
        void UpdateInspectionOrder(InspectionOrder ent);
        WildFireViewModel ConvertWildfireToView(InspectionOrderWildfireAssessment inspectionWildfire);
        IQueryable<InspectionOrderView> RetrieveIOView();
        IQueryable<InspectionOrderView> RetrieveMobileIoMapItList(Guid? inspectionOrderId, string inspectionStatusId, Guid? inspectorId, DateTime? inceptionDate, string location, string mitigationStatusId, string dateDifference, DateTime? inspectionDate, bool isLock);
        IQueryable<InspectionOrderView> RetrieveIoMapItList(Guid? inspectorId);
        InspectionOrderView RetrieveIoMapItByIoId(Guid? inspectionOrderId);
        void SendEmailToInsured(string webHost, string fromEmail, InspectionOrder io);
        InspectionOrder RetrieveIoByPolicyNumber(string policyNumber, string lastName);

        bool RetrieveByPolicyNumber(string policyNumber);
    }
}