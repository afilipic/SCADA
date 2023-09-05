namespace SCADA_backend.Model;

public class DigitalInput : Tag
{
    public DriverType Driver { get; set; }
    public DateTime ScanTime { get; set; }
    public bool isScanning { get; set; }
    public double Value { get; set; }

    public DigitalInput() {}

    public DigitalInput(string id, string description, int address, DriverType driver, DateTime scanTime, bool isScanning, double value)
    {
        Id = id;
        Description = description;
        Address = address;
        Driver = driver;
        ScanTime = scanTime;
        this.isScanning = isScanning;
        Value = value;
    }
}