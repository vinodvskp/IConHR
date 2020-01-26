using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblPerformanceReviewSettingMap : EntityTypeConfiguration<tblPerformanceReviewSetting>
    {
        public tblPerformanceReviewSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.PerformanceReviewID);

            // Properties
            this.Property(t => t.ReviewTitle)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(100);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblPerformanceReviewSettings");
            this.Property(t => t.PerformanceReviewID).HasColumnName("PerformanceReviewID");
            this.Property(t => t.ReviewTitle).HasColumnName("ReviewTitle");
            this.Property(t => t.ReviewCompletionDate).HasColumnName("ReviewCompletionDate");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.LocationID).HasColumnName("LocationID");
            this.Property(t => t.DepartmentID).HasColumnName("DepartmentID");
            this.Property(t => t.JobRoleID).HasColumnName("JobRoleID");
            this.Property(t => t.EmploymentTypeID).HasColumnName("EmploymentTypeID");
            this.Property(t => t.LengthOfService).HasColumnName("LengthOfService");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasOptional(t => t.lkpDepartment)
                .WithMany(t => t.tblPerformanceReviewSettings)
                .HasForeignKey(d => d.DepartmentID);
            this.HasOptional(t => t.lkpEmploymentType)
                .WithMany(t => t.tblPerformanceReviewSettings)
                .HasForeignKey(d => d.EmploymentTypeID);
            this.HasOptional(t => t.lkpLocation)
                .WithMany(t => t.tblPerformanceReviewSettings)
                .HasForeignKey(d => d.LocationID);
            this.HasOptional(t => t.tblCompanyDetail)
                .WithMany(t => t.tblPerformanceReviewSettings)
                .HasForeignKey(d => d.CompanyID);
            this.HasOptional(t => t.tblJobRole)
                .WithMany(t => t.tblPerformanceReviewSettings)
                .HasForeignKey(d => d.JobRoleID);

        }
    }
}
