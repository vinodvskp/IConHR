using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class lkpJobTypeMap : EntityTypeConfiguration<lkpJobType>
    {
        public lkpJobTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.JobTypeID);

            // Properties
            this.Property(t => t.JobType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lkpJobType");
            this.Property(t => t.JobTypeID).HasColumnName("JobTypeID");
            this.Property(t => t.JobType).HasColumnName("JobType");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
