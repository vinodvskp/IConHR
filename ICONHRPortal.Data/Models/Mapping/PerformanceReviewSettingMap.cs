using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class PerformanceReviewSettingMap : EntityTypeConfiguration<PerformanceReviewSetting>
    {
        public PerformanceReviewSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.PerformanceReviewID);

            // Properties
            this.Property(t => t.ReviewTitle)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PerformanceReviewSettings");
            this.Property(t => t.PerformanceReviewID).HasColumnName("PerformanceReviewID");
            this.Property(t => t.ReviewTitle).HasColumnName("ReviewTitle");
            this.Property(t => t.CompletionDate).HasColumnName("CompletionDate");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.LocationID).HasColumnName("LocationID");
            this.Property(t => t.DepartmentID).HasColumnName("DepartmentID");
            this.Property(t => t.JobRoleID).HasColumnName("JobRoleID");
            this.Property(t => t.EmployementTypeID).HasColumnName("EmployementTypeID");
            this.Property(t => t.SpecificEmployeeID).HasColumnName("SpecificEmployeeID");
            this.Property(t => t.ExcludeEmployeeID).HasColumnName("ExcludeEmployeeID");
            this.Property(t => t.LegthofServiceID).HasColumnName("LegthofServiceID");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateDAte).HasColumnName("UpdateDAte");

            // Relationships
            this.HasOptional(t => t.lkpDepartment)
                .WithMany(t => t.PerformanceReviewSettings)
                .HasForeignKey(d => d.DepartmentID);
            this.HasOptional(t => t.lkpEmploymentType)
                .WithMany(t => t.PerformanceReviewSettings)
                .HasForeignKey(d => d.EmployementTypeID);
            this.HasRequired(t => t.lkpLocation)
                .WithMany(t => t.PerformanceReviewSettings)
                .HasForeignKey(d => d.LocationID);
            this.HasOptional(t => t.tblJobRole)
                .WithMany(t => t.PerformanceReviewSettings)
                .HasForeignKey(d => d.JobRoleID);

        }
    }
}
