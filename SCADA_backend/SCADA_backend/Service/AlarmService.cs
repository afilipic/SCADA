using SCADA_backend.DTO;
using SCADA_backend.Model;
using SCADA_backend.Repository;

namespace SCADA_backend.Service;

public class AlarmService
{
    public  List<Alarm> GetAll()
    {
        return AlarmRepository.GetAll();
    }
    
    public  void Add(AlarmDTO alarm)
    {
        Alarm newAlarm = new Alarm();
        Random rand = new Random();
        newAlarm.Id = rand.Next(10000);
        
        newAlarm.AITagId = alarm.AITagId;
        newAlarm.Priority = alarm.Priority;
        newAlarm.Unit = alarm.Unit;
        
        newAlarm.Type = null;
        newAlarm.Limit = null;
        newAlarm.Value = null;
        
        newAlarm.isDeleted = false;
        
        AnalogInput tag = (AnalogInput)TagRepository.GetTagById(alarm.AITagId);
        tag.Alarms.Add(newAlarm);
        TagRepository.AddAlarmAI(tag);
        
        AlarmRepository.Save(newAlarm);
    }
    
    public  void Delete(int id)
    {
        Alarm alarm = AlarmRepository.GetById(id);
        if (alarm == null)
            throw new ArgumentException("Tag with the specified id does not exist!");
        alarm.isDeleted = true;
        AlarmRepository.Delete(alarm);
    }

    public void Trigger(string tagId, double value, double limit)
    {
        Alarm alarm = AlarmRepository.GetByTagId(tagId);
        
        if (alarm == null)
            throw new ArgumentException("Tag with the specified id does not exist!");

        alarm.Value = value;
        alarm.Limit = limit;
        alarm.Type = value > limit ? AlarmType.HIGH : AlarmType.LOW;
        
        AlarmLog log = new AlarmLog(alarm);
        
        // sacuvaj  u AlarmLog.txt i u bazu

        for (int i = 0; i < alarm.Priority; i++)
        {
            //posalji na front notifikaciju 
        }
        
        

    }
}