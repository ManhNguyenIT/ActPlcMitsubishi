using ActProgTypeLib;
using ActPlcMitsubishi.Models;

namespace ActPlcMitsubishi.Builders
{
    public class ActPlcBuilder
    {
        private string ActHostAddress { get; set; }
        private int ActCpuType { get; set; }
        private int ActUnitType { get; set; }
        private int ActProtocolType { get; set; } = (int)Models.ActProtocolType.TCP;
        private int ActPortNumber { get; set; }
        private int ActTimeOut { get; set; } = 3000;

        public ActPlcBuilder WithAddress(string host)
        {
            ActHostAddress = host;
            return this;
        }
        public ActPlcBuilder WithCpuType(ActCpuType type)
        {
            ActCpuType = (int)type;
            return this;
        }
        public ActPlcBuilder WithUnitType(ActUnitType type)
        {
            ActUnitType = (int)type;
            return this;
        }
        public ActPlcBuilder WithProtocolType(ActProtocolType type)
        {
            ActProtocolType = (int)type;
            return this;
        }
        public ActPlcBuilder WithPortNumber(ActPortNumber port)
        {
            ActPortNumber = (int)port;
            return this;
        }
        public ActPlcBuilder WithTimeOut(int timeout)
        {
            ActTimeOut = timeout;
            return this;
        }
        public IActProgType Build()
        {
            if (string.IsNullOrEmpty(ActHostAddress))
            {
                throw new System.Exception("Host address required");
            }
            if (ActCpuType == 0)
            {
                throw new System.Exception("Cpu type required");
            }
            if (ActUnitType == 0)
            {
                throw new System.Exception("Unit type required");
            }
            return new ActProgType
            {
                //ActATCommandPasswordCancelRetryTimes = 3,
                //ActATCommandResponseWaitTime = 1,
                //ActBaudRate = 0,
                //ActCallbackCancelWaitTime = 90,
                //ActCallbackDelayTime = 20,
                //ActCallbackReceptionWaitingTimeOut = 120,
                //ActConnectUnitNumber = 0,
                //ActConnectWay = 0,
                //ActConnectionCDWaitTime = 90,
                //ActConnectionModemReportWaitTime = 5,
                //ActControl = 0x0000,
                //ActCpuTimeOut = 0,
                //Set the value of 'ActCpuType' to the property(CPU_TYPE).
                ActCpuType = ActCpuType,
                //ActDataBits = 0x0000,
                //ActDestinationIONumber = 0,
                ActDestinationPortNumber = ActPortNumber,
                //ActDidPropertyBit = 1,
                //ActDisconnectionDelayTime = 3,
                //ActDisconnectionCDWaitTime = 5,
                //ActDsidPropertyBit = 1,
                //Set the value of 'ActHostAddress' to the PLC IP address.
                ActHostAddress = ActHostAddress,
                //ActIONumber = 0x03FF,
                //ActIntelligentPreferenceBit = 0,
                //ActLineType = 0,
                //ActMultiDropChannelNumber = 0,
                //ActNetworkNumber = 0,
                //ActParity = 0,
                //ActPasswordCancelResponseWaitTime = 5,
                //ActPortNumber = 0,
                //Set the value of 'ProtocolType' to the property(PROTOCOL).
                ActProtocolType = ActProtocolType,
                //ActSourceNetworkNumber = 0,
                //ActSourceStationNumber = 0,
                //ActStationNumber = 255,
                //ActStopBits = 0,
                //ActSumCheck = 0,
                //ActPacketType = 1,
                //ActTargetSimulator = 0,
                //ActThroughNetworkType = 0,
                ActTimeOut = ActTimeOut,
                //ActTransmissionDelayTime = 0,
                //ActUnitNumber = 0,
                //Set the value of 'UnitType' to the property(UNIT_QNUSB).
                ActUnitType = ActUnitType
            };
        }
    }
}
