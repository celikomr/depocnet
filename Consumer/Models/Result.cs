namespace Consumer.Models;

public class Result<T>
{
    public Payload<T>? Payload { get; set; }
}
