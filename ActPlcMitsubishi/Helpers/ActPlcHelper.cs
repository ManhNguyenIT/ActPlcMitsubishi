using ActProgTypeLib;
using ActPlcMitsubishi.Models;
using ActPlcMitsubishi.Services;
using System;
using System.IO;
using System.Linq;

namespace ActPlcMitsubishi.Helpers
{
    public class ActPlcHelper
    {
        public static IActProgType Build()
        {
            var file = $"{AppDomain.CurrentDomain.BaseDirectory}plc.txt";
            if (File.Exists(file))
            {
                var lines = File.ReadLines(file).ToList();
                if (lines.Count < 2)
                {
                    throw new Exception("plc.txt format wrong");
                }
                var headers = lines[0].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(i => !string.IsNullOrEmpty(i));
                var values = lines[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string json = "{" + string.Join(",", headers.Select((e, i) => $"'{e}':{values[i]}")) + "}";
                json = json.Replace(" ", string.Empty);
                try
                {
                    return new ActPlcAdapter(Newtonsoft.Json.JsonConvert.DeserializeObject<ActPlcModel>(json)).Build();
                }
                catch (Exception e)
                {
                    throw new FormatException(e.Message);
                }
            }
            else
            {
                throw new FileNotFoundException("plc.txt not found");
            }
        }
    }
}
