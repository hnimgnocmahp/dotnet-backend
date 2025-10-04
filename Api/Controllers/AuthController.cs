using Api.Models;
using Application.DTOs.User;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly LoginUserUseCase _loginUser;
    private readonly RegisterUserUseCase _registerUser;

    public AuthController(LoginUserUseCase loginUser, RegisterUserUseCase registerUser)
    {
        _loginUser = loginUser;
        _registerUser = registerUser;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _loginUser.ExecuteAsync(request);
        if (response == null)
            return Unauthorized(ApiResponse<string>.ErrorResponse("Invalid username or password"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "login successfully"));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request) {
        try
        {
            var result = await _registerUser.ExecuteAsync(request);
            return Ok(ApiResponse<object>.SuccessResponse(result!, "Register successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<string>.ErrorResponse(ex.Message));
        }
        
    }
}
