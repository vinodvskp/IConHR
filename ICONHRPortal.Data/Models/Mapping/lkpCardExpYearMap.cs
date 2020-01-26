using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpCardExpYearMap : EntityTypeConfiguration<lkpCardExpYear>
    {
        public lkpCardExpYearMap()
        {
            // Primary Key
            this.HasKey(t => t.CardExpYearID);

            // Properties
            // Table & Column Mappings
            this.ToTable("lkpCardExpYear");
            this.Property(t => t.CardExpYearID).HasColumnName("CardExpYearID");
            this.Property(t => t.CardExpYear).HasColumnName("CardExpYear");
        }
    }
}
