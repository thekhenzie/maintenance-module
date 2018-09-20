using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Infrastructure.Security
{
    [ModelBinder(BinderType = typeof(GenericModelBinder<ApplicationUser>))]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            IsActivated = true;
        }

        public ApplicationUser(string userName) : base(userName)
        {
            IsActivated = true;
            this.UserName = userName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public virtual List<Token> Tokens { get; set; }
        public string DisplayName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public string ZipCode { get; set; }

        public Guid? ProfilePhotoId { get; set; }
        [ForeignKey(nameof(ProfilePhotoId))] public Image ProfilePhoto { get; set; }

        public bool IsActivated { get; set; }
        public bool? isInsured { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(ApplicationUser);  
            var entBuilder = modelBuilder.Entity<ApplicationUser>();

            entBuilder.HasOne(a => a.ProfilePhoto).WithOne()
                .HasConstraintName($"FK_{entTypeName}_{nameof(ProfilePhoto)}");

            entBuilder
                .HasIndex(nameof(ProfilePhotoId))
                .IsUnique(false).HasName($"IX_{entTypeName}_{nameof(ProfilePhotoId)}");
        }
    }
}
