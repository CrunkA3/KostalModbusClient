# KostalModbusClient
Client for reading data from Kostal inverters

```c#
var client = new ModbusClient("192.168.1.120");
var pvPowerResult = await _client.GetTotalDcPower();

```