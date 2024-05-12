using System.Security.Cryptography;
using EMA_Project.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EMA_Project.Services
{


    public interface IStudentService
    {
        Task<bool> SignUp(StudentRegisterDto registerDto);
        Task<bool> SignIn(StudentLoginDto loginDto);


    }
}