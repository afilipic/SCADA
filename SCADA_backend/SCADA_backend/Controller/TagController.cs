using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SCADA_backend.Model;
using SCADA_backend.Service;

namespace SCADA_backend.Controller;

[Route("tags")]
[ApiController]
[EnableCors]
public class TagController : ControllerBase
{
    
    [HttpGet]
    [Route("DO")]
    public IActionResult GetAllDO()
    {
        return Ok(TagService.GetAllDO());
    }

    
    [HttpPost]
    [Route("DO")]
    public IActionResult AddDO(DigitalOutput tagInfo)
    {
        try
        {
            TagService.AddDO(tagInfo);
            return Ok("Digital output tag successfully added!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }

    
    [HttpPut]
    [Route("DO/{id}")]
    public IActionResult EditDO(string id, [FromBody] double value)
    {
        try
        {
            TagService.EditDO(id, value);
            return Ok("Output tag value successfully changed!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest( "Bad request!");
        }
    }
    
    [HttpDelete]
    [Route("DO/{id}")]
    public IActionResult DeleteDO(string id)
    {
        try
        {
            TagService.DeleteDO(id);
            return Ok("Tag successfully deleted!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
    
}