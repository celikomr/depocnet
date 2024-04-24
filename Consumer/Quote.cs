using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Consumer;

[Table("quote", Schema = "cw")]
public class Quote
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("product_id")]
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [Column("price")]
    public int? Price { get; set; }
}
