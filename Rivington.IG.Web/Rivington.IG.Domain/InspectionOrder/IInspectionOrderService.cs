using Rivington.IG.Domain.Models.OrderManagement;
using System;
using Rivington.IG.Domain.ViewModel;
using System.Threading.Tasks;

namespace Rivington.IG.Domain
{
    public interface IInspectionOrderService
    {
        InspectionOrder Save(Guid id, InspectionOrder inspectionOrder);
        bool SendInsuredEmailOnScheduled(InspectionOrder inspectionOrder, string webHost);
        Task<bool> SendEmailToManager(InspectionOrder inspectionOrder, string webHost);
        Task<bool> SendEmailToInspector(InspectionOrder inspectionOrder, string webHost);
        Task<bool> SendEmailToUnderWriter(InspectionOrder inspectionOrder, string webHost);
        Task<bool> SendEmailToInspectionUWI(InspectionOrder inspectionOrder, string webHost);
        Task<bool> SendEmailToInspectionUWA(InspectionOrder inspectionOrder, string webHost);
        Task<bool> SendEmailToInspectionPUWR(InspectionOrder inspectionOrder, string webHost);
        string GenerateRiskSummary(Guid id);
        ReportTitleViewModel ConvertToTitlePageProperties(InspectionOrder inspectionOrder);
        InspectionOrder ProcessIO(InspectionOrder inspectionOrder, Guid assignedById);
    }
}