namespace KostalModbusClient.Tests;

public class UnitTest1
{
    private const string HostName = "192.168.1.120";
    private static ModbusClient client = new ModbusClient(HostName);

    [Fact]
    public async Task TestInverterState()
    {
        var stateResponse = await client.GetInverterState();
        Assert.Equal(InverterState.FeedIn, stateResponse.Value);
    }


    [Fact]
    public async Task TestTotalDcPower()
    {
        var stateResponse = await client.GetTotalDcPower();
        Assert.NotEqual(0, stateResponse.Value);
    }
}