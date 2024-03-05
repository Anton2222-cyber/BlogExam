using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfigurations;

internal class PostTagEntityTypeConfiguration : IEntityTypeConfiguration<PostTag> {
	public void Configure(EntityTypeBuilder<PostTag> builder) {
		builder.ToTable("PostsTags");

		builder.HasKey(cp => new { cp.PostId, cp.TagId });
	}
}