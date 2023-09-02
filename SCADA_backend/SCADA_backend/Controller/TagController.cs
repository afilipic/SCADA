using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SCADA_backend.DTO;
using SCADA_backend.Model;
using SCADA_backend.Service;

namespace SCADA_backend.Controller;

[Route("tags")]
[ApiController]
// [EnableCors]
public class TagController : ControllerBase
{
    
    private readonly TagService _tagService;

    public TagController(TagService tagService)
    {
        _tagService = tagService;
    }
    
    [HttpGet]
    [Route("DO")]
    public IActionResult GetAllDO()
    {
        return Ok(_tagService.GetAllDO());
    }

    
    [HttpPost]
    [Route("DO")]
    public IActionResult AddDO(DigitalOutput tagInfo)
    {
        try
        {
            _tagService.AddDO(tagInfo);
            return Ok("Digital output tag successfully added!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }

    
    [HttpPut]
    [Route("DO/{id}")]
    public IActionResult EditDO(string id, [FromBody] DOeditDTO tag)
    {
        try
        {
            _tagService.EditDO(id, tag.Value);
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
            _tagService.DeleteDO(id);
            return Ok("Tag successfully deleted!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
    
    
    [HttpGet]
    [Route("DI")]
    public IActionResult GetAllDI()
    {
        return Ok(_tagService.GetAllDI());
    }

    
    [HttpPost]
    [Route("DI")]
    public IActionResult AddDI(DigitalInput tagInfo)
    {
        try
        {
            _tagService.AddDI(tagInfo);
            return Ok("Digital output tag successfully added!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }

    
    [HttpPut]
    [Route("DI/{id}")]
    public IActionResult EditDI(string id)
    {
        try
        {
            _tagService.EditDI(id);
            return Ok("Input tag value successfully changed!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest( "Bad request!");
        }
    }
    
    [HttpDelete]
    [Route("DI/{id}")]
    public IActionResult DeleteDI(string id)
    {
        try
        {
            _tagService.DeleteDI(id);
            return Ok("Tag successfully deleted!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
    
    
    
}