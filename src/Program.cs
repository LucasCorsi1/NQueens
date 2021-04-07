using System;
using System.Diagnostics;

namespace NQueensSimulatedAnnealing.src
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Digite a quantidade de rainhas :");
            var nQueens = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine("Digite o maximo de iterações :");
            var maxIterationss = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());


            Console.WriteLine("Digite a temperatura :");
            var temperature = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());


            Console.WriteLine("Digite o fator de resfriamento :");
            var coolingFactor = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var solution = SimulatedAnnealingSolver.Solve(nQueens, maxIterationss, temperature, coolingFactor);
            Console.WriteLine("Tempo de solução :" + " " + stopWatch.Elapsed.Seconds + " " + " Segundos ");
            stopWatch.Stop();
            if (solution == null)
                Console.WriteLine("Sem Solução para propriedades selecionadas");
            else
                foreach (var queens in solution)
                    Console.WriteLine(queens);
            Console.ReadKey();
        }
    }


}
