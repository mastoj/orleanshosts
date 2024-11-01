using WorkerSample2.Contracts;

namespace WorkerSample2.Logic;

public class PingGrain : Grain, IPingGrain
{
  public Task<string> Ping(string greeting)
  {
    return Task.FromResult($"You said: '{greeting}', I say: Pong!");
  }
}
