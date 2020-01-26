using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblMgrPerReviewRatingMap : EntityTypeConfiguration<tblMgrPerReviewRating>
    {
        public tblMgrPerReviewRatingMap()
        {
            // Primary Key
            this.HasKey(t => t.MgrPerReviewRatingID);

            // Properties
            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblMgrPerReviewRating");
            this.Property(t => t.MgrPerReviewRatingID).HasColumnName("MgrPerReviewRatingID");
            this.Property(t => t.MgrReviewSegmentID).HasColumnName("MgrReviewSegmentID");
            this.Property(t => t.PerformanceQuestionID).HasColumnName("PerformanceQuestionID");
            this.Property(t => t.ScoreID).HasColumnName("ScoreID");
            this.Property(t => t.Answer).HasColumnName("Answer");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.tblMgrPerReviewSegment)
                .WithMany(t => t.tblMgrPerReviewRatings)
                .HasForeignKey(d => d.MgrReviewSegmentID);
            this.HasRequired(t => t.tblPerformaceSegmentQuestion)
                .WithMany(t => t.tblMgrPerReviewRatings)
                .HasForeignKey(d => d.PerformanceQuestionID);

        }
    }
}
