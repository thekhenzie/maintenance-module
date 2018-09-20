using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rivington.IG.Domain.Models.Views
{
    [Table("vwOrderManagementList")]
    public class InspectionOrderView
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsLocked { get; set; }
        public Guid? IsLockedById { get; set; }
        public string IsLockedByUserName { get; set; }
        public string PolicyNumber { get; set; }
        public string InsuredName { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? InceptionDate { get; set; }
        public Guid? InspectorId { get; set; }
        public string Inspector { get; set; }
        public string Status { get; set; }
        public string DateDifference { get; set; }
        public string Location { get; set; }
        public string MitigationStatus { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string ZipCode { get; set; }
        public string StatusId { get; set; }
        public string MitigationId { get; set; }
        public string Username { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
