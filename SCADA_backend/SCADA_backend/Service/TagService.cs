using SCADA_backend.DTO;
using SCADA_backend.Model;
using SCADA_backend.Repository;

namespace SCADA_backend.Service;

public class TagService
{
    
    // DIGITAL OUTPUT
    
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
    
    public  void EditDO(string id,double value)
    {
        var tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified name does not exist!");
        
        DigitalOutput digitalTag = (DigitalOutput)tag;
        digitalTag.Value = value == 0 ? false : true;
        TagRepository.ChangeDO(digitalTag);
        
    }
    public  void DeleteDO(string id)
    {
        Tag tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified id does not exist!");
        TagRepository.Delete(id);
    }
    
    // ANALOG OUTPUT
    
    public  List<AnalogOutput> GetAllAO()
    {
        return TagRepository.GetAllAO();
       
    }
    
    public  void AddAO(AnalogOutput tagInfo)
    {
        if (TagRepository.GetTagById(tagInfo.Id) != null)
            throw new ArgumentException("TagName already in use!");
        if (TagRepository.GetTagByAddress(tagInfo.Address) != null)
            throw new ArgumentException("Address already in use!");
        tagInfo.Value = tagInfo.InitialValue;
        TagRepository.SaveAO(tagInfo);
    }
    
    public  void EditAO(string id,double value)
    {
        var tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified id does not exist!");
        
        AnalogOutput analogTag = (AnalogOutput)tag;
        analogTag.Value = value;
        TagRepository.ChangeAO(analogTag);
        
    }
    public  void DeleteAO(string id)
    {
        Tag tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified id does not exist!");
        TagRepository.Delete(id);
    }
    
    // ANALOG INPUT
    
    public  List<AnalogInput> GetAllAI()
    {
        return TagRepository.GetAllAI();
       
    }
    
    public  void AddAI(AnalogInput tagInfo)
    {
        if (TagRepository.GetTagById(tagInfo.Id) != null)
            throw new ArgumentException("TagName already in use!");
        if (TagRepository.GetTagByAddress(tagInfo.Address) != null)
            throw new ArgumentException("Address already in use!");
        TagRepository.SaveAI(tagInfo);
    }
    
    public  void EditAI(string id)
    {
        var tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified id does not exist!");
        
        AnalogInput analogTag = (AnalogInput)tag;
        analogTag.isScanning = !analogTag.isScanning;
        TagRepository.ChangeAI(analogTag);
        
    }
    public  void DeleteAI(string id)
    {
        Tag tag = TagRepository.GetTagById(id);
        if (tag == null)
            throw new ArgumentException("Tag with the specified id does not exist!");
        TagRepository.Delete(id);
    }

}