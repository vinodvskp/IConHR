using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblCompanyDetailMap : EntityTypeConfiguration<tblCompanyDetail>
    {
        public tblCompanyDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyID);

            // Properties
            this.Property(t => t.CompanyName)
                .HasMaxLength(100);

            this.Property(t => t.CompanySize)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("tblCompanyDetails");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.CompanySize).HasColumnName("CompanySize");
        }
    }
}
