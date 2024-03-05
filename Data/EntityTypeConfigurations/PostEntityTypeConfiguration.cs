using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfigurations;

internal class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post> {
	public void Configure(EntityTypeBuilder<Post> builder) {
		builder.ToTable("Posts");

		builder.Property(p => p.Title)
			.HasMaxLength(500)
			.IsRequired();

		builder.Property(p => p.ShortDescription)
			.HasMaxLength(5000)
			.IsRequired();

		builder.Property(p => p.Description)
			.HasMaxLength(5000)
			.IsRequired();

		builder.Property(p => p.Meta)
			.HasMaxLength(1000)
			.IsRequired();

		builder.Property(p => p.UrlSlug)
			.HasMaxLength(200)
			.IsRequired();

		builder.HasAlternateKey(p => p.UrlSlug);

		builder.Property(p => p.Published)
			.IsRequired();

		builder.Property(p => p.PostedOn)
			.IsRequired();
	}
}