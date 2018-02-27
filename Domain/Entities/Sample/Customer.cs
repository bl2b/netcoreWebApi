using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XYC.Domain.Entities.Sample
{
    public partial class Customer
    {
        public string Id { get; set; }

        [Required]
        [DisplayName("Company Name")]
        [MaxLength(80)]
        public string CompanyName { get; set; }
    
        [DisplayName("Contact Name")]
        [MaxLength(60)]
        public string ContactName { get; set; }
    
        [DisplayName("Contact Title")]
        [MaxLength(60)]
        public string ContactTitle { get; set; }

        [DisplayName("Address")]
        [MaxLength(120)]
        public string Address { get; set; }
        
        [DisplayName("City")]
        [MaxLength(30)]
        public string City { get; set; }
        
        [DisplayName("Region")]
        [MaxLength(30)]
        public string Region { get; set; }
        
        [DisplayName("Postal Code")]
        [MaxLength(20)]
        public string PostalCode { get; set; }
        
        [DisplayName("Country")]
        [MaxLength(30)]
        public string Country { get; set; }

        [DisplayName("Phone")]
        [MaxLength(48)]
        public string Phone { get; set; }

        [DisplayName("Fax")]
        [MaxLength(48)]
        public string Fax { get; set; }
    }

    internal partial class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "dbo");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("CustomerID").IsUnicode(false).HasMaxLength(10);
            builder.Property(t => t.CompanyName).HasColumnName("CompanyName").IsUnicode(false).HasMaxLength(80);
            builder.Property(t => t.ContactName).HasColumnName("ContactName").IsUnicode(false).HasMaxLength(60);
            builder.Property(t => t.ContactTitle).HasColumnName("ContactTitle").IsUnicode(false).HasMaxLength(60);
            builder.Property(t => t.Address).HasColumnName("Address").IsUnicode(false).HasMaxLength(120);
            builder.Property(t => t.City).HasColumnName("City").IsUnicode(false).HasMaxLength(30);
            builder.Property(t => t.Region).HasColumnName("Region").IsUnicode(false).HasMaxLength(30);
            builder.Property(t => t.PostalCode).HasColumnName("PostalCode").IsUnicode(false).HasMaxLength(20);
            builder.Property(t => t.Country).HasColumnName("Country").IsUnicode(false).HasMaxLength(30);
            builder.Property(t => t.Phone).HasColumnName("Phone").IsUnicode(false).HasMaxLength(48);
            builder.Property(t => t.Fax).HasColumnName("Fax").IsUnicode(false).HasMaxLength(48);
        }
    }

}

