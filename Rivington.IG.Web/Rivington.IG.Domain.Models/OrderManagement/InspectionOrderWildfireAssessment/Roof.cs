using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderWildfireAssessmentRoof
    {
        [Parent]
        public InspectionOrderWildfireAssessment InspectionOrderWildfireAssessment { get; set; }
        [Key]
        public Guid Id { get; set; }
        

        public string PrimaryRoofCoveringId { get; set; }
        [ForeignKey(nameof(PrimaryRoofCoveringId))]
        public PrimaryRoofCovering PrimaryRoofCovering { get; set; }

        public string SecondaryRoofCoveringId { get; set; }
        [ForeignKey(nameof(SecondaryRoofCoveringId))]
        public SecondaryRoofCovering SecondaryRoofCovering { get; set; }

        public ICollection<InspectionOrderWildfireAssessmentRoofOtherRoofCoverings> OtherRoofCoverings { get; set; }

        public string RoofTypeId { get; set; }
        [ForeignKey(nameof(RoofTypeId))]
        public RoofType RoofType { get; set; }

        public string RoofShapeId { get; set; }
        [ForeignKey(nameof(RoofShapeId))]
        public RoofShape RoofShape { get; set; }

        public string RoofPitchId { get; set; }
        [ForeignKey(nameof(RoofPitchId))]
        public RoofPitch RoofPitch { get; set; }

        public ICollection<InspectionOrderWildfireAssessmentRoofRoofConcernDetails> RoofConcernDetails { get; set; }
        public bool CombustibleMaterialsOnRoof { get; set; }
        public string CombustibleMaterialsonRoofComment { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentRoofRoofVentings> RoofVentings { get; set; }
        public bool VentingOpeningAllowEmberEntry { get; set; }
        public string VentingMeshCoveringSizeComment { get; set; }
        public bool Gutter { get; set; }
        public ICollection<InspectionOrderWildfireAssessmentRoofGutterTypes> GutterTypes { get; set; }
        public string GutterComment { get; set; }

        public string EavesTypeId { get; set; }
        [ForeignKey(nameof(EavesTypeId))]
        public EavesType EavesType { get; set; }

        public bool EavesAllowEmberEntry { get; set; }
        public string EavesComment { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            // IoWa = Inspection Order Wildfire Assessment
            const string entTypeName = "IoWaRoof";
            modelBuilder.Entity<InspectionOrderWildfireAssessment>()
                .HasOne(a => a.Roof).WithOne(b => b.InspectionOrderWildfireAssessment)
                .HasForeignKey<InspectionOrderWildfireAssessmentRoof>()
                .HasConstraintName($"FK_{nameof(InspectionOrderWildfireAssessment)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);

            var entBuilder = modelBuilder.Entity<InspectionOrderWildfireAssessmentRoof>();
            entBuilder.HasOne(a => a.PrimaryRoofCovering).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(PrimaryRoofCovering)}");
            entBuilder.HasOne(a => a.SecondaryRoofCovering).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(SecondaryRoofCovering)}");
            
            InspectionOrderWildfireAssessmentRoofOtherRoofCoverings.BuildModel(modelBuilder);

            entBuilder.HasOne(a => a.RoofType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(RoofType)}");
            entBuilder.HasOne(a => a.RoofShape).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(RoofShape)}");
            entBuilder.HasOne(a => a.RoofPitch).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(RoofPitch)}");

            InspectionOrderWildfireAssessmentRoofRoofConcernDetails.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentRoofRoofVentings.BuildModel(modelBuilder);

            InspectionOrderWildfireAssessmentRoofGutterTypes.BuildModel(modelBuilder);

            entBuilder.HasOne(a => a.EavesType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(EavesType)}");
        }
    }
}