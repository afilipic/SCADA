using SCADA_backend.Model;

namespace SCADA_backend.Repository;

public class TagRepository
{

    // DIGITAL OUTPUT
    
    public static Tag? GetTagById(string id)
    {
         AppDbContext dbContext = new AppDbContext();
         return dbContext.Tags.Any(tag => tag.Id == id) ? dbContext.Tags.FirstOrDefault(tag => tag.Id == id) : null;
       
    }
    public static Tag? GetTagByAddress(int address)
    {
        AppDbContext dbContext = new AppDbContext();
        return dbContext.Tags.Any(tag => tag.Address == address) ? dbContext.Tags.FirstOrDefault(tag => tag.Address == address) : null;
       
    }
    
    public static void Delete(string id)
    {
        Tag tag = GetTagById(id);
        AppDbContext dbContext = new AppDbContext();
        dbContext.Remove(tag);
        dbContext.SaveChanges();
    }
    
    public static List<DigitalOutput> GetAllDO()
    {
        List<DigitalOutput> digitalOutputs = new();
        AppDbContext dbContext = new AppDbContext();
        digitalOutputs.AddRange(dbContext.DigitalOutputs);
        return digitalOutputs;
    }

    public static void SaveDO(DigitalOutput digitalOutput)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.DigitalOutputs.Add(digitalOutput);
        dbContext.SaveChanges();
    }
    public static void ChangeDO(DigitalOutput tag)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.DigitalOutputs.Attach(tag);
        dbContext.Entry(tag).Property(x => x.Value).IsModified = true;
        dbContext.SaveChanges();
    }
       
    // DIGITAL INPUT
    
    public static List<String> GetAllDigitalInputIds()
    {
        List<String> ids = new List<string>();
        List<DigitalInput> digitalOutputs = new();
        AppDbContext dbContext = new AppDbContext();
        digitalOutputs.AddRange(dbContext.DigitalInputs);
        
        foreach (DigitalInput output in digitalOutputs)
        {
            ids.Add(output.Id);
        }

        return ids;
    }
    
    public static List<DigitalInput> GetAllDI()
    {
        List<DigitalInput> digitalInputs = new();
        AppDbContext dbContext = new AppDbContext();
        digitalInputs.AddRange(dbContext.DigitalInputs);
        return digitalInputs;
    }
    
    public static void SaveDI(DigitalInput digitalInput)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.DigitalInputs.Add(digitalInput);
        dbContext.SaveChanges();
    }
    public static void ChangeDI(DigitalInput tag)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.DigitalInputs.Attach(tag);
        dbContext.Entry(tag).Property(x => x.Value).IsModified = true;
        dbContext.SaveChanges();
    }
    public static void SwitchDI(DigitalInput tag)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.DigitalInputs.Attach(tag);
        dbContext.Entry(tag).Property(x => x.isScanning).IsModified = true;
        dbContext.SaveChanges();
    }
    
    // ANALOG OUTPUT

    public static List<AnalogOutput> GetAllAO()
    {
        List<AnalogOutput> analogOutputs = new();
        AppDbContext dbContext = new AppDbContext();
        analogOutputs.AddRange(dbContext.AnalogOutputs);
        return analogOutputs;
    }
    public static void SaveAO(AnalogOutput analogOutput)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.AnalogOutputs.Add(analogOutput);
        dbContext.SaveChanges();
    }
    public static void ChangeAO(AnalogOutput tag)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.AnalogOutputs.Attach(tag);
        dbContext.Entry(tag).Property(x => x.Value).IsModified = true;
        dbContext.SaveChanges();
    }
    
    // ANALOG INPUT
    
    public static List<String> GetAllAnalogInputIds()
    {
        List<String> ids = new List<string>();
        List<AnalogInput> analogOutputs = new();
        AppDbContext dbContext = new AppDbContext();
        analogOutputs.AddRange(dbContext.AnalogInputs);
        
        foreach (AnalogInput output in analogOutputs)
        {
            ids.Add(output.Id);
        }

        return ids;
    }
    
    public static List<AnalogInput> GetAllAI()
    {
        List<AnalogInput> analogInputs = new();
        AppDbContext dbContext = new AppDbContext();
        analogInputs.AddRange(dbContext.AnalogInputs);
        return analogInputs;
    }
    public static void SaveAI(AnalogInput analogInput)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.AnalogInputs.Add(analogInput);
        dbContext.SaveChanges();
    }
    public static void ChangeAI(AnalogInput tag)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.AnalogInputs.Attach(tag);
        dbContext.Entry(tag).Property(x => x.Value).IsModified = true;
        dbContext.SaveChanges();
    }
    public static void SwitchAI(AnalogInput tag)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.AnalogInputs.Attach(tag);
        dbContext.Entry(tag).Property(x => x.isScanning).IsModified = true;
        dbContext.SaveChanges();
    }
    public static void AddAlarmAI(AnalogInput tag)
    {
        AppDbContext dbContext = new AppDbContext();
        dbContext.AnalogInputs.Attach(tag);
        dbContext.Entry(tag).Property(x => x.Alarms).IsModified = true;
        dbContext.SaveChanges();
    }
}