using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblReportingManagerMap : EntityTypeConfiguration<tblReportingManager>
    {
        public tblReportingManagerMap()
        {
            // Primary Key
            this.HasKey(t => t.RepMgrID);

            // Properties
            this.Property(t => t.ReportingManager)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblReportingManager");
            this.Property(t => t.RepMgrID).HasColumnName("RepMgrID");
            this.Property(t => t.ReportingManager).HasColumnName("ReportingManager");
            this.Property(t => t.JobRoleID).HasColumnName("JobRoleID");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasOptional(t => t.tblJobRole)
                .WithMany(t => t.tblReportingManagers)
                .HasForeignKey(d => d.JobRoleID);

        }
    }
}
