using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("users")]
public class User
{
    [Key]
    [Column("user_id")]
    public int Id { get; set; }

    [Column("username")]
    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Column("password")]
    [Required]
    public string Password { get; set; } = string.Empty;

    [Column("full_name")]
    [MaxLength(100)]
    public string? FullName { get; set; }

    [Column("role")]
    public string Role { get; set; } = "staff";

    [Column("created_at")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
