using ASP.NET_Core_Exam.Models.Categories;
using ASP.NET_Core_Exam.Models.Posts;
using ASP.NET_Core_Exam.Models.Tags;
using AutoMapper;
using Data.Entities;

namespace ASP.NET_Core_Exam.Mappers;

public class AppMapProfile : Profile {
	public AppMapProfile() {
		CreateMap<Category, CategoryDataVm>();
		CreateMap<Post, PostVm>()
			.ForMember(
				dest => dest.Tags,
				opt => opt.MapFrom(
					src => src.Tags.Select(pt => pt.Tag).ToArray()
				)
			);

		CreateMap<Tag, TagVm>();

		CreateMap<Category, CategoryVm>();
	}
}
