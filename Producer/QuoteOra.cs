using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Producer;

[Table("QUOTE", Schema = "MAE_CORE")]
public class QuoteOra
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PRODUCT_ID")]
    public string? ProductId { get; set; }

    [Column("PRICE")]
    public int? Price { get; set; }
}
