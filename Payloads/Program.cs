﻿//JSON
var telemetry = new Payloads.Json.Telemetries() { WorkingSet = Environment.WorkingSet };
PayloadBinarySerializer jsonSerializer = new JsonUtfSerializer();
var jsonBytes = jsonSerializer.ToBytes(telemetry);
Console.WriteLine($"{jsonBytes.Length} json bytes: ");
jsonBytes.ToList().ForEach(x => Console.Write($"0x{x} "));
Console.WriteLine();
var jsonTel = jsonSerializer.FromBytes<Payloads.Json.Telemetries>(jsonBytes);
Console.WriteLine(jsonTel.WorkingSet);
Console.WriteLine();


//Proto
var t = new Telemetries { WorkingSet = Environment.WorkingSet };
PayloadBinarySerializer protoSerializer = new ProtobufSerializer(Telemetries.Parser);
var ptotoBytes = protoSerializer.ToBytes(t);
Console.WriteLine($"{ptotoBytes.Length} proto bytes: ");
ptotoBytes.ToList().ForEach(x => Console.Write($"0x{x} "));
Console.WriteLine(  );
t = protoSerializer.FromBytes<Telemetries>(ptotoBytes);
Console.WriteLine(t.WorkingSet);
Console.WriteLine();

//Avro
var avro = new Payloads.Avro.Telemetries() { WorkingSet = Environment.WorkingSet };
PayloadBinarySerializer avroSerializer = new AvroSerializer(avro.Schema);
var avroBytes = avroSerializer.ToBytes(avro);
Console.WriteLine($"{avroBytes.Length} Avro bytes: ");
avroBytes.ToList().ForEach(x => Console.Write($"0x{x} "));
Console.WriteLine(  );
avro = avroSerializer.FromBytes<Payloads.Avro.Telemetries>(avroBytes);
Console.WriteLine(avro.WorkingSet); ;