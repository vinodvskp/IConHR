using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblEmployeePerformanceMap : EntityTypeConfiguration<tblEmployeePerformance>
    {
        public tblEmployeePerformanceMap()
        {
            // Primary Key
            this.HasKey(t => t.EmployeePerformanceID);

            // Properties
            this.Property(t => t.CreatedBy)
                .HasMaxLength(200);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblEmployeePerformance");
            this.Property(t => t.EmployeePerformanceID).HasColumnName("EmployeePerformanceID");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.PerformanceReviewID).HasColumnName("PerformanceReviewID");
            this.Property(t => t.PerformanceSegmentID).HasColumnName("PerformanceSegmentID");
            this.Property(t => t.ScoreID).HasColumnName("ScoreID");
            this.Property(t => t.PerformanceQuestionID).HasColumnName("PerformanceQuestionID");
            this.Property(t => t.Answer).HasColumnName("Answer");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");

            // Relationships
            this.HasRequired(t => t.tblEmployeeDetail)
                .WithMany(t => t.tblEmployeePerformances)
                .HasForeignKey(d => d.EmpID);
            this.HasRequired(t => t.tblPerformanceReviewSetting)
                .WithMany(t => t.tblEmployeePerformances)
                .HasForeignKey(d => d.PerformanceReviewID);
            this.HasRequired(t => t.tblPerformanceScore)
                .WithMany(t => t.tblEmployeePerformances)
                .HasForeignKey(d => d.ScoreID);

        }
    }
}
