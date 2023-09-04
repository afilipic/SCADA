using SCADA_backend.Model;

namespace SCADA_backend.DTO;

public class AlarmDTO
{
    public string AITagId { get; set; }
    public int Priority { get; set; }
    public string Unit { get; set; }

    public AlarmDTO(){}
    
    public AlarmDTO(string aiTagId,  int priority, string unit)
    {
        AITagId = aiTagId;
        Priority = priority;
        Unit = unit;
    }
}