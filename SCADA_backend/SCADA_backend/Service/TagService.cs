using SCADA_backend.DTO;
using SCADA_backend.Model;
using SCADA_backend.Repository;

namespace SCADA_backend.Service;

public class TagService
{
    public  List<DigitalOutput> GetAllDO()
    {
        return TagRepository.GetAllDO();
       
    }
    
    public  void AddDO(DigitalOutput tagInfo)
    {
        if (TagRepository.GetTagById(tagInfo.Id) != null)
            throw new ArgumentException("TagName already in use!");
        if (TagRepository.GetTagByAddress(tagInfo.Address) != null)
            throw new ArgumentException("Address already in use!");
        tagInfo.Value = tagInfo.InitialValue;
        TagRepository.SaveDO(tagInfo);
    }
    
    public  void EditDO(string id, double value)
    {
        var tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified name does not exist!");
        
        DigitalOutput digitalTag = (DigitalOutput)tag;
        digitalTag.Value = value > 0.5 ? 1 : 0;
        TagRepository.ChangeDO(digitalTag);
        
    }
    public  void DeleteDO(string id)
    {
        Tag tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified id does not exist!");
        TagRepository.Delete(id);
    }
    
    
    public  List<DigitalInput> GetAllDI()
    {
        return TagRepository.GetAllDI();
       
    }
    
    public  void AddDI(DigitalInput tagInfo)
    {
        if (TagRepository.GetTagById(tagInfo.Id) != null)
            throw new ArgumentException("TagName already in use!");
        if (TagRepository.GetTagByAddress(tagInfo.Address) != null)
            throw new ArgumentException("Address already in use!");
        TagRepository.SaveDI(tagInfo);
    }
    
    public  void EditDI(string id)
    {
        var tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified name does not exist!");
        
        DigitalInput digitalTag = (DigitalInput)tag;
        digitalTag.isScanning = !digitalTag.isScanning;
        TagRepository.ChangeDI(digitalTag);
        
    }
    public  void DeleteDI(string id)
    {
        Tag tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified id does not exist!");
        TagRepository.Delete(id);
    }

}