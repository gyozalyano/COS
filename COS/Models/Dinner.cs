namespace COS.Models;

public class Dinner
{
    public int DinnerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? AllergyInformation { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageThumbnailUrl { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}