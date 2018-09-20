using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.Models.Constants
{
    public class InspectionStatusConstants
    {
        public const string PendingAssignment = "PA";
        public const string PendingQC = "PQC";
        public const string PendingQCItems = "PQCI";
        public const string PendingUWReview = "PUWR";
        public const string PendingWriteUp = "PWU";
        public const string ReadyToSchedule = "RTS";
        public const string Scheduled = "S";
        public const string UWApproved = "UWA";
        public const string UWIssues = "UWI";
    }
}
