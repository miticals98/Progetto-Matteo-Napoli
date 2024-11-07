using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progetto_Matteo_Napoli.Models;
using Progetto_Matteo_Napoli.Services.Interfaces;
using Progetto_Matteo_Napoli.Utils;

namespace Progetto_Matteo_Napoli.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
	{
		private ICrudServiceBase<User, UserDTO> _userService;
		public UserController(ICrudServiceBase<User,UserDTO> userService) 
		{
			_userService = userService;
		}
		/// <summary>
		/// Get a specific User.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public Response Read(int id)
		{
			try
			{
				var user = _userService.Read(id);
				if (user is { })
				{
					return new Response()
					{
						Code = 200,
						Data = Translate.UserToDTO(user),
						Message = "OK"
					};
				}
				else
				{
					return new Response()
					{
						Code= 404,
						Message ="User not found",
						Data = null
					};
				}
			}
			catch (Exception ex)
			{

				return new Response()
				{
					Code = 400,
					Data = null,
					Message = ex.Message
				};
			}
			
		}


		
		/// <summary>
		/// Create a specific User.
		/// </summary>
		/// <param name="userDTO"></param>
		/// <returns></returns>
		/// /// <remarks>
		/// Sample request:
		///
		///     POST /User
		///     {
		///        "id": 0,
		///        "name": "Marco Rossi",
		///        "email": "marco.rossi@email.it"
		///     }
		///
		/// </remarks>
		[HttpPost("")]
		
		public Response Create([FromBody]UserDTO userDTO)
		{
			try
			{
				User user = Translate.DTOToUser(userDTO);
				var res = _userService.Create(user);
				return new Response()
				{
					Code = 200,
					Data= res,
					Message = "OK"
				};
			}
			catch(Exception ex)
			{
				return new Response()
				{
					Code = 400,
					Data = null,
					Message = ex.Message
				};
			}
		}



        
        /// <summary>
        /// Modify a specific User.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     PUT /User
        ///     {
        ///        "id": 5,
        ///        "name": "Marco Rossi",
        ///        "email": "marco.rossi@email.it"
        ///     }
        ///
        /// </remarks>
        [HttpPut("")]
		
		public Response Update([FromBody] UserDTO userDTO)
		{
			try
			{
				var user = Translate.DTOToUser(userDTO);
				bool res = _userService.Update(user);
				if (res)
				{
					return new Response()
					{
						Code = 200,
						Data = true,
						Message = "OK"
					};
				}
				else
				{
					return new Response()
					{
						Code = 404,
						Message ="User not found",
						Data = false
					};
				}
			}
			catch (Exception ex)
			{
				return new Response()
				{
					Code = 400,
					Data = null,
					Message = ex.Message
				};
			}
		}

       
        /// <summary>
        /// Delete a specific User.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /User
        ///     {
        ///        "id": 7,
        ///        "name": "Marco Rossi",
        ///        "email": "marco.rossi@email.it"
        ///     }
        ///
        /// </remarks>
        [HttpDelete("")]
		
		public Response Delete([FromBody] UserDTO userDTO)
		{
			try
			{
				User user = Translate.DTOToUser(userDTO);
				bool res = _userService.Delete(user);
				return new()
				{
					Code = res ? 200 : 404,
					Data = res,
					Message = res ? "OK" : "User not found"
				};
            }
			catch(Exception ex)
			{
				return new Response()
				{
					Code = 400,
					Data = null,
					Message = ex.Message
				};
			}
		}
	}
}
