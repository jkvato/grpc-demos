# grpc-demos
gRPC Proof of Concept Demos

## HTTP/2, https://, Grpc.Core

### [grpc-dotnet7-service](grpc-dotnet7-service/README.md)

A simple .NET 7 gRPC service using boilerplate code. Works with `grpc-framework48-client`.

### [grpc-framework48-client](grpc-framework48-client/README.md)

A simple .NET Framework 4.8 client console app that can communicate with `grpc-dotnet7-service`. This client utilizes `Grpc.Core`, which is expected to be deprecated in May 2023.

## HTTP/1, http://, grpc-dotnet, gRPC-Web

### [grpc-dotnet6-service](grpc-dotnet6-service/README.md)

A simple .NET 6 gRPC service using boilerplate code. Works with `grpc-framework48-client-http`.

### [grpc-framework48-client-http](grpc-framework48-client-http/README.md)

A simple .NET Framework 4.8 client console app that can communicate with `grpc-dotnet6-service`.
