using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyecto.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase { }
}