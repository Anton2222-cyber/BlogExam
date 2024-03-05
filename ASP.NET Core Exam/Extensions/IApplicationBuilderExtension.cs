using ASP.NET_Core_Exam.Services;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Exam.Extensions;

public static class IApplicationBuilderExtension {
	public static async Task SeedTestContentAsync(this IApplicationBuilder builder, bool forceSeed = false) {
		using var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
		var service = scope.ServiceProvider;
		var context = service.GetRequiredService<DataContext>();

		if (!await context.Categories.AnyAsync() || forceSeed) {
			await SeedContentAsync(service);
		}
	}

	private static async Task SeedContentAsync(IServiceProvider serviceProvider) {
		var context = serviceProvider.GetRequiredService<DataContext>();
		var seeder = serviceProvider.GetRequiredService<IContentSeeder>();

		using var transaction = await context.Database.BeginTransactionAsync();

		var createdCategories = await seeder.SeedCategoriesAsync(10);
		List<Post> createdPosts = [];

		foreach (var category in createdCategories) {
			long categoryId = category.Id;

			createdPosts.AddRange(await seeder.SeedPostsAsync(100, categoryId));
		}

		var createdTags = await seeder.SeedTagsAsync(10);

		await seeder.SeedPostTagPairsAsync(4, createdPosts, createdTags);

		await transaction.CommitAsync();
	}
}
