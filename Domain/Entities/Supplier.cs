using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("suppliers")]
    public class Supplier
    {
        [Key]
        [Column("supplier_id")]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("phone")]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Column("email")]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Column("address")]
        public string Address { get; set; } = string.Empty;
    }