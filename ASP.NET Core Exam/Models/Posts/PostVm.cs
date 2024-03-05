using ASP.NET_Core_Exam.Models.Tags;

namespace ASP.NET_Core_Exam.Models.Posts;

public class PostVm {
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
	public CategoryDataVm Category { get; set; } = null!;

	public ICollection<TagVm> Tags { get; set; } = null!;
}
