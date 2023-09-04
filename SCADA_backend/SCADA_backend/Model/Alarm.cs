namespace SCADA_backend.Model;

public class Alarm
{
    public int Id { get; set; }
    public string AITagId { get; set; }
    
    public AlarmType? Type { get; set; }
    public int Priority { get; set; }
    public double? Limit { get; set; }
    public double? Value { get; set; }
    public string Unit { get; set; }

    public bool isDeleted { get; set; }


    public Alarm(){}

    public Alarm(int id, string aiTagId, AlarmType type, int priority, double limit, string unit, bool isDeleted)
    {
        Id = id;
        AITagId = aiTagId;
        Type = type;
        Priority = priority;
        Limit = limit;
        Unit = unit;
        this.isDeleted = isDeleted;
    }
}