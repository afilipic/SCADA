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
    
    // DIGITAL OUTPUT
    
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
    
    // ANALOG OUTPUT
    
    [HttpGet]
    [Route("AO")]
    public IActionResult GetAllAO()
    {
        return Ok(_tagService.GetAllAO());
    }
    
    [HttpGet]
    [Route("DI")]
    public IActionResult GetAllDI()
    {
        return Ok(_tagService.GetAllDI());
    }

    
    [HttpPost]
    [Route("AO")]
    public IActionResult AddAO(AnalogOutput tagInfo)
    {
        try
        {
            _tagService.AddAO(tagInfo);
            return Ok("Analog output tag successfully added!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
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
    [Route("AO/{id}")]
    public IActionResult EditAO(string id, [FromBody] double value)
    {
        try
        {
            _tagService.EditAO(id, value);
            return Ok("Analog output tag value successfully changed!");  
        }
        catch (ArgumentException ex)
        {
            return BadRequest( "Bad request!");
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
    [Route("AO/{id}")]
    public IActionResult DeleteAO(string id)
    {
        try
        {
            _tagService.DeleteAO(id);
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
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
    
    // ANALOG INPUT
    
    [HttpGet]
    [Route("AI")]
    public IActionResult GetAllAI()
    {
        return Ok(_tagService.GetAllAI());
    }

    
    [HttpPost]
    [Route("AI")]
    public IActionResult AddAI(AnalogInput tagInfo)
    {
        try
        {
            _tagService.AddAI(tagInfo);
            return Ok("Analog input tag successfully added!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }

    
    [HttpPut]
    [Route("AI/{id}")]
    public IActionResult EditAO(string id)
    {
        try
        {
            _tagService.EditAI(id);
            return Ok("Analog input tag value successfully changed!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest( "Bad request!");
        }
    }
    
    [HttpDelete]
    [Route("AI/{id}")]
    public IActionResult DeleteAI(string id)
    {
        try
        {
            _tagService.DeleteAI(id);
            return Ok("Tag successfully deleted!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
}