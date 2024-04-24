using System.Text.Json.Serialization;

namespace Consumer.Models;

public class Source
{
    public string? Version { get; set; }
    public string? Connector { get; set; }
    public string? Name { get; set; }
    public string? Snapshot { get; set; }
    public string? Db { get; set; }
    // public List<string?>? Sequence { get; set; }
    public string? Schema { get; set; }
    public string? Table { get; set; }
    public long? TxId { get; set; }
    public long? Lsn { get; set; }
    public string? XMin { get; set; }

    [JsonPropertyName("ts_ms")]
    public long? TsMs { get; set; }
}
