using ASP.NET_Core_Exam.Models.Categories;
using AutoMapper;
using Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Exam.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController(
	DataContext context,
	IMapper mapper
	) : ControllerBase {

	[HttpGet]
	public async Task<IActionResult> GetAll() {
		var categories = await context.Categories
			.OrderBy(c => c.Name)
			.Select(c => mapper.Map<CategoryVm>(c))
			.ToListAsync();

		return Ok(categories);
	}
}