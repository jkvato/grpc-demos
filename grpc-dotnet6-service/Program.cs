using grpc_dotnet6_service.Services;

namespace grpc_dotnet6_service
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);

         // Additional configuration is required to successfully run gRPC on macOS.
         // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

         // Add services to the container.
         builder.Services.AddGrpc();

         var app = builder.Build();

         // Utilize gRPC-Web.
         app.UseGrpcWeb();

         // Configure the HTTP request pipeline.

         // Remove the default
         //app.MapGrpcService<GreeterService>();

         // Add support for gRPC-Web.
         app.MapGrpcService<GreeterService>().EnableGrpcWeb();

         app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

         app.Run();
      }
   }
}