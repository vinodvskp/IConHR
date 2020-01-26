using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class EmpMgrPerReviewSegmentMap : EntityTypeConfiguration<EmpMgrPerReviewSegment>
    {
        public EmpMgrPerReviewSegmentMap()
        {
            // Primary Key
            this.HasKey(t => t.PerformanceSegmentID);

            // Properties
            this.Property(t => t.CreatedBy)
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.UpdatedBy)
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("EmpMgrPerReviewSegment");
            this.Property(t => t.PerformanceSegmentID).HasColumnName("PerformanceSegmentID");
            this.Property(t => t.SegmentID).HasColumnName("SegmentID");
            this.Property(t => t.PerformanceID).HasColumnName("PerformanceID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");

            // Relationships
            this.HasRequired(t => t.tblPerformanceSegment)
                .WithMany(t => t.EmpMgrPerReviewSegments)
                .HasForeignKey(d => d.SegmentID);

        }
    }
}
