using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblAdminDetailMap : EntityTypeConfiguration<tblAdminDetail>
    {
        public tblAdminDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.AdminID);

            // Properties
            this.Property(t => t.EmailID)
                .HasMaxLength(100);

            this.Property(t => t.PasswordSalt)
                .HasMaxLength(100);

            this.Property(t => t.PasswordHash)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblAdminDetails");
            this.Property(t => t.AdminID).HasColumnName("AdminID");
            this.Property(t => t.EmailID).HasColumnName("EmailID");
            this.Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
        }
    }
}
