namespace Consumer.Models;

public class Payload<T>
{
    public T? Before { get; set; }
    public T? After { get; set; }
    public Source? Source { get; set; }
}
