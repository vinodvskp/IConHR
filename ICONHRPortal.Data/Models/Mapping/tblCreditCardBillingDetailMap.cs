using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblCreditCardBillingDetailMap : EntityTypeConfiguration<tblCreditCardBillingDetail>
    {
        public tblCreditCardBillingDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.PostalCode)
                .HasMaxLength(50);

            this.Property(t => t.MobileNumber)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("tblCreditCardBillingDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CreditCardID).HasColumnName("CreditCardID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.MobileNumber).HasColumnName("MobileNumber");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Address).HasColumnName("Address");

            // Relationships
            this.HasOptional(t => t.lkpCountry)
                .WithMany(t => t.tblCreditCardBillingDetails)
                .HasForeignKey(d => d.CountryID);

        }
    }
}
