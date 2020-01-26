using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpEmploymentTypeMap : EntityTypeConfiguration<lkpEmploymentType>
    {
        public lkpEmploymentTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.EmploymentTypeID);

            // Properties
            this.Property(t => t.EmploymentTypeDesc)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lkpEmploymentType");
            this.Property(t => t.EmploymentTypeID).HasColumnName("EmploymentTypeID");
            this.Property(t => t.EmploymentTypeDesc).HasColumnName("EmploymentTypeDesc");
        }
    }
}
