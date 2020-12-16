namespace ActPlcMitsubishi.Models
{
    public class CommandModel
    {
        public string reg { get; set; }
        public int value { get; set; } = -1;
        public int rc { get; set; } = -1;
        public string message { get; set; }
    }
}
