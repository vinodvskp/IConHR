using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblEmpPerReviewPerformanceMap : EntityTypeConfiguration<tblEmpPerReviewPerformance>
    {
        public tblEmpPerReviewPerformanceMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpReviewID);

            // Properties
            this.Property(t => t.CreatedBy)
                .HasMaxLength(200);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblEmpPerReviewPerformance");
            this.Property(t => t.EmpReviewID).HasColumnName("EmpReviewID");
            this.Property(t => t.RepMgrID).HasColumnName("RepMgrID");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.PerformanceReviewID).HasColumnName("PerformanceReviewID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.SharetoManager).HasColumnName("SharetoManager");

            // Relationships
            this.HasOptional(t => t.tblEmployeeDetail)
                .WithMany(t => t.tblEmpPerReviewPerformances)
                .HasForeignKey(d => d.EmpID);
            this.HasRequired(t => t.tblPerformanceReviewSetting)
                .WithMany(t => t.tblEmpPerReviewPerformances)
                .HasForeignKey(d => d.PerformanceReviewID);

        }
    }
}
