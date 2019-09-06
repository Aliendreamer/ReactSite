namespace AcademySiteBackend.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	//[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : Controller
	{
		[HttpGet]
		[Route("login")]
		[ProducesResponseType(201)]
		[ProducesResponseType(500)]
		public IActionResult GetLogin()
		{
			return Ok("here");
		}

		/// <summary>
		/// Creates a TodoItem.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST /Login
		///     {
		///        "id": 1,
		///        "name": "Item1",
		///        "password": true
		///     }
		///
		/// </remarks>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns>A newly created TodoItem</returns>
		/// <response code="201">Returns login auth</response>
		/// <response code="400">If login failed</response>
		[HttpPost]
		[Route("login")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public IActionResult PostLogin(string username, string password)
		{
			return Ok();
		}
	}
}