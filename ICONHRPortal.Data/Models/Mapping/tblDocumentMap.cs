using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ICONHRPortal.Data.Models.Mapping
{
    public class tblDocumentMap : EntityTypeConfiguration<tblDocument>
    {
        public tblDocumentMap()
        {
            // Primary Key
            this.HasKey(t => t.DocumentID);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(200);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            this.Property(t => t.DocumentName)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.LastUpdatedBy)
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblDocument");
            this.Property(t => t.DocumentID).HasColumnName("DocumentID");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.EmpID).HasColumnName("EmpID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DocumentName).HasColumnName("DocumentName");
            this.Property(t => t.DocumentCategoryTypeID).HasColumnName("DocumentCategoryTypeID");
            this.Property(t => t.DocumentAddedDate).HasColumnName("DocumentAddedDate");
            this.Property(t => t.EmployeeAcess).HasColumnName("EmployeeAcess");
            this.Property(t => t.MangerAcess).HasColumnName("MangerAcess");
            this.Property(t => t.IsCompanyAccessOnly).HasColumnName("IsCompanyAccessOnly");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.LastUpdatedBy).HasColumnName("LastUpdatedBy");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");

            // Relationships
            this.HasOptional(t => t.tblEmployeeDetail)
                .WithMany(t => t.tblDocuments)
                .HasForeignKey(d => d.EmpID);

        }
    }
}
