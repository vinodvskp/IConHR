using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpEmployeeRoleMap : EntityTypeConfiguration<lkpEmployeeRole>
    {
        public lkpEmployeeRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpRoleID);

            // Properties
            this.Property(t => t.EmpRole)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("lkpEmployeeRoles");
            this.Property(t => t.EmpRoleID).HasColumnName("EmpRoleID");
            this.Property(t => t.EmpRole).HasColumnName("EmpRole");
        }
    }
}
