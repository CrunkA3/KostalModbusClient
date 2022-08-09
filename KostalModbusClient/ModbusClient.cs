using System.Net.Sockets;

namespace KostalModbusClient;

public class ModbusClient
{
    public string HostName { get; }
    public int Port { get; }
    public byte UnitId { get; }

    public ModbusClient(string hostName)
    {
        HostName = hostName;
        Port = 1502;
        UnitId = 71;
    }
    public ModbusClient(string hostName, int port, byte unitId)
    {
        HostName = hostName;
        Port = port;
        UnitId = unitId;
    }


    public Task<BoolResponseMessage> GetModbusEnabled(CancellationToken cancellationToken = default) => QueryBoolDataAsync(2, cancellationToken);
    public Task<StringResponseMessage> GetInverterArticleNumber(CancellationToken cancellationToken = default) => QueryStringDataAsync(6, cancellationToken);
    public Task<StringResponseMessage> GetInverterSerialNumber(CancellationToken cancellationToken = default) => QueryStringDataAsync(14, 16, cancellationToken);

    public Task<UInt16ResponseMessage> GetNumberOfBidirectionalConverter(CancellationToken cancellationToken = default) => QueryUInt16DataAsync(30, cancellationToken);
    public Task<UInt16ResponseMessage> GetNumberOfAcStrings(CancellationToken cancellationToken = default) => QueryUInt16DataAsync(32, cancellationToken);
    public Task<UInt16ResponseMessage> GetNumberOfPvStrings(CancellationToken cancellationToken = default) => QueryUInt16DataAsync(34, cancellationToken);

    public Task<VersionResponseMessage> GetHardwareVersion(CancellationToken cancellationToken = default) => QueryVersionDataAsync(36, cancellationToken);
    public Task<StringResponseMessage> GetSoftwareVersionMC(CancellationToken cancellationToken = default) => QueryStringDataAsync(38, cancellationToken);
    public Task<StringResponseMessage> GetSoftwareVersionIOC(CancellationToken cancellationToken = default) => QueryStringDataAsync(46, cancellationToken);

    public Task<UInt16ResponseMessage> GetPowerId(CancellationToken cancellationToken = default) => QueryUInt16DataAsync(54, cancellationToken);

    public Task<InverterStateResponseMessage> GetInverterState(CancellationToken cancellationToken = default) => QueryInverterStateDataAsync(56, cancellationToken);
    public Task<FloatResponseMessage> GetTotalDcPower(CancellationToken cancellationToken = default) => QueryFloatDataAsync(100, cancellationToken);
    public Task<EnergyManagerStateResponseMessage> GetInverterStateOfEnergyManager(CancellationToken cancellationToken = default) => QueryEnergyManagerStateDataAsync(104, cancellationToken);

    public Task<FloatResponseMessage> GetHomeOwnConsumptionFromBattery(CancellationToken cancellationToken = default) => QueryFloatDataAsync(106, cancellationToken);
    public Task<FloatResponseMessage> GetHomeOwnConsumptionFromGrid(CancellationToken cancellationToken = default) => QueryFloatDataAsync(108, cancellationToken);
    public Task<FloatResponseMessage> GetHomeOwnConsumptionFromPv(CancellationToken cancellationToken = default) => QueryFloatDataAsync(116, cancellationToken);

    public Task<FloatResponseMessage> GetTotalHomeOwnConsumptionFromBattery(CancellationToken cancellationToken = default) => QueryFloatDataAsync(110, cancellationToken);
    public Task<FloatResponseMessage> GetTotalHomeOwnConsumptionFromGrid(CancellationToken cancellationToken = default) => QueryFloatDataAsync(112, cancellationToken);
    public Task<FloatResponseMessage> GetTotalHomeOwnConsumptionFromPv(CancellationToken cancellationToken = default) => QueryFloatDataAsync(114, cancellationToken);
    public Task<FloatResponseMessage> GetTotalHomeOwnConsumption(CancellationToken cancellationToken = default) => QueryFloatDataAsync(118, cancellationToken);

    public Task<FloatResponseMessage> GetIsolationResistance(CancellationToken cancellationToken = default) => QueryFloatDataAsync(120, cancellationToken);
    public Task<FloatResponseMessage> GetPowerLimitFromEvu(CancellationToken cancellationToken = default) => QueryFloatDataAsync(122, cancellationToken);
    public Task<FloatResponseMessage> TotalHomeConsumptionRate(CancellationToken cancellationToken = default) => QueryFloatDataAsync(124, cancellationToken);
    public Task<FloatResponseMessage> GetWorkTime(CancellationToken cancellationToken = default) => QueryFloatDataAsync(144, cancellationToken);
    public Task<FloatResponseMessage> GetActualCos(CancellationToken cancellationToken = default) => QueryFloatDataAsync(150, cancellationToken);
    public Task<FloatResponseMessage> GetGridFrequency(CancellationToken cancellationToken = default) => QueryFloatDataAsync(152, cancellationToken);


    public Task<FloatResponseMessage> GetCurrentPhase1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(154, cancellationToken);
    public Task<FloatResponseMessage> GetActualPowerPhase1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(156, cancellationToken);
    public Task<FloatResponseMessage> GetVoltagePhase1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(158, cancellationToken);

    public Task<FloatResponseMessage> GetCurrentPhase2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(160, cancellationToken);
    public Task<FloatResponseMessage> GetActualPowerPhase2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(162, cancellationToken);
    public Task<FloatResponseMessage> GetVoltagePhase2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(164, cancellationToken);

    public Task<FloatResponseMessage> GetCurrentPhase3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(166, cancellationToken);
    public Task<FloatResponseMessage> GetActualPowerPhase3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(168, cancellationToken);
    public Task<FloatResponseMessage> GetVoltagePhase3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(170, cancellationToken);


    public Task<FloatResponseMessage> GetTotalAcActivePower(CancellationToken cancellationToken = default) => QueryFloatDataAsync(172, cancellationToken);
    public Task<FloatResponseMessage> GetTotalAcReactivePower(CancellationToken cancellationToken = default) => QueryFloatDataAsync(174, cancellationToken);
    public Task<FloatResponseMessage> GetTotalAcApparentPower(CancellationToken cancellationToken = default) => QueryFloatDataAsync(178, cancellationToken);

    public Task<FloatResponseMessage> GetBatteryChargeCurrent(CancellationToken cancellationToken = default) => QueryFloatDataAsync(190, cancellationToken);
    public Task<FloatResponseMessage> GetNumberOfBatteryCycles(CancellationToken cancellationToken = default) => QueryFloatDataAsync(194, cancellationToken);
    public Task<FloatResponseMessage> GetActualBatteryChargeCurrent(CancellationToken cancellationToken = default) => QueryFloatDataAsync(200, cancellationToken);
    public Task<PssbFuseStateResponseMessage> GetPssbFuseState(CancellationToken cancellationToken = default) => QueryPssbFuseStateDataAsync(202, cancellationToken);
    public Task<FloatResponseMessage> GetBatteryReadyFlag(CancellationToken cancellationToken = default) => QueryFloatDataAsync(208, cancellationToken);
    public Task<FloatResponseMessage> GetActStateOfCharge(CancellationToken cancellationToken = default) => QueryFloatDataAsync(210, cancellationToken);
    public Task<FloatResponseMessage> GetBatteryTemperature(CancellationToken cancellationToken = default) => QueryFloatDataAsync(214, cancellationToken);
    public Task<FloatResponseMessage> GetBatteryVoltage(CancellationToken cancellationToken = default) => QueryFloatDataAsync(216, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterCos(CancellationToken cancellationToken = default) => QueryFloatDataAsync(218, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterFrequency(CancellationToken cancellationToken = default) => QueryFloatDataAsync(220, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterCurrentPhase1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(222, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterActivePowerPhase1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(224, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterReactivePowerPhase1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(226, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterApparentPowerPhase1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(228, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterVoltagePhase1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(230, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterCurrentPhase2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(232, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterActivePowerPhase2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(234, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterReactivePowerPhase2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(236, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterApparentPowerPhase2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(238, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterVoltagePhase2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(240, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterCurrentPhase3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(242, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterActivePowerPhase3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(244, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterReactivePowerPhase3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(246, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterApparentPowerPhase3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(248, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterVoltagePhase3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(250, cancellationToken);

    public Task<FloatResponseMessage> GetPowermeterTotalActivePower(CancellationToken cancellationToken = default) => QueryFloatDataAsync(252, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterTotalReactivePower(CancellationToken cancellationToken = default) => QueryFloatDataAsync(254, cancellationToken);
    public Task<FloatResponseMessage> GetPowermeterTotalApparentPower(CancellationToken cancellationToken = default) => QueryFloatDataAsync(256, cancellationToken);
    public Task<FloatResponseMessage> GetCurrentDC1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(258, cancellationToken);
    public Task<FloatResponseMessage> GetPowerDC1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(260, cancellationToken);
    public Task<FloatResponseMessage> GetVoltageDC1(CancellationToken cancellationToken = default) => QueryFloatDataAsync(266, cancellationToken);
    public Task<FloatResponseMessage> GetCurrentDC2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(268, cancellationToken);
    public Task<FloatResponseMessage> GetPowerDC2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(270, cancellationToken);
    public Task<FloatResponseMessage> GetVoltageDC2(CancellationToken cancellationToken = default) => QueryFloatDataAsync(276, cancellationToken);
    public Task<FloatResponseMessage> GetCurrentDC3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(278, cancellationToken);
    public Task<FloatResponseMessage> GetPowerDC3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(280, cancellationToken);
    public Task<FloatResponseMessage> GetVoltageDC3(CancellationToken cancellationToken = default) => QueryFloatDataAsync(286, cancellationToken);
    public Task<FloatResponseMessage> GetYieldTotal(CancellationToken cancellationToken = default) => QueryFloatDataAsync(320, cancellationToken);
    public Task<FloatResponseMessage> GetYieldDaily(CancellationToken cancellationToken = default) => QueryFloatDataAsync(322, cancellationToken);
    public Task<FloatResponseMessage> GetYieldYearly(CancellationToken cancellationToken = default) => QueryFloatDataAsync(324, cancellationToken);
    public Task<FloatResponseMessage> GetYieldMonthly(CancellationToken cancellationToken = default) => QueryFloatDataAsync(326, cancellationToken);
    public Task<StringResponseMessage> GetInverterNetworkName(CancellationToken cancellationToken = default) => QueryStringDataAsync(384, 32, cancellationToken);
    public Task<UInt16ResponseMessage> GetIPEnable(CancellationToken cancellationToken = default) => QueryUInt16DataAsync(416, cancellationToken);
    public Task<UInt16ResponseMessage> GetManualIP(CancellationToken cancellationToken = default) => QueryUInt16DataAsync(418, cancellationToken);
    public Task<StringResponseMessage> GetIPAddress(CancellationToken cancellationToken = default) => QueryStringDataAsync(420, cancellationToken);
    public Task<StringResponseMessage> GetIPSubnetmask(CancellationToken cancellationToken = default) => QueryStringDataAsync(428, cancellationToken);
    public Task<StringResponseMessage> GetIPGateway(CancellationToken cancellationToken = default) => QueryStringDataAsync(436, cancellationToken);
    public Task<UInt16ResponseMessage> GetIPAutoDns(CancellationToken cancellationToken = default) => QueryUInt16DataAsync(444, cancellationToken);
    public Task<StringResponseMessage> GetIPDns1(CancellationToken cancellationToken = default) => QueryStringDataAsync(446, cancellationToken);
    public Task<StringResponseMessage> GetIPDns2(CancellationToken cancellationToken = default) => QueryStringDataAsync(454, cancellationToken);
    public Task<UInt32ResponseMessage> GetBatteryGrossCapacity(CancellationToken cancellationToken = default) => QueryUInt32DataAsync(512, cancellationToken);
    public Task<UInt16ResponseMessage> GetBatteryActualSoc(CancellationToken cancellationToken = default) => QueryUInt16DataAsync(514, cancellationToken);
    public Task<UInt32ResponseMessage> GetFirmwareMaincontroller(CancellationToken cancellationToken = default) => QueryUInt32DataAsync(515, cancellationToken);
    public Task<StringResponseMessage> GetBatteryManufacturer(CancellationToken cancellationToken = default) => QueryStringDataAsync(517, cancellationToken);


    public Task<UInt32ResponseMessage> GetBatteryModelId(CancellationToken cancellationToken = default) => QueryUInt32DataAsync(525, cancellationToken);
    public Task<UInt32ResponseMessage> GetBatterySerialNumber(CancellationToken cancellationToken = default) => QueryUInt32DataAsync(527, cancellationToken);
    public Task<UInt32ResponseMessage> GetWorkCapacity(CancellationToken cancellationToken = default) => QueryUInt32DataAsync(529, cancellationToken);
    public Task<UInt16ResponseMessage> GetInverterMaxPower(CancellationToken cancellationToken = default) => QueryUInt16DataAsync(531, cancellationToken);
    //public Task<FactorResponseMessage> GetInverterPeakGenerationPowerScaleFactor() => QueryStringDataAsync(532);
    public Task<StringResponseMessage> GetInverter(CancellationToken cancellationToken = default) => QueryStringDataAsync(535, 16, cancellationToken);
    public Task<StringResponseMessage> GetInverterModelId(CancellationToken cancellationToken = default) => QueryStringDataAsync(551, cancellationToken);
    public Task<StringResponseMessage> GetInverterSerialNumber2(CancellationToken cancellationToken = default) => QueryStringDataAsync(559, cancellationToken);
    public Task<Int16ResponseMessage> GetInverterGenerationPowerActual(CancellationToken cancellationToken = default) => QueryInt16DataAsync(575, cancellationToken);
    //public Task<FactorResponseMessage> GetPowerScaleFactor() => QueryStringDataAsync(576);
    public Task<UInt32ResponseMessage> GetGenerationEnergy(CancellationToken cancellationToken = default) => QueryUInt32DataAsync(577, cancellationToken);
    //public Task<FactorResponseMessage> GetEnergyScaleFactor() => QueryStringDataAsync(579);
    public Task<Int16ResponseMessage> GetActualBatteryChargePower(CancellationToken cancellationToken = default) => QueryInt16DataAsync(582, cancellationToken);
    public Task<UInt32ResponseMessage> GetBatteryFirmware(CancellationToken cancellationToken = default) => QueryUInt32DataAsync(586, cancellationToken);
    public Task<UInt16ResponseMessage> GetBatteryType(CancellationToken cancellationToken = default) => QueryUInt16DataAsync(588, cancellationToken);
    public Task<StringResponseMessage> GetProductName(CancellationToken cancellationToken = default) => QueryStringDataAsync(768, 32, cancellationToken);
    public Task<StringResponseMessage> GetPowerClass(CancellationToken cancellationToken = default) => QueryStringDataAsync(800, 32, cancellationToken);





    /// <summary>
    /// Query bool data from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>

    public async Task<BoolResponseMessage> QueryBoolDataAsync(short address, CancellationToken cancellationToken = default) => new BoolResponseMessage(await QueryDataAsync(address, 1, cancellationToken));

    /// <summary>
    /// Query float data from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>
    public async Task<FloatResponseMessage> QueryFloatDataAsync(short address, CancellationToken cancellationToken = default) => new FloatResponseMessage(await QueryDataAsync(address, 2, cancellationToken));

    /// <summary>
    /// Query string data with length of 8 chars from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>
    public Task<StringResponseMessage> QueryStringDataAsync(short address, CancellationToken cancellationToken = default) => QueryStringDataAsync(address, 8, cancellationToken);

    /// <summary>
    /// Query string data with specific length of chars from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="length">String length</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>
    public async Task<StringResponseMessage> QueryStringDataAsync(short address, byte length, CancellationToken cancellationToken = default) => new StringResponseMessage(await QueryDataAsync(address, length, cancellationToken), length);

    /// <summary>
    /// Query int16 data from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>
    public async Task<Int16ResponseMessage> QueryInt16DataAsync(short address, CancellationToken cancellationToken = default) => new Int16ResponseMessage(await QueryDataAsync(address, 1, cancellationToken));

    /// <summary>
    /// Query unsigned int16 data from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>
    public async Task<UInt16ResponseMessage> QueryUInt16DataAsync(short address, CancellationToken cancellationToken = default) => new UInt16ResponseMessage(await QueryDataAsync(address, 1, cancellationToken));

    /// <summary>
    /// Query unsigned int32 data from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>
    public async Task<UInt32ResponseMessage> QueryUInt32DataAsync(short address, CancellationToken cancellationToken = default) => new UInt32ResponseMessage(await QueryDataAsync(address, 2, cancellationToken));

    /// <summary>
    /// Query version data from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>
    public async Task<VersionResponseMessage> QueryVersionDataAsync(short address, CancellationToken cancellationToken = default) => new VersionResponseMessage(await QueryDataAsync(address, 2, cancellationToken));
    
    /// <summary>
    /// Query inverter-state data from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>
    public async Task<InverterStateResponseMessage> QueryInverterStateDataAsync(short address, CancellationToken cancellationToken = default) => new InverterStateResponseMessage(await QueryDataAsync(address, 1, cancellationToken));
    
    /// <summary>
    /// Query energy-manager-state data from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>
    public async Task<EnergyManagerStateResponseMessage> QueryEnergyManagerStateDataAsync(short address, CancellationToken cancellationToken = default) => new EnergyManagerStateResponseMessage(await QueryDataAsync(address, 2, cancellationToken));
    
    /// <summary>
    /// Query pssb-fuse-state data from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns> 
    /// <exception cref="ModbusException"></exception>
    public async Task<PssbFuseStateResponseMessage> QueryPssbFuseStateDataAsync(short address, CancellationToken cancellationToken = default) => new PssbFuseStateResponseMessage(await QueryDataAsync(address, 2, cancellationToken));


    /// <summary>
    /// Query data from Modbus-Server
    /// </summary>
    /// <param name="address">Starting Adress of query data</param>
    /// <param name="quantity">Number of registers (one register = 2 Bytes)</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns>
    /// <exception cref="ModbusException"></exception>
    private async Task<byte[]> QueryDataAsync(short address, short quantity, CancellationToken cancellationToken = default)
    {
        var requestBytes = RequestMessage.CreateReadMessage(UnitId, address, quantity).GetBytes();
        using var client = new TcpClient(HostName, Port);
        using var stream = client.GetStream();
        stream.Write(requestBytes, 0, requestBytes.Length);

        var responseBytes = new byte[64];
        var bytesRead = await stream.ReadAsync(responseBytes, 0, responseBytes.Length, cancellationToken: cancellationToken);

        stream.Close();
        client.Close();

        if (responseBytes[7] != 0x03) throw new ModbusException(new ExceptionResponseMessage(responseBytes));
        return responseBytes;
    }
}
