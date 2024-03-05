namespace Data.Entities;

public class Post {
	public long Id { get; set; }

	public string Title { get; set; } = null!;

	public string ShortDescription { get; set; } = null!;

	public string Description { get; set; } = null!;

	public string Meta { get; set; } = null!;

	public string UrlSlug { get; set; } = null!;

	public bool Published { get; set; }

	public DateTime PostedOn { get; set; }

	public DateTime? Modified { get; set; } = null!;

	public long CategoryId { get; set; }
	public Category Category { get; set; } = null!;

	public ICollection<PostTag> Tags { get; set; } = null!;
}