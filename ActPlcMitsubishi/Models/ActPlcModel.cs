namespace ActPlcMitsubishi.Models
{
    public class ActPlcModel
    {
        public int ActLogicalStationNumber { get; set; }
        public int ActUnitType { get; set; }
        public int ActProtocolType { get; set; }
        public int ActNetworkNumber { get; set; }
        public int ActStationNumber { get; set; }
        public int ActUnitNumber { get; set; }
        public int ActConnectUnitNumber { get; set; }
        public int ActIONumber { get; set; }
        public int ActCPUType { get; set; }
        public int ActPortNumber { get; set; }
        public int ActBaudRate { get; set; }
        public int ActDataBits { get; set; }
        public int ActParity { get; set; }
        public int ActStopBits { get; set; }
        public int ActControl { get; set; }
        public string ActHostAddress { get; set; }
        public int ActCpuTimeOut { get; set; }
        public int ActTimeOut { get; set; }
        public int ActSumCheck { get; set; }
        public int ActSourceNetworkNumber { get; set; }
        public int ActSourceStationNumber { get; set; }
        public int ActDestinationPortNumber { get; set; }
        public int ActDestinationIONumber { get; set; }
        public int ActMultiDropChannelNumber { get; set; }
        public int ActThroughNetworkType { get; set; }
        public int ActIntelligentPreferenceBit { get; set; }
        public int ActDidPropertyBit { get; set; }
        public int ActDsidPropertyBit { get; set; }
        public int ActPacketType { get; set; }
        public int ActConnectWay { get; set; }
        public string ActAtCommand { get; set; }
        public string ActDialNumber { get; set; }
        public string ActOutsideLineNumber { get; set; }
        public string ActCallbackNumber { get; set; }
        public int ActLineType { get; set; }
        public int ActConnectionCDWaitTime { get; set; }
        public int ActConnectionModemReportWaitTime { get; set; }
        public int ActDisconnectionCDWaitTime { get; set; }
        public int ActDisconnectionDelayTime { get; set; }
        public int ActTransmissionDelayTime { get; set; }
        public int ActATCommandResponseWaitTime { get; set; }
        public int ActPasswordCancelResponseWaitTime { get; set; }
        public int ActATCommandPasswordCancelRetryTimes { get; set; }
        public int ActCallbackCancelWaitTime { get; set; }
        public int ActCallbackDelayTime { get; set; }
        public int ActCallbackReceptionWaitingTimeOut { get; set; }
        public int ActTargetSimulator { get; set; }
        public int ActMxUnitSeries { get; set; }
    }
}
