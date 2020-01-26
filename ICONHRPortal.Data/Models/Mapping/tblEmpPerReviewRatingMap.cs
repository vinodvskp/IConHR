using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblEmpPerReviewRatingMap : EntityTypeConfiguration<tblEmpPerReviewRating>
    {
        public tblEmpPerReviewRatingMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpPerReviewRatingID);

            // Properties
            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblEmpPerReviewRating");
            this.Property(t => t.EmpPerReviewRatingID).HasColumnName("EmpPerReviewRatingID");
            this.Property(t => t.EmpReviewSegmentID).HasColumnName("EmpReviewSegmentID");
            this.Property(t => t.QuestionID).HasColumnName("QuestionID");
            this.Property(t => t.ScoreID).HasColumnName("ScoreID");
            this.Property(t => t.Answer).HasColumnName("Answer");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.tblEmpPerReviewSegment)
                .WithMany(t => t.tblEmpPerReviewRatings)
                .HasForeignKey(d => d.EmpReviewSegmentID);
            this.HasRequired(t => t.tblPerformaceSegmentQuestion)
                .WithMany(t => t.tblEmpPerReviewRatings)
                .HasForeignKey(d => d.QuestionID);

        }
    }
}
