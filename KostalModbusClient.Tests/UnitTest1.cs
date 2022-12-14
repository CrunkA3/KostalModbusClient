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


    [Fact]
    public async Task TestPowerClass()
    {
        var stateResponse = await client.GetPowerClass();
        Assert.NotEmpty(stateResponse.Value);
    }


    [Fact]
    public async Task TestInverterSerialNumber()
    {
        var stateResponse = await client.GetInverterSerialNumber();
        Assert.NotEmpty(stateResponse.Value);
    }


    [Fact]
    public async Task TestWrongAddress()
    {
        await Assert.ThrowsAsync<ModbusException>(async () => await client.QueryBoolDataAsync(900));
    }


    [Fact]
    public async Task TestPowerMultiValueResponse()
    {

        var totalAcPowerResponse = await client.GetTotalAcPower();

        var totalAcActivePowerResponse = await client.GetTotalAcActivePower();
        var totalAcReactivePowerResponse = await client.GetTotalAcReactivePower();
        var totalAcApparentPowerResponse = await client.GetTotalAcApparentPower();

        Assert.Equal(totalAcActivePowerResponse.Value, totalAcPowerResponse.ActivePower);
        Assert.Equal(totalAcReactivePowerResponse.Value, totalAcPowerResponse.ReactivePower);
        Assert.Equal(totalAcApparentPowerResponse.Value, totalAcPowerResponse.ApparentPower);
    }
}