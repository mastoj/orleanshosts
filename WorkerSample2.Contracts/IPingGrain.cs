namespace WorkerSample2.Contracts;

public interface IPingGrain : IGrainWithStringKey
{
  Task<string> Ping(string greeting);
}
