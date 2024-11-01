using System.Net;

var builder = WebApplication.CreateBuilder(args);

// builder.
builder.UseOrleans(sb =>
{
  sb
    .UseLocalhostClustering(siloPort: 11113, gatewayPort: 30002, new IPEndPoint(IPAddress.Loopback, 11111));
  sb.UseDashboard(x => x.HostSelf = true);
});

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Map("/dashboard", x => x.UseOrleansDashboard());

app.Run();
