using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpLocationMap : EntityTypeConfiguration<lkpLocation>
    {
        public lkpLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.LocationId);

            // Properties
            this.Property(t => t.Location)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("lkpLocation");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
        }
    }
}
