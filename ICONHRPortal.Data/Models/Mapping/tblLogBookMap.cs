using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblLogBookMap : EntityTypeConfiguration<tblLogBook>
    {
        public tblLogBookMap()
        {
            // Primary Key
            this.HasKey(t => t.LogBookID);

            // Properties
            this.Property(t => t.DrivingLicenceNumber)
                .HasMaxLength(40);

            this.Property(t => t.Issue)
                .HasMaxLength(100);

            this.Property(t => t.TrainingDescription)
                .HasMaxLength(200);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(100);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblLogBook");
  
            this.Property(t => t.LogBookID).HasColumnName("LogBookID");
            this.Property(t => t.LogDate).HasColumnName("LogDate");
            this.Property(t => t.EmpId).HasColumnName("EmpId");
            this.Property(t => t.DocumentType).HasColumnName("DocumentType");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.ApprisalReviewDate).HasColumnName("ApprisalReviewDate");
            this.Property(t => t.ApprisalReviewerID).HasColumnName("ApprisalReviewerID");
            this.Property(t => t.ApprisalReviewerName).HasColumnName("ApprisalReviewerName");
            this.Property(t => t.ApprisalNotes).HasColumnName("ApprisalNotes");
            this.Property(t => t.DrivingLicenceNumber).HasColumnName("DrivingLicenceNumber");
            this.Property(t => t.LicenceType).HasColumnName("LicenceType");
            this.Property(t => t.LicenceExpiryDate).HasColumnName("LicenceExpiryDate");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.Issue).HasColumnName("Issue");
            this.Property(t => t.IssueStatus).HasColumnName("IssueStatus");
            this.Property(t => t.IssueCreatedDate).HasColumnName("IssueCreatedDate");
            this.Property(t => t.IssueClosedDate).HasColumnName("IssueClosedDate");
            this.Property(t => t.IssueNotes).HasColumnName("IssueNotes");
            this.Property(t => t.TrainingType).HasColumnName("TrainingType");
            this.Property(t => t.TrainingDescription).HasColumnName("TrainingDescription");
            this.Property(t => t.PriorityType).HasColumnName("PriorityType");
            this.Property(t => t.TrainingStatus).HasColumnName("TrainingStatus");
            this.Property(t => t.TrainingStartDate).HasColumnName("TrainingStartDate");
            this.Property(t => t.TrainingEndDate).HasColumnName("TrainingEndDate");
            this.Property(t => t.TrainingNotes).HasColumnName("TrainingNotes");

            this.Property(t => t.DocName).HasColumnName("DocName");
            this.Property(t => t.DocType).HasColumnName("DocType");
            this.Property(t => t.DocFile).HasColumnName("DocFile");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");
        }
    }
}
