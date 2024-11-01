using WorkerSample.Contracts;

namespace WorkerSample.Logic;

public class HelloWorldGrain : Grain, IHelloWorldGrain
{
  public Task<string> SayHello(string greeting)
  {
    return Task.FromResult($"You said: '{greeting}', I say: Hello!");
  }
}
