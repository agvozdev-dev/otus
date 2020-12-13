using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Otus.Crud.Entities;
using Otus.Crud.Services;

namespace Otus.Crud.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid userId)
        {
            var user = await _userService.Get(userId).ConfigureAwait(false);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _userService.Create(user).ConfigureAwait(false);
            
            return Ok(user);
        }        
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            await _userService.Update(user).ConfigureAwait(false);

            var updatedUser = await _userService.Get(user.Id);
            
            return Ok(updatedUser);
        }

        public async Task<IActionResult> Delete(Guid userId)
        {
            await _userService.Delete(userId);

            return Ok();
        }
    }
}