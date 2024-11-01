namespace WorkerSample.Contracts;

public interface IHelloWorldGrain : IGrainWithStringKey
{
  Task<string> SayHello(string greeting);
}