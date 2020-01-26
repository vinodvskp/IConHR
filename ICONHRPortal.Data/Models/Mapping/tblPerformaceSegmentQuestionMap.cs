using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblPerformaceSegmentQuestionMap : EntityTypeConfiguration<tblPerformaceSegmentQuestion>
    {
        public tblPerformaceSegmentQuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.PerformanceQuestionID);

            // Properties
            this.Property(t => t.Question)
                .HasMaxLength(500);

            this.Property(t => t.HelpText)
                .HasMaxLength(500);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(200);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblPerformaceSegmentQuestions");
            this.Property(t => t.PerformanceQuestionID).HasColumnName("PerformanceQuestionID");
            this.Property(t => t.PerformanceSegmentID).HasColumnName("PerformanceSegmentID");
            this.Property(t => t.Question).HasColumnName("Question");
            this.Property(t => t.HelpText).HasColumnName("HelpText");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");

            // Relationships
            this.HasOptional(t => t.tblPerformanceSegment)
                .WithMany(t => t.tblPerformaceSegmentQuestions)
                .HasForeignKey(d => d.PerformanceSegmentID);

        }
    }
}
