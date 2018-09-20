namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionStatus : Enumeration
    {
        public static InspectionStatus PendingAssignment => new InspectionStatus("PA", "Pending Assignment");
        public static InspectionStatus PendingQC => new InspectionStatus("PQC", "Pending QC");
        public static InspectionStatus PendingQCItems => new InspectionStatus("PQCI", "Pending QC Items");
        public static InspectionStatus PendingUWReview => new InspectionStatus("PUWR", "Pending UW Review");
        public static InspectionStatus PendingWriteUp => new InspectionStatus("PWU", "Pending Write-Up");
        public static InspectionStatus ReadyToSchedule => new InspectionStatus("RTS", "Ready To Schedule");
        public static InspectionStatus Scheduled => new InspectionStatus("S", "Scheduled");
        public static InspectionStatus UWApproved => new InspectionStatus("UWA", "UW Approved"); 
        public static InspectionStatus UWIssues => new InspectionStatus("UWI", "UW Issues"); 
        
        public InspectionStatus()
        {
        }

        public InspectionStatus(string id, string name)
            : base(id, name)
        {
        }
    }
}
