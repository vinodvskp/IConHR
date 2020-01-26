using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class EmployeeTimesheetMap : EntityTypeConfiguration<EmployeeTimesheet>
    {
        public EmployeeTimesheetMap()
        {
            // Primary Key
            this.HasKey(t => t.TimesheetID);

            // Properties
            this.Property(t => t.EmpName)
                .HasMaxLength(50);

            this.Property(t => t.Project)
                .HasMaxLength(100);

            this.Property(t => t.Task)
                .HasMaxLength(100);

            this.Property(t => t.Details)
                .HasMaxLength(500);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(100);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("EmployeeTimesheets");
            this.Property(t => t.TimesheetID).HasColumnName("TimesheetID");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.EmpName).HasColumnName("EmpName");
            this.Property(t => t.Project).HasColumnName("Project");
            this.Property(t => t.Task).HasColumnName("Task");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.TotalHours).HasColumnName("TotalHours");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Approver).HasColumnName("Approver");
            this.Property(t => t.isApproved).HasColumnName("isApproved");
            this.Property(t => t.IsSubmited).HasColumnName("IsSubmited");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");
        }
    }
}
