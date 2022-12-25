using System;
using System.Net.Http;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace grpc_framework48_client_http
{
   internal class Program
   {
      // Get port from server's launchSettings.json file.
      private const int Port = 5093;

      static void Main(string[] args)
      {
         string user = "Bill";

         // Create the HttpHandler.
         var handler = new GrpcWebHandler(new HttpClientHandler()) { HttpVersion = new Version(1, 1) };
         var options = new GrpcChannelOptions { HttpHandler = handler };

         // Create the gRPC channel.
         string endpoint = $"http://localhost:{Port}";

         Console.WriteLine($"Attempting to contact server at {endpoint}.");

         using (var channel = GrpcChannel.ForAddress(endpoint, options))
         {
            var client = new Greeter.GreeterClient(channel);

            // Execute remote procedure call to gRPC service.
            var reply = client.SayHello(new HelloRequest { Name = user });

            // Display server response.
            Console.WriteLine($"Greeting: {reply.Message}");

            // Shut down the channel.
            channel.ShutdownAsync().Wait();
         }
      }
   }
}
