using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpCountryMap : EntityTypeConfiguration<lkpCountry>
    {
        public lkpCountryMap()
        {
            // Primary Key
            this.HasKey(t => t.CountryID);

            // Properties
            this.Property(t => t.CountryCode2)
                .HasMaxLength(5);

            this.Property(t => t.CountryName)
                .HasMaxLength(100);

            this.Property(t => t.CountryCode3)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("lkpCountry");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.CountryCode2).HasColumnName("CountryCode2");
            this.Property(t => t.CountryName).HasColumnName("CountryName");
            this.Property(t => t.CountryCode3).HasColumnName("CountryCode3");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.PhoneCode).HasColumnName("PhoneCode");
        }
    }
}
