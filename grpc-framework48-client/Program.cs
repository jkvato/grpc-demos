using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;

namespace grpc_framework48_client
{
   internal class Program
   {
      // Get the server's https port from launchSettings.json in the service's project.
      private const int Port = 7006;

      // Path to the public key of the server's HTTPS certificate.
      private const string CertificatePath = @"..\..\localhost.cer";

      static void Main(string[] args)
      {
         SslCredentials secureCredentials = new SslCredentials(File.ReadAllText(CertificatePath));
         Channel channel = new Channel("localhost", Port, secureCredentials);

         var client = new Greeter.GreeterClient(channel);
         string user = "you";

         var reply = client.SayHello(new HelloRequest { Name = user });
         Console.WriteLine($"Greeting: {reply.Message}");

         channel.ShutdownAsync().Wait();
      }
   }
}
