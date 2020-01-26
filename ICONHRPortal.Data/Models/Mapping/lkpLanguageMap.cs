using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpLanguageMap : EntityTypeConfiguration<lkpLanguage>
    {
        public lkpLanguageMap()
        {
            // Primary Key
            this.HasKey(t => t.LanguageID);

            // Properties
            this.Property(t => t.LanguageDesc)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("lkpLanguages");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.LanguageDesc).HasColumnName("LanguageDesc");
        }
    }
}
