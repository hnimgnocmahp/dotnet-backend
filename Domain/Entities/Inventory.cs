using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("inventory")]
    public class Inventory
    {
        [Key]
        [Column("inventory_id")]
        public int InventoryId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; } = 0;

        [Column("created_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }