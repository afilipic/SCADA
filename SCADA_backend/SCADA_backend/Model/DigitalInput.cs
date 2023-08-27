namespace SCADA_backend.Model;

public class DigitalInput : Tag
{
    public DriverType Driver { get; set; }
    public double ScanTime { get; set; }
    public bool isScanning { get; set; }
    
    public DigitalInput() {}

    public DigitalInput(string id, string description, int address, DriverType driver, double scanTime, bool isScanning)
    {
        Id = id;
        Description = description;
        Address = address;
        Driver = driver;
        ScanTime = scanTime;
        this.isScanning = isScanning;
    }
}