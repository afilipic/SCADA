using System.ComponentModel.DataAnnotations;

namespace SCADA_backend.Model;

public class Tag
{
    [Key]
    public string Id { get; set; }
    public string Description { get; set; }
    public int Address { get; set; }

    public Tag() {}
}