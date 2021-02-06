namespace ActPlcMitsubishi.Models
{
    public class CommandModel
    {
        public string reg { get; set; }
        public int start { get; set; }
        public int lenght { get; set; }
        public int[] values { get; set; }
        public int rc { get; set; } = -1;
        public string message { get; set; }
    }
}
