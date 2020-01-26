using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class WorkPatternMap : EntityTypeConfiguration<WorkPattern>
    {
        public WorkPatternMap()
        {
            // Primary Key
            this.HasKey(t => t.WorkPatternId);

            // Properties
            this.Property(t => t.WorkPatternName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CreatedDate)
                .HasMaxLength(50);

            this.Property(t => t.UpdatedDate)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("WorkPattern");
            this.Property(t => t.WorkPatternId).HasColumnName("WorkPatternId");
            this.Property(t => t.WorkPatternName).HasColumnName("WorkPatternName");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        }
    }
}
