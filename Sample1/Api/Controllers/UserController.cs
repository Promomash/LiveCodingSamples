using Api.Helpers;
using Api.ViewModels;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SaveUser(UserViewModel user)
        {
            var hash = new PasswordHash(user.Password);
            var userEntity = new Models.User()
            {
                CountryId = user.CountryId,
                ProvinceId = user.ProvinceId,
                Email = user.Email,
                PasswordHash = System.Text.Encoding.Default.GetString(hash.Hash)
            };

            await userRepository.SaveUser(userEntity);

            return Ok();
        }
    }
}
