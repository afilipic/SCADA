namespace SCADA_backend.Model;

public class AnalogInput : Tag
{
    public double LowLimit { get; set; }
    public double HighLimit { get; set; }
    public string Units { get; set; }
    public DriverType Driver { get; set; }
    public int ScanTime { get; set; }
    public bool isScanning { get; set; }
    
    public AnalogInput() {}

    public AnalogInput(string id, string description, int address, double lowLimit, double highLimit, string units, DriverType driver, int scanTime, bool isScanning)
    {
        Id = id;
        Description = description;
        Address = address;
        LowLimit = lowLimit;
        HighLimit = highLimit;
        Units = units;
        Driver = driver;
        ScanTime = scanTime;
        this.isScanning = isScanning;
    }
}