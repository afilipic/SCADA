using SCADA_backend.Model;

namespace SCADA_backend.Repository;

public class TagRepository
{
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
        dbContext.Entry(tag).Property(x => x.isScanning).IsModified = true;
        dbContext.SaveChanges();
    }
    


}