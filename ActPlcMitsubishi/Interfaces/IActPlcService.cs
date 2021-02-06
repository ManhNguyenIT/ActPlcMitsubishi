using ActProgTypeLib;
using ActPlcMitsubishi.Models;
using System.Threading.Tasks;

namespace ActPlcMitsubishi.Interfaces
{
    public interface IActPlcService
    {
        IActPlcService WithPlc(IActProgType plc);
        IActPlcService Build();
        Task<int> Connect();
        Task<CommandModel> Read(CommandModel model);
        Task<CommandModel> Write(CommandModel model);
    }
}
