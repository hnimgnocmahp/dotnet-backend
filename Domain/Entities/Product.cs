using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("products")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("supplier_id")]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("product_name")]
        public string ProductName { get; set; } = string.Empty;

        [Column("barcode")]
        [MaxLength(50)]
        public string Barcode { get; set; } = string.Empty;

        [Required]
        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Column("unit")]
        [MaxLength(20)]
        public string Unit { get; set; } = "pcs";

    [Column("created_at")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            // 🔹 Thêm navigation properties
    [ForeignKey("CategoryId")]
    public Category Category { get; set; } = null!;

    [ForeignKey("SupplierId")]
    public Supplier Supplier { get; set; } = null!;
    }