using SCADA_backend.Model;

namespace SCADA_backend.DTO;

public class DigitalOutputDTO
{
    public class OutputTagDTO
    {
        public string TagName { get; set; }
        public string Description { get; set; }
        public int Address { get; set; }
        public double InitialValue { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Units { get; set; }
        public double Value { get; set; }

        public OutputTagDTO(DigitalOutput digitalOutput)
        {
            TagName = digitalOutput.Id;
            Description = digitalOutput.Description;
            Address = digitalOutput.Address;
            InitialValue = digitalOutput.InitialValue ? 1 : 0;
            LowLimit = 0;
            HighLimit = 0;
            Units = "";
            Value = digitalOutput.Value ? 1 : 0;
        }
        
    }
}