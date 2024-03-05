using ASP.NET_Core_Exam.Models.Tags;
using AutoMapper;
using Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Exam.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TagsController(
	DataContext context,
	IMapper mapper
	) : ControllerBase {

	[HttpGet]
	public async Task<IActionResult> GetAll() {
		var tags = await context.Tags
			.OrderBy(t => t.Name)
			.Select(t => mapper.Map<TagVm>(t))
			.ToListAsync();

		return Ok(tags);
	}
}