// See https://aka.ms/new-console-template for more information
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService1;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("http://127.0.0.1:5166",new GrpcChannelOptions() { });

var client = new Greeter.GreeterClient(channel);


var res = client.SayHello(new HelloRequest() { Name = "Fred" });
Console.WriteLine(res.Message);