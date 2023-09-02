using SCADA_backend.Model;

namespace SCADA_backend.DTO;

public class DIeditDTO
{
    public string Description { get; set; }

    public int Address { get; set; }
    public DriverType Driver { get; set; }
    public double ScanTime { get; set; }
    public bool isScanning { get; set; }
    
    public DIeditDTO() {}

    public DIeditDTO(string description, int address, DriverType driver, double scanTime, bool isScanning)
    {
        Description = description;
        Address = address;
        Driver = driver;
        ScanTime = scanTime;
        this.isScanning = isScanning;
    }
}