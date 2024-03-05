using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfigurations;

internal class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag> {
	public void Configure(EntityTypeBuilder<Tag> builder) {
		builder.ToTable("Tags");

		builder.Property(t => t.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(t => t.UrlSlug)
			.HasMaxLength(50)
			.IsRequired();

		builder.HasAlternateKey(t => t.UrlSlug);

		builder.Property(t => t.Description)
			.HasMaxLength(200);
	}
}
