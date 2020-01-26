using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblPlannerMap : EntityTypeConfiguration<tblPlanner>
    {
        public tblPlannerMap()
        {
            // Primary Key
            this.HasKey(t => t.PlannerID);

            // Properties
            this.Property(t => t.PlannedEventName)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.LastUpdatedBy)
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblPlanner");
            this.Property(t => t.PlannerID).HasColumnName("PlannerID");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.PlannedEventName).HasColumnName("PlannedEventName");
            this.Property(t => t.PlannerCategoryID).HasColumnName("PlannerCategoryID");
            this.Property(t => t.PlannedDate).HasColumnName("PlannedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasOptional(t => t.lkpDepartment)
                .WithMany(t => t.tblPlanners)
                .HasForeignKey(d => d.DepartmentId);
            this.HasOptional(t => t.lkpLocation)
                .WithMany(t => t.tblPlanners)
                .HasForeignKey(d => d.LocationId);
            this.HasOptional(t => t.lkpPlannerCategoryType)
                .WithMany(t => t.tblPlanners)
                .HasForeignKey(d => d.PlannerCategoryID);

        }
    }
}
