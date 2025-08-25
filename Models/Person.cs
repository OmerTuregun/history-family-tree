namespace SoyAgaci.Api.Models;

public enum Gender { Unknown = 0, Male = 1, Female = 2 }

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public Gender Gender { get; set; }
    public DateOnly? Birth { get; set; }
    public DateOnly? Death { get; set; }
    public string? Notes { get; set; }
    // Görselleştirme için stil alanlarını sonra ekleriz (frameColor, segments vs.)
}
