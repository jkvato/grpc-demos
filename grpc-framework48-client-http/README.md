# grpc-framework48-client-http

## Steps to Create

1. Create .NET Framework console app.
2. Add the following NuGet packages: `Grpc.Net.Client`, `Grpc.Tools`, `Google.Protobuf` and `Grpc.Net.Client.Web`, and update all packages to latest versions.
3. Copy the `Protos` folder from `grpc-dotnet6-service` project. Edit the `greet.proto` file to change its namespace to `grpc_framework48_client_http`.
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

```
