using Medfar.Interview.DAL.Repositories;
using Medfar.Interview.Types;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repo;

        private readonly ILogger<UserController> _logger;

        public UserController(UserRepository RRepo,ILogger<UserController> logger)
        {
            _logger = logger;
            _repo = RRepo;
        }

        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            try
            {
                var users = _repo.GetAll();
                return Ok(users); // Return the list of users if everything is fine
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching users."); // Log the exception details
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request."); // Return a 500 Internal Server Error
            }
        }
        

        //[HttpPost("GetUsersPage")]
        //public async Task<IActionResult> GetUsersPage(int page = 1, int pageSize = 30, string searchTerm = "")
        //{
                 
        //    var allUsers = Repo.GetAll();

        //    // Apply filtering based on the searchTerm (first_name, last_name, email)
        //    if (!string.IsNullOrWhiteSpace(searchTerm))
        //    {
        //        searchTerm = searchTerm.ToLower();
                

        //         allUsers = allUsers.Where(u => u.first_name != null && u.first_name.ToLower().Contains(searchTerm.ToLower()) ||
        //                                                u.last_name != null && u.last_name.ToLower().Contains(searchTerm.ToLower()) ||
        //                                                u.email != null && u.email.ToLower().Contains(searchTerm.ToLower())).ToList();


        //    }

        //    // Get the total count of filtered users            
        //    var totalUsers = allUsers.Count();

        //    // Apply pagination: Skip and Take
        //    var users = allUsers
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToList();

        //    // Return paginated and filtered users along with total user count for the frontend to handle pagination
        //    return Ok(new
        //    {
        //        TotalUsers = totalUsers,
        //        Users = users
        //    });
        //}


        [HttpPost("InsertUser")]
        public async Task<IActionResult> InsertUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("User data is null.");
            }

            // more validation logic if needed
            if (string.IsNullOrEmpty(userDTO.first_name) || string.IsNullOrEmpty(userDTO.last_name) || string.IsNullOrEmpty(userDTO.email))
            {
                return BadRequest("Invalid user data.");
            }

            try
            {
               // Check if email is already in use
                var existingUser = _repo.GetByEmail(userDTO.email); // Assume this method checks for email uniqueness
                if (existingUser != null && existingUser.Count()!=0)
                {
                    return BadRequest("Email already exists.");
                }

                // Insert the new user
                 _repo.Insert(userDTO);
                 return Ok("User inserted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting user}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while inserting the user.");
            }
        }

    }


}
