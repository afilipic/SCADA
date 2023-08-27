using SCADA_backend.DTO;
using SCADA_backend.Model;
using SCADA_backend.Repository;

namespace SCADA_backend.Service;

public class TagService
{
    public static List<DigitalOutput> GetAllDO()
    {
        return TagRepository.GetAllDO();
       
    }
    
    public static void AddDO(DigitalOutput tagInfo)
    {
        if (TagRepository.GetTagById(tagInfo.Id) != null)
            throw new ArgumentException("TagName already in use!");
        if (TagRepository.GetTagByAddress(tagInfo.Address) != null)
            throw new ArgumentException("Address already in use!");
        tagInfo.Value = tagInfo.InitialValue;
        TagRepository.SaveDO(tagInfo);
    }
    
    public static void EditDO(string id,double value)
    {
        var tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified name does not exist!");
        
        DigitalOutput digitalTag = (DigitalOutput)tag;
        digitalTag.Value = value == 0 ? false : true;
        TagRepository.ChangeDO(digitalTag);
        
    }
    public static void DeleteDO(string id)
    {
        Tag tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified id does not exist!");
        TagRepository.Delete(id);
    }

}