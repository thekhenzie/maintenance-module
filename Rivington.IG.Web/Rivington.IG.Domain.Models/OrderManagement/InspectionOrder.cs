using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rivington.IG.Infrastructure.Security;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    [ModelBinder(BinderType = typeof(GenericModelBinder<InspectionOrder>))]  
    public class InspectionOrder
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsLocked { get; set; }
        public Guid? IsLockedById { get; set; }
        [ForeignKey(nameof(IsLockedById))]
        public ApplicationUser IsLockedBy { get; set; }

        public DateTime? AssignedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        [Required]
        public Policy Policy { get; set; }

        public ICollection<InspectionOrderNote> Notes { get; set; }

        public Guid? AssignedById { get; set; }
        [ForeignKey(nameof(AssignedById))]
        public ApplicationUser AssignedBy { get; set; }

        public Guid? CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public ApplicationUser CreatedBy { get; set; }

        public Guid? InspectorId { get; set; }
        [ForeignKey(nameof(InspectorId))]
        public ApplicationUser Inspector { get; set; }

        public InspectionOrderProperty Property { get; set; }
        public InspectionOrderWildfireAssessment WildfireAssessment { get; set; }
        public InspectionOrderPropertyPhoto PropertyPhoto { get; set; }
        public string RiskSummary { get; set; }
        public static void BuildModel(ModelBuilder modelBuilder)
        {
            Policy.BuildModel(modelBuilder);

            modelBuilder.Entity<InspectionOrder>()
                .HasOne(a => a.Inspector);

            modelBuilder.Entity<InspectionOrder>().ToTable();

            //modelBuilder.ImplementITrackable<InspectionOrder>();

            InspectionOrderProperty.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessment.BuildModel(modelBuilder);

            InspectionOrderPropertyPhoto.BuildModel(modelBuilder);
        }
    }
}