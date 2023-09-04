using SCADA_backend.Model;

namespace SCADA_backend.Repository;

public class AlarmRepository
{
    
    public static Alarm? GetById(int id)
    {
        AppDbContext dbContext = new AppDbContext();
        return dbContext.Alarms.Any(alarm => alarm.Id == id) ? dbContext.Alarms.FirstOrDefault(tag => tag.Id == id) : null;
       
    }
    
    public static Alarm? GetByTagId(string id)
    {
        AppDbContext dbContext = new AppDbContext();
        return dbContext.Alarms.Any(alarm => alarm.AITagId == id) ? dbContext.Alarms.FirstOrDefault(tag => tag.AITagId == id) : null;
       
    }
    public static List<Alarm> GetAll()
    {
        List<Alarm> alarms = new();
        AppDbContext dbContext = new AppDbContext();
        alarms.AddRange(dbContext.Alarms);
        return alarms;
    }

    public static void Save(Alarm alarm)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.Alarms.Add(alarm);
        dbContext.SaveChanges();
    }
    
    public static void Delete(Alarm alarm)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.Alarms.Attach(alarm);
        dbContext.Entry(alarm).Property(x => x.isDeleted).IsModified = true;
        dbContext.SaveChanges();
    }
}