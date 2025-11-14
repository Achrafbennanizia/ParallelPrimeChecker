using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        int limit = (int)Math.Sqrt(n);
        for (int i = 3; i <= limit; i += 2)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    static int CountPrimesSequential(int[] numbers)
    {
        int count = 0;
        foreach (var n in numbers)
        {
            if (IsPrime(n)) count++;
        }
        return count;
    }

    static int CountPrimesParallel(int[] numbers)
    {
        int count = 0;
        object locker = new();

        Parallel.ForEach(numbers, n =>
        {
            if (IsPrime(n))
            {
                lock (locker)
                {
                    count++;
                }
            }
        });

        return count;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Parallel Prime Checker (C# / .NET)");

        int size = 200_000;
        var rnd = new Random();
        var numbers = new int[size];

        for (int i = 0; i < size; i++)
            numbers[i] = rnd.Next(2, 2_000_000);

        var sw = Stopwatch.StartNew();
        int seq = CountPrimesSequential(numbers);
        sw.Stop();
        Console.WriteLine($"Sequential: {seq} primes in {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        int par = CountPrimesParallel(numbers);
        sw.Stop();
        Console.WriteLine($"Parallel:   {par} primes in {sw.ElapsedMilliseconds} ms");
    }
}
