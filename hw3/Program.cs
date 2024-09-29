using System;
using System.Threading;

CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token;
SemaphoreSlim semaphore = new SemaphoreSlim(0, 1);

ThreadPool.QueueUserWorkItem(x => {
    Loading(token);
    semaphore.Release(); 
});

bool isCancelled = false;

while (!isCancelled)
{
    var key = Console.ReadKey(true);
    if (key != null)
    {
        cts.Cancel(); 
        Thread.Sleep(1000);
        Console.WriteLine("Loading has cancelled...");
        Thread.Sleep(1000);
        isCancelled = true; 
    }
}


semaphore.Wait(); 
Console.WriteLine("Process is ended");

void Loading(CancellationToken token)
{
    Console.WriteLine("Loading has started...");
    Thread.Sleep(1000);

    for (int i = 1; i <= 100; i++)
    {
        Console.WriteLine($"{i}%");
        Thread.Sleep(500);
        Console.Clear();

        if (token.IsCancellationRequested)
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("Reverse loading has started.");
            Thread.Sleep(1000);
            for (int j = i; j > 0; j--)
            {
                Console.WriteLine($"{j}%");
                Thread.Sleep(500);
                Console.Clear();
            }
            break;
        }
    }

    Console.WriteLine("Loading has ended...");
}
