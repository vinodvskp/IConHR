using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblCreditCardDetailMap : EntityTypeConfiguration<tblCreditCardDetail>
    {
        public tblCreditCardDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.CreditCardID);

            // Properties
            this.Property(t => t.CardHolder)
                .HasMaxLength(100);

            this.Property(t => t.CardNumber)
                .HasMaxLength(30);

            this.Property(t => t.GatewayTokenID)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(100);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblCreditCardDetails");
            this.Property(t => t.CreditCardID).HasColumnName("CreditCardID");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.CardHolder).HasColumnName("CardHolder");
            this.Property(t => t.CardTypeID).HasColumnName("CardTypeID");
            this.Property(t => t.CardNumber).HasColumnName("CardNumber");
            this.Property(t => t.CardExpMonthID).HasColumnName("CardExpMonthID");
            this.Property(t => t.CardExpYearID).HasColumnName("CardExpYearID");
            this.Property(t => t.GatewayTokenID).HasColumnName("GatewayTokenID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");

            // Relationships
            this.HasOptional(t => t.lkpCardExpMonth)
                .WithMany(t => t.tblCreditCardDetails)
                .HasForeignKey(d => d.CardExpMonthID);
            this.HasOptional(t => t.lkpCardExpYear)
                .WithMany(t => t.tblCreditCardDetails)
                .HasForeignKey(d => d.CardExpYearID);
            this.HasOptional(t => t.lkpCardType)
                .WithMany(t => t.tblCreditCardDetails)
                .HasForeignKey(d => d.CardTypeID);
            this.HasOptional(t => t.tblEmployeeDetail)
                .WithMany(t => t.tblCreditCardDetails)
                .HasForeignKey(d => d.EmpID);

        }
    }
}
