using Grpc.Net.Client;
using GrpcDemo; 

Console.Write("Write your name: ");
var name = Console.ReadLine();

var handler = new HttpClientHandler
{
    // ignore SSL certificate errors (not recommended for prd)
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
};

using var channel = GrpcChannel.ForAddress("http://localhost:5144");
var client = new Greeter.GreeterClient(channel);

var request = new HelloRequest { Name = name };
var response = await client.SayHelloAsync(request);

Console.WriteLine($"Server answer: {response.Message}");
