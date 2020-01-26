using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblJobRoleMap : EntityTypeConfiguration<tblJobRole>
    {
        public tblJobRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.JobRoleID);

            // Properties
            this.Property(t => t.JobRole)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblJobRoles");
            this.Property(t => t.JobRoleID).HasColumnName("JobRoleID");
            this.Property(t => t.JobRole).HasColumnName("JobRole");
            this.Property(t => t.DeptID).HasColumnName("DeptID");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasOptional(t => t.lkpDepartment)
                .WithMany(t => t.tblJobRoles)
                .HasForeignKey(d => d.DeptID);

        }
    }
}
