using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblEmployeeJobDetailMap : EntityTypeConfiguration<tblEmployeeJobDetail>
    {
        public tblEmployeeJobDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.JobID);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblEmployeeJobDetails");
            this.Property(t => t.JobID).HasColumnName("JobID");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.DeptID).HasColumnName("DeptID");
            this.Property(t => t.JobRoleID).HasColumnName("JobRoleID");
            this.Property(t => t.RepMgrID).HasColumnName("RepMgrID");
            this.Property(t => t.LocationID).HasColumnName("LocationID");
            this.Property(t => t.EmpStartDate).HasColumnName("EmpStartDate");
            this.Property(t => t.JobTypeID).HasColumnName("JobTypeID");
            this.Property(t => t.ContractedHours).HasColumnName("ContractedHours");

            // Relationships
            this.HasOptional(t => t.lkpDepartment)
                .WithMany(t => t.tblEmployeeJobDetails)
                .HasForeignKey(d => d.DeptID);
            this.HasOptional(t => t.lkpJobType)
                .WithMany(t => t.tblEmployeeJobDetails)
                .HasForeignKey(d => d.JobTypeID);
            this.HasOptional(t => t.lkpLocation)
                .WithMany(t => t.tblEmployeeJobDetails)
                .HasForeignKey(d => d.LocationID);
            this.HasOptional(t => t.tblEmployeeDetail)
                .WithMany(t => t.tblEmployeeJobDetails)
                .HasForeignKey(d => d.EmpID);

        }
    }
}
