namespace Data.Entities;

public class Tag {
	public long Id { get; set; }

	public string Name { get; set; } = null!;

	public string UrlSlug { get; set; } = null!;

	public string? Description { get; set; }

	public ICollection<PostTag> Posts { get; set; } = null!;
}