namespace SoyAgaci.Api.Models;

public class Marriage
{
    public int Id { get; set; }
    public int Spouse1Id { get; set; }
    public int Spouse2Id { get; set; }
    public DateOnly? Start { get; set; }
    public DateOnly? End { get; set; }
}
