using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppBaseController : ControllerBase
    {
        public string? UserId
        {
            get => User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
