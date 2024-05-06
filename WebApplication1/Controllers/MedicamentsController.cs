using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/medicaments")]
public class MedicamentsController : ControllerBase
{
    [HttpGet("id:int")]
    public IActionResult GetMedicaments([FromRoute] int id)
    {
        
    }
}