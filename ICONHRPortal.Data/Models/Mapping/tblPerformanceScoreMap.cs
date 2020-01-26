using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblPerformanceScoreMap : EntityTypeConfiguration<tblPerformanceScore>
    {
        public tblPerformanceScoreMap()
        {
            // Primary Key
            this.HasKey(t => t.ScoreID);

            // Properties
            this.Property(t => t.RatingDescription)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("tblPerformanceScore");
            this.Property(t => t.ScoreID).HasColumnName("ScoreID");
            this.Property(t => t.PerformanceReviewID).HasColumnName("PerformanceReviewID");
            this.Property(t => t.RatingValue).HasColumnName("RatingValue");
            this.Property(t => t.RatingDescription).HasColumnName("RatingDescription");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.tblPerformanceReviewSetting)
                .WithMany(t => t.tblPerformanceScores)
                .HasForeignKey(d => d.PerformanceReviewID);

        }
    }
}
