using KostalModbusClient;

Console.WriteLine("Initialize client");

var client = new ModbusClient("192.168.1.120");

var totalAcPowerResponse = await client.GetTotalAcPower();

var totalAcActivePowerResponse = await client.GetTotalAcActivePower();
var totalAcReactivePowerResponse = await client.GetTotalAcReactivePower();
var totalAcApparentPowerResponse = await client.GetTotalAcApparentPower();

Console.Write(totalAcPowerResponse.ActivePower);
Console.Write(" = ");
Console.WriteLine(totalAcActivePowerResponse.Value);

Console.Write(totalAcPowerResponse.ReactivePower);
Console.Write(" = ");
Console.WriteLine(totalAcReactivePowerResponse.Value);

Console.Write(totalAcPowerResponse.ApparentPower);
Console.Write(" = ");
Console.WriteLine(totalAcApparentPowerResponse.Value);