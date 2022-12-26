using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Models;
using PrimeiraApi.Services;

namespace PrimeiraApi.Controllers {
    [ApiController]
    [Route("api")]   
    public class UserController : ControllerBase {
        UserServices data = new UserServices();
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers() {
            try {
                
                var users =  data.getServices();
                return Ok(users);
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> PostUsers(
            [FromBody] UserModel user
            ) {
            try {
                var users = data.PostServices(user);
                return Ok(users);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("users/{id}")]
        public async Task<IActionResult> GetUsers(
            [FromRoute] int id
            ) {
            try {
                var user = data.putServices(id);
                return Ok(user);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("users/{id}")]
        public async Task<IActionResult> DelUsers(
            [FromRoute] int id
            ) {
            try {
                var user = data.DelServices(id);
                return Ok(user);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}
