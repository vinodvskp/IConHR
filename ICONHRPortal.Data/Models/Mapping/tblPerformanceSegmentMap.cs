using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblPerformanceSegmentMap : EntityTypeConfiguration<tblPerformanceSegment>
    {
        public tblPerformanceSegmentMap()
        {
            // Primary Key
            this.HasKey(t => t.PerformanceSegmentID);

            // Properties
            this.Property(t => t.SegmentName)
                .HasMaxLength(100);

            this.Property(t => t.SegmentDescription)
                .HasMaxLength(500);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(200);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblPerformanceSegment");
            this.Property(t => t.PerformanceSegmentID).HasColumnName("PerformanceSegmentID");
            this.Property(t => t.PerformanceReviewID).HasColumnName("PerformanceReviewID");
            this.Property(t => t.SegmentName).HasColumnName("SegmentName");
            this.Property(t => t.SegmentDescription).HasColumnName("SegmentDescription");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");

            // Relationships
            this.HasOptional(t => t.tblPerformanceReviewSetting)
                .WithMany(t => t.tblPerformanceSegments)
                .HasForeignKey(d => d.PerformanceReviewID);

        }
    }
}
