namespace SoyAgaci.Api.Models;

public enum RelationCertainty { Certain=0, Probable=1, Possible=2 }

public class ParentChild
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public int ChildId { get; set; }
    public string Type { get; set; } = "biological"; // evlatlık vs. için
    public RelationCertainty Certainty { get; set; } = RelationCertainty.Certain;
}
