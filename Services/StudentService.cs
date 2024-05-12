
using EMA_Project.Dto;
using EMA_Project.Models;
using EMA_Project.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace EMA_Project.Services
{
    public class StudentService : IStudentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<bool> SignUp(StudentRegisterDto registerDto)
        {
            if (await _context.Student.AnyAsync(t => t.Name == registerDto.Name))
            {
                throw new InvalidOperationException("Name Is already registered");
            }


            var newTourist = new Student
            {
                Name = registerDto.Name,
                Level = registerDto.Level,
                Gender = registerDto.Gender,
                Password = registerDto.Password,
                Email = registerDto.Email,
            };

            _context.Student.Add(newTourist);
            await _context.SaveChangesAsync();

            return true;
        }



        public async Task<bool> SignIn(StudentLoginDto loginDto)
        {

            if (!await _context.Student.AnyAsync(t => t.Name == loginDto.Name && t.Password == loginDto.password))
                throw new InvalidOperationException("there is no user  with  this Name");

            return true;
        }
    }
}

