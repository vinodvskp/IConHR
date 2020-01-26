using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblAuthorisationRuleSettingMap : EntityTypeConfiguration<tblAuthorisationRuleSetting>
    {
        public tblAuthorisationRuleSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.AuthorisationRuleSettingsID);

            // Properties
            this.Property(t => t.RuleName)
                .HasMaxLength(100);

            this.Property(t => t.LocationID)
                .HasMaxLength(500);

            this.Property(t => t.LocationName)
                .HasMaxLength(1000);

            this.Property(t => t.DepartmentID)
                .HasMaxLength(500);

            this.Property(t => t.DepartmentName)
                .HasMaxLength(1000);

            this.Property(t => t.JobRoleID)
                .HasMaxLength(500);

            this.Property(t => t.JobRoleName)
                .HasMaxLength(500);

            this.Property(t => t.EmploymentTypeID)
                .HasMaxLength(500);

            this.Property(t => t.EmploymentTypeName)
                .HasMaxLength(1000);

            this.Property(t => t.SpecificEmployeeID)
                .HasMaxLength(1000);

            this.Property(t => t.ExcludeEmployeeID)
                .HasMaxLength(1000);

            this.Property(t => t.ApproverID)
                .HasMaxLength(1000);

            this.Property(t => t.ApproverName)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("tblAuthorisationRuleSettings");
            this.Property(t => t.AuthorisationRuleSettingsID).HasColumnName("AuthorisationRuleSettingsID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.InUse).HasColumnName("InUse");
            this.Property(t => t.RuleName).HasColumnName("RuleName");
            this.Property(t => t.LocationID).HasColumnName("LocationID");
            this.Property(t => t.LocationName).HasColumnName("LocationName");
            this.Property(t => t.DepartmentID).HasColumnName("DepartmentID");
            this.Property(t => t.DepartmentName).HasColumnName("DepartmentName");
            this.Property(t => t.JobRoleID).HasColumnName("JobRoleID");
            this.Property(t => t.JobRoleName).HasColumnName("JobRoleName");
            this.Property(t => t.EmploymentTypeID).HasColumnName("EmploymentTypeID");
            this.Property(t => t.EmploymentTypeName).HasColumnName("EmploymentTypeName");
            this.Property(t => t.SpecificEmployeeID).HasColumnName("SpecificEmployeeID");
            this.Property(t => t.SpecificEmployeeName).HasColumnName("SpecificEmployeeName");
            this.Property(t => t.ExcludeEmployeeID).HasColumnName("ExcludeEmployeeID");
            this.Property(t => t.ExcludeEmployeeName).HasColumnName("ExcludeEmployeeName");
            this.Property(t => t.ApproverID).HasColumnName("ApproverID");
            this.Property(t => t.ApproverName).HasColumnName("ApproverName");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
        }
    }
}
