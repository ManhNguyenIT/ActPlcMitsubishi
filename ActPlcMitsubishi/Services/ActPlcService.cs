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
        public event Action<string> OnActProgTypeErrorMessage = delegate { };
        public event Action<bool> OnActProgTypeStatusChanged = delegate { };
        private IActProgType _plc;
        public bool _IsConnected { get; private set; } = false;
        public bool IsConnected
        {
            get => _IsConnected;
            private set
            {
                if (value != _IsConnected)
                {
                    _IsConnected = value;
                    OnActProgTypeStatusChanged(value);
                }
            }
        }
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

        public Task<CommandModel> Read(CommandModel model)
        {
            return Task.Factory.StartNew(() =>
            {
                Connect();
                lock (_plc)
                {
                    _plc.Connect();
                    model.values = new int[model.lenght];
                    if (model.lenght == 1)
                    {
                        var res = -1;
                        model.rc = _plc.GetDevice(model.reg, out res);
                        model.values[0] = res;
                        model.message = Utils.ReturnCode((uint)model.rc);
                    }
                    else
                        for (int i = 0; i < model.lenght; i++)
                        {
                            var res = -1;
                            model.rc = _plc.GetDevice(model.reg + Convert.ToString(i + model.start, 8), out res);
                            model.values[i] = res;
                            model.message = Utils.ReturnCode((uint)model.rc);
                        }
                    _plc.Disconnect();
                    return model;
                }
            }, TaskCreationOptions.RunContinuationsAsynchronously);
        }

        public Task<CommandModel> Write(CommandModel model)
        {
            return Task.Factory.StartNew(() =>
            {
                Connect();
                lock (_plc)
                {
                    if (model.lenght == 1)
                    {
                        model.rc = _plc.SetDevice(model.reg + model.start, model.values[0]);
                        model.message = Utils.ReturnCode((uint)model.rc);
                    }
                    else
                        for (int i = 0; i < model.lenght; i++)
                        {
                            model.rc = _plc.SetDevice(model.reg + Convert.ToString(i + model.start, 8), model.values[i]);
                            model.message = Utils.ReturnCode((uint)model.rc);
                        }
                    _plc.Disconnect();
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