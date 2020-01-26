using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
        public class tblNotificationsMap : EntityTypeConfiguration<tblNotifications>
        { 
        public tblNotificationsMap()
        {

            // Primary Key
            this.HasKey(t => t.NotificationID);
            // Table & Column Mappings
            this.ToTable("tblNotifications");

            this.Property(t => t.ModifiedPropertyName).HasColumnName("ModifiedPropertyName");
            this.Property(t => t.OldPropertyName).HasColumnName("OldPropertyName");
            this.Property(t => t.NewPropertyValue).HasColumnName("NewPropertyValue");
            this.Property(t => t.NotificationShownStatus).HasColumnName("NotificationShownStatus");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");
        }
    }
}
