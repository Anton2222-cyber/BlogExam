using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfigurations;

internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category> {
	public void Configure(EntityTypeBuilder<Category> builder) {
		builder.ToTable("Categories");

		builder.Property(c => c.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(c => c.UrlSlug)
			.HasMaxLength(50)
			.IsRequired();

		builder.HasAlternateKey(c => c.UrlSlug);

		builder.Property(c => c.Description)
			.HasMaxLength(200);
	}
}
