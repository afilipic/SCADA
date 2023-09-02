namespace SCADA_backend.DTO;

public class DOeditDTO
{
    public string Description { get; set; }

    public int Address { get; set; }
    public double Value { get; set; }

    public DOeditDTO() {}

    public DOeditDTO(string description, int address, double value)
    {
        Description = description;
        Address = address;
        Value = value;
    }
}