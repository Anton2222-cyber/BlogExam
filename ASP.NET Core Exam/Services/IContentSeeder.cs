
using Data.Entities;

namespace ASP.NET_Core_Exam.Services;

public interface IContentSeeder {
	Task<List<Category>> SeedCategoriesAsync(int quantity);
	Task<List<Tag>> SeedTagsAsync(int quantity);
	Task<List<Post>> SeedPostsAsync(int quantity, long categoryId);
	Task<List<PostTag>> SeedPostTagPairsAsync(int quantityPerPost, List<Post> posts, List<Tag> tags);
}