using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblEmpPerReviewSegmentMap : EntityTypeConfiguration<tblEmpPerReviewSegment>
    {
        public tblEmpPerReviewSegmentMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpReviewSegmentID);

            // Properties
            this.Property(t => t.CreatedBy)
                .HasMaxLength(100);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblEmpPerReviewSegment");
            this.Property(t => t.EmpReviewSegmentID).HasColumnName("EmpReviewSegmentID");
            this.Property(t => t.SegmentID).HasColumnName("SegmentID");
            this.Property(t => t.EmpReviewID).HasColumnName("EmpReviewID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasOptional(t => t.tblEmpPerReviewPerformance)
                .WithMany(t => t.tblEmpPerReviewSegments)
                .HasForeignKey(d => d.EmpReviewID);
            this.HasRequired(t => t.tblPerformanceSegment)
                .WithMany(t => t.tblEmpPerReviewSegments)
                .HasForeignKey(d => d.SegmentID);

        }
    }
}
