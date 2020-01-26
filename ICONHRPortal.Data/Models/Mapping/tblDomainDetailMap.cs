using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblDomainDetailMap : EntityTypeConfiguration<tblDomainDetail>
    {
        public tblDomainDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.DomainID);

            // Properties
            this.Property(t => t.DomainName)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(100);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblDomainDetails");
            this.Property(t => t.DomainID).HasColumnName("DomainID");
            this.Property(t => t.DomainName).HasColumnName("DomainName");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");

            // Relationships
            this.HasOptional(t => t.tblCompanyDetail)
                .WithMany(t => t.tblDomainDetails)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
