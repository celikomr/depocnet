using Microsoft.AspNetCore.Mvc;

namespace Producer.Controllers;

[Route("[controller]")]
public class ProducerOraController : ControllerBase
{
    public ProducerOraController()
    {
    }

    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}
