using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblHolidays_AbsenceSettingsMap : EntityTypeConfiguration<tblHolidays_AbsenceSettings>
    {
        public tblHolidays_AbsenceSettingsMap()
        {
            // Primary Key
            this.HasKey(t => t.Holidays_AbsenceSettingID);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblHolidays_AbsenceSettings");
            this.Property(t => t.Holidays_AbsenceSettingID).HasColumnName("Holidays_AbsenceSettingID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.LocationID).HasColumnName("LocationID");
            this.Property(t => t.NormalWorkingHours).HasColumnName("NormalWorkingHours");
            this.Property(t => t.DefaultWorkPatternID).HasColumnName("DefaultWorkPatternID");
            this.Property(t => t.FullTimeHours).HasColumnName("FullTimeHours");
            this.Property(t => t.MaximumDurationofConsecutiveAnnualLeave).HasColumnName("MaximumDurationofConsecutiveAnnualLeave");
            this.Property(t => t.MaxHolidayCarryOverDays).HasColumnName("MaxHolidayCarryOverDays");
            this.Property(t => t.MaxHolidayCarryOverHours).HasColumnName("MaxHolidayCarryOverHours");
            this.Property(t => t.HolidayYearID).HasColumnName("HolidayYearID");
            this.Property(t => t.DefaultPublicHolidayTemplateID).HasColumnName("DefaultPublicHolidayTemplateID");
            this.Property(t => t.TotalHolidayEntitlementIncludePUblicHolidays).HasColumnName("TotalHolidayEntitlementIncludePUblicHolidays");
            this.Property(t => t.HolidayReturnToWorkForm).HasColumnName("HolidayReturnToWorkForm");
            this.Property(t => t.AuthoriseHolidaysFromEmail).HasColumnName("AuthoriseHolidaysFromEmail");
            this.Property(t => t.LOSRuleID).HasColumnName("LOSRuleID");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");

            // Relationships
            this.HasOptional(t => t.lkpLocation)
                .WithMany(t => t.tblHolidays_AbsenceSettings)
                .HasForeignKey(d => d.LocationID);
            this.HasOptional(t => t.tblCompanyDetail)
                .WithMany(t => t.tblHolidays_AbsenceSettings)
                .HasForeignKey(d => d.CompanyID);
            this.HasOptional(t => t.WorkPattern)
                .WithMany(t => t.tblHolidays_AbsenceSettings)
                .HasForeignKey(d => d.DefaultWorkPatternID);

        }
    }
}
