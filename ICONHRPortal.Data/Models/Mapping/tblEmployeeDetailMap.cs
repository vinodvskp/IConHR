using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblEmployeeDetailMap : EntityTypeConfiguration<tblEmployeeDetail>
    {
        public tblEmployeeDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpID);

            // Properties
            this.Property(t => t.EmpName)
                .HasMaxLength(100);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(50);

            this.Property(t => t.EmailID)
                .HasMaxLength(50);

            this.Property(t => t.PasswordSalt)
                .HasMaxLength(100);

            this.Property(t => t.PasswordHash)
                .HasMaxLength(100);

            this.Property(t => t.PasswordToken)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(100);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(100);

            this.Property(t => t.Gender)
                .HasMaxLength(10);

            this.Property(t => t.Address)
                .HasMaxLength(300);

            this.Property(t => t.PostalCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblEmployeeDetails");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.EmpName).HasColumnName("EmpName");
            this.Property(t => t.EmpRoleID).HasColumnName("EmpRoleID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.EmailID).HasColumnName("EmailID");
            this.Property(t => t.CompanyUrl).HasColumnName("CompanyUrl");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            this.Property(t => t.PasswordToken).HasColumnName("PasswordToken");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.ProfilePhoto).HasColumnName("ProfilePhoto");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");

            // Relationships
            this.HasOptional(t => t.lkpCountry)
                .WithMany(t => t.tblEmployeeDetails)
                .HasForeignKey(d => d.CountryID);
            this.HasOptional(t => t.lkpEmployeeRole)
                .WithMany(t => t.tblEmployeeDetails)
                .HasForeignKey(d => d.EmpRoleID);
            this.HasOptional(t => t.tblCompanyDetail)
                .WithMany(t => t.tblEmployeeDetails)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
