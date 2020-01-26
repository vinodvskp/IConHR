using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblCompanySettingMap : EntityTypeConfiguration<tblCompanySetting>
    {
        public tblCompanySettingMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanySettingID);

            // Properties
            this.Property(t => t.CompanyStatement)
                .HasMaxLength(1000);

            this.Property(t => t.Industry)
                .HasMaxLength(200);

            this.Property(t => t.DateFormat)
                .HasMaxLength(50);

            this.Property(t => t.MonthOrWeek)
                .HasMaxLength(50);

            this.Property(t => t.BaseCurrency)
                .HasMaxLength(50);

            this.Property(t => t.NI_SSNValidation)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("tblCompanySetting");
            this.Property(t => t.CompanySettingID).HasColumnName("CompanySettingID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.JobRoleID).HasColumnName("JobRoleID");
            this.Property(t => t.UploadLogo).HasColumnName("UploadLogo");
            this.Property(t => t.ApplyThemeColour).HasColumnName("ApplyThemeColour");
            this.Property(t => t.CompanyStatement).HasColumnName("CompanyStatement");
            this.Property(t => t.Industry).HasColumnName("Industry");
            this.Property(t => t.DateFormat).HasColumnName("DateFormat");
            this.Property(t => t.MonthOrWeek).HasColumnName("MonthOrWeek");
            this.Property(t => t.BaseCurrency).HasColumnName("BaseCurrency");
            this.Property(t => t.NI_SSNValidation).HasColumnName("NI/SSNValidation");
            this.Property(t => t.Resetpassword).HasColumnName("Resetpassword");
            this.Property(t => t.ProbationPeriod).HasColumnName("ProbationPeriod");
            this.Property(t => t.PasswordExpiryDuration).HasColumnName("PasswordExpiryDuration");
            this.Property(t => t.SessionTimeOutPeriod).HasColumnName("SessionTimeOutPeriod");
            this.Property(t => t.EmployeeAccessID).HasColumnName("EmployeeAccessID");
            this.Property(t => t.ManagerAccessID).HasColumnName("ManagerAccessID");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");

            // Relationships
            this.HasOptional(t => t.tblCompanyDetail)
                .WithMany(t => t.tblCompanySettings)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
