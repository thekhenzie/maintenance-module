using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rivington.IG.Domain.Models.Views
{
    [Table("vwUserManagementList")]
    public class ApplicationUserView
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string DisplayName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public string ZipCode { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string ThumbnailPath { get; set; }
        public string UserStatus { get; set; }
    }
}
