# grpc-dotnet6-service

## Steps to Create

1. Create .NET Framework 4.8 console app.
2. Change protocol in `appsettings.json` from `Http2` to `Http1`.
3. Install NuGet packages: `Grpc.AspNetCore.Web` and update all packages to latest releases.
4. Modify `Program.cs':

```cs
   // Utilize gRPC-Web.
   app.UseGrpcWeb();

   // Configure the HTTP request pipeline.

   // Remove the default
   //app.MapGrpcService<GreeterService>();

   // Add support for gRPC-Web.
   app.MapGrpcService<GreeterService>().EnableGrpcWeb();
```

5. Modify `launchSettings.json` to remove `https://localhost:7019` from `applicationUrl`.
6. Modify `Services/GreeterService.cs` to log the incoming request.

## gRPC-Web
