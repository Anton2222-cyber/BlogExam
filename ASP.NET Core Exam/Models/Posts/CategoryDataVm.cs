namespace ASP.NET_Core_Exam.Models.Posts;

public class CategoryDataVm {
	public long Id { get; set; }

	public string Name { get; set; } = null!;

	public string UrlSlug { get; set; } = null!;

	public string? Description { get; set; }
}
