using System;
using System.Collections.Generic;

namespace NQueensSimulatedAnnealing
{
    public class SimulatedAnnealing
    {

        public static IEnumerable<int> Solve(int nQueens, int maxNumOfIterations, double temperature, double coolingFactor)
        {
            var r = SolverUtils.GenerateRandomState(nQueens);

            var costToBeat = SolverUtils.GetHeuristicCost(r);
            int count = 0;
            for (var x = 0; x < maxNumOfIterations && costToBeat > 0; x++)
            {
                r = MakeMove(r, costToBeat, temperature);
                costToBeat = SolverUtils.GetHeuristicCost(r);
                temperature = Math.Max(temperature * coolingFactor, 0.01);
                count++;
                Console.WriteLine("Custo da Heuristica : " + costToBeat);
            }
            Console.WriteLine("Numero de Iterações: " + count);
            return costToBeat == 0 ? r : null;
        }

        private static int[] MakeMove(int[] r, int costToBeat, double temp)
        {
            var rnd = new Random();
            var n = r.Length;

            while (true)
            {
                var nCol = rnd.Next(n);
                var nRow = rnd.Next(n);
                var tmpRow = r[nCol];
                r[nCol] = nRow;

                var cost = SolverUtils.GetHeuristicCost(r);
                if (cost < costToBeat)
                    return r;

                var dE = costToBeat - cost;
                var acceptProb = Math.Min(1, Math.Exp(dE / temp));

                if (rnd.NextDouble() < acceptProb)
                    return r;

                r[nCol] = tmpRow;
            }
        }
    }
}