namespace SCADA_backend.Model;

public class AnalogOutput : Tag
{
    public double LowLimit { get; set; }
    public double HighLimit { get; set; }
    public string Units { get; set; }
    public double InitialValue { get; set; }
    public double Value { get; set; }

    public AnalogOutput() { }

    public AnalogOutput(string id, string description, int address, double lowLimit, double highLimit, string units, double initialValue, double value)
    {
        Id = id;
        Description = description;
        Address = address;
        LowLimit = lowLimit;
        HighLimit = highLimit;
        Units = units;
        InitialValue = initialValue;
        Value = value;
    }
}