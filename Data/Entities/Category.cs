namespace Data.Entities;

public class Category {
	public long Id { get; set; }

	public string Name { get; set; } = null!;

	public string UrlSlug { get; set; } = null!;

	public string? Description { get; set; }

	public ICollection<Post> Posts { get; set; } = null!;
}