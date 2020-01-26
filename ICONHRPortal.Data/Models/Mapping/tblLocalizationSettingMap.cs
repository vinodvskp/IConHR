using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblLocalizationSettingMap : EntityTypeConfiguration<tblLocalizationSetting>
    {
        public tblLocalizationSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.LocalizationSettingID);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblLocalizationSettings");
            this.Property(t => t.LocalizationSettingID).HasColumnName("LocalizationSettingID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.CompanyDefaultLanguageID).HasColumnName("CompanyDefaultLanguageID");
            this.Property(t => t.LocationID).HasColumnName("LocationID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");

            // Relationships
            this.HasOptional(t => t.lkpLanguage)
                .WithMany(t => t.tblLocalizationSettings)
                .HasForeignKey(d => d.LanguageID);
            this.HasOptional(t => t.lkpLocation)
                .WithMany(t => t.tblLocalizationSettings)
                .HasForeignKey(d => d.LocationID);
            this.HasOptional(t => t.tblCompanyDetail)
                .WithMany(t => t.tblLocalizationSettings)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
