using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rivington.IG.Domain.Models.OrderManagement
{
    public class InspectionOrderPropertyHomeDetail
    {
        [Parent]
        public InspectionOrderProperty InspectionOrderProperty { get; set; }
        [Key]
        public Guid Id { get; set; }
        
        public string ArchitecturalStyleId { get; set; }
        [ForeignKey(nameof(ArchitecturalStyleId))]
        public ArchitecturalStyle ArchitecturalStyle { get; set; }
        
        public string FramingTypeId { get; set; }
        [ForeignKey(nameof(FramingTypeId))]
        public FramingType FramingType { get; set; }
        
        public string ConstructionQualityId { get; set; }
        [ForeignKey(nameof(ConstructionQualityId))]
        public ConstructionQuality ConstructionQuality { get; set; }
        
        public string HomeShapeId { get; set; }
        [ForeignKey(nameof(HomeShapeId))]
        public HomeShape HomeShape { get; set; }
        
        public string PrimaryExteriorWallCoveringId { get; set; }
        [ForeignKey(nameof(PrimaryExteriorWallCoveringId))]
        public PrimaryExteriorWallCovering PrimaryExteriorWallCovering { get; set; }
        
        public string SecondaryExteriorWallCoveringId { get; set; }
        [ForeignKey(nameof(SecondaryExteriorWallCoveringId))]
        public SecondaryExteriorWallCovering SecondaryExteriorWallCovering { get; set; }
        
        public string PrimaryRoofCoveringId { get; set; }
        [ForeignKey(nameof(PrimaryRoofCoveringId))]
        public PrimaryRoofCovering PrimaryRoofCovering { get; set; }
        
        public string SecondaryRoofCoveringId { get; set; }
        [ForeignKey(nameof(SecondaryRoofCoveringId))]
        public SecondaryRoofCovering SecondaryRoofCovering { get; set; }

        public string RoofTypeId { get; set; }
        [ForeignKey(nameof(RoofTypeId))]
        public RoofType RoofType { get; set; }
        public string RoofShapeId { get; set; }
        [ForeignKey(nameof(RoofShapeId))]
        public RoofShape RoofShape { get; set; }

        public string RoofPitchId { get; set; }
        [ForeignKey(nameof(RoofPitchId))]
        public RoofPitch RoofPitch { get; set; }

        public string FoundationTypeId { get; set; }
        [ForeignKey(nameof(FoundationTypeId))]
        public FoundationType FoundationType { get; set; }
        
        public int? NumberofStories { get; set; }
        
        public string SlopeOfSiteId { get; set; }
        [ForeignKey(nameof(SlopeOfSiteId))]
        public SlopeOfSite SlopeOfSite { get; set; }

        public ICollection<InspectionOrderPropertyHomeDetailLocales> Locales { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            var entTypeName = nameof(InspectionOrderPropertyHomeDetail);
            modelBuilder.Entity<InspectionOrderProperty>()
                .HasOne(a => a.HomeDetail).WithOne(b => b.InspectionOrderProperty)
                .HasForeignKey<InspectionOrderPropertyHomeDetail>()
                .HasConstraintName($"FK_{nameof(InspectionOrderProperty)}_{entTypeName}")
                .OnDelete(DeleteBehavior.Cascade);

            var entBuilder = modelBuilder.Entity<InspectionOrderPropertyHomeDetail>();
            entBuilder.HasOne(a => a.ArchitecturalStyle).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(ArchitecturalStyle)}");
            entBuilder.HasOne(a => a.FramingType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(FramingType)}");
            entBuilder.HasOne(a => a.ConstructionQuality).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(ConstructionQuality)}");
            entBuilder.HasOne(a => a.HomeShape).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(HomeShape)}");
            entBuilder.HasOne(a => a.PrimaryExteriorWallCovering).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(PrimaryExteriorWallCovering)}");
            entBuilder.HasOne(a => a.SecondaryExteriorWallCovering).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(SecondaryExteriorWallCovering)}");
            entBuilder.HasOne(a => a.PrimaryRoofCovering).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(PrimaryRoofCovering)}");
            entBuilder.HasOne(a => a.SecondaryRoofCovering).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(SecondaryRoofCovering)}");
            entBuilder.HasOne(a => a.RoofType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(RoofType)}");
            entBuilder.HasOne(a => a.RoofShape).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(RoofShape)}");
            entBuilder.HasOne(a => a.RoofPitch).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(RoofPitch)}");
            entBuilder.HasOne(a => a.FoundationType).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(FoundationType)}");
            entBuilder.HasOne(a => a.SlopeOfSite).WithMany().HasConstraintName($"FK_{entTypeName}_{nameof(SlopeOfSite)}");

            InspectionOrderPropertyHomeDetailLocales.BuildModel(modelBuilder);
        }
    }
}