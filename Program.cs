using System;
using System.Diagnostics;

namespace NQueensSimulatedAnnealing
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var response = SimulatedAnnealing.Solve(6, 1000000000, 4000, 50000);
            Console.WriteLine("Tempo de solução :" + stopWatch.Elapsed.Seconds + " Segundos ");
            stopWatch.Stop();
            if (response == null)
                Console.WriteLine("Sem Solução");
            else
                foreach (var r in response)
                {
                    Console.WriteLine(r);
                }
        }
    }
}
