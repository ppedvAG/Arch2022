// See https://aka.ms/new-console-template for more information
using HalloSingelton;

Console.WriteLine("Hello, World!");

Parallel.For(0, 100, i =>
{
    Logger.Instance.Info($"Para {i:000}");
});


Logger.Instance.Info("Hallo Logger");
Logger.Instance.Info("Hallo Logger 2");