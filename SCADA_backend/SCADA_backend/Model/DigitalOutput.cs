namespace SCADA_backend.Model;

public class DigitalOutput : Tag
{
    public bool InitialValue { get; set; }
    public bool Value { get; set; }

    public DigitalOutput() {}

    public DigitalOutput(string id, string description, int address, bool initialValue, bool value)
    {
        Id = id;
        Description = description;
        Address = address;
        InitialValue = initialValue;
        Value = value;
    }
}