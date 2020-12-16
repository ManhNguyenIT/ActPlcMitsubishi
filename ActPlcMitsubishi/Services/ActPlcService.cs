using ActProgTypeLib;
using ActPlcMitsubishi.Models;
using System;
using System.Threading.Tasks;
using ActPlcMitsubishi.Helpers;
using ActPlcMitsubishi.Builders;
using ActPlcMitsubishi.Interfaces;

namespace ActPlcMitsubishi.Services
{
    public class ActPlcService : IActPlcService
    {
        private IActProgType _plc;
        private bool IsConnected = false;
        private ActPlcService()
        {
            try
            {
                _plc = ActPlcHelper.Build();
            }
            catch 
            {
                _plc = new ActPlcBuilder()
                    .WithAddress(AppSettingHelper.ReadSetting("plc-address"))
                    .WithCpuType((ActCpuType)Enum.Parse(typeof(ActCpuType), AppSettingHelper.ReadSetting("cpu")))
                    .WithUnitType((ActUnitType)Enum.Parse(typeof(ActUnitType), AppSettingHelper.ReadSetting("unit")))
                    .WithPortNumber((ActPortNumber)Enum.Parse(typeof(ActPortNumber), AppSettingHelper.ReadSetting("plc-port")))
                    .WithProtocolType((ActProtocolType)Enum.Parse(typeof(ActProtocolType), AppSettingHelper.ReadSetting("protocol")))
                    .Build();
            }
        }

        public IActPlcService WithPlc(IActProgType plc)
        {
            if (_plc != null)
            {
                _plc.Close();
            }
            _plc = plc;
            return this;
        }

        public IActPlcService Build()
        {
            CheckPlc();
            return this;
        }

        private void CheckPlc()
        {
            if (_plc == null)
            {
                throw new Exception("Plc config required");
            }
        }

        public Task<int> Connect()
        {
            return Task.Factory.StartNew(() =>
           {
               if (IsConnected)
               {
                   return 0;
               }
               lock (_plc)
               {
                   int rc = -1;
                   rc = _plc.Open();
                   IsConnected = rc == 0;
                   return rc;
               }
           }, TaskCreationOptions.RunContinuationsAsynchronously);
        }

        public Task<CommandModel> ReadBit(CommandModel model)
        {
            return Task.Factory.StartNew(() =>
            {
                lock (_plc)
                {
                    var res = -1;
                    model.rc = _plc.GetDevice(model.reg, out res);
                    model.value = res;
                    model.message = Utils.ReturnCode((uint)model.rc);
                    return model;
                }
            }, TaskCreationOptions.RunContinuationsAsynchronously);
        }

        public Task<CommandModel> WriteBit(CommandModel model)
        {
            return Task.Factory.StartNew(() =>
            {
                lock (_plc)
                {
                    model.rc = _plc.SetDevice(model.reg, model.value);
                    model.message = Utils.ReturnCode((uint)model.rc);
                    return model;
                }
            }, TaskCreationOptions.RunContinuationsAsynchronously);
        }

        public static IActPlcService Instance { get => PlcServiceHelper.INSTANCE; }

        private static class PlcServiceHelper
        {
            public static readonly IActPlcService INSTANCE = new ActPlcService();
        }
    }
}