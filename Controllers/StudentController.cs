using EMA_Project.Dto;

using EMA_Project.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _StudentService;

    public StudentController(IStudentService StudentService)
    {
        _StudentService = StudentService;
        //_hostingEnvironment = hostingEnvironment;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUpStudent([FromBody] StudentRegisterDto touristDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Call the service to sign up the student
            var isSignedUp = await _StudentService.SignUp(touristDTO);

            if (isSignedUp)
            {
                return Ok("Student Added successfully!");
            }
            else
            {
                return StatusCode(500, "Failed to add student. Please try again later.");
            }
        }
        catch (Exception ex)
        {
            // Log the exception for further analysis
            Console.WriteLine(ex.ToString());

            // Check if there's an inner exception
            var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "";

            return StatusCode(500, $"An error occurred: {ex.Message}. Inner exception: {innerExceptionMessage}");
        }

    }
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] StudentLoginDto loginDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Call the service to sign in the user
            var isSignedIn = await _StudentService.SignIn(loginDto);

            if (isSignedIn)
            {
                return Ok("Sign-in successful!");
            }
            else
            {
                return Unauthorized("Invalid email or password.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}