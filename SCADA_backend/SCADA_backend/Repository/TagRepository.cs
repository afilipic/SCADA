using SCADA_backend.Model;

namespace SCADA_backend.Repository;

public class TagRepository
{
    /*public static Tag? GetTagById(string id)
    {
        using var dbContext = new DatabaseContext();
        return dbContext.Tags.Any(tag => tag.TagName == id) ? dbContext.Tags.FirstOrDefault(tag => tag.TagName == id) : null;
    }
    public static Tag? GetTagByAddress(int address)
    {
        using var dbContext = new DatabaseContext();
        return dbContext.Tags.Any(tag => tag.Address == address) ? dbContext.Tags.FirstOrDefault(tag => tag.Address == address) : null;
    }
    
    public static void Delete(string id)
    {
        Tag tag = GetTagById(id);
        using var dbContext = new DatabaseContext();
        dbContext.Entry(tag).State = EntityState.Deleted;
        dbContext.SaveChanges();
    }
    public static List<DigitalOutput> GetAllDO()
    {
        List<DigitalOutput> digitalOutputs = new();
        using var dbContext = new DatabaseContext();
        digitalOutputs.AddRange(dbContext.DigitalOutputs);
        return digitalOutputs;
    }
    public static void SaveDO(DigitalOutput digitalOutput)
    {
        using var dbContext = new DatabaseContext();
        dbContext.DigitalOutputs.Add(digitalOutput);
        dbContext.SaveChanges();
    }
    public static void ChangeDO(DigitalOutput tag)
    {
        using var dbContext = new DatabaseContext();
        dbContext.DigitalOutputs.Attach(tag);
        dbContext.Entry(tag).Property(x => x.Value).IsModified = true;
        dbContext.SaveChanges();
    }*/

}