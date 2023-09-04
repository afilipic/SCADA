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
    
    public  void AddAlarm(AnalogInput tag)
    {
        Alarm alarm = new Alarm();
        Random rand = new Random();
        alarm.Id = rand.Next(10000);
        
        alarm.AnalogInputId = tag.Id;
        alarm.Priority = 2;  //rand od 1 do 3
        alarm.Unit = tag.Units;
        
        alarm.Value = tag.Value;
        alarm.Limit = tag.Value > tag.HighLimit ? tag.HighLimit : tag.LowLimit;
        alarm.Type = tag.Value > tag.HighLimit ? AlarmType.HIGH : AlarmType.LOW;
        alarm.TimeStamp = DateTime.Now;
        alarm.isDeleted = false;
        

        AlarmRepository.Save(alarm);
        //upisi u AlarmLog.txt
        
        
        for (int i = 0; i < alarm.Priority; i++)
        {
            //posalji na front notifikaciju 
        }

    }
    
    public  void Delete(int id)
    {
        Alarm alarm = AlarmRepository.GetById(id);
        if (alarm == null)
            throw new ArgumentException("Tag with the specified id does not exist!");
        alarm.isDeleted = true;
        AlarmRepository.Delete(alarm);
    }
    
}