using Bogus;
using Data.Context;
using Data.Entities;

namespace ASP.NET_Core_Exam.Services;

public class ContentSeeder(
	DataContext context
	) : IContentSeeder {

	private static readonly Faker<Category> categoryGenerator;
	private static readonly Faker<Tag> tagGenerator;
	private static readonly Faker<Post> postGenerator;

	static ContentSeeder() {
		categoryGenerator = new Faker<Category>()
			.RuleFor(c => c.Name, f => f.Commerce.Categories(1).First())
			.RuleFor(c => c.UrlSlug, f => Guid.NewGuid().ToString())
			.RuleFor(c => c.Description, f => f.Lorem.Lines(lineCount: 1));

		tagGenerator = new Faker<Tag>()
			.RuleFor(t => t.Name, f => f.Random.Word())
			.RuleFor(t => t.UrlSlug, f => Guid.NewGuid().ToString())
			.RuleFor(t => t.Description, f => f.Lorem.Lines(lineCount: 1));

		postGenerator = new Faker<Post>()
			.RuleFor(p => p.Title, f => f.Random.Words(5))
			.RuleFor(p => p.ShortDescription, f => f.Lorem.Lines(lineCount: 1))
			.RuleFor(p => p.Description, f => f.Lorem.Lines(lineCount: 3))
			.RuleFor(p => p.Meta, f => f.Lorem.Lines(lineCount: 2))
			.RuleFor(p => p.UrlSlug, f => Guid.NewGuid().ToString())
			.RuleFor(p => p.Published, f => f.Random.Bool())
			.RuleFor(p => p.PostedOn, f => DateTime.SpecifyKind(f.Date.Between(new DateTime(2010, 1, 1), DateTime.Now), DateTimeKind.Utc));
	}

	public async Task<List<Category>> SeedCategoriesAsync(int quantity) {
		var generatedCategories = Enumerable.Range(0, quantity)
			.Select(i => categoryGenerator.Generate())
			.ToList();

		await context.Categories.AddRangeAsync(generatedCategories);
		await context.SaveChangesAsync();

		return generatedCategories;
	}

	public async Task<List<Tag>> SeedTagsAsync(int quantity) {
		var generatedTags = Enumerable.Range(0, quantity)
			.Select(i => tagGenerator.Generate())
			.ToList();

		await context.Tags.AddRangeAsync(generatedTags);
		await context.SaveChangesAsync();

		return generatedTags;
	}

	public async Task<List<Post>> SeedPostsAsync(int quantity, long categoryId) {
		var generatedPosts = Enumerable.Range(0, quantity)
			.Select(i => {
				var post = postGenerator.Generate();
				post.CategoryId = categoryId;
				return post;
			})
			.ToList();

		await context.Posts.AddRangeAsync(generatedPosts);
		await context.SaveChangesAsync();

		return generatedPosts;
	}

	public async Task<List<PostTag>> SeedPostTagPairsAsync(int quantityPerPost, List<Post> posts, List<Tag> tags) {
		var postIds = posts.Select(p => p.Id).ToList();
		var tagIds = tags.Select(t => t.Id).ToList();

		List<PostTag> generatedPostTagPairs = [];

		foreach (var postId in postIds) {
			var postTagPairsGenegator = new Faker<PostTag>()
				.RuleFor(pt => pt.PostId, f => postId)
				.RuleFor(pt => pt.TagId, f => f.PickRandom(tagIds));

			var postTagPairs = Enumerable.Range(0, quantityPerPost)
				.Select(i => postTagPairsGenegator.Generate())
				.ToList();

			generatedPostTagPairs.AddRange(postTagPairs);
		}

		generatedPostTagPairs = generatedPostTagPairs.DistinctBy(pt => new { pt.PostId, pt.TagId }).ToList();

		await context.PostTags.AddRangeAsync(generatedPostTagPairs);
		await context.SaveChangesAsync();

		return generatedPostTagPairs;
	}
}
