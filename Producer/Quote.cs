using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Producer;

[Table("quote", Schema = "cw")]
public class Quote
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("product_id")]
    public string? ProductId { get; set; }

    [Column("price")]
    public int? Price { get; set; }
}
