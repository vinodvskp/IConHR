using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpDepartmentMap : EntityTypeConfiguration<lkpDepartment>
    {
        public lkpDepartmentMap()
        {
            // Primary Key
            this.HasKey(t => t.DeptID);

            // Properties
            this.Property(t => t.DeptName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lkpDepartments");
            this.Property(t => t.DeptID).HasColumnName("DeptID");
            this.Property(t => t.DeptName).HasColumnName("DeptName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
