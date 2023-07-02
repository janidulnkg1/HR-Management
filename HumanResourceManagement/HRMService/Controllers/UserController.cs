using HRMService.Context;
using HRMService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using HRMService.Context;

namespace HRMService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserController(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        [HttpPost("/userLogin")]
        public ActionResult Login(UserLoginModel loginModel)
        {
            var user = _dbContext.Set<User>()
                .FirstOrDefault(u => u.Username == loginModel.Username && u.Password == EncryptMD5(loginModel.Password));

            if (user == null)
            {
                return BadRequest("Invalid email or password");
            }



            return Ok("Login successful");
        }

        [HttpPost("/userRegister")]
        public async Task<ActionResult> Register(UserRegisterModel registerModel)
        {
            var existingUser = _dbContext.Set<User>().FirstOrDefault(u => u.Username == registerModel.Username);

            if (existingUser != null)
            {
                return BadRequest("Email already exists");
            }

            var user = new User
            {
                userId = registerModel.userId,
                firstName = registerModel.firstName,
                lastName = registerModel.lastName,
                Username = registerModel.Username,
                Password = EncryptMD5(registerModel.Password),
                Designation = "USER"
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return Ok("User Added Successfully!");


        }

        [HttpGet("/getUsers")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _dbContext.Users;
        }

        [HttpGet("/getUser/{userId:int}")]
        public async Task<ActionResult<User>> GetById(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            return user;
        }

        [HttpPut("/updateUser")]
        public async Task<ActionResult> Update(User user)
        {
            var u = new User
            {
                userId = user.userId,
                firstName = user.firstName,
                lastName = user.lastName,
                Username = user.Username,
                Password = EncryptMD5(user.Password),
                Designation = "USER"
            };

            _dbContext.Users.Update(u);
            await _dbContext.SaveChangesAsync();
            return Ok("User updated successfully!");
        }

        [HttpDelete("/deleteUser/{userId:int}")]
        public async Task<ActionResult> Delete(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return Ok($"User {userId} has been removed successfully!");
        }

        private string EncryptMD5(string data)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] hashBytes = md5.ComputeHash(dataBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
       





    }
}
