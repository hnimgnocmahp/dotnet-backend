using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("orders")]
public class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("promo_id")]
    public int? PromoId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("order_date")]
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Column("status")]
    [MaxLength(10)]
    public string Status { get; set; } = "pending";

    [Column("total_amount", TypeName = "decimal(10,2)")]
    public decimal TotalAmount { get; set; }

    [Column("discount_amount", TypeName = "decimal(10,2)")]
    public decimal DiscountAmount { get; set; } = 0;
}