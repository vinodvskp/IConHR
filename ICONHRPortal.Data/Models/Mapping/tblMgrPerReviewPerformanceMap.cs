using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblMgrPerReviewPerformanceMap : EntityTypeConfiguration<tblMgrPerReviewPerformance>
    {
        public tblMgrPerReviewPerformanceMap()
        {
            // Primary Key
            this.HasKey(t => t.MgrReviewID);

            // Properties
            this.Property(t => t.CreatedBy)
                .HasMaxLength(200);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblMgrPerReviewPerformance");
            this.Property(t => t.MgrReviewID).HasColumnName("MgrReviewID");
            this.Property(t => t.RepMgrID).HasColumnName("RepMgrID");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.PerformanceReviewID).HasColumnName("PerformanceReviewID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasOptional(t => t.tblEmployeeDetail)
                .WithMany(t => t.tblMgrPerReviewPerformances)
                .HasForeignKey(d => d.EmpID);
            this.HasRequired(t => t.tblPerformanceReviewSetting)
                .WithMany(t => t.tblMgrPerReviewPerformances)
                .HasForeignKey(d => d.PerformanceReviewID);

        }
    }
}
