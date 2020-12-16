using ActProgTypeLib;
using ActPlcMitsubishi.Models;
using System;

namespace ActPlcMitsubishi.Services
{
    public class ActPlcAdapter
    {
        private readonly ActPlcModel model;

        public ActPlcAdapter(ActPlcModel model)
        {
            this.model = model;
        }

        public IActProgType Build()
        {
            if (model==null)
            {
                throw new Exception("ActPlcModel required");
            }

            return new ActProgType
            {
                ActATCommandPasswordCancelRetryTimes = model.ActATCommandPasswordCancelRetryTimes,
                ActATCommandResponseWaitTime = model.ActATCommandResponseWaitTime,
                ActBaudRate = model.ActBaudRate,
                ActCallbackCancelWaitTime = model.ActCallbackCancelWaitTime,
                ActCallbackDelayTime = model.ActCallbackDelayTime,
                ActCallbackReceptionWaitingTimeOut = model.ActCallbackReceptionWaitingTimeOut,
                ActConnectUnitNumber = model.ActConnectUnitNumber,
                ActConnectWay = model.ActConnectWay,
                ActConnectionCDWaitTime = model.ActConnectionCDWaitTime,
                ActConnectionModemReportWaitTime = model.ActConnectionModemReportWaitTime,
                ActControl = model.ActControl,
                ActCpuTimeOut = model.ActCpuTimeOut,
                ActCpuType = model.ActCPUType,
                ActDataBits = model.ActDataBits,
                ActDestinationIONumber = model.ActDestinationIONumber,
                ActDestinationPortNumber = model.ActDestinationPortNumber,
                ActDidPropertyBit = model.ActDidPropertyBit,
                ActDisconnectionDelayTime = model.ActDisconnectionDelayTime,
                ActDisconnectionCDWaitTime = model.ActDisconnectionCDWaitTime,
                ActDsidPropertyBit = model.ActDsidPropertyBit,
                ActHostAddress = model.ActHostAddress,
                ActIONumber = model.ActIONumber,
                ActIntelligentPreferenceBit = model.ActIntelligentPreferenceBit,
                ActLineType = model.ActLineType,
                ActMultiDropChannelNumber = model.ActMultiDropChannelNumber,
                ActNetworkNumber = model.ActNetworkNumber,
                ActParity = model.ActParity,
                ActPasswordCancelResponseWaitTime = model.ActPasswordCancelResponseWaitTime,
                ActPortNumber = model.ActPortNumber,
                ActProtocolType = model.ActProtocolType,
                ActSourceNetworkNumber = model.ActSourceNetworkNumber,
                ActSourceStationNumber = model.ActSourceStationNumber,
                ActStationNumber = model.ActStationNumber,
                ActStopBits = model.ActStopBits,
                ActSumCheck = model.ActSumCheck,
                ActPacketType = model.ActPacketType,
                ActTargetSimulator = model.ActTargetSimulator,
                ActThroughNetworkType = model.ActThroughNetworkType,
                ActTimeOut = model.ActTimeOut,
                ActTransmissionDelayTime = model.ActTransmissionDelayTime,
                ActUnitNumber = model.ActUnitNumber,
                ActUnitType = model.ActUnitType
            };
        }
    }
}
