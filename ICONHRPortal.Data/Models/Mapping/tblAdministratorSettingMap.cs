using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblAdministratorSettingMap : EntityTypeConfiguration<tblAdministratorSetting>
    {
        public tblAdministratorSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.AdministratorSettingID);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblAdministratorSettings");
            this.Property(t => t.AdministratorSettingID).HasColumnName("AdministratorSettingID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.AssignedEmployeeID).HasColumnName("AssignedEmployeeID");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");

            // Relationships
            this.HasOptional(t => t.tblCompanyDetail)
                .WithMany(t => t.tblAdministratorSettings)
                .HasForeignKey(d => d.CompanyID);
            this.HasOptional(t => t.tblEmployeeDetail)
                .WithMany(t => t.tblAdministratorSettings)
                .HasForeignKey(d => d.AssignedEmployeeID);

        }
    }
}
