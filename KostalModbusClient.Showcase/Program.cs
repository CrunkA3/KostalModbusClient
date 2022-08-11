using KostalModbusClient;

Console.WriteLine("Initialize client");

var client = new ModbusClient("192.168.1.120");

var totalAcPowerResponse = await client.GetTotalAcPower();

Console.WriteLine(totalAcPowerResponse.ActivePower);
Console.WriteLine(totalAcPowerResponse.ReactivePower);
Console.WriteLine(totalAcPowerResponse.ApparentPower);