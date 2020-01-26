using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpDocumentCategoryTypeMap : EntityTypeConfiguration<lkpDocumentCategoryType>
    {
        public lkpDocumentCategoryTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.DocumentCategoryTypeID);

            // Properties
            this.Property(t => t.DocumentCategoryName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lkpDocumentCategoryType");
            this.Property(t => t.DocumentCategoryTypeID).HasColumnName("DocumentCategoryTypeID");
            this.Property(t => t.DocumentCategoryName).HasColumnName("DocumentCategoryName");
        }
    }
}
