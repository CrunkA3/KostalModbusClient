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



    public Task<BoolResponseMessage> GetModbusEnabled() => QueryBoolDataAsync(2);
    public Task<StringResponseMessage> GetInverterArticleNumber() => QueryStringDataAsync(6);
    public Task<StringResponseMessage> GetInverterSerialNumber() => QueryStringDataAsync(14);

    public Task<UInt16ResponseMessage> GetNumberOfBidirectionalConverter() => QueryUInt16DataAsync(30);
    public Task<UInt16ResponseMessage> GetNumberOfAcStrings() => QueryUInt16DataAsync(32);
    public Task<UInt16ResponseMessage> GetNumberOfPvStrings() => QueryUInt16DataAsync(34);

    public Task<VersionResponseMessage> GetHardwareVersion() => QueryVersionDataAsync(36);
    public Task<StringResponseMessage> GetSoftwareVersionMC() => QueryStringDataAsync(38);
    public Task<StringResponseMessage> GetSoftwareVersionIOC() => QueryStringDataAsync(46);

    public Task<UInt16ResponseMessage> GetPowerId() => QueryUInt16DataAsync(54);

    public Task<InverterStateResponseMessage> GetInverterState() => QueryInverterStateDataAsync(56);
    public Task<FloatResponseMessage> GetTotalDcPower() => QueryFloatDataAsync(100);
    public Task<EnergyManagerStateResponseMessage> GetInverterStateOfEnergyManager() => QueryEmergyManagerStateDataAsync(104);

    public Task<FloatResponseMessage> GetHomeOwnConsumptionFromBattery() => QueryFloatDataAsync(106);
    public Task<FloatResponseMessage> GetHomeOwnConsumptionFromGrid() => QueryFloatDataAsync(108);
    public Task<FloatResponseMessage> GetHomeOwnConsumptionFromPv() => QueryFloatDataAsync(116);

    public Task<FloatResponseMessage> GetTotalHomeOwnConsumptionFromBattery() => QueryFloatDataAsync(110);
    public Task<FloatResponseMessage> GetTotalHomeOwnConsumptionFromGrid() => QueryFloatDataAsync(112);
    public Task<FloatResponseMessage> GetTotalHomeOwnConsumptionFromPv() => QueryFloatDataAsync(114);
    public Task<FloatResponseMessage> GetTotalHomeOwnConsumption() => QueryFloatDataAsync(118);

    public Task<FloatResponseMessage> GetIsolationResistance() => QueryFloatDataAsync(120);
    public Task<FloatResponseMessage> GetPowerLimitFromEvu() => QueryFloatDataAsync(122);
    public Task<FloatResponseMessage> TotalHomeConsumptionRate() => QueryFloatDataAsync(124);
    public Task<FloatResponseMessage> GetWorkTime() => QueryFloatDataAsync(144);
    public Task<FloatResponseMessage> GetActualCos() => QueryFloatDataAsync(150);
    public Task<FloatResponseMessage> GetGridFrequency() => QueryFloatDataAsync(152);


    public Task<FloatResponseMessage> GetCurrentPhase1() => QueryFloatDataAsync(154);
    public Task<FloatResponseMessage> GetActualPowerPhase1() => QueryFloatDataAsync(156);
    public Task<FloatResponseMessage> GetVoltagePhase1() => QueryFloatDataAsync(158);

    public Task<FloatResponseMessage> GetCurrentPhase2() => QueryFloatDataAsync(160);
    public Task<FloatResponseMessage> GetActualPowerPhase2() => QueryFloatDataAsync(162);
    public Task<FloatResponseMessage> GetVoltagePhase2() => QueryFloatDataAsync(164);

    public Task<FloatResponseMessage> GetCurrentPhase3() => QueryFloatDataAsync(166);
    public Task<FloatResponseMessage> GetActualPowerPhase3() => QueryFloatDataAsync(168);
    public Task<FloatResponseMessage> GetVoltagePhase3() => QueryFloatDataAsync(170);


    public Task<FloatResponseMessage> GetTotalAcActivePower() => QueryFloatDataAsync(172);
    public Task<FloatResponseMessage> GetTotalAcReactivePower() => QueryFloatDataAsync(174);
    public Task<FloatResponseMessage> GetTotalAcApparentPower() => QueryFloatDataAsync(178);

    public Task<FloatResponseMessage> GetBatteryChargeCurrent() => QueryFloatDataAsync(190);
    public Task<FloatResponseMessage> GetNumberOfBatteryCycles() => QueryFloatDataAsync(194);
    public Task<FloatResponseMessage> GetActualBatteryChargeCurrent() => QueryFloatDataAsync(200);
    public Task<PssbFuseStateResponseMessage> GetPssbFuseState() => QueryPssbFuseStateDataAsync(202);
    public Task<FloatResponseMessage> GetBatteryReadyFlag() => QueryFloatDataAsync(208);
    public Task<FloatResponseMessage> GetActStateOfCharge() => QueryFloatDataAsync(210);
    public Task<FloatResponseMessage> GetBatteryTemperature() => QueryFloatDataAsync(214);
    public Task<FloatResponseMessage> GetBatteryVoltage() => QueryFloatDataAsync(216);
    public Task<FloatResponseMessage> GetPowermeterCos() => QueryFloatDataAsync(218);
    public Task<FloatResponseMessage> GetPowermeterFrequency() => QueryFloatDataAsync(220);
    public Task<FloatResponseMessage> GetPowermeterCurrentPhase1() => QueryFloatDataAsync(222);
    public Task<FloatResponseMessage> GetPowermeterActivePowerPhase1() => QueryFloatDataAsync(224);
    public Task<FloatResponseMessage> GetPowermeterReactivePowerPhase1() => QueryFloatDataAsync(226);
    public Task<FloatResponseMessage> GetPowermeterApparentPowerPhase1() => QueryFloatDataAsync(228);
    public Task<FloatResponseMessage> GetPowermeterVoltagePhase1() => QueryFloatDataAsync(230);
    public Task<FloatResponseMessage> GetPowermeterCurrentPhase2() => QueryFloatDataAsync(232);
    public Task<FloatResponseMessage> GetPowermeterActivePowerPhase2() => QueryFloatDataAsync(234);
    public Task<FloatResponseMessage> GetPowermeterReactivePowerPhase2() => QueryFloatDataAsync(236);
    public Task<FloatResponseMessage> GetPowermeterApparentPowerPhase2() => QueryFloatDataAsync(238);
    public Task<FloatResponseMessage> GetPowermeterVoltagePhase2() => QueryFloatDataAsync(240);
    public Task<FloatResponseMessage> GetPowermeterCurrentPhase3() => QueryFloatDataAsync(242);
    public Task<FloatResponseMessage> GetPowermeterActivePowerPhase3() => QueryFloatDataAsync(244);
    public Task<FloatResponseMessage> GetPowermeterReactivePowerPhase3() => QueryFloatDataAsync(246);
    public Task<FloatResponseMessage> GetPowermeterApparentPowerPhase3() => QueryFloatDataAsync(248);
    public Task<FloatResponseMessage> GetPowermeterVoltagePhase3() => QueryFloatDataAsync(250);

    public Task<FloatResponseMessage> GetPowermeterTotalActivePower() => QueryFloatDataAsync(252);
    public Task<FloatResponseMessage> GetPowermeterTotalReactivePower() => QueryFloatDataAsync(254);
    public Task<FloatResponseMessage> GetPowermeterTotalApparentPower() => QueryFloatDataAsync(256);
    public Task<FloatResponseMessage> GetCurrentDC1() => QueryFloatDataAsync(258);
    public Task<FloatResponseMessage> GetPowerDC1() => QueryFloatDataAsync(260);
    public Task<FloatResponseMessage> GetVoltageDC1() => QueryFloatDataAsync(266);
    public Task<FloatResponseMessage> GetCurrentDC2() => QueryFloatDataAsync(268);
    public Task<FloatResponseMessage> GetPowerDC2() => QueryFloatDataAsync(270);
    public Task<FloatResponseMessage> GetVoltageDC2() => QueryFloatDataAsync(276);
    public Task<FloatResponseMessage> GetCurrentDC3() => QueryFloatDataAsync(278);
    public Task<FloatResponseMessage> GetPowerDC3() => QueryFloatDataAsync(280);
    public Task<FloatResponseMessage> GetVoltageDC3() => QueryFloatDataAsync(286);
    public Task<FloatResponseMessage> GetYieldTotal() => QueryFloatDataAsync(320);
    public Task<FloatResponseMessage> GetYieldDaily() => QueryFloatDataAsync(322);
    public Task<FloatResponseMessage> GetYieldYearly() => QueryFloatDataAsync(324);
    public Task<FloatResponseMessage> GetYieldMonthly() => QueryFloatDataAsync(326);
    public Task<StringResponseMessage> GetInverterNetworkName() => QueryStringDataAsync(384, 32);
    public Task<UInt16ResponseMessage> GetIPEnable() => QueryUInt16DataAsync(416);
    public Task<UInt16ResponseMessage> GetManualIP() => QueryUInt16DataAsync(418);
    public Task<StringResponseMessage> GetIPAddress() => QueryStringDataAsync(420);
    public Task<StringResponseMessage> GetIPSubnetmask() => QueryStringDataAsync(428);
    public Task<StringResponseMessage> GetIPGateway() => QueryStringDataAsync(436);
    public Task<UInt16ResponseMessage> GetIPAutoDns() => QueryUInt16DataAsync(444);
    public Task<StringResponseMessage> GetIPDns1() => QueryStringDataAsync(446);
    public Task<StringResponseMessage> GetIPDns2() => QueryStringDataAsync(454);
    public Task<UInt32ResponseMessage> GetBatteryGrossCapacity() => QueryUInt32DataAsync(512);
    public Task<UInt16ResponseMessage> GetBatteryActualSoc() => QueryUInt16DataAsync(514);
    public Task<UInt32ResponseMessage> GetFirmwareMaincontroller() => QueryUInt32DataAsync(515);
    public Task<StringResponseMessage> GetBatteryManufacturer() => QueryStringDataAsync(517);


    public Task<UInt32ResponseMessage> GetBatteryModelId() => QueryUInt32DataAsync(525);
    public Task<UInt32ResponseMessage> GetBatterySerialNumber() => QueryUInt32DataAsync(527);
    public Task<UInt32ResponseMessage> GetWorkCapacity() => QueryUInt32DataAsync(529);
    public Task<UInt16ResponseMessage> GetInverterMaxPower() => QueryUInt16DataAsync(531);
    //public Task<FactorResponseMessage> GetInverterPeakGenerationPowerScaleFactor() => QueryStringDataAsync(532);
    public Task<StringResponseMessage> GetInverter() => QueryStringDataAsync(535, 16);
    public Task<StringResponseMessage> GetInverterModelId() => QueryStringDataAsync(551);
    public Task<StringResponseMessage> GetInverterSerialNumber2() => QueryStringDataAsync(559);
    public Task<Int16ResponseMessage> GetInverterGenerationPowerActual() => QueryInt16DataAsync(575);
    //public Task<FactorResponseMessage> GetPowerScaleFactor() => QueryStringDataAsync(576);
    public Task<UInt32ResponseMessage> GetGenerationEnergy() => QueryUInt32DataAsync(577);
    //public Task<FactorResponseMessage> GetEnergyScaleFactor() => QueryStringDataAsync(579);
    public Task<Int16ResponseMessage> GetActualBatteryChargePower() => QueryInt16DataAsync(582);
    public Task<UInt32ResponseMessage> GetBatteryFirmware() => QueryUInt32DataAsync(586);
    public Task<UInt16ResponseMessage> GetBatteryType() => QueryUInt16DataAsync(588);
    public Task<StringResponseMessage> GetProductName() => QueryStringDataAsync(768, 32);
    public Task<StringResponseMessage> GetPower() => QueryStringDataAsync(800, 32);





    public async Task<BoolResponseMessage> QueryBoolDataAsync(short address, CancellationToken cancellationToken = default) => new BoolResponseMessage(await QueryDataAsync(address, 1, cancellationToken));
    public async Task<FloatResponseMessage> QueryFloatDataAsync(short address, CancellationToken cancellationToken = default) => new FloatResponseMessage(await QueryDataAsync(address, 2, cancellationToken));
    public Task<StringResponseMessage> QueryStringDataAsync(short address, CancellationToken cancellationToken = default) => QueryStringDataAsync(address, 8, cancellationToken);
    public async Task<StringResponseMessage> QueryStringDataAsync(short address, byte length, CancellationToken cancellationToken = default) => new StringResponseMessage(await QueryDataAsync(address, length, cancellationToken), length);
    public async Task<Int16ResponseMessage> QueryInt16DataAsync(short address, CancellationToken cancellationToken = default) => new Int16ResponseMessage(await QueryDataAsync(address, 1, cancellationToken));
    public async Task<UInt16ResponseMessage> QueryUInt16DataAsync(short address, CancellationToken cancellationToken = default) => new UInt16ResponseMessage(await QueryDataAsync(address, 1, cancellationToken));
    public async Task<UInt32ResponseMessage> QueryUInt32DataAsync(short address, CancellationToken cancellationToken = default) => new UInt32ResponseMessage(await QueryDataAsync(address, 2, cancellationToken));
    public async Task<VersionResponseMessage> QueryVersionDataAsync(short address, CancellationToken cancellationToken = default) => new VersionResponseMessage(await QueryDataAsync(address, 2, cancellationToken));
    public async Task<InverterStateResponseMessage> QueryInverterStateDataAsync(short address, CancellationToken cancellationToken = default) => new InverterStateResponseMessage(await QueryDataAsync(address, 1, cancellationToken));
    public async Task<EnergyManagerStateResponseMessage> QueryEmergyManagerStateDataAsync(short address, CancellationToken cancellationToken = default) => new EnergyManagerStateResponseMessage(await QueryDataAsync(address, 2, cancellationToken));
    public async Task<PssbFuseStateResponseMessage> QueryPssbFuseStateDataAsync(short address, CancellationToken cancellationToken = default) => new PssbFuseStateResponseMessage(await QueryDataAsync(address, 2, cancellationToken));

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

        return responseBytes;
    }
}