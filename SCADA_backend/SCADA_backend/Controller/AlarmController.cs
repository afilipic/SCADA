using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SCADA_backend.DTO;
using SCADA_backend.Service;

namespace SCADA_backend.Controller;
[Route("alarm")]
[ApiController]
[EnableCors]
public class AlarmController : ControllerBase
{
    private readonly AlarmService _alarmService;

    public AlarmController(AlarmService alarmService)
    {
        _alarmService = alarmService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_alarmService.GetAll());
    }
    //
    // [HttpPost]
    // public IActionResult addAlarm(AlarmDTO alarm)
    // { 
    //     _alarmService.Add(alarm);
    //     return Ok("Alarm successfully created!");
    // }
    
    [HttpDelete]
    [Route("{id}")]

    public IActionResult deleteAlarm(int id)
    {
        _alarmService.Delete(id);
        return Ok("Alarm successfully deleted!");

    }
    
}