using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpCardTypeMap : EntityTypeConfiguration<lkpCardType>
    {
        public lkpCardTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.CardTypeID);

            // Properties
            this.Property(t => t.CardType)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("lkpCardTypes");
            this.Property(t => t.CardTypeID).HasColumnName("CardTypeID");
            this.Property(t => t.CardType).HasColumnName("CardType");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
