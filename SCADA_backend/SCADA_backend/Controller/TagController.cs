using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SCADA_backend.DTO;
using SCADA_backend.Hubs;
using SCADA_backend.Model;
using SCADA_backend.Service;

namespace SCADA_backend.Controller;

[Route("tags")]
[ApiController]
[EnableCors]
public class TagController : ControllerBase
{

    private readonly TagService _tagService;
    private readonly IHubContext<TagHub> _tagContext;

    public TagController(TagService tagService,  IHubContext<TagHub> hubContext)
    {
        _tagService = tagService;
        _tagContext = hubContext;
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
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Digital output tag successfully added!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }


    [HttpPut]
    [Route("DO/{id}/{value}")]
    public IActionResult EditDO(string id, double value)
    {
        try
        {
            _tagService.EditDO(id, value);
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Output tag value successfully changed!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }

    [HttpDelete]
    [Route("DO/{id}")]
    public IActionResult DeleteDO(string id)
    {
        try
        {
            _tagService.DeleteDO(id);
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Tag successfully deleted!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
    
    // DIGITAL INPUT
    
    
    [HttpGet]
    [Route("DI")]
    public IActionResult GetAllDI()
    {
        return Ok(_tagService.GetAllDI());
    }
    
    [HttpGet]
    [Route("DI/ids")]
    public IActionResult GetAllDIIds()
    {
        return Ok(_tagService.GetAllDigitalInputIds());
    }
    
    [HttpPost]
    [Route("DI/{id}/{value}")]
    public IActionResult ValueDIFromRTU(string id, double value)
    {
        try
        {
            _tagService.EditDI(id, value);
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Successfully updated digital input value!");
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
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Digital output tag successfully added!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
    
    
    [HttpPut]
    [Route("DI/{id}/{value}")]
    public IActionResult EditDI(string id, double value)
    {
        try
        {
            _tagService.EditDI(id, value);
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Input tag value successfully changed!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
    [HttpPut]
    [Route("DI/switch/{id}")]
    public IActionResult SwitchDI(string id)
    {
        try
        {
            _tagService.SwitchDI(id);
            return Ok("Input tag value successfully changed!");
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
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

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

    [HttpPost]
    [Route("AO")]
    public IActionResult AddAO(AnalogOutput tagInfo)
    {
        try
        {
            _tagService.AddAO(tagInfo);
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");
            return Ok("Analog output tag successfully added!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }


    [HttpPut]
    [Route("AO/{id}/{value}")]
    public IActionResult EditAO(string id, double value)
    {
        try
        {
            _tagService.EditAO(id, value);
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Analog output tag value successfully changed!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }


    [HttpDelete]
    [Route("AO/{id}")]
    public IActionResult DeleteAO(string id)
    {
        try
        {
            _tagService.DeleteAO(id);
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Tag successfully deleted!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }


    // ANALOG INPUT
    
    [HttpGet]
    [Route("AI/ids")]
    public IActionResult GetAllAIIds()
    {
        return Ok(_tagService.GetAllAnalogInputIds());
    }
    
    [HttpPost]
    [Route("AI/{id}/{value}")]
    public IActionResult ValueAIFromRTU(string id, double value)
    {
        try
        {
            _tagService.EditAI(id, value);
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Successfully updated analog input value!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
    
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
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Analog input tag successfully added!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }

    
    [HttpPut]
    [Route("AI/{id}/{value}")]
    public IActionResult EditAI(string id, double value)
    {
        try
        {
            _tagService.EditAI(id, value);
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Input tag value successfully changed!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
    [HttpPut]
    [Route("AI/switch/{id}")]
    public IActionResult SwitchAI(string id)
    {
        try
        {
            _tagService.SwitchAI(id);
            return Ok("Input tag value successfully changed!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
    
    [HttpDelete]
    [Route("AI/{id}")]
    public IActionResult DeleteAI(string id)
    {
        try
        {
            _tagService.DeleteAI(id);
            _tagContext.Clients.All.SendAsync("ReceiveTag", "tags");

            return Ok("Tag successfully deleted!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request!");
        }
    }
}