namespace ASP.NET_Core_Exam.Models.Posts;

public class FilteredPosts {
	public ICollection<PostVm> Posts { get; set; } = null!;
	public int PagesCount { get; set; }
}
