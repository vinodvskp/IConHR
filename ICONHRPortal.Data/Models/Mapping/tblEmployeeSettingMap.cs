using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblEmployeeSettingMap : EntityTypeConfiguration<tblEmployeeSetting>
    {
        public tblEmployeeSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.EmployeeSettingsID);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblEmployeeSettings");
            this.Property(t => t.EmployeeSettingsID).HasColumnName("EmployeeSettingsID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.ManagerCanSeeEmployeeSalary).HasColumnName("ManagerCanSeeEmployeeSalary");
            this.Property(t => t.EmployeeCanSeeTheirOwnSalary).HasColumnName("EmployeeCanSeeTheirOwnSalary");
            this.Property(t => t.AllowEmployeeToUploadPhoto).HasColumnName("AllowEmployeeToUploadPhoto");
            this.Property(t => t.ManagerCanSeeEmployeeContactDetail).HasColumnName("ManagerCanSeeEmployeeContactDetail");
            this.Property(t => t.ManagerCanUploadDocument).HasColumnName("ManagerCanUploadDocument");
            this.Property(t => t.TopFactsAboutOurCompanyReport).HasColumnName("TopFactsAboutOurCompanyReport");
            this.Property(t => t.ManagerCanSeeEmployeeDOB).HasColumnName("ManagerCanSeeEmployeeDOB");
            this.Property(t => t.Appraisal).HasColumnName("Appraisal");
            this.Property(t => t.Benefits).HasColumnName("Benefits");
            this.Property(t => t.CPD).HasColumnName("CPD");
            this.Property(t => t.DrivingLicence).HasColumnName("DrivingLicence");
            this.Property(t => t.Qualification).HasColumnName("Qualification");
            this.Property(t => t.Training).HasColumnName("Training");
            this.Property(t => t.Vehicle).HasColumnName("Vehicle");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");

            // Relationships
            this.HasOptional(t => t.tblCompanyDetail)
                .WithMany(t => t.tblEmployeeSettings)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
