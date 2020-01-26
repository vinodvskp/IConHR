using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpCardExpMonthMap : EntityTypeConfiguration<lkpCardExpMonth>
    {
        public lkpCardExpMonthMap()
        {
            // Primary Key
            this.HasKey(t => t.CardExpMonthID);

            // Properties
            this.Property(t => t.CardExpMonthName)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("lkpCardExpMonth");
            this.Property(t => t.CardExpMonthID).HasColumnName("CardExpMonthID");
            this.Property(t => t.CardExpMonth).HasColumnName("CardExpMonth");
            this.Property(t => t.CardExpMonthName).HasColumnName("CardExpMonthName");
        }
    }
}
