using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SCADA_backend.Model;
using SCADA_backend.Repository;

namespace SCADA_backend.Controller;
[Route("reports")]
[ApiController]
[EnableCors]
public class ReportController : ControllerBase
{
    // alarmi u odredjenom periodu
    [HttpGet]
    [Route("alarms/period")]
    public IActionResult GetAlarmsByPeriod([FromBody] Period period)
    {
        return Ok(AlarmRepository.AllByPeriod(period.From, period.To));
    }
    
    
    // alarmi sa nekim prioritetom
    [HttpGet]
    [Route("alarms/priority/{p}")]
    public IActionResult GetAlarmsByPriority(int p)
    {
        return Ok(AlarmRepository.AllByPriority(p));
    }
    
    
    // poslednja vrednost svih AI 
    [HttpGet]
    [Route("AI")]
    public IActionResult GetLastAI()
    {
        return Ok(TagRepository.GetAllAIreport());
    }
    
    
    // poslednja vrednost svih DI
    [HttpGet]
    [Route("DI")]
    public IActionResult GetLastDI()
    {
        return Ok(TagRepository.GetAllDIreport());
    }
    
    // sve vrednosti svih tagova u odredjenom periodu
    [HttpGet]
    [Route("tags/period")]
    public IActionResult GetAllByPeriod([FromBody] Period period)
    {
        return Ok(TagRepository.GetAllByPeriod(period.From, period.To));
    }
    
    
    // sve vrednosti trazenog taga
    [HttpGet]
    [Route("tags/{id}")]
    public IActionResult GetAllByTagId(string id)
    {
        return Ok(TagRepository.GetAllById(id));
    }
}