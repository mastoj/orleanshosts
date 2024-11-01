using System.Net;

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleans(siloBuilder =>
{
  siloBuilder
      .UseLocalhostClustering(siloPort: 11111, gatewayPort: 30000, new IPEndPoint(IPAddress.Loopback, 11111));
});

var host = builder.Build();
host.Run();
