namespace SCADA_backend.Model;

public class AlarmLog : Alarm
{
    public DateTime? TimeStamp { get; set; }
    
    public AlarmLog(){}

    public AlarmLog(Alarm alarm)
    {
        Id = alarm.Id;
        AITagId = alarm.AITagId;
        Type = alarm.Type;
        Priority = alarm.Priority;
        Limit = alarm.Limit;
        Unit = alarm.Unit;
        isDeleted = alarm.isDeleted;
        
        TimeStamp = DateTime.Now;
        
    }

}