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

    public Task<FloatResponseMessage> GetWorkTime() => QueryFloatDataAsync(144);



    public async Task<BoolResponseMessage> QueryBoolDataAsync(short address, CancellationToken cancellationToken = default) => new BoolResponseMessage(await QueryDataAsync(address, 1, cancellationToken));
    public async Task<FloatResponseMessage> QueryFloatDataAsync(short address, CancellationToken cancellationToken = default) => new FloatResponseMessage(await QueryDataAsync(address, 2, cancellationToken));
    public async Task<StringResponseMessage> QueryStringDataAsync(short address, CancellationToken cancellationToken = default) => new StringResponseMessage(await QueryDataAsync(address, 8, cancellationToken));
    public async Task<UInt16ResponseMessage> QueryUInt16DataAsync(short address, CancellationToken cancellationToken = default) => new UInt16ResponseMessage(await QueryDataAsync(address, 1, cancellationToken));
    public async Task<UInt32ResponseMessage> QueryUInt32DataAsync(short address, CancellationToken cancellationToken = default) => new UInt32ResponseMessage(await QueryDataAsync(address, 2, cancellationToken));
    public async Task<VersionResponseMessage> QueryVersionDataAsync(short address, CancellationToken cancellationToken = default) => new VersionResponseMessage(await QueryDataAsync(address, 2, cancellationToken));
    public async Task<InverterStateResponseMessage> QueryInverterStateDataAsync(short address, CancellationToken cancellationToken = default) => new InverterStateResponseMessage(await QueryDataAsync(address, 1, cancellationToken));
    public async Task<EnergyManagerStateResponseMessage> QueryEmergyManagerStateDataAsync(short address, CancellationToken cancellationToken = default) => new EnergyManagerStateResponseMessage(await QueryDataAsync(address, 2, cancellationToken));

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