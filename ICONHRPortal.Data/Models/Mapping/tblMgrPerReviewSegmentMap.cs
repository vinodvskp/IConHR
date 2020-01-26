using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblMgrPerReviewSegmentMap : EntityTypeConfiguration<tblMgrPerReviewSegment>
    {
        public tblMgrPerReviewSegmentMap()
        {
            // Primary Key
            this.HasKey(t => t.MgrReviewSegmentID);

            // Properties
            this.Property(t => t.CreatedBy)
                .HasMaxLength(100);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblMgrPerReviewSegment");
            this.Property(t => t.MgrReviewSegmentID).HasColumnName("MgrReviewSegmentID");
            this.Property(t => t.PerformanceSegmentID).HasColumnName("PerformanceSegmentID");
            this.Property(t => t.MgrReviewID).HasColumnName("MgrReviewID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasOptional(t => t.tblMgrPerReviewPerformance)
                .WithMany(t => t.tblMgrPerReviewSegments)
                .HasForeignKey(d => d.MgrReviewID);

        }
    }
}
