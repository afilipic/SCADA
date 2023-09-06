using Org.BouncyCastle.Cms;

namespace SCADA_backend.Model;

public class TagLog
{
    public int Id { get; set; }
    public string TagId { get; set; }
    public DateTime TimeStamp { get; set; }
    public double Value { get; set; }

    public TagLog(int id, string tagId, DateTime timeStamp, double value)
    {
        Id = id;
        TagId = tagId;
        TimeStamp = timeStamp;
        Value = value;
    }
}