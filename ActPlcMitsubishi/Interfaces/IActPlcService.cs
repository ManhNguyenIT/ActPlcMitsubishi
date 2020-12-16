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
        Task<CommandModel> ReadBit(CommandModel model);
        Task<CommandModel> WriteBit(CommandModel model);
    }
}
