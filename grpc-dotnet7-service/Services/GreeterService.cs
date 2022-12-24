using Grpc.Core;
using grpc_dotnet7_service;

namespace grpc_dotnet7_service.Services
{
   public class GreeterService : Greeter.GreeterBase
   {
      private readonly ILogger<GreeterService> _logger;
      public GreeterService(ILogger<GreeterService> logger)
      {
         _logger = logger;
      }

      public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
      {
         _logger.Log(LogLevel.Information, $"Received request from {context.Peer}");
         return Task.FromResult(new HelloReply
         {
            Message = "Hello " + request.Name
         });
      }
   }
}