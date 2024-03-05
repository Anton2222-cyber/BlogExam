namespace ASP.NET_Core_Exam.Models.Posts;

public class PostsFilterVm {
	public int Count { get; set; }
	public int PageNumber { get; set; }

	public string? TagUrlSlug { get; set; }
	public string? CategoryUrlSlug { get; set; }
}
