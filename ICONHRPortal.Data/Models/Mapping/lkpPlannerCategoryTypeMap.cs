using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpPlannerCategoryTypeMap : EntityTypeConfiguration<lkpPlannerCategoryType>
    {
        public lkpPlannerCategoryTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.PlannerCategoryID);

            // Properties
            this.Property(t => t.PlannerCategoryName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lkpPlannerCategoryType");
            this.Property(t => t.PlannerCategoryID).HasColumnName("PlannerCategoryID");
            this.Property(t => t.PlannerCategoryName).HasColumnName("PlannerCategoryName");
        }
    }
}
