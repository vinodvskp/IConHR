using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblEmailSettingMap : EntityTypeConfiguration<tblEmailSettings>
    {
        public tblEmailSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.EmailSettingsID);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblEmailSettings");
            this.Property(t => t.EmailSettingsID).HasColumnName("EmailSettingsID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.DailyAdminEmail).HasColumnName("DailyAdminEmail");
            this.Property(t => t.WeeklyManagerEmail).HasColumnName("WeeklyManagerEmail");
            this.Property(t => t.WeeklyEmployeeEmail).HasColumnName("WeeklyEmployeeEmail");
            this.Property(t => t.HolidayEmailReminder).HasColumnName("HolidayEmailReminder");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");

            // Relationships
            this.HasRequired(t => t.tblCompanyDetail)
                .WithMany(t => t.tblEmailSettings)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
