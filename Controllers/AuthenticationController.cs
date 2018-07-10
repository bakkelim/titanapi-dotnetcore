using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace titanapi_dotnetcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] LoginModel model)
        {
            try
            {
                if (model.Username.ToLower().Equals("error"))
                {
                    throw new Exception("Some error occured");
                }

                if (model.Username.ToLower().Equals("titan") && model.Password.Equals("Moon"))
                {
                    var user = new AppAuthUser
                    {
                        username = model.Username,
                        bearerToken = "token",
                        isAuthenticated = true,
                    };

                    return Ok(user);
                }                

                return Unauthorized();
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
