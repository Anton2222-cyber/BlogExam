using Data.Entities;
using Data.Entities.Identity;
using Data.EntityTypeConfigurations;
using Data.EntityTypeConfigurations.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class DataContext(DbContextOptions<DataContext> options)
	: IdentityDbContext<User, Role, long, IdentityUserClaim<long>, UserRole, IdentityUserLogin<long>,
		IdentityRoleClaim<long>, IdentityUserToken<long>>(options) {

	public DbSet<Category> Categories { get; set; }
	public DbSet<Post> Posts { get; set; }
	public DbSet<Tag> Tags { get; set; }
	public DbSet<PostTag> PostTags { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
		new UserRoleEntityTypeConfiguration().Configure(modelBuilder.Entity<UserRole>());

		new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());
		new PostEntityTypeConfiguration().Configure(modelBuilder.Entity<Post>());
		new TagEntityTypeConfiguration().Configure(modelBuilder.Entity<Tag>());
		new PostTagEntityTypeConfiguration().Configure(modelBuilder.Entity<PostTag>());
	}
}
