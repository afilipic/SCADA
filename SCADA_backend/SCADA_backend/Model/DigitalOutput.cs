namespace SCADA_backend.Model;

public class DigitalOutput : Tag
{
    public double InitialValue { get; set; }
    public double Value { get; set; }

    public DigitalOutput() {}

    public DigitalOutput(string id, string description, int address, double initialValue, double value)
    {
        Id = id;
        Description = description;
        Address = address;
        InitialValue = initialValue;
        Value = value;
    }
}