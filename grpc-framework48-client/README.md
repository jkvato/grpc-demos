# grpc-framework48-client

This client was written as a proof of concept to demonstrate how a .NET Framework 4.8 client can connect to a gRPC service running on .NET 7 using HTTPS.

The client needs to use the public key of the server's HTTPS certificate.

The client utilizes `Grpc.Core`, which is expected to be deprecated May 2023. ([Source](https://grpc.io/blog/grpc-csharp-future/) and [source](https://groups.google.com/g/grpc-io/c/OTj5mb1qzb0))

## Steps to create

1. Create a console application running on .NET Framework 4.8.
2. Add the following NuGet references: `Google.Protobuf`, `Grpc.Core`, `Grpc.Net.Client` and `Grpc.Tools`. Update any dependencies brought in to their latest versions.
3. Copy the `Protos` folder from `grpc-dotnet7-service` project. Edit the `greet.proto` file to change its namespace to `grpc_framework48_client`.
4. Manually add the `greet.proto` file to the project by editing `grpc-framework48-client.csproj` with a text editor and adding the following lines:

```xml
  <ItemGroup>
    <Protobuf Include="**/*.proto" />
  </ItemGroup>
```

5. Write the code in `Program.cs`.

```cs
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
```

6. Copy the public key of the server's certificate to the project's folder and name the file `certificate.pem`.

## Certificate

The key to making HTTPS work in gRPC using the .NET Framework is to copy the public key of the server's HTTPS certificate and use it in the `SslCredentials` in the client.

In this demonstration, the default dev certificate is used.

The dev certificate is stored in the Windows Certificate Manager (search Windows for Manage User Certificates), in the Personal Certificates store. It shows up as issued to localhost, issued by localhost, with the friendly name "ASP.NET Core HTTPS development certificate".

The public certificate can be obtained by exporting it in Base-64 encoded X.509 (.CER) format in the Windows Certificate Manager. This file contains the public key encoded in base-64 text.
