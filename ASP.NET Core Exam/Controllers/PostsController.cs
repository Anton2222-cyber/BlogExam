using ASP.NET_Core_Exam.Models.Posts;
using AutoMapper;
using Data.Context;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Exam.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PostsController(
	DataContext context,
	IMapper mapper
	) : ControllerBase {

	[HttpGet]
	public async Task<IActionResult> GetPage([FromQuery] PostsFilterVm filter) {
		if (filter.PageNumber < 1)
			return BadRequest("PageNumber is invalid");

		if (filter.Count < 1)
			return BadRequest("Count is invalid");

		IQueryable<Post> query = context.Posts
			.Include(p => p.Category)
			.Include(p => p.Tags)
				.ThenInclude(pt => pt.Tag)
			.OrderByDescending(p => p.PostedOn);

		if (filter.TagUrlSlug is not null)
			query = query.Where(p => p.Tags.Any(t => t.Tag.UrlSlug == filter.TagUrlSlug));

		if (filter.CategoryUrlSlug is not null)
			query = query.Where(p => p.Category.UrlSlug == filter.CategoryUrlSlug);

		int pagesCount = (int)Math.Ceiling((double)await query.CountAsync() / filter.Count);

		query = query.Skip(filter.Count * (filter.PageNumber - 1));
		query = query.Take(filter.Count);

		var posts = await query
			.Select(p => mapper.Map<PostVm>(p))
			.ToListAsync();

		return Ok(new FilteredPosts {
			Posts = posts,
			PagesCount = pagesCount
		});
	}

	[HttpGet("{urlSlug}")]
	public async Task<IActionResult> GetByUrlSlug(string urlSlug) {
		var post = await context.Posts
			.Include(p => p.Category)
			.Include(p => p.Tags)
				.ThenInclude(pt => pt.Tag)
			.FirstOrDefaultAsync(p => p.UrlSlug == urlSlug);

		if (post is null)
			return StatusCode(StatusCodes.Status404NotFound, "Post with this urlSlug is not found");

		return Ok(mapper.Map<PostVm>(post));
	}
}
