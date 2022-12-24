using System;
using System.IO;
using Grpc.Core;

namespace grpc_framework48_client
{
   internal class Program
   {
      // Get the server's HTTPS port from launchSettings.json in the service's project.
      private const int Port = 7006;

      // Path to the public key of the server's HTTPS certificate.
      private const string CertificatePath = @"..\..\certificate.cer";

      static void Main(string[] args)
      {
         string user = "Bill";

         // Read in the public key of the server's HTTPS certificate.
         SslCredentials secureCredentials = new SslCredentials(File.ReadAllText(CertificatePath));

         // Create the gRPC channel and client.
         var channel = new Channel("localhost", Port, secureCredentials);
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
