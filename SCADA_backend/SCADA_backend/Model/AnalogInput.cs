namespace SCADA_backend.Model;

public class AnalogInput : Tag
{
    public double LowLimit { get; set; }
    public double HighLimit { get; set; }
    public string Units { get; set; }
    public DriverType Driver { get; set; }
    public DateTime ScanTime { get; set; }
    public bool isScanning { get; set; }
    public double Value { get; set; }
    
    // public ICollection<Alarm> Alarms { get; set; } = new List<Alarm>();

    public AnalogInput() {}

    public AnalogInput(string id, string description, int address, double lowLimit, double highLimit, string units, DriverType driver, DateTime scanTime, bool isScanning, double value)
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
        Value = value;
        // Alarms = new List<Alarm>();

    }

    // public void AddAlarm(Alarm alarm)
    // {
    //     Alarms.Add(alarm);
    // }
}